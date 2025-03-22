let cart = JSON.parse(localStorage.getItem("cart")) || [];
let totalPrice = 0;

function updateLocalStorage() {
    localStorage.setItem("cart", JSON.stringify(cart));
}

function updateCartDisplay() {
    const cartContainer = document.querySelector('.cart-items-container');
    const totalDiv = document.querySelector('.total-price');
    const totalLike = document.querySelector('.total-like');

    if (!cartContainer || !totalDiv) return; // Pour éviter les erreurs si les éléments ne sont pas présents

    cartContainer.innerHTML = '';

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

    totalPrice = cart.reduce((total, product) => total + (product.price * product.quantity), 0);
    totalDiv.textContent = `Total: ${totalPrice.toFixed(2)} DH`; // Formatage du prix total

    const totalItems = cart.reduce((total, product) => total + product.quantity, 0);
    if (totalLike) totalLike.textContent = totalItems;

    updateLocalStorage();
}

function addToCart(event) {
    const shopItem = event.target.closest('.shop-item');
    const productName = shopItem.querySelector('h6 a').textContent;
    const productImage = shopItem.querySelector('.image img').src;
    const productPrice = parseFloat(shopItem.querySelector('.price .current-price').textContent.replace(/[^0-9.]/g, ''));
    const productQuantity = parseInt(shopItem.querySelector('.qty-spinner').value, 10);

    if (productQuantity < 1) return; // Empêche l'ajout de produits avec quantité négative ou zéro

    const existingProduct = cart.find(item => item.name === productName);
    if (existingProduct) {
        existingProduct.quantity += productQuantity;
    } else {
        cart.push({ name: productName, image: productImage, price: productPrice, quantity: productQuantity });
    }

    updateCartDisplay();
    alert(`Le produit "${productName}" a été ajouté au panier.`);
}

function removeProduct(index) {
    cart.splice(index, 1);
    updateCartDisplay();
}

function updateQuantity(index, change) {
    if (cart[index].quantity + change >= 1) {
        cart[index].quantity += change;
    }
    updateCartDisplay();
}

function closeSidebar() {
    document.querySelector('.cart-sidebar').style.display = 'none';
}

function showSidebar() {
    document.querySelector('.cart-sidebar').style.display = 'block';
}

document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.cart.add-to-cart').forEach(button => button.addEventListener('click', addToCart));

    const cartIcon = document.querySelector('.like-box');
    if (cartIcon) cartIcon.addEventListener('click', showSidebar);

    document.querySelector('.close-sidebar').addEventListener('click', closeSidebar);
    document.querySelector('.checkout-btn').addEventListener('click', () => alert("Phase de paiement en préparation."));

    updateCartDisplay(); // Met à jour l'affichage du panier au chargement
});
