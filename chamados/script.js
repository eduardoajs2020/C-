const backendUrl = 'http://localhost:5208';


// Função para abrir chamado
function abrirChamado(numero, assunto, descricao) {
    fetch(`${backendUrl}/api/chamados/abrir`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ numero: parseInt(numero), assunto: assunto, descricao: descricao })
    })
    .then(response => {
        if (!response.ok) {
            return response.json().then(errorData => { throw new Error(JSON.stringify(errorData)); });
        }
       // Check response type (text or JSON)
      if (response.headers.get('Content-Type').includes('application/json')) {
        return response.json();  // Parse JSON response
      } else {
        return response.text();
      }
    })
        
    .then(data => {
        console.log(data);
      let successMessage = document.createElement('div');
      successMessage.classList.add('success-message');
      // Access data based on response type (text or object property)
      successMessage.textContent = typeof data === 'string' ? data : data.message || 'Chamado aberto com sucesso.';
      document.getElementById('chamadoSuccessMessage').appendChild(successMessage);

        // Limpar os campos do formulário
        document.getElementById('numeroInput').value = '';
        document.getElementById('assuntoInput').value = '';
        document.getElementById('descricaoInput').value = '';
        listarChamados();
        alert(data);
        
        
    })
    .catch(error => {
        console.error('Erro:', error);
        let errorMessage = document.createElement('div');
        errorMessage.classList.add('error-message');
        errorMessage.textContent = 'Erro ao abrir chamado: ' + error;
        document.getElementById('chamadoErrorMessage').appendChild(errorMessage);
    });

    // Evento de submissão do formulário de abrir chamado
document.getElementById('chamadoForm').addEventListener('submit', function(event) {
    event.preventDefault();

    let numero = document.getElementById('numeroInput').value;
    let assunto = document.getElementById('assuntoInput').value;
    let descricao = document.getElementById('descricaoInput').value;

    if (!assunto || !descricao) {
        alert('Os campos "assunto" e "descricao" são obrigatórios.');
        return;
    }

    abrirChamado(numero, assunto, descricao);
});

}

// Função para fechar chamado
function fecharChamado(numero) {
    fetch(`${backendUrl}/api/chamados/fechar/${numero}`, {
        method: 'POST'
    })
    .then(response => {
        if (!response.ok) {
            return response.json().then(errorData => { throw new Error(JSON.stringify(errorData)); });
        }
        return response.text();
    })
    .then(data => {
        console.log(data);
        let successMessage = document.createElement('div');
        successMessage.classList.add('success-message');
        successMessage.textContent = 'Chamado fechado com sucesso.';
        document.getElementById('fecharChamadoMessage').appendChild(successMessage);

        // Limpar o campo do formulário
        document.getElementById('numeroFecharInput').value = '';

        // Atualizar a lista de chamados
        listarChamados();
    })
    .catch(error => {
        console.error('Erro:', error);
        let errorMessage = document.createElement('div');
        errorMessage.classList.add('error-message');
        errorMessage.textContent = 'Erro ao fechar chamado: ' + error;
        document.getElementById('fecharChamadoErrorMessage').appendChild(errorMessage);
    });
}

// Função para listar chamados
function listarChamados() {
  fetch(`${backendUrl}/api/chamados/listar`)
    .then(async (response) => {
        if (!response.ok) {
            const errorData = await response.json();
            const errorMessage = errorData.message || 'Ocorreu um erro ao listar chamados.';
            throw new Error(errorMessage);
        }
        return response.json();
    })
    .then(data => {
        console.log(data);
        let chamadosList = document.getElementById('chamadosList');
        chamadosList.innerHTML = '';

        // Exibir chamados abertos
        if (typeof data.ChamadosAbertos !== 'undefined' && data.ChamadosAbertos.length > 0) {
                    let abertosHeader = document.createElement('h2');
                    abertosHeader.textContent = 'Chamados Abertos';
                    chamadosList.appendChild(abertosHeader);

        data.ChamadosAbertos.forEach(chamado => {
                        let chamadoItem = document.createElement('div');
                        chamadoItem.classList.add('chamado-item');
                        let numero = document.createElement('span');
                        numero.classList.add('numero');
                        numero.textContent = 'Número: ' + chamado.numero;
                        let assunto = document.createElement('div');
                        assunto.classList.add('assunto');
                        assunto.textContent = 'Assunto: ' + chamado.assunto;
                        let dataAbertura = document.createElement('div');
                        dataAbertura.classList.add('data');
                        dataAbertura.textContent = 'Data Abertura: ' + chamado.dataAbertura;
                        chamadoItem.appendChild(numero);
                        chamadoItem.appendChild(assunto);
                        chamadoItem.appendChild(dataAbertura);
                        chamadosList.appendChild(chamadoItem);
                    });
                } else {
                    let noChamadosAbertos = document.createElement('p');
                    noChamadosAbertos.textContent = 'Nenhum chamado aberto.';
                    chamadosList.appendChild(noChamadosAbertos);
                }

        // Exibir chamados fechados
        if (typeof data.ChamadosFechados !== 'undefined' && data.ChamadosFechados.length > 0) {
                    let fechadosHeader = document.createElement('h2');
                    fechadosHeader.textContent = 'Chamados Fechados';
                    chamadosList.appendChild(fechadosHeader);

                    data.ChamadosFechados.forEach(chamado => {
                        let chamadoItem = document.createElement('div');
                        chamadoItem.classList.add('chamado-item');
                        let numero = document.createElement('span');
                        numero.classList.add('numero');
                        numero.textContent = 'Número: ' + chamado.numero;
                        let assunto = document.createElement('div');
                        assunto.classList.add('assunto');
                        assunto.textContent = 'Assunto: ' + chamado.assunto;
                        let dataAbertura = document.createElement('div');
                        dataAbertura.classList.add('data');
                        dataAbertura.textContent = 'Data Abertura: ' + chamado.dataAbertura;
                        let dataFechamento = document.createElement('div');
                        dataFechamento.classList.add('data');
                        dataFechamento.textContent = 'Data Fechamento: ' + chamado.dataFechamento;
                        chamadoItem.appendChild(numero);
                        chamadoItem.appendChild(assunto);
                        chamadoItem.appendChild(dataAbertura);
                        chamadoItem.appendChild(dataFechamento);
                        chamadosList.appendChild(chamadoItem);
                    });
                } else {
                    let noChamadosFechados = document.createElement('p');
                    noChamadosFechados.textContent = 'Nenhum chamado fechado.';
                    chamadosList.appendChild(noChamadosFechados);
                }
            })
    .catch(error => {
        console.error('Erro:', error);
        let errorMessage = document.createElement('div');
        errorMessage.classList.add('error-message');
        errorMessage.textContent = 'Erro ao listar chamados: ' + error;
        document.getElementById('chamadosErrorMessage').appendChild(errorMessage);
    });
}


// Evento de submissão do formulário de fechar chamado
document.getElementById('fecharChamadoForm').addEventListener('submit', function(event) {
    event.preventDefault();

    let numeroFechar = document.getElementById('numeroFecharInput').value;

    fecharChamado(numeroFechar);
});

// Chamar a função para exibir a lista de chamados ao carregar a página
listarChamados();


