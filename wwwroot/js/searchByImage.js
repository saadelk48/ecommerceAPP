document.addEventListener("DOMContentLoaded", function () {
    let searchContainer = document.getElementById("search-container");
    let imageSidebar = document.getElementById("image-sidebar");
    let hideTimeout;

    // Fonction pour afficher la sidebar avec une animation fluide
    function showSidebar() {
        clearTimeout(hideTimeout);
        imageSidebar.style.display = "block";
        imageSidebar.style.opacity = "1";
        imageSidebar.style.transform = "translateY(0)";
    }

    // Fonction pour cacher la sidebar avec une transition douce
    function hideSidebar() {
        hideTimeout = setTimeout(() => {
            imageSidebar.style.opacity = "0";
            imageSidebar.style.transform = "translateY(-5px)";
            setTimeout(() => {
                imageSidebar.style.display = "none";
            }, 200);
        }, 300);
    }

    // Événements pour afficher et cacher la sidebar
    searchContainer.addEventListener("mouseenter", showSidebar);
    imageSidebar.addEventListener("mouseenter", showSidebar);
    searchContainer.addEventListener("mouseleave", hideSidebar);
    imageSidebar.addEventListener("mouseleave", hideSidebar);
});
