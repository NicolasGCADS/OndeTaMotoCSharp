# 🏍️ OndeTáMoto - API REST em .NET

Este projeto é uma Web API desenvolvida em **ASP.NET Core**, que permite o controle de motos registradas em uma garagem, com operações básicas de CRUD (Create, Read, Update, Delete). A aplicação segue uma arquitetura em camadas, com separação de responsabilidades entre **Model**, **Business**, **Data** e **API**.

---

## 🏍️ Nome do Projeto:  OndeTáMoto?

O projeto OndeTáMoto? nasceu a partir de uma demanda real da Mottu, uma empresa inovadora que atua no ramo de soluções para motofrete. Eles enfrentavam um desafio prático: como organizar de maneira eficiente e em tempo real o controle das motos dentro da garagem da empresa?

A Mottu precisava de uma solução que fosse além das tradicionais planilhas e anotações manuais — algo que trouxesse mais visibilidade, agilidade e precisão no acompanhamento das motos que entram, saem e permanecem no espaço físico da garagem.

Foi com esse desafio em mãos que desenvolvemos o OndeTáMoto?, uma solução tecnológica baseada em IoT (Internet das Coisas), pensada para oferecer controle automatizado, informação em tempo real e usabilidade prática para o dia a dia da operação.

A dinâmica do sistema é simples, porém poderosa: cada moto da frota é equipada com uma tag inteligente, que funciona como um identificador exclusivo. Assim, toda movimentação é registrada instantaneamente, sem necessidade de intervenção manual.

Esses dados são enviados para um aplicativo mobile, que centraliza todas as informações em uma interface amigável. A equipe da Mottu pode, com poucos toques na tela, visualizar o status de cada moto, saber onde ela está estacionada, identificar quais estão dentro ou fora da garagem e até categorizá-las conforme sua finalidade ou situação atual.

O resultado é um sistema que promove mais organização, eficiência e segurança, além de reduzir erros humanos e retrabalhos. Com o OndeTáMoto?, a Mottu ganha uma solução sob medida para sua operação, com a tecnologia sendo utilizada de forma prática e inteligente para resolver um problema real.

Mais do que um controle de motos, entregamos uma nova forma de gerir a frota com simplicidade, precisão e inovação.

---

## 🏗️ Justificativa da Arquitetura

O projeto segue uma arquitetura em camadas para garantir:

Separação de responsabilidades:

Model → Representa as entidades e regras de negócio.

Business → Contém a lógica de negócio e validações.

Data → Responsável pelo acesso ao banco de dados via Entity Framework Core.

API → Exposição dos endpoints REST para consumo por clientes, aplicativos ou Swagger.

Manutenibilidade e escalabilidade: Cada camada pode ser alterada sem impactar diretamente as outras, facilitando atualizações e expansões futuras.

Facilidade de testes: A lógica de negócio está isolada da camada de apresentação, permitindo testes unitários consistentes.

Integração com IoT: O sistema foi planejado para receber dados em tempo real de tags inteligentes associadas às motos, permitindo controle automatizado e rastreabilidade precisa.


---

## 🔗 Rotas
🔹 MotoController

Método	Endpoint	Descrição

GET	/api/moto	Lista todas as motos

GET	/api/moto/{id}	Retorna moto por ID

POST	/api/moto	Cria uma nova moto

PUT	/api/moto/{id}	Atualiza uma moto

DELETE	/api/moto/{id}	Remove uma moto

🔹 UsuarioController

Método	Endpoint	Descrição

GET	/api/usuario	Lista todos os usuários

GET	/api/usuario/{id}	Retorna usuário por ID

POST	/api/usuario	Cria um novo usuário

PUT	/api/usuario/{id}	Atualiza um usuário

DELETE	/api/usuario/{id}	Remove um usuário

🔹 EstabelecimentoController

Método Endpoint Descrição 
GET /api/estabelecimento Lista todos os estabelecimentos 

GET /api/estabelecimento/{id} Retorna um estabelecimento por ID 

POST /api/estabelecimento Cria um novo estabelecimento 

PUT /api/estabelecimento/{id} Atualiza um estabelecimento 

DELETE /api/estabelecimento/{id} Remove um estabelecimento

🔹 SetorController

Método Endpoint Descrição 

GET /api/setor Lista todos os setores 

GET /api/setor/{id} Retorna um setor por ID 

POST /api/setor Cria um novo setor 

PUT /api/setor/{id} Atualiza um setor 

