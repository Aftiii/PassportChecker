// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    initGenders();
    initNationalities();
});
function initGenders() {
    ajax("genders").done(function (msg) {
        createDropDownListFromJson("genders", msg, "key", "value");
    });
}
function initNationalities() {
    ajax("nationalities").done(function (msg) {
        createDropDownListFromJson("nationalities", msg, "key", "value");
    });
}