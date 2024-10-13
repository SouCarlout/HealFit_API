using HealFit.Context;
using HealFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealFit.Repositories {
    public class UnitOfWork : IUnitOfWork {

        public AppDbContext _context;
        private IUsuarioRepository? _usuarioRepo;
        private IDadosRepository? _dadosRepo;
        private IConsumoRepository? _consumoRepo;


        public UnitOfWork(AppDbContext context) {

            _context = context;
        }

        public IUsuarioRepository UsuarioRepository {

            get {
                return _usuarioRepo = _usuarioRepo ?? new UsuarioRepository(_context);
            }
        }

        public IDadosRepository DadosRepository {

            get {
                return _dadosRepo = _dadosRepo ?? new DadosRepository(_context);
            }
        }

        public IConsumoRepository ConsumoRepository {

            get {
                return _consumoRepo = _consumoRepo ?? new ConsumoRepository(_context);
            }
        }

        public async Task CommitAsync() {

            await _context.SaveChangesAsync();
        }
        public async Task Dispose() {

            await _context.SaveChangesAsync();
        }
    }
}
