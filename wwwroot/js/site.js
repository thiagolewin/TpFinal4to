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
