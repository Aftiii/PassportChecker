$(document).ready(function () {
    initGenders();
    initNationalities();
    lazyFunction();
});
function initGenders() {
    ajax("genders").done(function (msg) {
        createDropDownListFromJson("gender", msg, "key", "value");
        $("#gender").val(2);
    });
}
function initNationalities() {
    ajax("nationalities").done(function (msg) {
        createDropDownListFromJson("nationality", msg, "key", "value");
        $("#nationality").val(222);
    });
}
function lazyFunction() {
    $("#passportnumber").val("112256503");
    
    $("#dateofbirth").val("1989-02-12")
    
    $("#dateofexpiry").val("2020-10-01");
    $("#mzr").val("1122565035GBR8902122M2010016<<<<<<<<<<<<<<04");
}
$("#btn_validate").click(function (e) {
    ajax("PassportValidator", $("#frm_passport").serializeObject()).done(function (msg) {
        $("#div_entryContainer").hide(600, function () {
            populatePassFails(msg);
        });

    }).fail(function (xhr) {
        $("#error").show().delay(20000).fadeOut();;
        $("#error").html(errorParser(xhr.responseJSON));
    });
    e.preventDefault();
});
$("#btn_checkAnother").click(function () {
    $("#results").hide(600, function () {
        $("#tbl_results").find("span").text("");
        $("#div_entryContainer").show(600);
    });
})
function errorParser(error) {
    var text = "";
    $.each(error, function (key, value) {
        text += "Issue with:" + key + " <br />";
        $.each(value, function (key, value) {
             text += "Error:" + value + " <br />";
        });
        text += "<br />";
    });
    return text;
}
function populatePassFails(validatedResults) {
    populateResult("#passportNumberCheckDigit",validatedResults.passportNumberCheckDigit);
    populateResult("#dateOfBirthCheckDigit",validatedResults.dateOfBirthCheckDigit);
    populateResult("#passportExpirationDateCheckDigit",validatedResults.passportExpirationDateCheckDigit);
    populateResult("#personalNumberCheckDigit",validatedResults.personalNumberCheckDigit);
    populateResult("#finalCheckDigit",validatedResults.finalCheckDigit);
    populateResult("#genderCrossCheck",validatedResults.genderCrossCheck);
    populateResult("#dateOfBirthCrossCheck",validatedResults.dateOfBirthCrossCheck);
    populateResult("#expirationDateCrossCheck",validatedResults.expirationDateCrossCheck);
    populateResult("#nationalityCrossCheck",validatedResults.nationalityCrossCheck);
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