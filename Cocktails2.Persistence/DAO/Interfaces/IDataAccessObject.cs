using Cocktails2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Persistence.DAO.Interfaces;


/* This interface is not used at the moment. */
public interface IDataAccessObject
{
    public int Id { get; set; }
    public Cocktail ToDomainEntity();
}
