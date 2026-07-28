# Tarefas API — Gerenciamento de Tarefas

API REST desenvolvida em **C# com ASP.NET Core** para cadastro e gerenciamento de tarefas.

O projeto foi construído com foco no aprendizado de desenvolvimento backend, arquitetura em camadas, Entity Framework Core, integração com SQL Server, utilização de DTOs, validação de dados e implementação de operações CRUD.

---

## Objetivos de aprendizado

O projeto foi desenvolvido para aplicar conceitos importantes de programação e engenharia de software:

* Desenvolvimento de APIs REST com ASP.NET Core;
* Organização de uma aplicação em camadas;
* Separação entre domínio, aplicação e infraestrutura;
* Utilização de controllers;
* Criação e utilização de DTOs;
* Aplicação de regras de negócio em serviços;
* Injeção de dependência;
* Persistência de dados com Entity Framework Core;
* Integração com SQL Server;
* Criação e aplicação de migrations;
* Implementação de operações CRUD;
* Validação de dados;
* Utilização de enums;
* Tratamento de respostas HTTP;
* Documentação de endpoints com Swagger.

---

## Funcionalidades

O sistema permite:

* Cadastrar tarefas;
* Consultar todas as tarefas;
* Buscar uma tarefa pelo identificador;
* Atualizar uma tarefa existente;
* Excluir uma tarefa;
* Definir o status da tarefa;
* Validar título e descrição;
* Persistir os dados em um banco SQL Server;
* Testar os endpoints pela interface do Swagger.

---

## Modelo de tarefa

Cada tarefa possui as seguintes informações:

| Campo       | Descrição                     |
| ----------- | ----------------------------- |
| `Id`        | Identificador único           |
| `Titulo`    | Título da tarefa              |
| `Descricao` | Descrição da tarefa           |
| `Data`      | Data de criação ou referência |
| `Status`    | Situação atual da tarefa      |

Os status disponíveis são:

```text
Pendente
Realizado
```

O uso de um `enum` restringe os valores aceitos e evita estados inválidos.

---

## Arquitetura do projeto

A aplicação foi organizada nas seguintes camadas:

```text
API/
├── Application/
├── Domain/
├── Infrastructure/
├── Properties/
├── appsettings.json
└── TarefasAPI.csproj
```

### Domain

A camada de domínio representa os elementos centrais do sistema.

Ela contém:

* Entidades;
* Enums;
* Contratos;
* Elementos relacionados às regras do domínio.

A entidade de tarefa representa os dados que serão persistidos no banco.

### Application

A camada de aplicação coordena os casos de uso do sistema.

Ela contém elementos como:

* Controllers;
* Serviços;
* DTOs de entrada e saída;
* Validações;
* Operações de cadastro, consulta, edição e exclusão.

Essa camada recebe as requisições HTTP, valida os dados e encaminha as operações para a infraestrutura.

### Infrastructure

A camada de infraestrutura é responsável pela comunicação com recursos externos.

Entre suas responsabilidades estão:

* Configuração do `DbContext`;
* Integração com SQL Server;
* Mapeamento das entidades;
* Persistência dos dados;
* Migrations do Entity Framework Core.

---

## DTOs

O projeto utiliza objetos específicos para representar os dados de cada operação.

### DTO de criação

Utilizado para cadastrar uma nova tarefa:

```json
{
  "titulo": "Estudar ASP.NET Core",
  "descricao": "Revisar controllers, services e DTOs"
}
```

### DTO de atualização

Utilizado para editar uma tarefa:

```json
{
  "titulo": "Estudar Entity Framework",
  "descricao": "Revisar migrations e relacionamentos",
  "status": 1
}
```

A utilização de DTOs evita que a entidade do banco seja exposta diretamente pela API.

---

## Endpoints

