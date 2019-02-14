function createDropDownListFromJson(listId, json, key, value) {
    for (var i = 0; i < json.length; i++) {
        var option = document.createElement("option");
        option.value = json[i][key];
        option.textContent = json[i][value];
        $("#" + listId).append(option);
    }
}
function ajax(service, data) {
    var baseUrl = 'https://localhost:44398/api/';
    var fullUrl = baseUrl + service;
    if (!data) {
        var request = $.get(fullUrl)
    } else {
        var request = $.ajax({
            url: baseUrl + service,
            method: "POST",
            data: JSON.stringify(data)
        });

    }
    return request;
}