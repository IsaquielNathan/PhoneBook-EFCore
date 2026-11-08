# PhoneBook-EFCore
App de console C# para gerenciamento de contatos. Implementa operações CRUD com Entity Framework Core (Code-First), validação de dados e data seeding.

Instalação e configuração das bibliotecas

Acesse o terminal integrado do VS Code (Ctrl + Shift + ') e execute os comandos abaixo dentro da pasta que contém o arquivo .csproj.

1. Instalação do Spectre.Console
dotnet add package Spectre.Console


Biblioteca utilizada para criar menus interativos, tabelas, textos coloridos e interfaces estilizadas no terminal.

2. Instalação do Entity Framework Core 10 com SQLite
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

dotnet add package Microsoft.EntityFrameworkCore.Design

3. Instalação da ferramenta CLI do Entity Framework
dotnet tool install --global dotnet-ef --version 10.*


Verificar a versão instalada:

dotnet ef --version

4. Compilação do projeto
dotnet build

5. Criação e aplicação das migrations

Criar a migration inicial:

dotnet ef migrations add InitialCreate


Aplicar a migration e criar/atualizar o banco SQLite:

dotnet ef database update

Execute os comandos na pasta que contém o arquivo .csproj.

Download DB Browser for SQL lite 