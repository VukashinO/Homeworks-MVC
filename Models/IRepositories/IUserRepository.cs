using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.IRepositories
{
     public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User Get(int id);

        User Add(User user);

        User Update(User user);

        User Delete(int id);
    }
}