| Método   | Endpoint            | Descrição                |
| -------- | ------------------- | ------------------------ |
| `POST`   | `/api/tarefas`      | Cadastra uma tarefa      |
| `GET`    | `/api/tarefas`      | Lista todas as tarefas   |
| `GET`    | `/api/tarefas/{id}` | Busca uma tarefa pelo ID |
| `PUT`    | `/api/tarefas/{id}` | Atualiza uma tarefa      |
| `DELETE` | `/api/tarefas/{id}` | Exclui uma tarefa        |

A rota exata pode variar conforme a configuração presente no controller.

---

## Fluxo da aplicação

```text
Cliente HTTP
     ↓
Controller
     ↓
DTO e validação
     ↓
Service
     ↓
DbContext
     ↓
SQL Server
```

Exemplo de cadastro:

1. O cliente envia os dados da tarefa;
2. O controller recebe o DTO;
3. A camada de aplicação valida os campos;
4. O serviço cria a entidade;
5. O Entity Framework adiciona o registro;
6. O SQL Server persiste os dados;
7. A API retorna uma resposta HTTP.

---

## Validações

Entre as regras aplicadas estão:

* O título é obrigatório;
* O título possui limite de caracteres;
* A descrição possui limite de caracteres;
* O identificador deve representar uma tarefa existente;
* O status deve corresponder a um valor válido do enum;
* Dados inválidos não devem ser enviados ao banco.

---

## Códigos HTTP

| Código                      | Uso                               |
| --------------------------- | --------------------------------- |
| `200 OK`                    | Consulta ou atualização realizada |
| `201 Created`               | Tarefa cadastrada                 |
| `204 No Content`            | Exclusão realizada                |
| `400 Bad Request`           | Dados inválidos                   |
| `404 Not Found`             | Tarefa não encontrada             |
| `500 Internal Server Error` | Erro inesperado                   |

---

## Tecnologias utilizadas

* C#;
* ASP.NET Core;
* Controllers;
* Entity Framework Core;
* SQL Server;
* DTOs;
* Injeção de dependência;
* Swagger e OpenAPI;
* Git e GitHub.

---

## Como executar o projeto

### Pré-requisitos

* .NET SDK compatível com o projeto;
* SQL Server ou SQL Server Express;
* Git;
* Visual Studio, Visual Studio Code ou Rider;
* Entity Framework CLI.

### 1. Clone o repositório

```bash
git clone https://github.com/enricobarni/TarefasAPI.git
```

### 2. Acesse a pasta

```bash
cd TarefasAPI
```

### 3. Restaure as dependências

```bash
dotnet restore
```

### 4. Configure o banco

Edite a string de conexão no arquivo:

```text
API/appsettings.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "SqlServerConnection": "Server=localhost;Database=TarefasDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

O nome da chave deve corresponder ao utilizado na configuração do `DbContext`.

### 5. Aplique as migrations

```bash
dotnet ef database update --project API
```

### 6. Execute a aplicação

```bash
dotnet run --project API
```

Para atualização automática durante o desenvolvimento:

```bash
dotnet watch --project API
```

### 7. Acesse o Swagger

Abra a URL exibida no terminal e acrescente:

```text
/swagger
```

---

## Estrutura conceitual

```text
Tarefa
├── Id
├── Titulo
├── Descricao
├── Data
└── Status
```

O projeto demonstra a implementação de uma API completa, desde o recebimento da requisição até a persistência no banco de dados.

---

## Aprendizados obtidos

Durante o desenvolvimento, foram praticados:

* Construção de APIs REST;
* Arquitetura em camadas;
* Separação de responsabilidades;
* Controllers e services;
* DTOs;
* Validação de entrada;
* Entity Framework Core;
* Migrations;
* SQL Server;
* Enums;
* Operações CRUD;
* Códigos HTTP;
* Documentação com Swagger;
* Versionamento com Git.

---

## Autor

Desenvolvido por **Enrico Barni Venturato**.

* GitHub: [enricobarni](https://github.com/enricobarni)
* LinkedIn: [Enrico Barni Venturato](https://www.linkedin.com/in/enrico-barni-venturato/)

---

Este projeto faz parte da minha jornada de aprendizado em desenvolvimento backend, APIs REST, arquitetura de software e ecossistema .NET.
