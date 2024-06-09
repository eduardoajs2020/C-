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

// Função para abrir processo
async function abrirProcesso(numero, assunto, descricao) {
    try {
        const data = await sendRequest(`${backendUrl}/api/processos/abrir`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ numero: parseInt(numero), assunto, descricao })
        });
        console.log(data);
        showSuccessMessage('processoSuccessMessage', typeof data === 'string' ? data : data.message || 'Processo Cadastrado com sucesso.');

        // Limpar os campos do formulário
        document.getElementById('numeroInput').value = '';
        document.getElementById('assuntoInput').value = '';
        document.getElementById('descricaoInput').value = '';

        listarChamados();
    } catch (error) {
        showErrorMessage('processoErrorMessage', error);
    }
}

// Evento de submissão do formulário de abrir processo
document.getElementById('processoForm').addEventListener('submit', function (event) {
    event.preventDefault();

    let numero = document.getElementById('numeroInput').value;
    let assunto = document.getElementById('assuntoInput').value;
    let descricao = document.getElementById('descricaoInput').value;

    if (!assunto || !descricao) {
        alert('Os campos "assunto" e "descricao" são obrigatórios.');
        return;
    }

    abrirProcesso(numero, assunto, descricao);
});

// Função para fechar processo
async function fecharProcesso(numero) {
    try {
        const data = await sendRequest(`${backendUrl}/api/processo/fechar/${numero}`, { method: 'POST' });
        console.log(data);
        showSuccessMessage('fecharProcessoMessage', 'Processo fechado com sucesso.');

        // Limpar o campo do formulário
        document.getElementById('numeroFecharInput').value = '';

        listarProcessos();
    } catch (error) {
        showErrorMessage('fecharChamadoErrorMessage', error);
    }
}

// Evento de submissão do formulário de fechar processos
document.getElementById('fecharChamadoForm').addEventListener('submit', function (event) {
    event.preventDefault();

    let numeroFechar = document.getElementById('numeroFecharInput').value;
    fecharProcesso(numeroFechar);
});

// Função para listar processos
async function listarProcessos() {
    try {
        const data = await sendRequest(`${backendUrl}/api/processo/listar`);
        console.log(data);
        displayProcessos(data);
    } catch (error) {
        showErrorMessage('chamadosErrorMessage', error);
    }
}

// Função para gerar o HTML da tabela
function generateTableHTML(chamados) {
    let html = '<table>';
    html += '<tr><th>Número</th><th>Assunto</th><th>Descrição</th><th>Data Abertura</th><th>Data Fechamento</th><th>Status</th></tr>';

    processos.forEach(processo => {
        html += `<tr>
            <td>${processo.numero}</td>
            <td>${processo.assunto}</td>
            <td>${processo.descricao}</td>
            <td>${processo.dataAbertura}</td>
            <td>${processo.dataFechamento ? processo.dataFechamento : 'N/A'}</td>
            <td>${processo.status}</td>
        </tr>`;
    });

    html += '</table>';
    return html;
}

// Função para exibir os processos
function displayProcessos(data) {
    let processosList = document.getElementById('processosList');
    processosList.innerHTML = '';

    // Exibir processos abertos
    if (data.processosAbertos && data.processosAbertos.length > 0) {
        let abertosHeader = document.createElement('h2');
        abertosHeader.textContent = 'Processos Abertos';
        processosList.appendChild(abertosHeader);

        let abertosTable = generateTableHTML(data.processosAbertos);
        processosList.innerHTML += abertosTable;
    } else {
        let noProcessosAbertos = document.createElement('p');
        noProcessosAbertos.textContent = 'Nenhum processo aberto.';
        processosList.appendChild(noProcessosAbertos);
    }

    // Exibir processos fechados
    if (data.processosFechados && data.processosFechados.length > 0) {
        let fechadosHeader = document.createElement('h2');
        fechadosHeader.textContent = 'Processos Fechados';
        processosList.appendChild(fechadosHeader);

        let fechadosTable = generateTableHTML(data.processosFechados);
        processosList.innerHTML += fechadosTable;
    } else {
        let noProcessosFechados = document.createElement('p');
        noProcessosFechados.textContent = 'Nenhum processo fechado.';
        processosList.appendChild(noProcessosFechados);
    }
}

// Chamar a função para exibir a lista de processos ao carregar a página
listarProcessos();