using CRUP.MinimalAPI.Entities;
using CRUP.MinimalAPI.Services;
using Microsoft.OpenApi.Models;

namespace CRUP.MinimalAPI.Endpoints
{
    public static class LivrosEndpoints
    {
        public static void RegisterLivrosEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/livros", async (Livro livro, ILivroService _livroService) =>
            {
                await _livroService.AddLivro(livro);
                return Results.Created($"{livro.Id}", livro);
            })
    .WithName("AddLivro")
    .RequireAuthorization()
    .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
    {
        Summary = "Incluir um livro",
        Description = "Inclui um novo livro na biblioteca",
        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Minha Biblioteca" } }
    });

            endpoints.MapGet("/livros", async (ILivroService _livroService) =>
                TypedResults.Ok(await _livroService.GetLivros()))
                .WithName("GetLivros")
                .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
                {
                    Summary = "Obtem todos os livros da biblioteca",
                    Description = "Retorna informaçoes sobre livros.",
                    Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Minha Biblioteca" } }
                });

            endpoints.MapGet("/livros/{id}", async (ILivroService _livroService, int id) =>
            {
                var livro = await _livroService.GetLivro(id);

                if (livro != null) return Results.Ok(livro);
                else return Results.NotFound();
            })
                .WithName("GetLivrosPorId")
                .RequireAuthorization()
                .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
                {
                    Summary = "Obtem um livro pelo seu id",
                    Description = "Retorna a informaçao de um livro.",
                    Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Minha Biblioteca" } }
                });

            endpoints.MapDelete("/livros/{id}", async (int id, ILivroService _livroService) =>
            {
                await _livroService.DeleteLivro(id);
                return Results.Ok($"Livro de id={id} deleteado");
            })
                .WithName("DeletePorId")
                .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
                {
                    Summary = "Deleta um livro pelo seu id",
                    Description = "Deleta um livro da biblioteca",
                    Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Minha Biblioteca" } }
                });

        }
    }
}
