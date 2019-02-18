function initGenders() {
    ajax("genders").done(function (msg) {
        //map the genders onto a select list
        createDropDownListFromJson("gender", msg, "key", "value");
    });
}
function initNationalities() {
    ajax("nationalities").done(function (msg) {
        //map the nationalities onto a select list
        createDropDownListFromJson("nationality", msg, "key", "value");
    });
}
function errorParser(error) {
    var text = "";
    //For each error parameter
    $.each(error, function (errorParam, errorValue) {
        text += "Issue with:" + errorParam + " <br />";
        //For each individual error for that parameter
        $.each(errorValue, function (individualErrorKey, individualErrorValue) {
            text += "Error:" + individualErrorValue + " <br />";
        });
        text += "<br />";
    });
    return text;
}
function populatePassFails(validatedResults) {
    populateResult("#passportNumberCheckDigit", validatedResults.passportNumberCheckDigit);
    populateResult("#dateOfBirthCheckDigit", validatedResults.dateOfBirthCheckDigit);
    populateResult("#passportExpirationDateCheckDigit", validatedResults.passportExpirationDateCheckDigit);
    populateResult("#personalNumberCheckDigit", validatedResults.personalNumberCheckDigit);
    populateResult("#finalCheckDigit", validatedResults.finalCheckDigit);
    populateResult("#genderCrossCheck", validatedResults.genderCrossCheck);
    populateResult("#dateOfBirthCrossCheck", validatedResults.dateOfBirthCrossCheck);
    populateResult("#expirationDateCrossCheck", validatedResults.expirationDateCrossCheck);
    populateResult("#nationalityCrossCheck", validatedResults.nationalityCrossCheck);
    populateResult("#passportNumberCrossCheck", validatedResults.passportNumberCrossCheck);
    $("#results").show(600);
}
function populateResult(element, outcome) {
    if (outcome === true) {
        $(element).css("color", "green");
    } else {
        $(element).css("color", "red");
    }
    $(element).text(outcome ? "Pass" : "Fail");
}
function validatePassport() {
    //serialize all of the input boxes into a JSON object
    ajax("PassportValidator", $("#frm_passport").serializeObject()).done(function (msg) {
        $("#div_entryContainer").hide(600, function () {
            //once we've hidden the entry container, fill in the results table with the data returned
            populatePassFails(msg);
        });

    }).fail(function (xhr) {
        //Show errors for 20 seconds
        $("#error").show().delay(20000).fadeOut();
        $("#error").html(errorParser(xhr.responseJSON));
    });

}

$("#btn_validate").click(function (e) {
    //validate for the date and times so we don't send "dd/mm/yyyy"
    $("#frm_passport").validate({
        rules: {
            dateofbirth: {
                required: true,
                dateISO:true
            },
            dateofexpiry: {
                required: true,
                dateISO:true
            }
        },
        submitHandler: function () {
            //prevent the post to form refreshing the page
            e.preventDefault();
            validatePassport();
        }
    });
    
});

$("#btn_checkAnother").click(function () {
    //fade the results out to bring the entry container back to screen
    $("#results").hide(600, function () {
        $("#tbl_results").find("span").text("");
        $("#div_entryContainer").show(600);
    });
});

$(document).ready(function () {
    //Get our static data from enums
    initGenders();
    initNationalities();
});