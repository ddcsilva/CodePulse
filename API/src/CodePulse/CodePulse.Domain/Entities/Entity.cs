namespace CodePulse.Domain.Entities;

/// <summary>
/// Classe base para entidades do domínio.
/// </summary>
public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataAlteracao { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
    }

    /// <summary>
    /// Atualiza a data de modificação para a entidade.
    /// </summary>
    public void AtualizarDataAlteracao()
    {
        DataAlteracao = DateTime.UtcNow;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
        {
            return false;
        }

        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}