DELETE /api/setor/{id} Remove um setor

---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)
- Visual Studio 2022+
- REST Client (ou Postman)
- Dockerfile
---

## Como Rodar 

1. Git clone https://github.com/NicolasGCADS/OndeTaMotoProject.git
2. Selecione a pasta OndeTaMoto e selecione OndeTaMoto.sln para compilar o projeto completo
3. Ao rodar o Crud, rode com HTTPS 
4. Ao rodar o Crud com Swagger, rode com esse link http://localhost:5294/swagger/index.html

---
## Deploy do Swagger

http://191.235.235.207:5294/swagger/index.html

---

## 🔧 Configuração do Banco de Dados

1. No arquivo `appsettings.json` da pasta `OndeTaMotoApi`, configure sua string de conexão:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=OndeTaMotoDb;Trusted_Connection=True;TrustServerCertificate=True"
}

---
## Exemplos para rodar

```json

🏍️ Moto

Listar todas as motos

GET /api/Moto
Accept: application/json


Criar uma nova moto

POST /api/Moto
Content-Type: application/json

{
  "id": 1,
  "nome": "mottu",
  "tag": "alomottu2",
  "placa": "1236784"
}


Obter moto por ID

GET /api/Moto/1
Accept: application/json


Atualizar moto por ID

PUT /api/Moto/1
Content-Type: application/json

{
  "id": 1,
  "nome": "Honda atualizado",
  "tag": "aloHonda123",
  "placa": 1234567
}


Remover moto por ID

DELETE /api/Moto/1
Accept: application/json

👤 Usuário

Listar todos os usuários

GET /api/Usuario
Accept: application/json


Criar um novo usuário

POST /api/Usuario
Content-Type: application/json

{
  "id": 1,
  "email": "usuario@email.com",
  "senha": "123456"
}


Obter usuário por ID

GET /api/Usuario/1
Accept: application/json


Atualizar usuário por ID

PUT /api/Usuario/1
Content-Type: application/json

{
  "id": 1,
  "email": "usuario@atualizado.com",
  "senha": "novaSenha123"
}


Remover usuário por ID

DELETE /api/Usuario/1
Accept: application/json

🏢 Setor

Listar todos os setores

GET /api/Setor
Accept: application/json


Criar um novo setor

POST /api/Setor
Content-Type: application/json

{
  "id": 1,
  "nome": "Setor 2",
  "tamanho": 2000
}


Obter setor por ID

GET /api/Setor/1
Accept: application/json


Atualizar setor por ID

PUT /api/Setor/1
Content-Type: application/json

{
  "id": 1,
  "nome": "Setor Atualizado",
  "tamanho": 2500
}


Remover setor por ID

DELETE /api/Setor/1
Accept: application/json

🏢 Estabelecimento

Listar todos os estabelecimentos

GET /api/Estabelecimento
Accept: application/json


Criar um novo estabelecimento

POST /api/Estabelecimento
Content-Type: application/json

{
  "id": 1,
  "nome": "Estabelecimento2",
  "tamanho": 100
}


Obter estabelecimento por ID

GET /api/Estabelecimento/1
Accept: application/json


Atualizar estabelecimento por ID

PUT /api/Estabelecimento/1
Content-Type: application/json

{
  "id": 1,
  "nome": "Estabelecimento Atualizado",
  "tamanho": 120
}


Remover estabelecimento por ID

DELETE /api/Estabelecimento/1
Accept: application/json

```
--- 

# OndeTaMoto - Instruções rápidas

- Executar API:
  - dotnet restore
  - dotnet build
  - dotnet run --project OndeTaMotoApi

- Health checks:
  - Liveness: GET https://{host}/health
  - Readiness: GET https://{host}/health/ready

- Versionamento:
  - Endpoints expostos em `/api/v1/...` (controle de versão básico por rota).

- Autenticação:
  - JWT configurado; configure seção `Jwt` em `appsettings.json`.

- Testes:
  - Ainda não existem testes xUnit completos no repositório.
  - Para que eu implemente testes (xUnit) e endpoint ML.NET, autorize a adição de pacotes NuGet (`Microsoft.ML`, `xunit`, `Microsoft.AspNetCore.Mvc.Testing`, etc.).

  

## 🧑‍💻 Integrantes do Grupo

Guilherme Romanholi Santos - RM557462

Murilo Capristo - RM556794

Nicolas Guinante Cavalcanti - RM557844





