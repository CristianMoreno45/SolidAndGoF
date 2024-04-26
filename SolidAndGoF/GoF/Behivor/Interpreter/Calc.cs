using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.Interpreter
{
    public class Calc
    {
        public class ExpressionParser
        {
            public int Calculate(string expression)
            {
                Console.WriteLine($"the expresion is: '{expression}'");
                Stack<IExpression> res = new Stack<IExpression>();
                foreach (var symbol in expression)
                {

                    switch (symbol)
                    {
                        case '+':
                            res.Push(new AdditionExpression());
                            break;
                        case '-':
                            res.Push(new SubstractionExpression());
                            break;
                        default:
                            try
                            {
                                if (res.Count == 2)
                                {
                                    var operation = res.Pop();
                                    if (operation is AdditionExpression)
                                        res.Push(new AdditionExpression(
                                                res.Pop().Interpreter(),
                                                new NumericExpression(symbol).Interpreter()
                                        ));
                                    if (operation is SubstractionExpression)
                                        res.Push(new SubstractionExpression(
                                                res.Pop().Interpreter(),
                                                new NumericExpression(symbol).Interpreter()
                                        ));
                                }
                                else
                                {
                                    res.Push(new NumericExpression(symbol));
                                }
                            }
                            catch
                            {
                                return 0;
                            }

                            break;
                    }
                }
                var result = res.Pop().Interpreter();
                return result;
            }

        }
        public interface IExpression
        {
            int Interpreter();
        }

        public class NumericExpression : IExpression
        {
            private int _number = 0;

            public NumericExpression(char number)
            {
                int intnumber = 0;
                if (int.TryParse(number.ToString(), out intnumber))
                    _number = intnumber;
                else
                    throw new Exception("It is not a number");

            }
            public int Interpreter()
            {
                return _number;
            }
        }
        public class AdditionExpression : IExpression
        {
            private int _n1 = 0;
            private int _n2 = 0;
            public AdditionExpression() { }
            public AdditionExpression(int n1, int n2)
            {
                _n1 = n1;
                _n2 = n2;
            }
            public int Interpreter()
            {
                return _n1 + _n2;
            }
        }
        public class SubstractionExpression : IExpression
        {
            private int _n1 = 0;
            private int _n2 = 0;
            public SubstractionExpression() { }
            public SubstractionExpression(int n1, int n2)
            {
                _n1 = n1;
                _n2 = n2;
            }
            public int Interpreter()
            {
                return _n1 - _n2;
            }
        }
    }
}
