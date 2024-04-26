using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.Iterator
{
    public class ShapesIterator
    {
        public interface IIterator<T>
        {
            bool HasNext();
            T Next();
        }

        public class Shape
        {
            public string Name { get; private set; }

            public Shape(string name)
            {
                Name = name;

            }

        }

        public class ShapeCollection
        {
            private List<Shape> _shapes;

            public ShapeCollection()
            {
                _shapes = new List<Shape>();
                AddItem("Circulo");
                AddItem("Cuadrado");
                AddItem("Rectangulo");
            }

            public IIterator<Shape> CreateIterator() => new ShapeIterator(_shapes.ToArray());

            public void AddItem(string name)
            {
                Shape shape = new Shape(name);
                _shapes.Add(shape);
            }

        }

        public class ShapeIterator : IIterator<Shape>
        {
            private int _position = 0;
            private Shape[] _collection;

            public ShapeIterator(Shape[] collection)
            {
                _collection = collection;
            }

            public bool HasNext() => _position < _collection.Length && _collection[_position] != null;

            public Shape Next()
            {
                Shape shape = _collection[_position];
                _position++;
                return shape;
            }
        }
    }
}
