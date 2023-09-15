using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Repository.Interface
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
    }
}
