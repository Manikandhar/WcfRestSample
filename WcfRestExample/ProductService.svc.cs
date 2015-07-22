using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace WcfRestExample {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(MaxItemsInObjectGraph = 65536000, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ProductService : IProductService {
        private static List<Product> products = new List<Product>();
        public ProductService() {
            for (int i = 0; i < 3; i++) {
                products.Add(new Product() {
                    Id = i,
                    Cost = i * 3.33m,
                    IsInStock = new Random().NextDouble() == 0.5,
                    Name = "Product " + i
                });
            }
        }

        public List<Product> GetAllProducts() {
            return products;
        }

        public Product GetProduct(string id) {
            int productId;
            if (int.TryParse(id, out productId)) {
                var product = products.FirstOrDefault(x => x.Id.Equals(productId));
                return product;
            }
            return null;
        }

        public string AddProduct(Product product) {
            var newId = products.Count + 1;
            product.Id = newId;
            products.Add(product);
            return newId.ToString();
        }

        public string DeleteProduct(string id) {
            int productId;
            if (int.TryParse(id, out productId)) {
                var product = products.FirstOrDefault(x => x.Id.Equals(productId));
                if (product != null) {
                    products.Remove(product);
                    return "Deleted Successfully...";
                }
            }
            return "Could not delete...";
        }

    }
}
