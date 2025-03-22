// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener("DOMContentLoaded", function () {
    let settingsIcon = document.getElementById("settingsIcon");
    let settingsMenu = document.getElementById("settingsMenu");

    if (settingsIcon && settingsMenu) {

        settingsIcon.addEventListener("click", function (event) {
            settingsMenu.classList.toggle("show");
        });

        // Fermer le menu si on clique en dehors
        document.addEventListener("click", function (event) {
            if (!settingsIcon.contains(event.target) && !settingsMenu.contains(event.target)) {
                settingsMenu.classList.remove("show");
            }
        });
    }
});