const personal = document.querySelectorAll(".personal")
for(let i = 0; i< personal.length;i++) {
    
    
    personal[i].children[1].addEventListener("click",(e)=> {
        e.preventDefault()
        if(personal[i].children[0].children[2].value) {
            const user = $("#username").html();
            console.log(user)
            let data = personal[i].children[0].children[0].textContent
            let valor = personal[i].children[0].children[2].value
            $.ajax({
                url: '/Home/EditarInfo',
                data: {username: user, campo: data , data: valor},
                type: 'GET',
                dataType: 'json',
                success: function(response) {
                    console.log(response);
                    personal[i].children[0].children[2].outerHTML = `<h2>${valor}</h2>`
                }, 
                error: function(xhr,status) {
                    alert("Disculpe, existio un problema")
                },
                complete: function(xhr,status) {
                    console.log("realizada")
                }
            })
        }
        let boton = personal[i].children[1].outerHTML;
        personal[i].children[0].children[2].outerHTML = `<input type=text id="datoPerso" value=${personal[i].children[0].children[2].textContent}>`
    })
}