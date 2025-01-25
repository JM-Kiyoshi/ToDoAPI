# ToDoList

Este projeto é uma API Rest de gerenciamento de tarefas e listas de tarefas, além de um CRUD( Criar, Ler, Atualizar e Deletar) para usuários com login autenticado via JWT. Feito a partir do desafio do Núcleo de Desenvolvimento de Software do IFCE Maracanaú.

## Funcionalidades

- CRUD - Assignments (Tarefas).
- CRUD - AssignmentLists (Lista de tarefas).
- CRUD - User (Usuarios).
- Login via E-mail e senha.
- Criação de lista via token do usuário.
- Hash de senha via Argon2

## Tecnologias usadas:
- C#
- .NET 8
- Entity Framework Core 8.0.2
- MySQL
- AutoMapper
- FluentValidation
- ScottBrady91.AspNetCore.Identity.Argon2PasswordHasher

## Como instalar e utilizar

1. Clone o repositório:

```bash
git clone https://github.com/JM-Kiyoshi/ToDoAPI.git
cd ToDoList
```
2. Restaure as dependências:
```bash
dotnet restore
```

3. Configure o banco de dados MySQL de acordo com o seu banco, usuário e senha no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=todolist;User=root;Password=yourpassword;"
}
```
4. Aplique as migrações para criar o banco de dados:

```bash
dotnet ef database update
```

5. Execute a API:

```bash
cd ToDoList.API
dotnet run
```
