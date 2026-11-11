# PhoneBook - The C# Academy

Este é um aplicativo de console desenvolvido em C# com Entity Framework Core e SQLite, criado para cumprir os requisitos do desafio de gerenciamento de contatos da **The C# Academy**. 

O foco do projeto foi a construção de uma arquitetura limpa, persistência confiável de dados relacionais e uma interface de usuário resiliente a erros no terminal.

## 🚀 Funcionalidades

* **Gerenciamento de Contatos (CRUD):** Adição, visualização, atualização e remoção de contatos.
* **Gerenciamento de Categorias (CRUD):** Organização de contatos com base em categorias pré-definidas ou customizadas.
* **Integridade de Dados:** Implementação de relacionamento 1:N entre Categorias e Contatos, utilizando `DeleteBehavior.Restrict` para evitar exclusões inconsistentes no banco de dados.
* **Interface Interativa:** Utilização da biblioteca `Spectre.Console` para a renderização de menus navegáveis, painéis e tabelas de exibição.
* **Validação de Entrada:**
  * Exigência de formato válido para e-mails (contendo `@`).
  * Validação de telefone, exigindo exatamente 11 dígitos numéricos e avisando ao usuário sobre o formato correto.
  * Bloqueio contra inserção de nomes vazios.
* **Resiliência e Tratamento de Erros: Implementação de validações de entrada para evitar dados inconsistentes, incluindo verificação de contatos duplicados, formato de e-mail, quantidade de dígitos do telefone e existência de registros antes de determinadas operações.
* **Data Seeding:** População automática do banco de dados com contatos e categorias iniciais na primeira execução.

## 🛠️ Tecnologias Utilizadas
* **C# / .NET 10**
* **Entity Framework Core 10** (Abordagem Code-First)
* **SQLite**
* **Spectre.Console**

## 🏗️ Arquitetura do Projeto

O código adota o padrão MVC (Model-View-Controller) adaptado para aplicações de console, visando a clara separação de responsabilidades:
* **Models:** Classes de domínio (`Contact` e `Category`) que mapeiam o esquema do banco de dados.
* **Controllers:** Responsáveis pela comunicação direta com o banco de dados e pelo tratamento de exceções de infraestrutura.
* **Services:** Camada intermediária encarregada de executar as regras de negócio e validar os dados de entrada do usuário antes da persistência.
* **UI (User Interface):** Componentes estritamente focados na exibição visual dos dados e captura das ações no terminal.

## 💻 Instalação e Execução

**Pré-requisitos:**
* SDK do .NET 10.
* Ferramentas CLI do EF Core instaladas globalmente (`dotnet tool install --global dotnet-ef`).
* *Opcional:* [DB Browser for SQLite](https://sqlitebrowser.org/) (para visualização gráfica das tabelas).

**Passo a passo:**

1. Clone o repositório e acesse a pasta do projeto:
   `git clone https://github.com/IsaquielNathan/PhoneBook-EFCore.git`
   `cd PhoneBook-EFCore/PhoneBook`

2. Restaure as dependências do .NET:
   `dotnet restore`

3. Crie e atualize o banco de dados (o Data Seeding será aplicado automaticamente):
   `dotnet ef database update`

4. Execute a aplicação:
   `dotnet run`

## 🔍 Visualização do Banco de Dados

Para consultar os registros gerados diretamente no banco de dados:
1. Abra o aplicativo DB Browser for SQLite.
2. Selecione a opção "Abrir Banco de Dados".
3. Navegue até a pasta raiz do projeto e abra o arquivo `contact.db`.
4. Utilize a aba "Navegar Dados" para visualizar os dados inseridos nas tabelas `Contacts` e `Categories`.

## 🧠 Reflexão de Desenvolvimento

* Foi uma experiência muito boa desenvolvendo uma aplicação com esse nível de exigência, e por mais que haja simplicidade em tudo que a envolve. Sendo um app CRUD foi gratificante conseguir entregar algo que execute todos os requisitos pedidos. Trabalhar com o Entity Framework Core como camada de dados me permitiu entender na prática como funciona a persistência relacional e a abordagem Code-First, especialmente ao lidar com o relacionamento entre categorias e contatos. Além disso, estruturar a aplicação em camadas (MVC) e utilizar a biblioteca Spectre.Console para blindar as entradas do usuário expandiu bastante minha visão sobre como construir aplicações de terminal mais limpas, organizadas e resilientes a erros.*