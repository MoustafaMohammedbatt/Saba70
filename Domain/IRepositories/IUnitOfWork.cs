using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUnitOfWork
    {
        IBaseRepository<GueessPlayer> GueessPlayers { get; }
        IBaseRepository<XOImagesColmns> XOImagesColmns { get; }
        IBaseRepository<XOImagesRows> XOImagesRows { get; }
        IBaseRepository<PassWord> PassWords { get; }
        IBaseRepository<Risk> Risks { get; }
        IBaseRepository<Acting> Acting { get; }



        int Complete();
    }
}
