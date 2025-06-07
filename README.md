# WebLibrary

Sistema de gerenciamento de biblioteca online desenvolvido em ASP.NET Core.

## Estrutura do Projeto

- `API/Controllers/` - Controllers da API (ex: BookController, LoanController)
- `API/DTOs/` - Data Transfer Objects (ex: BookDto, LoanDto)
- `API/Repositories/` - Repositórios de acesso a dados
- `API/Services/` - Serviços de negócio
- `Entities/Interfaces/` - Interfaces das entidades e serviços
- `Entities/Models/` - Modelos das entidades de domínio

## Requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- MongoDB (ou conexão MongoDB Atlas)

## Configuração

1. Clone o repositório.
2. Configure a string de conexão do MongoDB em [`appsettings.json`](WebLibrary/appsettings.json):

   ```json
   "MongoDbSettings": {
     "ConnectionString": "<sua-connection-string>",
     "DatabaseName": "LibraryDb",
     "BooksCollection": "Books"
   }
   ```

3. Restaure os pacotes NuGet:

   ```sh
   dotnet restore
   ```

## Executando o Projeto

No diretório `WebLibrary`, execute:

```sh
dotnet run --project WebLibrary/WebLibrary.csproj
```

A API estará disponível em `https://localhost:5001` (ou porta configurada).

## Testes

Os testes unitários estão no projeto `WebLibrary.Test`. Para rodar os testes:

```sh
dotnet test WebLibrary.Test/WebLibrary.Test.csproj
```

## Principais Endpoints

- `GET /api/book` - Lista todos os livros
- `GET /api/book/{id}` - Detalhes de um livro
- `POST /api/book` - Cria um novo livro
- `PUT /api/book/{id}` - Atualiza um livro
- `DELETE /api/book/{id}` - Remove um livro
- `GET /api/book/search?query=palavra` - Busca livros por termo
- `GET /api/book/top` - Lista os livros mais populares
- `POST /books/{bookId}/loans` - Registra um empréstimo

## Swagger

A documentação interativa da API está disponível em `/swagger` quando rodando em ambiente de desenvolvimento.

---

> Projeto Referente ao Teste Técnico da Empresa UpFlux. 
> Desenvolvido por João Pedro Fachini Moreira Silva.
