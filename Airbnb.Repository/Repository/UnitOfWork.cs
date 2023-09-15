using Airbnb.DataModels.Data;
using Airbnb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Repository.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AuthDbContext _context;
        public UnitOfWork(AuthDbContext context)
        {
            _context = context;
        }

        public IAuthRepository AuthRepository => new AuthRepository(_context);
    }
}
