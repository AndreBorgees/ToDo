📝 ToDoAPI

Projeto .NET para gerenciamento de tarefas, categorias e relacionamentos entre eles, seguindo boas práticas de DDD, Clean Architecture e Clean Code. Utiliza SQLite como banco de dados e GitHub Actions com runner self-hosted para CI/CD.

---

🎯 Objetivo

Criar uma API limpa e escalável para gerenciamento de tarefas e categorias

Validar boas práticas de Clean Code e DDD

Automatizar build e deploy usando GitHub Actions com runner self-hosted

Fornecer um building block reutilizável para serviços e entidades base

---

🛠 Tecnologias utilizadas

- ASP.NET Core
- C# 12
- SQLite
- GitHub Actions (runner self-hosted)
- Domain-Driven Design (DDD)
- Clean Architecture
- Clean Code

---

📦 Estrutura do projeto

```groovy
src/
├── BuildingBlock/
│   ├── Core/
│   │   ├── Data/
│   │   ├── DomainObjects/
│   │   ├── Mediator/
│   │   └── Messages/
│   └── Core.csproj
├── Services/
│   ├── WebAPI.Core/
│   │   └── Controllers/
│   │       └── BaseController.cs
│   ├── ToDo/
│   │   ├── ToDo.API/
│   │   ├── ToDo.Application/
│   │   │   ├── Commands/
│   │   │   │   ├── Categorias/
│   │   │   │   ├── Tarefas/
│   │   │   │   └── TarefasCategorias/
│   │   │   ├── DTOs/
│   │   │   │   ├── CategoriaDTO.cs
│   │   │   │   └── TarefaDTO.cs
│   │   │   └── Queries/
│   │   │       ├── Categorias/
│   │   │       │   ├── CategoriaQueries.cs
│   │   │       │   └── ICategoriaQueries.cs
│   │   │       ├── Tarefas/
│   │   │       └── TarefasCategorias/
│   │   ├── ToDo.Domain/
│   │   │   ├── Entities/
│   │   │   │   ├── Categorias/
│   │   │   │   │   ├── Categoria.cs
│   │   │   │   │   └── ICategoriaRepository.cs
│   │   │   │   └── Tarefas/
│   │   │   │       ├── Tarefa.cs
│   │   │   │       └── ITarefaRepository.cs
│   │   │   └── Enums/
│   │   └── ToDo.Infrastructure/
│   │       ├── Data/
│   │       │   ├── Context/
│   │       │   │   └── DataContext.cs
│   │       │   ├── Mappings/
│   │       │   └── Repositories/
│   │       └── Migrations/
│   │           ├── 20250905215653_Inicial.cs
│   │           └── DataContextModelSnapshot.cs
└── Web/
```

---

⚙️ GitHub Actions CI/CD

O projeto possui um runner self-hosted configurado para:
- Checkout do código
- Build da solução
- Testes unitários
- Publicação e deploy local (simulando produção)

Exemplo de workflow (simplificado):

```groovy
name: ToDo API CI/CD

on:
  push:
    branches:
      - main

jobs:
  build-and-deploy:
    runs-on: self-hosted
    steps:
      - name: Checkout code
        uses: actions/checkout@v3

      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '7.0.x'

      - name: Build
        run: dotnet build src/Services/ToDo/ToDo.sln --configuration Release

      - name: Test
        run: dotnet test src/Services/ToDo/ToDo.sln

      - name: Publish
        run: dotnet publish src/Services/ToDo/ToDo.API/ToDo.API.csproj -c Release -o ./publish
```
O deploy real pode ser feito copiando a pasta publish para o servidor ou usando algum script adicional.

---

🚀 Como usar

✅ Pré-requisitos
- .NET SDK 7.0+
- SQLite
- GitHub Actions runner self-hosted

📦 Passo a passo

1. Clonar o projeto

```groovy
git clone https://github.com/AndreBorgees/ToDo.git
```

2. Rodar a API localmente

```groovy
cd src/Services/ToDo/ToDo.API
dotnet run
```

3. A API estará disponível em http://localhost:5000 por padrão.

4. Build e deploy automático serão executados sempre que houver push na branch main.
