using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static SolidAndGoF.GoF.Structural.Adapter.XmlAdapter;

namespace SolidAndGoF.GoF.Structural.Adapter
{
    /// <summary>
    /// Allows collaboration between objects with incompatible interfaces.
    /// </summary>
    public class XmlAdapter
    {
        public class Product
        {
            public Product(string name, double price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; set; }
            public double Price { get; set; }
        }

        public class ProductDataProvider()
        {
            public List<Product> GetProductList()
            {
                return new List<Product>() {
                    new Product("Notebook", 2),
                    new Product("Pencil", 0.45),
                    new Product("Eraser", 0.2),
                    new Product("Pencil sharpener", 0.3),
                };
            }
        }

        // This the source
        public interface IProductJsonAdapter
        {
            string GetProductJson();
        }
        public class ProductJsonAdapter : IProductJsonAdapter
        {
            public string GetProductJson()
            {
                ProductDataProvider db = new ProductDataProvider();
                return Newtonsoft.Json.JsonConvert.SerializeObject(db.GetProductList(), Newtonsoft.Json.Formatting.Indented);
            }
        }

        // This is the adapter of source 
        public interface IProductXmlAdapter
        {
            XDocument GetProductXml();
        }

        public class ProductXmlAdapter : IProductXmlAdapter
        {
            IProductJsonAdapter _productJsonAdapter;
            public ProductXmlAdapter(IProductJsonAdapter productJsonAdapter)
            {
                _productJsonAdapter = productJsonAdapter;
            }


            public XDocument GetProductXml()
            {

                XDocument response = new();
                XElement xelement = new("Products");
                xelement.Add(
                    Newtonsoft.Json.JsonConvert
                    .DeserializeObject<IEnumerable<Product>>(_productJsonAdapter.GetProductJson())
                    .Select(p => new XElement("Product",
                    new XAttribute("Name", p.Name), new XAttribute("Price", p.Price)
                    )));

 
                response.Add(xelement);
                return response;

                /*
                 * ,
                 */

            }
        }


    }
}
