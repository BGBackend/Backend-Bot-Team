using BackendBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendBot.Repositories
{
    public class InMemoryUserProductRepository : InMemoryRepositoryBase<UserProduct>
    {
        private List<UserProduct> userProducts = new List<UserProduct>();

        public InMemoryUserProductRepository()
        {
            userProducts.Add(
                    new UserProduct
                    {
                        UserProductId = 1,
                        AutorenewEnabled = true,
                        Disabled = false,
                        EmailAddress = "anamaria.hudisteanu@bullguard.com",
                        Expires = "30/04/2019",
                        IsTemporary = false,
                        OrderId = 10001861,
                        ProductId = 1,
                        TransitionType = TransitionType.AutoRenew,
                    }
                );

            userProducts.Add(
                   new UserProduct
                   {
                       UserProductId = 2,
                       AutorenewEnabled = false,
                       Disabled = false,
                       EmailAddress = "gabriel.mihaila@bullguard.com",
                       Expires = "05/05/2018",
                       IsTemporary = false,
                       OrderId = 10001861,
                       ProductId = 4,
                       TransitionType = TransitionType.ChangeProduct,
                   }
               );
            userProducts.Add(
                   new UserProduct
                   {
                       UserProductId = 3,
                       AutorenewEnabled = false,
                       Disabled = true,
                       EmailAddress = "chatbot@bullguard.com",
                       Expires = "30/04/2019",
                       IsTemporary = false,
                       OrderId = 10001861,
                       ProductId = 2,
                       TransitionType = TransitionType.Upgrade,
                   }
               );
            userProducts.Add(
                   new UserProduct
                   {
                       UserProductId = 4,
                       AutorenewEnabled = true,
                       Disabled = false,
                       EmailAddress = "calin.lencu@bullguard.com",
                       Expires = "08/08/2017",
                       IsTemporary = false,
                       OrderId = 10001861,
                       ProductId = 3,
                       TransitionType = TransitionType.TrialConversion,
                   }
               );
            userProducts.Add(
                    new UserProduct
                    {
                        UserProductId = 5,
                        AutorenewEnabled = true,
                        Disabled = false,
                        EmailAddress = "chatbot@bullguard.com",
                        Expires = "30/04/2019",
                        IsTemporary = false,
                        OrderId = 10001861,
                        ProductId = 5,
                        TransitionType = TransitionType.AutoRenew,
                    }
                );
            userProducts.Add(
                   new UserProduct
                   {
                       UserProductId = 6,
                       AutorenewEnabled = false,
                       Disabled = false,
                       EmailAddress = "gabriel.mihaila@bullguard.com",
                       Expires = "05/05/2018",
                       IsTemporary = false,
                       OrderId = 10001861,
                       ProductId = 1,
                       TransitionType = TransitionType.ChangeProduct,
                   }
               );
            userProducts.Add(
                   new UserProduct
                   {
                       UserProductId = 7,
                       AutorenewEnabled = false,
                       Disabled = true,
                       EmailAddress = "chatbot@bullguard.com",
                       Expires = "30/04/2019",
                       IsTemporary = false,
                       OrderId = 10001861,
                       ProductId = 2,
                       TransitionType = TransitionType.Upgrade,
                   }
               );
            userProducts.Add(
                   new UserProduct
                   {
                       UserProductId = 8,
                       AutorenewEnabled = true,
                       Disabled = false,
                       EmailAddress = "anamaria.hudisteanu@bullguard.com",
                       Expires = "30/04/2019",
                       IsTemporary = false,
                       OrderId = 10001900,
                       ProductId = 5,
                       TransitionType = TransitionType.TrialConversion,
                   }
               );
            userProducts.Add(
                   new UserProduct
                   {
                       UserProductId = 7,
                       AutorenewEnabled = false,
                       Disabled = true,
                       EmailAddress = "chatbot@bullguard.com",
                       Expires = "30/04/2019",
                       IsTemporary = false,
                       OrderId = 10001888,
                       ProductId = 5,
                       TransitionType = TransitionType.Upgrade,
                   }
               );
            userProducts.Add(
                   new UserProduct
                   {
                       UserProductId = 8,
                       AutorenewEnabled = true,
                       Disabled = false,
                       EmailAddress = "anamaria.hudisteanu@bullguard.com",
                       Expires = "30/04/2019",
                       IsTemporary = false,
                       OrderId = 10001765,
                       ProductId = 3,
                       TransitionType = TransitionType.TrialConversion,
                   }
               );
        }

        public override IEnumerable<UserProduct> Find(Func<UserProduct, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<UserProduct> FindAll()
        {
            return userProducts;
        }

        public override UserProduct FindById(int id)
        {
            return this.userProducts.SingleOrDefault(x => x.UserProductId == id);
        }

        public override UserProduct FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProduct> GetByEmail(string emailAddress)
        {
            return userProducts.Where(up => up.EmailAddress.ToLower() == emailAddress.ToLower());
        }
    }
}