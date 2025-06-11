# AutoManager API 🚗

**AutoManager API** é uma aplicação back-end desenvolvida com **ASP.NET Core Web API (Minimal API)** para gerenciamento de veículos. Essa API RESTful permite o cadastro, listagem, consulta, edição e remoção de veículos.

## 🖼️ Demonstração
![tela-api](https://github.com/user-attachments/assets/5639e47d-dcbd-4639-af4d-3a8dd6e1fb2a)

## 🌐 Endpoints

A API conta com as seguintes rotas:

| Método   | Rota                          | Descrição                          |
|----------|-------------------------------|------------------------------------|
| `GET`    | `/api/v1/vehicles`            | Lista todos os veículos            |
| `GET`    | `/api/v1/vehicles/{id}`       | Retorna um veículo por **ID**      |
| `GET`    | `/api/v1/vehicles/by-plate/{plate}`| Retorna um veículo por **placa**   |
| `POST`   | `/api/v1/vehicles`                   | Cadastra um novo veículo           |
| `PUT`    | `/api/v1/vehicles/{id}`              | Edita um veículo existente         |
| `DELETE` | `/api/v1/vehicles/{id}`              | Deleta um veículo                  |

## 🛠️ Tecnologias

- [.NET 9](https://dotnet.microsoft.com/)
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core/web-api/)
- [Minimal APIs](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)

## 📦 Instalação e Execução

```bash
git clone https://github.com/seu-usuario/AutoManager.API.git
cd AutoManager.API

dotnet restore
dotnet run
