function Estrellas(cuantas) {
    const miDiv = document.querySelector(".content")
    for(let i = 0; i<miDiv.childElementCount;i++) {
        if(miDiv.children[i].children[1].children[1].children[1].childElementCount != cuantas) {
            miDiv.children[i].style = "display:none;";
        } else {
            miDiv.children[i].style = "display:block;";
        }
    }
}
