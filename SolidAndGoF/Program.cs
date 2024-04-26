// See https://aka.ms/new-console-template for more information
using SolidAndGoF.SOLID.SingleResponsability;
using Solid_BeforeS = SolidAndGoF.SOLID.SingleResponsability.ClassToRefactor;
using Solid_AfterS = SolidAndGoF.SOLID.SingleResponsability.ClassRefactored;
using Solid_BeforeO = SolidAndGoF.SOLID.OpenClose.ClassToRefactor;
using Solid_AfterO = SolidAndGoF.SOLID.OpenClose.ClassRefactored;
using Solid_BeforeeL = SolidAndGoF.SOLID.LiskovSubstitution.ClassToRefactor;
using Builder = SolidAndGoF.GoF.Creational.Builder;
using FluentBuilder = SolidAndGoF.GoF.Creational.FluentBuilder;
using FactoryMethod = SolidAndGoF.GoF.Creational.FactoryMethod;
using AbstractFactory = SolidAndGoF.GoF.Creational.AbstractFactory;
using ProductsAndCategories = SolidAndGoF.GoF.Creational.Prototype.ProductsAndCategories;
using static SolidAndGoF.GoF.Creational.Prototype.DeepCopyExtension;
using SolidAndGoF.GoF.Creational.Singleton;
using static SolidAndGoF.GoF.Structural.Adapter.XmlAdapter;
using static SolidAndGoF.GoF.Structural.Bridge.DeductionsInPayRoll;
using SolidAndGoF.GoF.Structural.Composite;
using SolidAndGoF.GoF.Structural.Decorator;
using SolidAndGoF.GoF.Structural.Facade;
using static SolidAndGoF.GoF.Structural.Facade.Routine;
using SolidAndGoF.GoF.Structural.FlyWeight;
using SolidAndGoF.GoF.Structural.Proxy;
using SolidAndGoF.GoF.Behivor.ChainResponsability;
using static SolidAndGoF.GoF.Behivor.Command.eShop;
using SolidAndGoF.GoF.Behivor.Command;
using SolidAndGoF.GoF.Behivor.Interpreter;
using SolidAndGoF.GoF.Behivor.Iterator;
using static SolidAndGoF.GoF.Behivor.Iterator.ShapesIterator;
using SolidAndGoF.GoF.Behivor.Memento;
using SolidAndGoF.GoF.Behivor.Mediator;
using SolidAndGoF.GoF.Behivor.NullObject;
using static SolidAndGoF.GoF.Behivor.Observer.GroceryStore;
using SolidAndGoF.GoF.Behivor.Observer;
using static SolidAndGoF.GoF.Behivor.Observer.SchoolNotification;
using SolidAndGoF.GoF.Behivor.State;


//Console.WriteLine("SOLID");
//Console.WriteLine("========================================");
//Console.WriteLine("SingleResponsability");
//Console.WriteLine("========================================");
//Console.WriteLine("Before:");
//Solid_BeforeS solid_BeforeS = new Solid_BeforeS();
//solid_BeforeS.Handle1("solid_BeforeS1.txt");
//solid_BeforeS.Handle2("solid_BeforeS2.txt");
//solid_BeforeS.Handle3("solid_BeforeS3.txt");
//solid_BeforeS.Handle4("solid_BeforeS4.txt");
//Console.WriteLine("Check .\\solid_BeforeS1.txt, .\\solid_BeforeS2.txt, .\\solid_BeforeS3.txt, .\\solid_BeforeS4.txt");
//Console.WriteLine("After:");
//Solid_AfterS solid_AfterS = new Solid_AfterS();
//solid_AfterS.Handle1("solid_AfterS1.txt");
//solid_AfterS.Handle2("solid_AfterS2.txt");
//solid_AfterS.Handle3("solid_AfterS3.txt");
//solid_AfterS.Handle4("solid_AfterS4.txt");
//Console.WriteLine("Check .\\solid_BeforeS1.txt, .\\solid_AfterS2.txt, .\\solid_AfterS3.txt, .\\solid_AfterS4.txt");

//Console.WriteLine("========================================");
//Console.WriteLine("OpenClose");
//Console.WriteLine("========================================");
//Console.WriteLine("Before:");
//Solid_BeforeO solid_BeforeO = new Solid_BeforeO();
//solid_BeforeO.Handle1();
//Console.WriteLine("After:");
//Solid_AfterO solid_AfterO = new Solid_AfterO();
//solid_AfterO.Handle1();

