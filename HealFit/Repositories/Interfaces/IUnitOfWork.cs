namespace HealFit.Repositories.Interfaces; 
public interface IUnitOfWork {

    IUsuarioRepository UsuarioRepository { get; }
    IDadosRepository DadosRepository { get; }

    Task CommitAsync();
}
