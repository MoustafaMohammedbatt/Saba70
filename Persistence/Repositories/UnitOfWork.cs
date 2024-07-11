using Domain.Entities;
using Domain.IRepositories;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IBaseRepository<GueessPlayer> GueessPlayers => new BaseRepository<GueessPlayer>(_context);

        public IBaseRepository<XOImagesColmns> XOImagesColmns => new BaseRepository<XOImagesColmns>(_context);

        public IBaseRepository<XOImagesRows> XOImagesRows => new BaseRepository<XOImagesRows>(_context);

        public IBaseRepository<PassWord> PassWords => new BaseRepository<PassWord>(_context);

        public IBaseRepository<Risk> Risks => new BaseRepository<Risk>(_context);

        public IBaseRepository<Acting> Acting => new BaseRepository<Acting>(_context);

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
