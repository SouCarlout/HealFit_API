using HealFit.Context;
using HealFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealFit.Repositories {
    public class UnitOfWork : IUnitOfWork {

        public AppDbContext _context;
        private IUsuarioRepository? _usuarioRepo;


        public UnitOfWork(AppDbContext context) {

            _context = context;
        }

        public IUsuarioRepository UsuarioRepository {

            get {
                return _usuarioRepo = _usuarioRepo ?? new UsuarioRepository(_context);
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
