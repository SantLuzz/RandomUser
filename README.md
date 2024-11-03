# Random User

## Descrição do Projeto

O **Random User** é uma aplicação web que permite a importação, visualização e gerenciamento de informações de usuários. Com uma interface amigável, a aplicação possibilita que os usuários importem dados de um serviço externo e visualizem essas informações de forma organizada.

## Funcionalidades

- **Importação de Usuários**: Permite ao usuário especificar a quantidade e o país dos usuários a serem importados.
- **Exibição de Dados**: Mostra os dados dos usuários em uma tabela organizada, com informações como ID, Nome, Email, Gênero, Data de Nascimento, Nacionalidade, Endereço e Telefone.
- **Validação de Dados**: Garante que os campos obrigatórios sejam preenchidos antes da importação.
- **Atualização de Usuários**: permite o usuário alterar os dados exibidos na tela

## Tecnologias Utilizadas

### Frontend
- **HTML5**: Para a estruturação da página.
- **CSS3**: Para a estilização e layout da aplicação.
- **JavaScript**: Para funcionalidades dinâmicas, como a importação e exibição dos usuários.
- **Fetch API**: Para comunicação com serviços web e manipulação de dados JSON.

### Backend
- **Minimal API Rest C#**: API REST para comunicação com a base de dados.
- **Entity Framework**: Para acesso e manipulação de dados no banco.
- **.NET 8**: Plataforma para desenvolvimento da API.
- **PostgreSQL**: Para armazenamento de dados.
- **CORS**: Para permitir requisições de diferentes origens.
- **Swagger**: Para documentação e testes da API.

## Requisitos

Antes de executar o projeto, certifique-se de ter o seguinte instalado:

- Um navegador moderno (como Google Chrome, Firefox, ou Safari)
- Conexão à internet (para chamadas de API)
- **PostgreSQL**: Para o banco de dados, que deve ser anexado a partir da pasta fornecida.

## Instalação

- Clone o repositório:
   ```bash
   git clone https://github.com/SantLuzz/RandomUser.git
- Navegue até o diretório do projeto.
- Anexe o banco de dados PostgreSQL da pasta fornecida:
   - RandomUser\RandomUser.Api\Data\DataBase\dump-randomUser-dev-202411031722.sql
- No arquivo AppSettings da API, ajuste a connection string do banco de dados.
- Certifique-se de executar a API para que a aplicação possa se comunicar com o banco de dados.
- Abra o arquivo index.html em um navegador da sua escolha.

## Uso
- Ao abrir a aplicação, você verá um formulário onde poderá inserir a quantidade de usuários e o país para importação.
- Após preencher os campos, clique no botão Importar Usuários.
- Os dados importados serão exibidos em uma tabela logo abaixo do formulário.
- Caso ocorra algum erro durante a importação, uma mensagem será exibida.

## Endpoints da API

A seguir estão os endpoints disponíveis na API, que podem ser visualizados ao executar a API e acessar a URL `url-api/swagger/`:

### Health Check
- **GET /**: Retorna a saúde da API.

### Imports
- **POST /v1/imports/users**: Importa usuários da API externa e os salva na base de dados.
  - **Parâmetros:**
    - `quantity`: Quantidade de registros que devem ser importados (padrão é 15).
    - `nationality`: Sigla da nacionalidade dos usuários (padrão é "br").

### Users
- **GET /v1/users**: Recupera todos os usuários na base de dados.
- **GET /v1/users/{id}**: Recupera um usuário específico na base de dados.
- **PUT /v1/users/{id}**: Atualiza os dados de um usuário específico na base de dados.
