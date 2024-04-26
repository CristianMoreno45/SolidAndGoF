namespace SolidAndGoF.SOLID.LiskovSubstitution
{
    public class ClassRefactored
    {

        // Define common interface
        public interface IAnimal
        {
            string Noise { get; set; }
            void MakeNoise();
        }

        // Implement common interface
        public class Animal: IAnimal
        {
            public string Noise { get; set; }
            public virtual void MakeNoise()
            {
                Console.WriteLine(Noise);
            }
        }


        // Define concrete interface
        public interface ICanFly: IAnimal
        {
            void Fly();
        }

        public class Dog : Animal
        {
            public Dog()
            {
                Noise = "wof wof!";
            }          
        }
        public class Parrot : Animal, ICanFly
        {
            public Parrot()
            {
                Noise = "Rrrrrua!";
            }
            public virtual void Fly()
            {
                Console.WriteLine("I'm Flying");
            }
        }



        public void Handle1()
        {
            try
            {
                Animal animal = new Animal();
                animal.Noise = "Pio pio!";
                animal.MakeNoise();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public void Handle2()
        {
            try
            {
                IAnimal animal = new Dog();
                animal.MakeNoise();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public void Handle3()
        {
            try
            {
                ICanFly animal = new Parrot();
                animal.MakeNoise();
                animal.Fly();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

    }
}
