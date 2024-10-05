using HealFit.Context;
using HealFit.Models;
using HealFit.Repositories.Interfaces;

namespace HealFit.Repositories;
public class DadosRepository : Repository<DadosPessoais>, IDadosRepository {
    public DadosRepository(AppDbContext context) : base(context) {

    }
}
