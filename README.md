# 🚀 Mottu Web API - Projeto ASP.NET Core + Oracle

Este projeto consiste na construção de uma **API RESTful** para gerenciamento de dados de uma aplicação corporativa, utilizando as tecnologias **ASP.NET Core**, **Entity Framework Core** e **banco de dados Oracle**.

---

## 📑 Descrição do Projeto

A aplicação foi desenvolvida com os seguintes objetivos:

- Implementar um CRUD completo com mais de 3 rotas GET parametrizadas
- Retornar os códigos HTTP adequados para cada operação
- Usar o **EF Core com migrations** para geração das tabelas Oracle
- Criar uma API organizada, documentada e testável
- Documentação gerada com **Swagger**

---

## 📌 Principais Entidades

- Cliente
- Logradouro
- Bairro
- Cidade
- Estado
- País
- Filial
- Departamento
- FilialDepartamento
- Funcionario
- Modelo
- Moto
- Manutencao

---

## 🧪 Rotas da API

### 📁 Cliente
| Método | Rota                         | Descrição                              |
|--------|------------------------------|----------------------------------------|
| GET    | /api/cliente                 | Lista todos os clientes                |
| GET    | /api/cliente/{id}           | Busca cliente por ID                   |
| GET    | /api/cliente/nome/{nome}    | Busca cliente por nome (PathParam)     |
| GET    | /api/cliente/cpf/{cpf}      | Busca cliente por CPF (PathParam)      |
| GET    | /api/cliente/email/{email}  | Busca cliente por e-mail (PathParam)   |
| POST   | /api/cliente                | Cria novo cliente                      |
| PUT    | /api/cliente/{id}           | Atualiza cliente                       |
| DELETE | /api/cliente/{id}           | Remove cliente                         |

### 📁 Exemplo de outras rotas

- `/api/bairro`, `/api/cidade`, `/api/estado`, `/api/pais`
- `/api/funcionario`, `/api/modelo`, `/api/moto`, `/api/manutencao`

Todas com CRUD completo (`GET`, `POST`, `PUT`, `DELETE`).

---

## ⚙️ Instalação e Execução

### 🧾 Pré-requisitos

- Oracle Database XE instalado e rodando
- Visual Studio 2022 com .NET 7 ou superior
- Oracle.ManagedDataAccess e Oracle.EntityFrameworkCore instalados
- Git instalado

---

### Configurar appsettings.json

"ConnectionStrings": {
  "OracleConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=[servidor]:[porta]/[serviço];"
}
	-> "SEU_USUARIO" : Adicione o seu usuário do banco de dados da Oracle
	-> "SUA_SENHA" : Adicione a sua senha do banco de dados da Oracle
	-> "[servidor]:[porta]/[serviço]" -> Adicione essas informações conforme as informações do seu banco

---

### Aplicar Migrations

	Abra o Package Manager Console e execute:
	> Add-Migration Inicial
	> Update-Database

---

### Como executar o projeto?

	-> No Visual Studio, selecione MottuWebApplication como projeto de inicialização
	-> Pressione F5 para iniciar
	-> Acesse o Swagger: https://localhost:xxxx/swagger

---
 
## 👨‍💻 Integrantes do Grupo

| Nome                                      | RM       | Turma  |
|-------------------------------------------|----------|--------|
| Eduarda Tiemi Akamini Machado             | 554756   | 2TDSPH |
| Felipe Pizzinato Bigatto                  | 555141   | 2TDSPH |
| Gustavo de Oliveira Turci Sandrini        | 557505   | 2TDSPW |
