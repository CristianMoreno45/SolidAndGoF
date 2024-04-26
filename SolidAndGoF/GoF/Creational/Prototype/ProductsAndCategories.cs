using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static SolidAndGoF.GoF.Creational.Prototype.ProductsAndCategories;

namespace SolidAndGoF.GoF.Creational.Prototype
{
    /// <summary>
    /// It allows you to copy existing objects without the code depending on their classes.
    /// </summary>
    public class ProductsAndCategories
    {
        [Serializable]
        public class Category
        {
            public string Name { get; set; }
            public Category(string name)
            {
                Name = name;
            }

        }

        [Serializable]
        public class Product
        {
            public string Name { get; set; }
            public Category Category { get; set; }
            public Product(string name, Category category)
            {
                Name = name;
                Category = category;
            }

        }
    }

    public static class DeepCopyExtension
    {
        public static T DeepCopy<T>(this T self)
        {
            using var stream = new MemoryStream();
            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(stream, self);
            stream.Position = 0;
            return (T)serializer.ReadObject(stream);
        }
    }
}
