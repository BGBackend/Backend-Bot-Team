using BackendBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendBot.Repositories
{
    public class InMemoryProductRepository : InMemoryRepositoryBase<Product>
    {
        private List<Product> products;

        public InMemoryProductRepository()
        {
            products = new List<Product>();

            products.Add(
                     new Product
                     {
                         ProductId = 1,
                         Name = $"BullGuard Premium Protection",
                         Description = $"Get the ultimate in identity and social media protection and safeguard all your computers whether PC, Mac or Android with one license. This premium suite monitors your entire digital life 24/7. Includes award-winning antivirus protection.",
                         Image = $"https://www.bullguard.com/shop/Content/Img/Site2016/product_box_bpp.png",
                         Price = "29.95 $"
                     }
                 );
            products.Add(
                     new Product
                     {
                         ProductId = 2,
                         Name = $"BullGuard Antivirus",
                         Description = $"Looking for a smarter Antivirus? Choose Bullguard’s cutting-edge multi-layered defence system to keep all malware out. Plus, it’s the only Antivirus with antispam protection.",
                         Image = $"https://www.bullguard.com/shop/Content/Img/Site2016/product_box_av.png",
                         Price = "89.95 $"
                     }
                 );
            products.Add(
                    new Product
                    {
                        ProductId = 3,
                        Name = $"BullGuard Identity Protection",
                        Description = $"Want a web-based identity and social media protection that works across all devices and operating systems? Get the solution that works for everyone.",
                        Image = $"https://www.bullguard.com/shop/Content/Img/Site2016/product_box_idp_1.png",
                        Price = "39.95 $"
                    }
                );
            products.Add(
                    new Product
                    {
                        ProductId = 4,
                        Name = $"BullGuard Internet Security",
                        Description = $"The best protection against malware and spam. Multi-device protection for Windows, Mac and Android so you can safeguard all your computers with a single license. Includes powerful parental controls.",
                        Image = $"https://www.bullguard.com/shop/Content/Img/Site2016/product_box_is.png",
                        Price = "59.95 $"
                    }
                );
            products.Add(
                    new Product
                    {
                        ProductId = 5,
                        Name = $"BullGuard Mobile Security",
                        Description = $"Want smart security for your Android phone or tablet? Safeguard it against viruses, malware, spam calls/messages and theft. Parental controls keep kids safe.",
                        Image = $"https://www.bullguard.com/shop/Content/Img/Site2016/product_box_ms.png",
                        Price = "19.95 $"
                    }
                );
        }

        public override Product FindByName(string name)
        {
            return products.SingleOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public override IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Product> FindAll()
        {
            return products;
        }

        public override Product FindById(int id)
        {
            return products.SingleOrDefault(x => x.ProductId == id);
        }
    }
}