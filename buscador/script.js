function realizarPesquisa() {
    let termoPesquisa = document.getElementById("termoPesquisa").value;

    // Chamar a API do backend (C#) para realizar a pesquisa
    fetch(`/api/pesquisarTJMG?termoPesquisa=${encodeURIComponent(termoPesquisa)}`)
        .then(response => response.json())
        .then(data => mostrarResultados(data))
        .catch(error => console.error('Ocorreu um erro:', error));
}

function mostrarResultados(data) {
    let resultadoPesquisa = document.getElementById("resultadoPesquisa");
    resultadoPesquisa.innerHTML = "";

    if (data.length > 0) {
        let listaResultados = document.createElement("ul");

        data.forEach(item => {
            let tituloLink = document.createElement("a");
            tituloLink.href = item.url;
            tituloLink.textContent = item.titulo;

            let itemLista = document.createElement("li");
            itemLista.appendChild(tituloLink);

            listaResultados.appendChild(itemLista);
        });

        resultadoPesquisa.appendChild(listaResultados);
    } else {
        resultadoPesquisa.textContent = "Nenhum resultado encontrado.";
    }
}
