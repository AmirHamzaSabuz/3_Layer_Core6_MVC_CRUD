using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUintOfWork
    {
        ICountryRepository CountryRepo { get; }
        void Save();
    }
}
