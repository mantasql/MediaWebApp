using DomainModel.DataAccess;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repo
{
    public class UserRepo : IUserRepo
    {
        public readonly ApplicationContext context;

        public UserRepo(ApplicationContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddUserAsync(string id, string userName)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            User user = new User
            {
                Id = id,
                UserName = userName
            };


            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
