const backendUrl = 'http://localhost:5274';

// Função para enviar requisição HTTP
async function sendRequest(url, options) {
    try {
        const response = await fetch(url, options);
        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || JSON.stringify(errorData));
        }
        return response.headers.get('Content-Type').includes('application/json') ? response.json() : response.text();
    } catch (error) {
        console.error('Erro:', error);
        throw error;
    }
}

// Função para exibir mensagens de sucesso
function showSuccessMessage(containerId, message) {
    let successMessage = document.createElement('div');
    successMessage.classList.add('success-message');
    successMessage.textContent = message;
    document.getElementById(containerId).appendChild(successMessage);
}

// Função para exibir mensagens de erro
function showErrorMessage(containerId, error) {
    let errorMessage = document.createElement('div');
    errorMessage.classList.add('error-message');
    errorMessage.textContent = 'Erro: ' + error;
    document.getElementById(containerId).appendChild(errorMessage);
}

// Função para abrir chamado
async function abrirChamado(numero, assunto, descricao) {
    try {
        const data = await sendRequest(`${backendUrl}/api/chamados/abrir`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ numero: parseInt(numero), assunto, descricao })
        });
        console.log(data);
        showSuccessMessage('chamadoSuccessMessage', typeof data === 'string' ? data : data.message || 'Chamado aberto com sucesso.');

        // Limpar os campos do formulário
        document.getElementById('numeroInput').value = '';
        document.getElementById('assuntoInput').value = '';
        document.getElementById('descricaoInput').value = '';

        listarChamados();
    } catch (error) {
        showErrorMessage('chamadoErrorMessage', error);
    }
}

// Evento de submissão do formulário de abrir chamado
document.getElementById('chamadoForm').addEventListener('submit', function (event) {
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

// Função para fechar chamado
async function fecharChamado(numero) {
    try {
        const data = await sendRequest(`${backendUrl}/api/chamados/fechar/${numero}`, { method: 'POST' });
        console.log(data);
        showSuccessMessage('fecharChamadoMessage', 'Chamado fechado com sucesso.');

        // Limpar o campo do formulário
        document.getElementById('numeroFecharInput').value = '';

        listarChamados();
    } catch (error) {
        showErrorMessage('fecharChamadoErrorMessage', error);
    }
}

// Evento de submissão do formulário de fechar chamado
document.getElementById('fecharChamadoForm').addEventListener('submit', function (event) {
    event.preventDefault();

    let numeroFechar = document.getElementById('numeroFecharInput').value;
    fecharChamado(numeroFechar);
});

// Função para listar chamados
async function listarChamados() {
    try {
        const data = await sendRequest(`${backendUrl}/api/chamados/listar`);
        console.log(data);
        displayChamados(data);
    } catch (error) {
        showErrorMessage('chamadosErrorMessage', error);
    }
}

// Função para gerar o HTML da tabela
function generateTableHTML(chamados) {
    let html = '<table>';
    html += '<tr><th>Número</th><th>Assunto</th><th>Descrição</th><th>Data Abertura</th><th>Data Fechamento</th><th>Status</th></tr>';

    chamados.forEach(chamado => {
        html += `<tr>
            <td>${chamado.numero}</td>
            <td>${chamado.assunto}</td>
            <td>${chamado.descricao}</td>
            <td>${chamado.dataAbertura}</td>
            <td>${chamado.dataFechamento ? chamado.dataFechamento : 'N/A'}</td>
            <td>${chamado.status}</td>
        </tr>`;
    });

    html += '</table>';
    return html;
}

// Função para exibir os chamados
function displayChamados(data) {
    let chamadosList = document.getElementById('chamadosList');
    chamadosList.innerHTML = '';

    // Exibir chamados abertos
    if (data.chamadosAbertos && data.chamadosAbertos.length > 0) {
        let abertosHeader = document.createElement('h2');
        abertosHeader.textContent = 'Chamados Abertos';
        chamadosList.appendChild(abertosHeader);

        let abertosTable = generateTableHTML(data.chamadosAbertos);
        chamadosList.innerHTML += abertosTable;
    } else {
        let noChamadosAbertos = document.createElement('p');
        noChamadosAbertos.textContent = 'Nenhum chamado aberto.';
        chamadosList.appendChild(noChamadosAbertos);
    }

    // Exibir chamados fechados
    if (data.chamadosFechados && data.chamadosFechados.length > 0) {
        let fechadosHeader = document.createElement('h2');
        fechadosHeader.textContent = 'Chamados Fechados';
        chamadosList.appendChild(fechadosHeader);

        let fechadosTable = generateTableHTML(data.chamadosFechados);
        chamadosList.innerHTML += fechadosTable;
    } else {
        let noChamadosFechados = document.createElement('p');
        noChamadosFechados.textContent = 'Nenhum chamado fechado.';
        chamadosList.appendChild(noChamadosFechados);
    }
}

// Chamar a função para exibir a lista de chamados ao carregar a página
listarChamados();
