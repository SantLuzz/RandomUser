const apiUrl = 'http://localhost:5262/v1/users'; // URL base para usuários
const importUrl = 'http://localhost:5262/v1/imports/users'; // URL para importar usuários

async function fetchUsers() {
    try {
        const response = await fetch(`${apiUrl}?pageNumber=1&pageSize=300`);
        const users = await response.json();
        console.log(users); // Verifica o que está sendo retornado
        
        displayUsers(users);

    } catch (error) {
        console.error('Erro ao buscar usuários:', error); // Exibe erros de requisição
    }
}

function displayUsers(users) {
    const userTableBody = document.querySelector('#userTable tbody');
    userTableBody.innerHTML = ''; // Limpa a tabela antes de inserir novos dados

    if (users.data && Array.isArray(users.data)) {
        users.data.forEach(user => {
            const row = document.createElement('tr');
            row.setAttribute('data-id', user.id); // Adiciona o data-id à linha
            row.innerHTML = `
                    <td>${user.id}</td>
                    <td contenteditable="true">${user.name}</td>
                    <td contenteditable="true">${user.email}</td>
                    <td contenteditable="true">${user.gender || ''}</td>
                    <td contenteditable="true" data-id="${user.id}">${user.birthDate ? new Date(user.birthDate).toLocaleDateString('pt-BR') : ''}</td>
                    <td contenteditable="true">${user.nationality || ''}</td>
                    <td contenteditable="true">${user.address || ''}</td>
                    <td contenteditable="true">${user.phone || ''}</td>
                    <td contenteditable="true">${user.mobile || ''}</td>
                    <td>
                        <button onclick="updateUser(${user.id})">Editar</button>
                    </td>
                `;
            userTableBody.appendChild(row);
        });
    } else {
        console.error('Nenhum usuário encontrado.');
    }
}

async function updateUser(userId) {
    const row = document.querySelector(`tr[data-id="${userId}"]`);

    if (!row) {
        console.error(`Linha não encontrada para o usuário com ID: ${userId}`);
        return; // Sai da função se a linha não for encontrada
    }

    const name = row.cells[1].innerText;
    const email = row.cells[2].innerText;
    const gender = row.cells[3].innerText;
    
    // Obtém a data de nascimento, convertendo de DD/MM/YYYY para o formato ISO
    const birthDateString = row.cells[4].innerText;
    const [day, month, year] = birthDateString.split('/'); // Divide a string em partes
    const birthDate = new Date(`${year}-${month}-${day}T00:00:00Z`).toISOString(); // Converte para ISO
    
    const nationality = row.cells[5].innerText;
    const address = row.cells[6].innerText;
    const phone = row.cells[7].innerText;
    const mobile = row.cells[8].innerText;

    const response = await fetch(`${apiUrl}/${userId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            id: userId,
            name,
            email,
            gender,
            birthDate,
            nationality,
            address,
            phone,
            mobile
        }),
    });

    if (response.ok) {
        alert('Usuário atualizado com sucesso!');
        fetchUsers(); // Recarrega a lista de usuários
    } else {
        alert('Erro ao atualizar o usuário.');
    }
}


// Função para importar usuários
async function importUsers() {
    const userCount = document.getElementById('userCount').value;
    const country = document.getElementById('country').value;
    
    if (!userCount || !country) {
        alert('Por favor, preencha todos os campos!');
        return;
    }

    const response = await fetch(importUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            quantity: userCount,
            country: country
        }),
    });

    if (response.ok) {
        alert('Usuários importados com sucesso!');
        fetchUsers(); // Recarrega a lista de usuários após a importação
    } else {
        alert('Erro ao importar usuários.');
    }
}

// Adiciona o listener para o botão de importação
document.getElementById('importButton').addEventListener('click', importUsers);

// Chama a função fetchUsers ao iniciar a página
window.onload = fetchUsers;
