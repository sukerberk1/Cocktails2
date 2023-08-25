using Cocktails2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Persistence.DAO.Interfaces;

public interface IDataAccessObject
{
    public Cocktail ToDomainEntity();
}
