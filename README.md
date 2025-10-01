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

---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)
- Visual Studio 2022+
- REST Client (ou Postman)

---

## Como Rodar 

1. Git clone https://github.com/NicolasGCADS/OndeTaMotoProject.git
2. Selecione a pasta OndeTaMoto e selecione OndeTaMoto.sln para compilar o projeto completo
3. Ao rodar o Crud, rode com HTTPS 
4. Ao rodar o Crud com Swagger, rode com esse link http://localhost:5294/swagger/index.html

---

## 🔧 Configuração do Banco de Dados

1. No arquivo `appsettings.json` da pasta `OndeTaMotoApi`, configure sua string de conexão:

json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=OndeTaMotoDb;Trusted_Connection=True;TrustServerCertificate=True"
}

--- 

## 🧑‍💻 Integrantes do Grupo

Guilherme Romanholi Santos - RM557462

Murilo Capristo - RM556794

Nicolas Guinante Cavalcanti - RM557844





