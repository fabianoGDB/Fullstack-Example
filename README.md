# 💰 Aplicação Financeira em .NET

## 📌 Sobre o Projeto

Uma aplicação robusta desenvolvida em **.NET** para gerenciar transações financeiras, integração com pagamentos, autenticação de usuários e visualização de dados. O objetivo é oferecer uma solução segura e eficiente para o controle financeiro empresarial.

## 🏗 Estrutura do Projeto

O projeto segue boas práticas de organização e desenvolvimento, garantindo escalabilidade e manutenção facilitada.

## 📖 Tecnologias Utilizadas

- 🟣 **.NET 8**
- 💾 **Entity Framework Core**
- 🛡 **ASP.NET Identity**
- 🔗 **Minimal APIs**
- 🎨 **Blazor** (para interface interativa)
- 💳 **Stripe API** (para integrações de pagamento)
- 📊 **Power BI** (para gráficos e relatórios)
- 📦 **MySQL** (banco de dados relacional)
- 📄 **CSV Import/Export** (manipulação de dados)

## 📚 Módulos da Aplicação

### 📌 Apresentação do Curso

Introdução ao projeto e sua estrutura.

### 🏗 Estruturando o Projeto

Configuração inicial do projeto, dependências e arquitetura.

### ⚡ Fundamentos dos Minimal APIs

Introdução ao uso das **Minimal APIs** no **.NET 8**.

### 📜 Documentação da API

Uso do **Swagger** para documentar os endpoints da API.

### 🛠 Entity Framework

Configuração do **EF Core**, migrations e mapeamento de entidades.

### 🎯 Padronização

Boas práticas para garantir código limpo e sustentável.

### 🎭 Handlers

Uso de **Handlers** para separação de responsabilidades e melhoria na organização do código.

### 🔄 Endpoints

Criação e consumo de **endpoints** utilizando Minimal APIs.

### 🔄 API de Transações

Módulo responsável pelo controle de transações financeiras.

### 🔑 ASP.NET Identity

Autenticação e autorização de usuários na aplicação.

### 🏗 Organizando o Minimal API

Estratégias para estruturar melhor as **Minimal APIs**.

### 🎨 Layouts e Temas

Configuração visual do sistema utilizando **Blazor** e estilos personalizados.

### 🔐 Identity no Blazor

Integração do **ASP.NET Identity** com **Blazor** para segurança do usuário.

### 📝 CRUD

Operações básicas de **Create, Read, Update, Delete** para manipulação de dados.

### 📊 Gráficos

Geração de relatórios interativos com **Power BI**.

### 🛍 Área de Pedidos - Backend

Gerenciamento de pedidos e fluxo financeiro no backend.

### 🖥 Área de Pedidos - Frontend

Interface para controle e visualização dos pedidos.

### 💳 Integração com Stripe (NOVO)

Implementação de pagamentos online via **Stripe API**.

## 🚀 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-repo/financeiro-dotnet.git
   ```
2. Navegue até a pasta do projeto:
   ```bash
   cd financeiro-dotnet
   ```
3. Rode o docker

```
docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server

docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1435:1433 -d mcr.microsoft.com/mssql/server

```

4. Instale as dependências:
   ```bash
   dotnet restore
   ```
5. Execute as migrations do banco de dados:

   ```bash
   dotnet ef database update
   ```

6. Inicie a aplicação:
   ```bash
   dotnet run
   ```

## 📌 Contribuições

Contribuições são bem-vindas! Siga os passos abaixo para colaborar:

1. Faça um **fork** do repositório.
2. Crie uma **branch** para sua feature:
   ```bash
   git checkout -b minha-feature
   ```
3. Commit suas mudanças:
   ```bash
   git commit -m "Minha nova feature"
   ```
4. Faça um **push** para sua branch:
   ```bash
   git push origin minha-feature
   ```
5. Abra um **Pull Request** no GitHub.

---

🚀 Desenvolvido com ❤️ por Fabiano
