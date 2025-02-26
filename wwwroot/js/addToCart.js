// Variables globales pour stocker les produits dans le panier et le total
let cart = [];
let totalPrice = 0;

// Fonction pour mettre à jour l'affichage du panier dans la sidebar et le nombre d'articles dans la navbar
function updateCartDisplay() {
    const cartContainer = document.querySelector('.cart-items-container');
    const totalDiv = document.querySelector('.total-price');
    const totalLike = document.querySelector('.total-like');

    // Réinitialiser le contenu de la sidebar
    cartContainer.innerHTML = '';

    // Afficher les produits dans le panier
    cart.forEach((product, index) => {
        const productDiv = document.createElement('div');
        productDiv.className = 'cart-item';
        productDiv.innerHTML = `
      <img src="${product.image}" alt="${product.name}" />
      <div class="item-details">
        <p>${product.name}</p>
        <p>Quantité: ${product.quantity}</p>
        <p>Prix: ${product.price} DH</p>
      </div>
      <div class="item-actions">
        <button onclick="removeProduct(${index})">Supprimer</button>
        <button onclick="updateQuantity(${index}, 1)">+</button>
        <button onclick="updateQuantity(${index}, -1)">-</button>
      </div>
    `;
        cartContainer.appendChild(productDiv);
    });

    // Calculer le total
    totalPrice = cart.reduce((total, product) => total + (product.price * product.quantity), 0);
    totalDiv.textContent = `Total: ${totalPrice} DH`;

    // Mettre à jour le nombre d'articles dans le panier (la valeur de .total-like)
    const totalItems = cart.reduce((total, product) => total + product.quantity, 0);
    totalLike.textContent = totalItems; // Mettre à jour la valeur de l'élément .total-like
}

// Fonction pour ajouter un produit au panier
function addToCart(event) {
    const shopItem = event.target.closest('.shop-item');
    const productName = shopItem.querySelector('h6 a').textContent;
    const productImage = shopItem.querySelector('.image img').src;
    const productPrice = parseFloat(shopItem.querySelector('.price .current-price').textContent.replace(/[^0-9.]/g, ''));
    const productQuantity = parseInt(shopItem.querySelector('.qty-spinner').value);

    // Ajouter ou mettre à jour le produit dans le panier
    const existingProduct = cart.find(item => item.name === productName);
    if (existingProduct) {
        existingProduct.quantity = productQuantity;
    } else {
        cart.push({ name: productName, image: productImage, price: productPrice, quantity: productQuantity });
    }

    totalPrice = cart.reduce((total, product) => total + (product.price * product.quantity), 0);
    updateCartDisplay(); // Mettre à jour l'affichage du panier
    alert(`Le produit "${productName}" a été ajouté au panier.`);
}


// Fonction pour supprimer un produit du panier
function removeProduct(index) {
    const product = cart[index];
    totalPrice -= product.price * product.quantity;
    cart.splice(index, 1);
    updateCartDisplay(); // Mettre à jour l'affichage du panier
}

// Fonction pour mettre à jour la quantité d'un produit dans le panier
function updateQuantity(index, change) {
    const product = cart[index];
    product.quantity += change;
    if (product.quantity < 1) product.quantity = 1; // Assurez-vous que la quantité est au moins 1
    totalPrice = cart.reduce((total, product) => total + (product.price * product.quantity), 0);
    updateCartDisplay(); // Mettre à jour l'affichage du panier
}

// Fonction pour fermer la sidebar
function closeSidebar() {
    const sidebar = document.querySelector('.cart-sidebar');
    sidebar.style.display = 'none';
}

// Fonction pour afficher la sidebar
function showSidebar() {
    const sidebar = document.querySelector('.cart-sidebar');
    sidebar.style.display = 'block';
}

// Initialiser les événements
document.addEventListener('DOMContentLoaded', () => {
    // Associer un gestionnaire de clics à chaque bouton "Ajouter au panier"
    const addToCartButtons = document.querySelectorAll('.cart.add-to-cart');
    addToCartButtons.forEach(button => button.addEventListener('click', addToCart));

    // Associer un gestionnaire pour afficher la sidebar
    const cartIcon = document.querySelector('.like-box');
    cartIcon.addEventListener('click', showSidebar);

    // Ajouter un gestionnaire pour fermer la sidebar
    const closeButton = document.querySelector('.close-sidebar');
    closeButton.addEventListener('click', closeSidebar);

    // Ajouter un gestionnaire pour le bouton "Passer à la caisse"
    const checkoutButton = document.querySelector('.checkout-btn');
    checkoutButton.addEventListener('click', () => alert("Phase de paiement en préparation."));
});
