namespace SolidAndGoF.SOLID.LiskovSubstitution
{
    public class ClassToRefactor
    {
        public class Animal
        {
            public string Noise { get; set; }
            public virtual void MakeNoise()
            {
                Console.WriteLine(Noise);
            }

            public virtual void Fly()
            {
                Console.WriteLine("I'm Flying");
            }

        }

        public class Dog : Animal
        {
            public Dog()
            {
                Noise = "wof wof!";
            }

            public override void Fly()
            {
                throw new NotImplementedException("Sorry, I canot fly.");
            }
        }
        public class Parrot : Animal
        {
            public Parrot()
            {
                Noise = "Rrrrrua!";
            }
        }



        public void Handle1()
        {
            try
            {
                Animal animal = new Animal();
                animal.Noise = "Pio pio!";
                animal.MakeNoise();
                animal.Fly();
                Console.WriteLine($"Error: The chicken cannot fly, it should be controled by self.");
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
                Animal animal = new Dog();
                animal.MakeNoise();
                animal.Fly();
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
                Animal animal = new Parrot();
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
