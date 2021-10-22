# Desenvolvimento de aplicações com .NET

## Parte 1

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

Add-Migration InitialCreate
Update-Database

Add-Migration NOME_DA_TABELA
```



## Parte2

Abrir o **gerenciador de pacotes do NuGet** e procurar por:
	**swashbuckle.AspNetCore**
	Clicar em instalar

Ir em **properties** do projeto e ativar a opção:
	**XML documentarion file** deixando o caminho padrão sem alterar

Na opção **debug** e mudar o launch browser para:
	**swagger**

Em **startup.cs** adicionar as seguintes linhas em **ConfigureServices**:

```c#
services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Curso API", Version = "v1"}); });
```

Em **startup.cs** adicionar as seguintes linhas em **Configure** após o **if do env.IsDevelopmente**:

```c#
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CursoAPI"); });
```

Adicionar referência ao projeto **CursoMVC**

Criar um arquivo **scaffold** de **API com EntityFramework** usando os arquivos de **Categoria.cs** do outro projeto como referência

Em **startup.cs** adicionar as seguintes linhas em **ConfigureServices**:

```c#
services.AddDbContext<Context>();
```

Em **properties** configurar para executar os dois projetos juntos ao mesmo tempo

Criar um arquivo **scaffold** de **API com EntityFramework** usando os arquivos de **Produto.cs** do outro projeto como referência

Em **ProdutosController.cs** alterar o **GetProdutos**:

```c#
return await _context.Produtos.ToListAsync();
return await _context.Produtos.Include("Categoria").ToListAsync();
```

Em **ProdutosController.cs** alterar o **GetProduto**:

```c#
var produto = await _context.Produtos.FindAsync(id);
var produto = await _context.Produtos.Include("Categoria").FirstOrDefaultAsync(x => x.Id == id);
```

