function createDropDownListFromJson(listId, json, key, value) {
    //generic method to populate a select list from data passed in
    json.forEach(function (element) {
        var option = document.createElement("option");
        option.value = element[key];
        option.textContent = element[value];
        $("#" + listId).append(option);
    });
}
function ajax(service, data) {
    //generic method to perform an async ajax request
    var baseUrl = "https://localhost:44398/api/";
    var fullUrl = baseUrl + service;
    var request;
    if (!data) {
        request = $.get(fullUrl);
    } else {
        request = $.ajax({
            contentType: "application/json",
            url: fullUrl,
            method: "POST",
            data: JSON.stringify(data)
        });

    }
    //return a promise for methods to pend on the async request.
    return request;
}