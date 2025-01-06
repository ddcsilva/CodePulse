namespace CodePulse.Domain.ValueObjects;

/// <summary>
/// Representa um Slug gerado a partir do título de uma postagem.
/// </summary>
public sealed class Slug
{
    public string Valor { get; }

    private Slug(string valor)
    {
        Valor = valor ?? throw new ArgumentException("O slug não pode ser nulo.");
    }

    public static Slug Criar(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("O título não pode ser vazio para gerar um slug.");

        var slug = titulo.ToLower().Trim()
            .Replace("ç", "c")
            .Replace("á", "a").Replace("é", "e").Replace("í", "i")
            .Replace("ó", "o").Replace("ú", "u")
            .Replace("ã", "a").Replace("õ", "o")
            .Replace("ê", "e").Replace("ô", "o")
            .Replace(" ", "-");

        return new Slug(slug);
    }

    public override string ToString() => Valor;

    public override bool Equals(object? obj)
    {
        if (obj is Slug other)
        {
            return Valor == other.Valor;
        }

        return false;
    }

    public override int GetHashCode() => Valor.GetHashCode();
}
