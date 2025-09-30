# MottuWebApplication

Este projeto segue uma arquitetura inspirada em Clean Architecture com as camadas:

- API (Presentation) — `MottuWebApplication`
- Application — `MottuWebApplication.Application`
- Domain — `MottuWebApplication.Domain`
- Infrastructure — `MottuWebApplication.Infrastructure`

Principais padrões aplicados:

- Repository Pattern (genérico com EF Core)
- Service Layer (serviços específicos de domínio e CRUD genérico)
- Dependency Injection (extensões `AddInfrastructure` e `AddApplication`)
- Swagger com comentários XML

Para executar a API, inicie o projeto `MottuWebApplication` e acesse `/swagger` para a documentação.
<h1 align="center">🏍️ Mottu Web API - Projeto ASP.NET Core + Oracle</h1>

<p align="center">
  <strong>Desenvolvido para o Challenge 2025 - 1º Semestre | Disciplina: ADVANCED BUSINESS DEVELOPMENT WITH .NET</strong><br>
  <em>FIAP - 2º Ano - Análise e Desenvolvimento de Sistemas</em>
</p>

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

## 🧭 Justificativa do Domínio

O domínio escolhido representa um cenário corporativo de gestão de frotas e operações, no qual:

- Clientes realizam cadastros e se relacionam com endereços (logradouro/bairro/cidade/estado/país).
- A empresa opera com filiais e departamentos (estrutura organizacional), relacionando-os por meio de `FilialDepartamento`.
- A frota é composta por `Moto` e seus respectivos `Modelo`s; cada moto está vinculada a uma estrutura de `FilialDepartamento`.
- `Manutencao` registra entradas e saídas de serviços, garantindo disponibilidade e segurança dos veículos.

Essa modelagem reflete um problema de negócio real que exige operações CRUD claras, validações simples e consultas filtradas—
um encaixe ideal para demonstrar boas práticas REST com ASP.NET Core + EF Core + Oracle.

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

### 📁 Cidade
| Método | Rota                   | Descrição              |
| ------ | ---------------------- | ---------------------- |
| GET    | /api/cidade            | Lista todas as cidades |
| GET    | /api/cidade/{idCidade} | Busca cidade por ID    |
| POST   | /api/cidade            | Cria nova cidade       |
| PUT    | /api/cidade/{idCidade} | Atualiza cidade        |
| DELETE | /api/cidade/{idCidade} | Remove cidade          |

### 📁Bairro
| Método | Rota                   | Descrição              |
| ------ | ---------------------- | ---------------------- |
| GET    | /api/bairro            | Lista todos os bairros |
| GET    | /api/bairro/{idBairro} | Busca bairro por ID    |
| POST   | /api/bairro            | Cria novo bairro       |
| PUT    | /api/bairro/{idBairro} | Atualiza bairro        |
| DELETE | /api/bairro/{idBairro} | Remove bairro          |

### 📁 Departamento
| Método HTTP | Rota                                 | Descrição                                  |
| ----------- | ------------------------------------ | ------------------------------------------ |
| `GET`       | `/api/Departamento`                  | Lista todos os departamentos               |
| `GET`       | `/api/Departamento/{idDepartamento}` | Retorna um departamento específico pelo ID |
| `POST`      | `/api/Departamento`                  | Cria um novo departamento                  |
| `PUT`       | `/api/Departamento/{idDepartamento}` | Atualiza um departamento existente         |
| `DELETE`    | `/api/Departamento/{idDepartamento}` | Deleta um departamento pelo ID             |

### 📁 Estado
| Método HTTP | Rota                     | Descrição                            |
| ----------- | ------------------------ | ------------------------------------ |
| `GET`       | `/api/Estado`            | Lista todos os estados               |
| `GET`       | `/api/Estado/{idEstado}` | Retorna um estado específico pelo ID |
| `POST`      | `/api/Estado`            | Cria um novo estado                  |
| `PUT`       | `/api/Estado/{idEstado}` | Atualiza um estado existente         |
| `DELETE`    | `/api/Estado/{idEstado}` | Deleta um estado pelo ID             |


### 📁 Filial
| Método HTTP | Rota                      | Descrição                                           |
| ----------- | ------------------------- | --------------------------------------------------- |
| `GET`       | `/api/Filial`             | Lista todas as filiais                              |
| `GET`       | `/api/Filial/{idFilial}`  | Retorna uma filial específica pelo ID               |
| `GET`       | `/api/Filial/nome/{nome}` | Busca filiais que contenham parte do nome informado |
| `POST`      | `/api/Filial`             | Cria uma nova filial                                |
| `PUT`       | `/api/Filial/{idFilial}`  | Atualiza uma filial existente                       |
| `DELETE`    | `/api/Filial/{idFilial}`  | Deleta uma filial pelo ID                           |

### 📁 FilialDepartamento
| Método HTTP | Rota                                             | Descrição                                         |
| ----------- | ------------------------------------------------ | ------------------------------------------------- |
| `GET`       | `/api/FilialDepartamento`                        | Lista todas as relações filial-departamento       |
| `GET`       | `/api/FilialDepartamento/{idFilialDepartamento}` | Retorna uma relação específica pelo ID            |
| `POST`      | `/api/FilialDepartamento`                        | Cria uma nova relação entre filial e departamento |
| `PUT`       | `/api/FilialDepartamento/{idFilialDepartamento}` | Atualiza uma relação existente                    |
| `DELETE`    | `/api/FilialDepartamento/{idFilialDepartamento}` | Deleta uma relação pelo ID                        |

