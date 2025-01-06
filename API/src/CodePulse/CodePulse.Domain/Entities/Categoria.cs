using CodePulse.Domain.ValueObjects;

namespace CodePulse.Domain.Entities;

public class Categoria : Entity
{
    public string Nome { get; private set; }
    public Slug Slug { get; private set; }

    private Categoria()
    {
        Nome = default!;
        Slug = default!;
    }

    public Categoria(string nome)
    {
        ValidarCampos(nome);

        Nome = nome;
        Slug = Slug.Criar(nome);
    }

    /// <summary>
    /// Atualiza os dados da categoria.
    /// </summary>
    public void Atualizar(string nome)
    {
        ValidarCampos(nome);

        Nome = nome;
        Slug = Slug.Criar(nome);

        AtualizarDataAlteracao();
    }

    private static void ValidarCampos(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome da categoria não pode ser vazio.");
    }
}
