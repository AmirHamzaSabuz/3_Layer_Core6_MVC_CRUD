using Core.Interfaces;
using Infrastructure.DataContext;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUintOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICountryRepository CountryRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CountryRepo = new CountryRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
