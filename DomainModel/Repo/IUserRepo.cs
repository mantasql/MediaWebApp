using DomainModel.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repo
{
    public interface IUserRepo
    {
        public Task AddUserAsync(string id, string userName);
    }
}
