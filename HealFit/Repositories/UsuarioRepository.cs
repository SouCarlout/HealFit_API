using HealFit.Context;
using HealFit.Models;
using HealFit.Repositories.Interfaces;

namespace HealFit.Repositories;
public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository {
    public UsuarioRepository(AppDbContext context) : base(context) {
    }
}
