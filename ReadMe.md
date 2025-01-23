# Projeto - API para consulta à API pública do GitHub
API desenvolvida em .NET 9 utilizando C#, com o intuito de realizar consulta à API do GitHub (https://docs.github.com/rest)


### Diretório Flow
Contém o fluxo de um chatbot em JSON. O chatbot foi desenvolvido utilizando a plataforma Blip. 

### Link de acesso à API e Endpoints:
https://consultagithub.azurewebsites.net/swagger/index.html

> **Listar repositórios de um usuário**: /api/Github/{userName}
> **Listar um repositório específico**: /api/Github/{owner}/{repo}
> **Obter url do avatar do usuário**: /api/Github/avatar/{userName}

----

### Instruções para rodar o projeto
Após fazer o clone, será necessário criar uma imagem no docker para rodar o projeto

