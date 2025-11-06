dotnet run --project .\MottuWebApplication\MottuWebApplication.csproj --launch-profile http
# 🏍️ Mottu Web API — ASP.NET Core + Oracle

**Challenge 2025 — FIAP**

API REST para gerenciamento de clientes, motos e outras entidades, com integração de um modelo ML.NET para predição de necessidade de manutenção (endpoint `Reviews`).

---

## Índice

- [Integrantes](#integrantes)
- [Visão geral e arquitetura](#visão-geral-e-arquitetura)
- [Funcionalidades adicionadas](#funcionalidades-adicionadas)
- [Pré-requisitos & execução rápida](#pré-requisitos--execução-rápida)
- [Exemplos de endpoints](#exemplos-de-endpoints)
- [Testes](#testes)
- [Deploy do modelo (CI/CD)](#deploy-do-modelo-cicd)
- [Estrutura do repositório](#estrutura-do-repositório)

---

## Integrantes

- Eduarda Tiemi Akamini Machado – RM 554756 – 2TDSPH
- Felipe Pizzinato Bigatto Garcia – RM 555141 – 2TDSPW
- Gustavo de Oliveira Turci Sandrini – RM 557505 – 2TDSPW

---

## Visão geral e arquitetura

O projeto segue princípios de Clean Architecture com camadas separadas:

- API (presentation): controllers REST com respostas HTTP padronizadas e documentação via Swagger/OpenAPI.
- Application: serviços e interfaces (casos de uso por entidade).
- Domain: entidades e regras de negócio.
- Infrastructure: EF Core (Oracle), DbContext, repositórios e migrations.

Motivações principais:

- isolamento das responsabilidades para facilitar testes e manutenção;
- clareza na separação entre regras de domínio e infraestrutura;
- observabilidade e documentação via Swagger para uso por consumidores.

---

## Funcionalidades adicionadas

- Integração ML.NET (`MottuWebApplication.Trainer` + `PredictionEnginePool`): treina e exporta o modelo (`model-manutencao.zip`) e permite predizer em runtime. Motivação: automação de decisões de manutenção.
- Endpoint `Reviews` (persistência e histórico): guarda entradas usadas na predição e o resultado (predição + score). Motivação: auditabilidade e feedback para re-treinamento.
- Serviço `IPredictionService`: wrapper em torno do `PredictionEnginePool` para separar a lógica de predição e facilitar testes/mocks.
- Documentação XML (comentários em controllers) para melhorar a descoberta via Swagger.
- Estratégia de deploy do modelo: caminho resolvido via `ContentRootPath` e instruções para incluir o ZIP no publish/artefato.

---

## Pré-requisitos & execução rápida

- .NET 9 SDK
- Oracle DB (se usar a persistência real) — configure `MottuWebApplication/appsettings.json`

Configurar connection string em `MottuWebApplication/appsettings.json`:

```json
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

Abra o Swagger em: http://localhost:5233/swagger

---

## Exemplos de endpoints

Os exemplos abaixo são ilustrativos — consulte Swagger para o catálogo completo.

Clientes (exemplos)
- GET /api/Cliente
- GET /api/Cliente/{id}
- POST /api/Cliente

```json
{
	"nmCliente": "João Silva",
	"nrCpf": "123.456.789-00",
	"nmEmail": "joao@empresa.com",
	"idLogradouro": 10
}
```

Motos (exemplo de POST)

```json
{
	"nmPlaca": "ABC1D23",
	"stMoto": "Ativo",
	"kmRodado": 1200.5,
	"idCliente": 1,
	"idModelo": 1,
	"idFilialDepartamento": 1
}
```

Reviews (ML endpoint)

- GET /api/Reviews
- GET /api/Reviews/{id}
- POST /api/Reviews

Exemplo de corpo (POST):

```json
{
	"kmRodados": 1200.5,
	"diasDesdeUltimaManutencao": 30
}
```

Exemplo de resposta (201 Created):

```json
{
	"id": 123,
	"kmRodados": 1200.5,
	"diasDesdeUltimaManutencao": 30,
	"predictedManutencao": "Positivo",
	"manutencaoScore": 0.87
}
```

`manutencaoScore` é a pontuação de confiança (valores próximos a 1 indicam maior confiança).

---

## Testes

Executar testes (PowerShell):

```powershell
dotnet restore .\MottuWebApplication.sln
dotnet build .\MottuWebApplication.sln -c Debug
dotnet test .\MottuWebApplication.sln -c Debug
```

Executar apenas o projeto de testes:

```powershell
dotnet test .\MottuWebApplication.Tests\MottuWebApplication.Tests.csproj -c Debug
```

Filtrar por testes (ex.: nomes com 'Reviews'):

```powershell
dotnet test .\MottuWebApplication.Tests\MottuWebApplication.Tests.csproj -c Debug --filter "FullyQualifiedName~Reviews"
```

Observação: a maior parte dos testes é unitária e usa mocks. Se algum teste depender de recursos externos (ex.: Oracle), ajuste a connection string ou variáveis de ambiente antes de rodar.

---

## Deploy do modelo (CI/CD)

Instruções rápidas para garantir que `model-manutencao.zip` esteja disponível no publish/pasta do app:

- Opção A — copiar o ZIP durante a pipeline (ex.: GitHub Actions)

	- Bash (Linux/macOS runner):

```yaml
- name: Build trainer and copy model
	run: |
		dotnet build ./MottuWebApplication.Trainer -c Release
		cp ./MottuWebApplication.Trainer/bin/Release/net9.0/model-manutencao.zip ./MottuWebApplication/
```

	- PowerShell (Windows runner):

```yaml
- name: Build trainer and copy model (Windows)
	run: |
		dotnet build .\MottuWebApplication.Trainer -c Release
		Copy-Item -Path .\MottuWebApplication.Trainer\bin\Release\net9.0\model-manutencao.zip -Destination .\MottuWebApplication\ -Force
	shell: pwsh
```

- Opção B — marcar o arquivo como Content no projeto Web (`CopyToOutputDirectory`)

Adicione ao `MottuWebApplication.csproj`:

```xml
<ItemGroup>
	<Content Include="model-manutencao.zip">
		<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
	</Content>
</ItemGroup>
```

Isso garante que `dotnet publish` inclua o arquivo no diretório de publicação.

---

## Estrutura do repositório

- `MottuWebApplication` — Web API (controllers, `Program.cs`)
- `MottuWebApplication.Application` — serviços e injeção de dependências
- `MottuWebApplication.Domain` — entidades do domínio
- `MottuWebApplication.Infrastructure` — DbContext, repositórios e migrations
- `MottuWebApplication.Trainer` — código e pipeline de treinamento ML.NET
- `MottuWebApplication.Tests` — testes automatizados

---

Se quiser, eu posso:

- executar `dotnet build` + `dotnet test` e colar a saída aqui;
- adicionar um exemplo de workflow GitHub Actions que construa o Trainer, copie o modelo e publique a API.

---

Consulte o Swagger para a documentação detalhada dos endpoints.