### 📁 Funcionario
| Método HTTP | Rota                               | Descrição                                  |
| ----------- | ---------------------------------- | ------------------------------------------ |
| GET         | `/api/Funcionario`                 | Lista todos os funcionários                |
| GET         | `/api/Funcionario/{idFuncionario}` | Retorna um funcionário pelo ID             |
| POST        | `/api/Funcionario`                 | Cadastra um novo funcionário               |
| PUT         | `/api/Funcionario/{idFuncionario}` | Atualiza um funcionário existente          |
| DELETE      | `/api/Funcionario/{idFuncionario}` | Remove um funcionário pelo ID              |
| GET         | `/api/Funcionario/nome/{nome}`     | Filtra funcionários por nome               |
| GET         | `/api/Funcionario/cargo/{cargo}`   | Filtra funcionários por cargo              |
| GET         | `/api/Funcionario/email/{email}`   | Filtra funcionários por e-mail corporativo |

### 📁 Logradouro
| Método HTTP | Rota                             | Descrição                        |
| ----------- | -------------------------------- | -------------------------------- |
| GET         | `/api/Logradouro`                | Lista todos os logradouros       |
| GET         | `/api/Logradouro/{idLogradouro}` | Retorna um logradouro por ID     |
| POST        | `/api/Logradouro`                | Cadastra um novo logradouro      |
| PUT         | `/api/Logradouro/{idLogradouro}` | Atualiza um logradouro existente |
| DELETE      | `/api/Logradouro/{idLogradouro}` | Remove um logradouro por ID      |

### 📁 Modelo
| Método HTTP | Rota                     | Descrição                           | Corpo da Requisição  | Retorno                                     |
| ----------- | ------------------------ | ----------------------------------- | -------------------- | ------------------------------------------- |
| GET         | `/api/Modelo`            | Retorna todos os modelos            | —                    | Lista de objetos `Modelo`                   |
| GET         | `/api/Modelo/{idModelo}` | Retorna um modelo específico por ID | —                    | Objeto `Modelo`, ou `404` se não encontrado |
| POST        | `/api/Modelo`            | Cria um novo modelo                 | Objeto `Modelo` JSON | `201 Created` com o novo modelo             |
| PUT         | `/api/Modelo/{idModelo}` | Atualiza um modelo existente        | Objeto `Modelo` JSON | `204 No Content` ou `400 Bad Request`       |
| DELETE      | `/api/Modelo/{idModelo}` | Exclui um modelo                    | —                    | `204 No Content` ou `404 Not Found`         |

### 📁 Moto
| Método HTTP | Rota da API                                           | Parâmetros                   | Descrição                                                        |
| ----------- | ----------------------------------------------------- | ---------------------------- | ---------------------------------------------------------------- |
| `GET`       | `/api/moto`                                           | —                            | Retorna todas as motos cadastradas.                              |
| `GET`       | `/api/moto/{idMoto}`                                  | `idMoto` (int)               | Retorna uma moto específica pelo ID.                             |
| `POST`      | `/api/moto`                                           | `moto` (JSON body)           | Cria uma nova moto (valida placa, status e km rodado).           |
| `PUT`       | `/api/moto/{idMoto}`                                  | `idMoto` (int), `moto` body  | Atualiza uma moto existente.                                     |
| `DELETE`    | `/api/moto/{idMoto}`                                  | `idMoto` (int)               | Remove uma moto pelo ID.                                         |
| `GET`       | `/api/moto/placa/{placa}`                             | `placa` (string)             | Retorna as motos com placa igual à informada (case-insensitive). |
| `GET`       | `/api/moto/status/{status}`                           | `status` (string)            | Retorna as motos com o status informado (case-insensitive).      |
| `GET`       | `/api/moto/filialdepartamento/{idFilialDepartamento}` | `idFilialDepartamento` (int) | Retorna as motos vinculadas a um `FilialDepartamento`.           |

### 📁 Pais
| Método HTTP | Rota                 | Descrição                         | Corpo da Requisição | Retorno                                   |
| ----------- | -------------------- | --------------------------------- | ------------------- | ----------------------------------------- |
| GET         | `/api/Pais`          | Retorna todos os países           | —                   | Lista de objetos `Pais`                   |
| GET         | `/api/Pais/{idPais}` | Retorna um país específico por ID | —                   | Objeto `Pais`, ou `404` se não encontrado |
| POST        | `/api/Pais`          | Cria um novo país                 | Objeto `Pais` JSON  | `201 Created` com o novo país             |
| PUT         | `/api/Pais/{idPais}` | Atualiza um país existente        | Objeto `Pais` JSON  | `204 No Content` ou `400 Bad Request`     |
| DELETE      | `/api/Pais/{idPais}` | Exclui um país                    | —                   | `204 No Content` ou `404 Not Found`       |

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
