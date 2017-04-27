using BackendBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendBot.Repositories
{
    public class InMemoryUserRepository : InMemoryRepositoryBase<User>
    {
        public List<User> users;

        public InMemoryUserRepository()
        {
            users = new List<User>();

            users.Add(
                new User
                {
                    FullName = "Anamaria Hudisteanu",
                    EmailAddress = "anamaria.hudisteanu@bullguard.com"
                }
                );
            users.Add(
               new User
               {
                   FullName = "Gabriel Mihaila",
                   EmailAddress = "gabriel.mihaila@bullguard.com"
               }
               );
            users.Add(
               new User
               {
                   FullName = "Calin Lencu",
                   EmailAddress = "calin.lencu@bullguard.com"
               }
               );
            users.Add(
               new User
               {
                   FullName = "Uber Chat Bot",
                   EmailAddress = "chatbot@bullguard.com"
               }
               );
        }
        public override IEnumerable<User> Find(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<User> FindAll()
        {
            return users;
        }

        public override User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override User FindByName(string name)
        {
            return this.users.SingleOrDefault(x => x.FullName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public User GetByEmailAddress(string emailAddress)
        {
            return this.users.SingleOrDefault(x => x.EmailAddress.Equals(emailAddress, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}