//Console.WriteLine("========================================");
//Console.WriteLine("LiskovSubstitution");
//Console.WriteLine("========================================");
//Console.WriteLine("Before:");
//Solid_BeforeeL solid_BeforeeL = new Solid_BeforeeL();
//solid_BeforeeL.Handle1();
//solid_BeforeeL.Handle2();
//solid_BeforeeL.Handle3();

//Console.WriteLine("========================================");
//Console.WriteLine("GOF: BUILDER");
//Console.WriteLine("========================================");
//var burger1 = new Builder.BurgerAssembly(new Builder.CheeseBurger());
//burger1.AssembleBurguer();
//Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(burger1.GetBurguer));


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: FLUENT BUILDER");
//Console.WriteLine("========================================");
//var burger2 = new FluentBuilder.BurgerBuilder().WithBread().WithProtein().WithCheese().WithCondiments().Burger;
//Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(burger2));


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Factory Method");
//Console.WriteLine("========================================");
//var user1 = FactoryMethod.User.Factory.CreateColombianUser("Cristian", "example@domain.com");
//Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user1));

//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Abstract Factory");
//Console.WriteLine("========================================");
//AbstractFactory.PizzaAbstractFactoryRemaked.PizzaStore myStore = new AbstractFactory.PizzaAbstractFactoryRemaked.ColombiaStore();
//AbstractFactory.PizzaAbstractFactoryRemaked.Pizza pizza1 = myStore.Order(AbstractFactory.PizzaAbstractFactoryRemaked.PizzaType.Pepperoni);
//Console.WriteLine($"Pizza {pizza1.Name} is ready.");
//AbstractFactory.PizzaAbstractFactoryRemaked.Pizza pizza2 = myStore.Order(AbstractFactory.PizzaAbstractFactoryRemaked.PizzaType.Hawaiian);
//Console.WriteLine($"Pizza {pizza2.Name} is ready.");


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Prototype");
//Console.WriteLine("========================================");
//ProductsAndCategories.Product product1 = new ProductsAndCategories.Product("Aleza Dot 4", new ProductsAndCategories.Category("Technology"));
//var product2 = product1.DeepCopy();
//product2.Name = "Laptop Lenovo 21 inches, 32 GB Ram";
//product2.Category.Name = "Computers";
//Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(product1));
//Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(product2));


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Singletone");
//Console.WriteLine("========================================");
//var configuration1 = Configuration.Intance();
//var configuration2 = Configuration.Intance();
//var configuration3 = Configuration.Intance();
//configuration1.GetConfiguration("CompanyAddress");
//Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(configuration1.GetConfiguration("CompanyAddress")));

