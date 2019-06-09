using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHut.Models.IRepositories;

namespace PizzaHut.Models.MockUserRepository
{
    public class MockUserRepository : IUserRepository
    {
        List<User> users;

        public MockUserRepository()
        {
            users = new List<User>()
            {
                new User{ID=1, Name="vukashin", Address="11 Oktomvri", City="Skopje", Email="v@gmail.com"},
                new User{ID=2, Name="dejan", Address="12 Januar", City="Skopje", Email="v@gmail.com"},
                new User{ID=3, Name="trajan", Address="13 Septemvri", City="Skopje", Email="v@gmail.com"},
            };
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User Get(int id)
        {
            var user = users.Where(userId => userId.ID == id).FirstOrDefault();
            return user;
        }

        public User Add(User user)
        {
            int nextID = users.Max(userID => userID.ID);
            user.ID = nextID;
            users.Add(user);
            return user;
        }

        public User Update(User Changeuser)
        {
            User user = users.Where(userID => userID.ID == Changeuser.ID).FirstOrDefault();

            if(user != null)
            {
                user.ID = Changeuser.ID;
                user.Name = Changeuser.Name;
                user.Address = Changeuser.Address;
                user.City = Changeuser.City;
                user.Email = Changeuser.Email;
            }
            return user;
        }

        public User Delete(int id)
        {
            User user = users.Where(userID => userID.ID == id).FirstOrDefault();
            users.Remove(user);
            return user;
        }
    }
}
