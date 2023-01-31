using ClarikaTest.DataAccess.Domain.Models;
using ClarikaTest.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarikaTest.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        private IRepository<Members> _membersRepository;
        private IRepository<Tweets> _tweetsRepository;

        public IRepository<Members> MembersRepository
        {
            get
            {
                if (_membersRepository == null)
                {
                    _membersRepository = new MembersRepository(_context);
                }
                return _membersRepository;
            }
        }

        public IRepository<Tweets> TweetsRepository
        {
            get
            {
                if (_tweetsRepository == null)
                {
                    _tweetsRepository = new TweetsRepository(_context);
                }
                return _tweetsRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
