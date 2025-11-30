# Sistema de Controle de Confeitaria - DER e Configuração

## 📋 Estrutura do Banco de Dados

Este projeto utiliza Entity Framework Core 8.0 com SQL Server para gerenciar o banco de dados da confeitaria.

### Entidades Principais

1. **Produto** - Ingredientes, matéria-prima pronta e sobras
2. **Receita** - Receitas com custos e preços
3. **ReceitaItem** - Ingredientes usados na receita
4. **ReceitaProdutoGerado** - Produtos gerados pela receita
5. **ReceitaSobra** - Sobras geradas pela receita
6. **Producao** - Registros de produção
7. **ProducaoItem** - Itens consumidos na produção
8. **ProducaoProdutoGerado** - Produtos gerados na produção
9. **ProducaoSobra** - Sobras geradas na produção
10. **Fornecedor** - Cadastro de fornecedores
11. **FornecedorProduto** - Produtos de cada fornecedor (com código/descrição específicos)
12. **NotaFiscal** - Notas fiscais
13. **NotaFiscalItem** - Itens da nota fiscal

## 🚀 Configuração Inicial

### 1. Iniciar SQL Server no Docker

```bash
docker-compose up -d
```

Isso irá iniciar o SQL Server na porta 1433 com:
- **Usuário:** sa
- **Senha:** YourStrong@Passw0rd
- **Database:** Será criada automaticamente na primeira migration

### 2. Instalar as Dependências

```bash
dotnet restore
```

### 3. Criar a Migration

```bash
dotnet ef migrations add InitialCreate
```

### 4. Aplicar a Migration ao Banco

```bash
dotnet ef database update
```

## 📁 Estrutura de Pastas

```
Confentaria/
├── Models/              # Entidades do banco de dados
│   ├── Produto.cs
│   ├── Receita.cs
│   ├── ReceitaItem.cs
│   ├── ReceitaProdutoGerado.cs
│   ├── ReceitaSobra.cs
│   ├── Producao.cs
│   ├── ProducaoItem.cs
│   ├── ProducaoProdutoGerado.cs
│   ├── ProducaoSobra.cs
│   ├── Fornecedor.cs
│   ├── FornecedorProduto.cs
│   ├── NotaFiscal.cs
│   └── NotaFiscalItem.cs
├── Data/                # Contexto do Entity Framework
│   ├── ConfentariaDbContext.cs
│   └── DatabaseHelper.cs
├── Formularios/         # Telas do sistema
├── appsettings.json     # Configuração da connection string
└── docker-compose.yml   # Configuração do SQL Server
```

## 🔧 Como Usar o DbContext

### Exemplo de uso em um formulário:

```csharp
using Confentaria.Data;
using Confentaria.Models;

// Criar instância do contexto
using var context = DatabaseHelper.CreateDbContext();

// Exemplo: Listar produtos
var produtos = context.Produtos.ToList();

// Exemplo: Adicionar produto
var novoProduto = new Produto
{
    Nome = "Farinha de Trigo",
    Tipo = TipoProduto.Ingrediente,
    UnidadeMedida = "kg",
    EstoqueAtual = 10
};
context.Produtos.Add(novoProduto);
context.SaveChanges();
```

## 📊 Relacionamentos Principais

- **Receita** → **ReceitaItem** (1:N) - Uma receita tem vários ingredientes
- **Receita** → **ReceitaProdutoGerado** (1:N) - Uma receita gera vários produtos
- **Receita** → **ReceitaSobra** (1:N) - Uma receita pode gerar várias sobras
- **Receita** → **Producao** (1:N) - Uma receita pode ter várias produções
- **Producao** → **ProducaoItem** (1:N) - Uma produção consome vários itens
- **Producao** → **ProducaoProdutoGerado** (1:N) - Uma produção gera vários produtos
- **Producao** → **ProducaoSobra** (1:N) - Uma produção pode gerar várias sobras
- **Fornecedor** → **FornecedorProduto** (1:N) - Um fornecedor tem vários produtos
- **FornecedorProduto** → **Produto** (N:1) - Produtos do fornecedor referenciam produtos internos
- **Fornecedor** → **NotaFiscal** (1:N) - Um fornecedor tem várias notas fiscais
- **NotaFiscal** → **NotaFiscalItem** (1:N) - Uma nota fiscal tem vários itens
- **NotaFiscalItem** → **FornecedorProduto** (N:1) - Itens podem estar associados a produtos do fornecedor

## 🔐 Configuração da Connection String

A connection string está configurada no arquivo `appsettings.json`. Para alterar:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=ConfentariaDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;"
  }
}
```

**Importante:** Altere a senha no `docker-compose.yml` e no `appsettings.json` para produção!

## 📝 Próximos Passos

1. Criar as telas de cadastro de produtos
2. Criar a tela de cadastro de receitas
3. Criar a tela de produção
4. Criar a tela de importação de notas fiscais
5. Implementar a integração com o script Python para leitura de notas fiscais

## 🐳 Comandos Docker Úteis

```bash
# Iniciar o container
docker-compose up -d

# Parar o container
docker-compose down

# Ver logs
docker-compose logs -f sqlserver

# Acessar o SQL Server via linha de comando
docker exec -it confentaria-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd
```

## ⚠️ Observações

- O projeto foi atualizado para .NET 8.0
- Todas as dependências do Entity Framework foram adicionadas
- O banco de dados será criado automaticamente na primeira migration
- Certifique-se de que o Docker está rodando antes de executar as migrations

