# Prova Prática de Desenvolvimento API e Cliente - DBM

## Objetivo
O projeto consiste em dois sistemas integrados:
1. Uma API em C# (ASP.NET Core Web API) para importar e disponibilizar dados de um arquivo CSV em um banco de dados SQL Server.
2. Um cliente em Python para consumir essa API, processar os dados e exibi-los de forma categorizada.

## Tecnologias Utilizadas
- **Backend:** C# com ASP.NET Core Web API
- **Banco de Dados:** SQL Server
- **Cliente:** Python com requisições HTTP

## Funcionalidades
### API em C#
1. **Importação de CSV**: Um endpoint permite o envio de um arquivo CSV contendo os dados para armazenamento no SQL Server.
2. **Consulta por ID**: Um endpoint retorna os dados de um registro específico em formato JSON.
3. **Migrações e Configurações**: O projeto inclui as migrações necessárias para criar as tabelas no SQL Server.

### Cliente em Python
1. **Consumo da API**: O cliente realiza requisições HTTP para buscar dados da API.
2. **Categorização de Idade**:
   - **Jovem:** Menos de 30 anos
   - **Adulto:** Entre 30 e 40 anos
   - **Sênior:** Acima de 40 anos
3. **Exibição Organizada**: Os dados são formatados e apresentados de forma clara ao usuário.

## Estrutura do Projeto
```
TESTE-DBM/
├── api-csharp/         # Projeto em C# (ASP.NET Core Web API)
│   ├── Controllers/    # Controladores da API
│   ├── Models/         # Modelos de dados
│   ├── Services/       # Lógica de negócio
│   ├── Data/           # Contexto e migrações do banco
│   ├── Program.cs      # Configuração da API
│   ├── appsettings.json # Configuração do banco de dados
└── cliente-python/     # Projeto em Python
    ├── cliente.py      # Script principal para consumo da API
```

## Como Executar

### 1. Configurar o SQL Server
- Certifique-se de que o SQL Server está instalado e em execução.
- Atualize as configurações de conexão no `appsettings.json`.
- Rode as migrações:
  ```sh
   cd api-csharp
     dotnet ef database update
  ```

### 2. Executar a API em C#
```sh
 dotnet run
```
A API ficará acessível em `http://localhost:{{port}}`.

## Endpoints da API
- **Importar CSV:** `POST /api/import`
- **Buscar por ID:** `GET /api/dados/{id}`

## Exemplo de Uso
### Enviar um CSV para a API (via Postman ou curl)
```sh
curl -X POST -F "file=@dados.csv" http://localhost:{{port}}/api/import
```

### Buscar um registro por ID
```sh
curl http://localhost:{{port}}/api/dados/1
```

### 3. Executar o Cliente em Python
```sh
cd cliente-python
python cliente.py
```

## Contribuição
Caso queira contribuir, faça um fork do repositório e abra um pull request com suas melhorias!

---
Projeto desenvolvido como parte da Prova Prática de Desenvolvimento - DBM.

