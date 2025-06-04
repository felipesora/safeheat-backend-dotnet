# 🔥 SafeHeat - Backend .NET (Gestão Pública)

[![GitHub Repo](https://img.shields.io/badge/GitHub-Repository-blue)](https://github.com/felipesora/safeheat-backend-dotnet)

>API e aplicação web desenvolvidas com .NET para a **gestão pública de abrigos e recursos** durante eventos de calor extremo.

## 📝 Descrição do Projeto

**SafeHeat (.NET)** é a parte administrativa da solução, voltada à gestão de abrigos e recursos em cenários de calor intenso. Com essa aplicação, prefeituras e órgãos públicos podem:

- Cadastrar e atualizar abrigos;
- Acompanhar a capacidade de atendimento de cada local;
- Gerenciar recursos disponíveis por abrigo;
- Utilizar uma API REST para integração com sistemas externos;
- Utilizar uma interface web (Razor Pages) para controle interno.

Este projeto integra o desafio interdisciplinar "**Protech the Future**" da FIAP, buscando soluções para um mundo com eventos climáticos extremos.

---

## 🚀 Funcionalidades

- ✅ Cadastro de abrigos (nome, endereço, capacidade etc.)
- ✅ Atualização da capacidade dos abrigos
- ✅ Registro de recursos disponíveis em cada abrigo
- ✅ Interface web (Razor Pages) para operadores da gestão pública
- ✅ API REST com Swagger

---

## 👥 Integrantes

- **Felipe Ulson Sora** – RM555462 – [@felipesora](https://github.com/felipesora)
- **Augusto Lope Lyra** – RM558209 – [@lopeslyra10](https://github.com/lopeslyra10)
- **Vinicius Ribeiro Nery Costa** – RM559165 – [@ViniciusRibeiroNery](https://github.com/ViniciusRibeiroNery)

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- Oracle Database
- Razor Pages (MVC)
- API REST com boas práticas
- Swagger
- Camadas: Domain, Application, Infrastructure, Presentation

---

## 📦 Estrutura do Projeto

```bash
safeheat-backend-dotnet/
├── Domain/ # Entidades e interfaces
├── Application/ # DTOs, services
├── Infrastructure/ # Repositórios, banco, migrations
├── Presentation/ # Controllers da API e Razor Pages
├── SafeHeat.sln # Solução do projeto
└── appsettings.json # Configurações da aplicação
```

---

## 🔄 Relacionamento entre Entidades

```bash
[Abrigo]
   └──▶ (1:N) ─── [Recurso]
```

- Cada **Abrigo** pode ter vários **Recursos** associados.
- Os recursos incluem itens como "Água", "Ventiladores", "Medicamentos", etc.
- Cada abrigo tem capacidade máxima configurável.

---

## 📡 Endpoints da API (REST)

> A seguir, exemplos de endpoints REST públicos para integração externa.

### 🏠 Abrigos

- `📬 POST /api/AbrigoApi`  
  Cadastra um novo abrigo.

```jsonc
{
  "nome": "Abrigo Municipal - Zona Sul",
  "cep": "01226010",
  "rua": "Rua das Palmeiras",
  "numero": "123",
  "bairro": "Vila Buarque",
  "cidade": "São Paulo",
  "estado": "SP",
  "capacidadeTotal": 100,
  "ocupacaoAtual": 40
}
```

- `📄 GET /api/AbrigoApi`  
  Lista todos os abrigos cadastrados.

- `🔍 GET /api/AbrigoApi/{id}`  
  Lista o abrigo cadastrado com este id.

- `✏️ PUT /api/AbrigoApi/{id}`  
  Atualiza os dados do abrigo com este id.

```jsonc
{
  "nome": "Abrigo Municipal - Zona Sul",
  "cep": "01226010",
  "rua": "Rua das Palmeiras",
  "numero": "123",
  "bairro": "Vila Buarque",
  "cidade": "São Paulo",
  "estado": "SP",
  "capacidadeTotal": 100,
  "ocupacaoAtual": 70
}
```

- `🗑️ DELETE /api/AbrigoApi/{id}`  
  Remove o abrigo com este id.

---

### 🧰 Recursos

- `📬 POST /api/RecursosDisponiveisApi`  
  Cadastra um novo recurso.

```jsonc
{
  "nome": "Garrafa Água Potável - 200ml",
  "quantidade": 150,
  "abrigoId": 1
}
```

- `📄 GET /api/RecursosDisponiveisApi`  
  Lista todos os recursos cadastrados.

- `🔍 GET /api/RecursosDisponiveisApi/{id}`  
  Lista o recurso cadastrado com este id.

- `✏️ PUT /api/RecursosDisponiveisApi/{id}`  
  Atualiza os dados do recurso com este id.

```jsonc
{
  "nome": "Garrafa Água Potável - 200ml",
  "quantidade": 90,
  "abrigoId": 1
}
```

- `🗑️ DELETE /api/RecursosDisponiveisApi/{id}`  
  Remove o recurso com este id.

---

## 🖥️ Interface Web (Razor Pages)

A aplicação web oferece uma interface amigável para operadores públicos. Telas principais:

- Página Inicial com lista de abrigos
- Cadastro e edição de abrigos
- Listagem de recursos por abrigo
- Cadastro e edição de recursos

---

## 📖 Swagger - Documentação da API

A API REST pode ser acessada via navegador com Swagger UI:

```bash
https://localhost:56980/swagger/index.html
```
> Inclui todos os endpoints, parâmetros, exemplos e possibilidade de testar diretamente pela interface.

---

## 🚀 Como Executar o Projeto

### 🔧 Requisitos

- .NET 8 SDK
- Visual Studio 2022 ou superior
- Oracle Database
- Postman (para testar endpoints REST)

### 📥 1. Clonar o projeto

```bash
git clone https://github.com/felipesora/safeheat-backend-dotnet.git
```

### ⚙️ 2. Configurar Banco de Dados

No `appsettings.json`, configure a string de conexão:

```csharp
"ConnectionStrings": {
        "Oracle": "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=USUARIO;Password=SENHA;"
}
```

### 🛠️ 3. Aplicar Migrations e rodar

Via terminal ou Package Manager Console:

```bash
dotnet ef database update
```

Depois, execute o projeto:

```bash
dotnet run
```

## 🌐 4. Acessar a aplicação
- API REST: https://localhost:56980/swagger/index.html
- Razor Pages: https://localhost:56980/

---

## ✅ Pronto!
Você está com o backend .NET do SafeHeat rodando, pronto para testes e uso em produção/instituições públicas.

## 🎥 Demonstrações e Links Relacionados

### 📽️ Vídeo de Demonstração da Solução Completa
Veja o funcionamento completo da solução SafeHeat (Backend .NET):

[🔗 Assista à demonstração](https://www.youtube.com/watch?v=dxxsXDfPdro)

### 🗣️ Vídeo Pitch do Projeto

Entenda o contexto, problema, solução proposta e impacto social do SafeHeat no nosso pitch oficial:

[🔗 Assista ao Pitch](https://github.com/felipesora)

### ☕ Projeto Java (API para Aplicativo)

Backend em Java responsável por gerenciar usuários, locais monitorados e alertas de calor consumidos pelo app:

[🔗 Repositório da API Java (SafeHeat Backend Java)](https://github.com/felipesora/safeheat-backend-java)

### 📱 Projeto Mobile (React Native)

Frontend mobile desenvolvido com React Native, integrando as APIs de Java e .NET:

[🔗 Repositório do Mobile (SafeHeat App)](https://github.com/felipesora/safeheat-frontend-mobile)