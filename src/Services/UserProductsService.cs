using BackendBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendBot.Services
{
    public class UserProductsService
    {
        public static Repositories.InMemoryUserProductRepository _userProductRepository = new Repositories.InMemoryUserProductRepository();

        public static IEnumerable<UserProduct> GetUserProducts()
        {
            return _userProductRepository.FindAll();
        }

        public static IEnumerable<UserProduct> GetUserProductyByEmailAddressWithAutoRenewEnabled(string emailAddress)
        {
            return _userProductRepository.GetByEmail(emailAddress).Where(up => up.AutorenewEnabled == true);
        }

        public static IEnumerable<UserProduct> GetUserProductyByEmailAddress(string emailAddress)
        {
            return _userProductRepository.GetByEmail(emailAddress);
        }

        public static UserProduct GetUserProductyById(int id)
        {
            return _userProductRepository.FindById(id);
        }
    }
}