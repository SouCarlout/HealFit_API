using HealFit.Context;
using HealFit.Models;
using HealFit.Repositories.Interfaces;

namespace HealFit.Repositories;
public class ConsumoRepository : Repository<Consumo>, IConsumoRepository {
    public ConsumoRepository(AppDbContext context) : base(context) {
    }
}
