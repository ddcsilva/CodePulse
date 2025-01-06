using CodePulse.Domain.Entities;
using CodePulse.Domain.Exceptions;
using CodePulse.Domain.ValueObjects;

public class Postagem : Entity
{
    public string Titulo { get; private set; }
    public string DescricaoCurta { get; private set; }
    public string Conteudo { get; private set; }
    public string UrlImagemDestaque { get; private set; } = string.Empty;
    public Slug Slug { get; private set; }
    public DateTime DataPublicacao { get; private set; } = DateTime.UtcNow;
    public string Autor { get; private set; }
    public bool Visivel { get; private set; }

    private Postagem()
    {
        Titulo = default!;
        DescricaoCurta = default!;
        Conteudo = default!;
        UrlImagemDestaque = string.Empty;
        Slug = default!;
        Autor = default!;
    }

    public Postagem(string titulo, string descricaoCurta, string conteudo, string urlImagemDestaque, string autor, bool visivel)
    {
        ValidarCampos(titulo, conteudo, autor);

        Titulo = titulo;
        DescricaoCurta = descricaoCurta ?? string.Empty;
        Conteudo = conteudo;
        UrlImagemDestaque = urlImagemDestaque ?? string.Empty;
        Autor = autor;
        Visivel = visivel;
        Slug = Slug.Criar(titulo);
    }

    /// <summary>
    /// Atualiza os dados da postagem.
    /// </summary>
    public void Atualizar(string titulo, string descricaoCurta, string conteudo, string urlImagemDestaque, bool visivel)
    {
        ValidarCampos(titulo, conteudo, Autor);

        Titulo = titulo;
        DescricaoCurta = descricaoCurta ?? string.Empty;
        Conteudo = conteudo;
        UrlImagemDestaque = urlImagemDestaque ?? string.Empty;
        Visivel = visivel;
        Slug = Slug.Criar(titulo);

        AtualizarDataAlteracao();
    }

    /// <summary>
    /// Publica a postagem, tornando-a visível.
    /// </summary>
    public void Publicar()
    {
        Visivel = true;
        AtualizarDataAlteracao();
    }

    private static void ValidarCampos(string titulo, string conteudo, string autor)
    {
        if (string.IsNullOrWhiteSpace(titulo) || titulo.Length < 5)
        {
            throw new DomainException("O título deve ter pelo menos 5 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(conteudo) || conteudo.Length < 20)
        {
            throw new DomainException("O conteúdo deve ter pelo menos 20 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(autor))
        {
            throw new DomainException("O autor não pode ser vazio.");
        }
    }
}