//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Adapter");
//Console.WriteLine("========================================");
//var jsonHandler = new ProductJsonAdapter();
//var xmlAdapter = new ProductXmlAdapter(jsonHandler);
//Console.WriteLine(jsonHandler.GetProductJson());
//Console.WriteLine(xmlAdapter.GetProductXml());


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Bridge ");
//Console.WriteLine("========================================");
//PayRollHandler payRollHandler = new PayRollHandler();
//var developer = new Devleloper(payRollHandler) { Name = "Elizabeth Rendon" };
//var scrumMaster = new ScrumMaster(payRollHandler) { Name = "Paola Lasso" };
//developer.GetPayRoll();
//scrumMaster.GetPayRoll();


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Composite ");
//Console.WriteLine("========================================");
//OrganizationalUnit.Employee Juan = new OrganizationalUnit.TeamMember("Juan Marnitez", 1000);
//OrganizationalUnit.Employee Marck = new OrganizationalUnit.TeamMember("Marck Solis", 2000);
//OrganizationalUnit.Employee Maria = new OrganizationalUnit.TeamMember("Maria Nicholson", 1800);
//OrganizationalUnit.Employee Carla = new OrganizationalUnit.TeamLead("Carla Solano", 4000);
//Carla.AddMember(Juan);
//Carla.AddMember(Marck);
//Carla.AddMember(Maria);
//Console.WriteLine($"The cost of the Carlas's team is :{Carla.GetCost()}");
//Console.WriteLine($"The cost of Juan is :{Juan.GetCost()}");


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Decorator ");
//Console.WriteLine("========================================");
//var Coffe = new CoffeShop.AdditionOfCream(new CoffeShop.AdditionOfChocolate(new CoffeShop.AdditionOfMilk (new CoffeShop.Basic())));
//Console.WriteLine($"The cost of {Coffe.GetDescription()} is:{Coffe.GetCost()}");
//var Coffe2 = new CoffeShop.AdditionOfCream(new CoffeShop.AdditionOfMilk(new CoffeShop.Basic()));
//Console.WriteLine($"The cost of {Coffe2.GetDescription()} is:{Coffe2.GetCost()}");


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Facade ");
//Console.WriteLine("========================================");
//var house = new Routine.Running();
//house.GoRunning();
//Console.WriteLine($"The state of music is {MusicController.IsOn} and the running is {RunningController.IsOn}");
//house.CompleteRunning();
//Console.WriteLine($"The state of music is {MusicController.IsOn} and the running is {RunningController.IsOn}");


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: FlyWeight ");
//Console.WriteLine("========================================");
//var shapes = new Shapes.ShapeObjectFactory();
//Console.WriteLine(shapes.GetShape("Rectangle").Print());
//Console.WriteLine($"Number of objects created: {shapes.TotalObjectsCreated}");
//Console.WriteLine(shapes.GetShape("Rectangle").Print());
//Console.WriteLine($"Number of objects created: {shapes.TotalObjectsCreated}");
//Console.WriteLine(shapes.GetShape("Circle").Print());
//Console.WriteLine($"Number of objects created: {shapes.TotalObjectsCreated}");
//Console.WriteLine(shapes.GetShape("Circle").Print());
//Console.WriteLine(shapes.GetShape("Circle").Print());
//Console.WriteLine($"Number of objects created: {shapes.TotalObjectsCreated}");


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Proxy ");
//Console.WriteLine("========================================");
//var client = new Restaurant.ProxyPerson(new Restaurant.Person(10000));
//Console.WriteLine(client.Eat());
//var client2 = new Restaurant.ProxyPerson(new Restaurant.Person(0));
//Console.WriteLine(client2.Eat());


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Chain Responsability ");
//Console.WriteLine("========================================");
//var editorJr = new Editorial.EditorLJr();
//var editorSsr = new Editorial.EditorLSsr();
//var editorSr = new Editorial.EditorLSr();
//var excecutive = new Editorial.Executive();
//editorJr.SetSuccessor(editorSsr);
//editorSsr.SetSuccessor(editorSr);
//editorSr.SetSuccessor(excecutive);
//Console.WriteLine(editorJr.HandleRequest(new Editorial.Document("Zap", "Text 1234")));
//Console.WriteLine(editorJr.HandleRequest(new Editorial.Document("Foo", "Text 12345 123")));
//Console.WriteLine(editorJr.HandleRequest(new Editorial.Document("Bar", "Text 12345 1234 123")));
//Console.WriteLine(editorJr.HandleRequest(new Editorial.Document("Zaz", "Text 12345 1234 1234 123")));

//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Chain Responsability ");
//Console.WriteLine("========================================");
//var editorJr = new Editorial.EditorLJr();
//var editorSsr = new Editorial.EditorLSsr();
//var editorSr = new Editorial.EditorLSr();
//var excecutive = new Editorial.Executive();
//editorJr.SetSuccessor(editorSsr);
//editorSsr.SetSuccessor(editorSr);
//editorSr.SetSuccessor(excecutive);
//Console.WriteLine(editorJr.HandleRequest(new Editorial.Document("Zap", "Text 1234")));
//Console.WriteLine(editorJr.HandleRequest(new Editorial.Document("Foo", "Text 12345 123")));
//Console.WriteLine(editorJr.HandleRequest(new Editorial.Document("Bar", "Text 12345 1234 123")));
//Console.WriteLine(editorJr.HandleRequest(new Editorial.Document("Zaz", "Text 12345 1234 1234 123")));


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Command ");
//Console.WriteLine("========================================");
//var modifyPrice = new ModifyPriceCommand();
//var product = new eShop.Product("IPhone", 5000);
//Console.WriteLine(product);
//modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Increase, 100));
//modifyPrice.Invoke();
//modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Increase, 500));
//modifyPrice.Invoke();
//// action not allowed
//modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Decrease, 30000));
//modifyPrice.Invoke();
//Console.WriteLine(product);
//modifyPrice.Undo();
//Console.WriteLine(product);


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Interperter ");
//Console.WriteLine("========================================");
//Console.WriteLine(new Calc.ExpressionParser().Calculate("1+2").ToString());
//Console.WriteLine(new Calc.ExpressionParser().Calculate("5-2").ToString());
//Console.WriteLine(new Calc.ExpressionParser().Calculate("3-2").ToString());


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Iterator ");
//Console.WriteLine("========================================"); ;
//var shapesFactory = new ShapesIterator.ShapeCollection();
//var iterator = shapesFactory.CreateIterator();
//while (iterator.HasNext())
//{
//    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(iterator.Next()));
//}



