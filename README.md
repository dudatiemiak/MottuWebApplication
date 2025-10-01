<h1 align="center">🏍️ Mottu Web API – ASP.NET Core + Oracle</h1>

<p align="center">
	<strong>Challenge 2025 – 1º Semestre | ADVANCED BUSINESS DEVELOPMENT WITH .NET</strong><br>
	<em>FIAP – 2º Ano – Análise e Desenvolvimento de Sistemas</em>
</p>

---

## 👨‍👩‍👧 Integrantes

- Eduarda Tiemi Akamini Machado – RM 554756 – 2TDSPH
- Felipe Pizzinato Bigatto – RM 555141 – 2TDSPH
- Gustavo de Oliveira Turci Sandrini – RM 557505 – 2TDSPW

---

## 🧱 Justificativa da Arquitetura

O projeto adota Clean Architecture com camadas isoladas e responsabilidades claras:

- API (Presentation): Controllers REST padronizadas (rotas nomeadas, CreatedAtRoute, retornos HTTP adequados) e Swagger com comentários XML.
- Application: Serviços de domínio específicos por entidade (ex.: IClienteService, IMotoService, IEstadoService etc.).
- Domain: Entidades e validações via data annotations.
- Infrastructure: EF Core + Oracle, DbContext e repositórios específicos por entidade.

Motivações:

- Separação de responsabilidades e testabilidade das regras de negócio.
- Facilidade de manutenção e evolução (cada entidade possui seu serviço e repositório próprios).
- Aderência a boas práticas REST e documentação via Swagger.

---

## 🚀 Como executar a API

Pré-requisitos:

- .NET 9 SDK instalado
- Oracle Database acessível (credenciais no appsettings)

Configurar conexão (arquivo `MottuWebApplication/appsettings.json`):

```
{
	"ConnectionStrings": {
		"OracleConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=//host:porta/SERVICO"
	}
}
```

Executar (PowerShell):

```powershell
dotnet build .\MottuWebApplication.sln -c Debug
dotnet run --project .\MottuWebApplication\MottuWebApplication.csproj --launch-profile http
```

Swagger:

- URL: http://localhost:5233/swagger

---

## 📚 Exemplos de uso dos endpoints

Alguns exemplos práticos (corpos em JSON). Consulte o Swagger para o catálogo completo.

1) Clientes

- GET todos: GET /api/Cliente
- GET por ID: GET /api/Cliente/1
- POST criar:

```json
{
	"nmCliente": "João Silva",
	"nrCpf": "123.456.789-00",
	"nmEmail": "joao@empresa.com",
	"idLogradouro": 10
}
```

- PUT atualizar: PUT /api/Cliente/1

```json
{
	"idCliente": 1,
	"nmCliente": "João da Silva",
	"nrCpf": "123.456.789-00",
	"nmEmail": "joao.silva@empresa.com",
	"idLogradouro": 10
}
```
Respostas: 204 No Content | 400 Bad Request (id divergente) | 404 Not Found

2) Estados

- GET todos: GET /api/Estado
- GET por ID: GET /api/Estado/1
- POST criar:

```json
{
	"nmEstado": "São Paulo"
}
```

- PUT atualizar: PUT /api/Estado/5

```json
{
	"idEstado": 5,
	"nmEstado": "Minas Gerais",
	"idPais": 1
}
```
Respostas: 204 No Content | 400 Bad Request (id divergente) | 404 Not Found

3) Motos

- GET todos: GET /api/Moto
- GET por ID: GET /api/Moto/1
- POST criar:

```json
{
	"nmPlaca": "ABC1D23",
	"stMoto": "Ativa",
	"kmRodado": 1200.5,
	"idCliente": 1,
	"idModelo": 2,
	"idFilialDepartamento": 3
}
```

- PUT atualizar: PUT /api/Moto/12

```json
{
	"idMoto": 12,
	"nmPlaca": "ABC1D23",
	"stMoto": "Em manutenção",
	"kmRodado": 1500.0,
	"idCliente": 1,
	"idModelo": 2,
	"idFilialDepartamento": 3
}
```
Respostas: 204 No Content | 400 Bad Request (id divergente) | 404 Not Found

4) Países

- GET todos: GET /api/Pais
- GET por ID: GET /api/Pais/1
- POST criar:

```json
{
	"nmPais": "Brasil"
}
```

5) Departamentos

- GET todos: GET /api/Departamento
- GET por ID: GET /api/Departamento/2
- POST criar:

```json
{
	"nmDepartamento": "Operações",
	"dsDepartamento": "Coordena as operações diárias"
}
```

- PUT atualizar: PUT /api/Departamento/2

```json
{
	"idDepartamento": 2,
	"nmDepartamento": "Operações",
	"dsDepartamento": "Coordena as operações e logística"
}
```
Respostas: 204 No Content | 400 Bad Request (id divergente) | 404 Not Found

6) Funcionários

- GET todos: GET /api/Funcionario
- GET por ID: GET /api/Funcionario/7
- POST criar:

```json
{
	"nmFuncionario": "Maria Souza",
	"nmCargo": "Analista",
	"nmEmailCorporativo": "maria.souza@empresa.com",
	"nmSenha": "SenhaForte@123",
	"idFilial": 3
}
```

- PUT atualizar: PUT /api/Funcionario/7

```json
{
	"idFuncionario": 7,
	"nmFuncionario": "Maria Souza",
	"nmCargo": "Analista Sênior",
	"nmEmailCorporativo": "maria.souza@empresa.com",
	"nmSenha": "SenhaForte@123",
	"idFilial": 3
}
```
Respostas: 204 No Content | 400 Bad Request (id divergente) | 404 Not Found

Observação: Todas as demais entidades seguem o mesmo padrão CRUD (GET, GET por ID, POST, PUT, DELETE).

---



## 🧪 Testes – como rodar

Este repositório utiliza testes de unidade (quando presentes). Para executar:

```powershell
dotnet test .\MottuWebApplication.sln -c Debug
```

---

## 🗂️ Estrutura das camadas

- `MottuWebApplication` (API)
- `MottuWebApplication.Application` (Serviços e interfaces por entidade)
- `MottuWebApplication.Domain` (Entidades e regras de domínio)
- `MottuWebApplication.Infrastructure` (EF Core + Oracle, DbContext, repositórios)

---

Qualquer dúvida ou sugestão é bem-vinda — consulte o Swagger para detalhes das rotas e modelos.
