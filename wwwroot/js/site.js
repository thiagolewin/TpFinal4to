document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.querySelector('.input');
    const cards = document.querySelectorAll('.card');


    const startsWith = (string, term) => string.trim().toLowerCase().indexOf(term.trim().toLowerCase()) === 0;

    searchInput.addEventListener("click",()=> {
        const currentUrl = window.location.pathname;
        const desiredUrl = '/Home/Index';
        if (currentUrl !== desiredUrl) {
            window.location.href = desiredUrl
        } 
    })
    searchInput.addEventListener('input', function () {
        const searchTerm = searchInput.value.toLowerCase().trim();


        cards.forEach(card => {
            const title = card.querySelector('.title').innerText.toLowerCase();


            const matches = startsWith(title, searchTerm);


            card.style.display = matches ? 'block' : 'none';
        });
    });
});

const menuToggle = document.getElementById('menu-toggle');
const mobileMenu = document.getElementById('mobile-menu');
const closeButton = document.getElementById('close-button');


menuToggle.addEventListener('click', () => {
    mobileMenu.style.left = "0";
});


closeButton.addEventListener('click', () => {
    mobileMenu.style.left = "-100%";
});


document.addEventListener('click', (event) => {
    if (event.target !== menuToggle && event.target !== mobileMenu && event.target !== closeButton) {
        mobileMenu.style.left = "-100%";
    }
});


const stars = document.querySelectorAll('.star');


stars.forEach(star => {
    star.addEventListener('mouseover', () => {
        star.classList.add('active');
    });
   
    star.addEventListener('mouseout', () => {
        star.classList.remove('active');
    });
});





