namespace HealFit.Repositories.Interfaces; 
public interface IUnitOfWork {

    IUsuarioRepository UsuarioRepository { get; }

    Task CommitAsync();
}
