const form = document.querySelector("form")
const input = document.querySelector("#Contraseña")
const inputc = document.querySelector("#Confirmacion-Contraseña")
const mensaje = document.querySelector(".mensaje")
const password = document.querySelector(".mensajepassword")
const passwordRepetida = document.querySelector(".mensajepasswordrepetida")
console.log(input)
input.addEventListener("input",(e)=> {
    passwordRepetida.textContent = ""
    password.textContent = ""
    let caracteresEspeciales = ['!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'];
    let abecedarioMayuscula = [
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    ];
    
    let contieneCaracter = false
    let contieneMayuscula = false
    caracteresEspeciales.forEach(element => {
        if(e.target.value.includes(element)) {
            contieneCaracter = true
        }
    });
    abecedarioMayuscula.forEach(element => {
        if(e.target.value.includes(element)) {
            contieneMayuscula = true
        }
    });
    if(e.target.value.length < 8 || !contieneCaracter || !contieneMayuscula) {
        password.textContent = "La contraseña debe tener 8 caracteres, un carácter especial y una mayúscula!"
        return false;
    } else {
        if(input.value != inputc.value) {
            passwordRepetida.textContent = "Contraseñas distintas!"
            return false;
        } else {
            console.log("ok");
        }
    }
})
inputc.addEventListener("input",()=>{
    console.log("a")
    if(input.value != inputc.value) {
        passwordRepetida.textContent = "Contraseñas distintas!"
        return false;
    } else {
        passwordRepetida.textContent = ""
        console.log("ok");
    }
})
form.addEventListener("submit",(e)=> {
    e.preventDefault()
    let caracteresEspeciales = ['!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'];
    let abecedarioMayuscula = [
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    ];
    
    let contieneCaracter = false
    let contieneMayuscula = false
    caracteresEspeciales.forEach(element => {
        if(input.value.includes(element)) {
            contieneCaracter = true
        }
    });
    abecedarioMayuscula.forEach(element => {
        if(input.value.includes(element)) {
            contieneMayuscula = true
        }
    });
    if(input.value.length < 8 || !contieneCaracter || !contieneMayuscula) {
        mensaje.textContent = "La contraseña debe tener 8 caracteres, un carácter especial y una mayúscula!"
        return false;
    } else {
        if(input.value != inputc.value) {
            mensaje.textContent = "Contraseñas distintas!"
            return false;
        } else {
            console.log("ok");
            form.submit();
        }
    }
})