//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Mememto ");
//Console.WriteLine("========================================"); ;
//var product = new StockRecover.Product(1000);
//Console.WriteLine("The price is: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(product.Price));
//product.ChangePrice(300);
//product.ChangePrice(200);
//product.ChangePrice(-100);
//Console.WriteLine("The price is: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(product.Price));
//product.Undo();
//Console.WriteLine("The price before undo is: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(product.Price));
//product.Undo();
//Console.WriteLine("The price before undo is: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(product.Price));
//product.Undo();
//Console.WriteLine("The price before undo is: {0}", Newtonsoft.Json.JsonConvert.SerializeObject
//(product.Price));
//product.Redo();
//Console.WriteLine("The price before redo is: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(product.Price));


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Mediator");
//Console.WriteLine("========================================"); ;
//var mediator = new xboxRoom.Mediator();
//var player = new xboxRoom.Boy(mediator);
//var room = new xboxRoom.PlayRoom(mediator);
//mediator.RegisterBoy(player);
//mediator.RegisterPlayRoom(room);
//Console.WriteLine("The room is {0}", mediator.IsPlayRoomAvailable() ? "available": "not available");
//Console.WriteLine("The boy {0} play ", player.Play() ? "can" : "can't");
//room.GivePermission();
//Console.WriteLine("The room is {0}", mediator.IsPlayRoomAvailable() ? "available" : "not available");
//Console.WriteLine("The boy {0} play ", player.Play() ? "can" : "can't");


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Null Object");
//Console.WriteLine("========================================"); ;
//var store = new MobileShop.MobileRepository();
//store.GetMobileByName("samsung").TurnOn();
//store.GetMobileByName(null).TurnOn();


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Observer basic");
//Console.WriteLine("========================================"); ;
//var lemon = new GroceryStore.Lemon(0.82);
//lemon.Attach(new GroceryStore.Restaurant("Giobanni's Pizza", 0.77));
//lemon.Attach(new GroceryStore.Restaurant("La Gloria", 0.74));
//lemon.Attach(new GroceryStore.Restaurant("The big boss", 0.75));
//// change price
//lemon.PricePerKg = 0.79;
//Console.WriteLine("");
//lemon.PricePerKg = 0.76;
//Console.WriteLine("");
//lemon.PricePerKg = 0.74;
//Console.WriteLine("");
//lemon.PricePerKg = 0.81;


//Console.WriteLine("========================================");
//Console.WriteLine("GOF: Observer Advance");
//Console.WriteLine("========================================"); ;
//SchoolNotification.Teacher teacherOne = new SchoolNotification.Teacher("Math");
//teacherOne.Updates += Student.TeacherNotification;
//teacherOne.Evaluate("Maria", 5);
//teacherOne.Evaluate("Jhon", 4.8);
//teacherOne.Evaluate("Michael", 4.4);
//teacherOne.Evaluate("Carolina", 2.4);


Console.WriteLine("========================================");
Console.WriteLine("GOF: State");
Console.WriteLine("========================================"); ;


var currentStatus = TrafficLightController.State.Red;
int option = 0;
do {
    var result = TrafficLightController.StateMachine[currentStatus];
    Console.WriteLine($"The current status is: {currentStatus}");
    Console.WriteLine($"Select a option:");
    for (int i = 0; i < result.Count; i++)
    {
        Console.WriteLine($"{i}: {result.Keys.ElementAt(i)}");

    }
    Console.WriteLine($"99: Exit");
    option = int.Parse(Console.ReadLine());
    currentStatus = result.Values.ElementAt(option);

} while (option != 99);



Console.ReadLine();