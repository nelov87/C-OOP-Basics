using P03_Wild_Farm.Animals;
using P03_Wild_Farm.Animals.Birds.Factory;
using P03_Wild_Farm.Animals.Felines.Factory;
using P03_Wild_Farm.Animals.Mammals.Factory;
using P03_Wild_Farm.Foods.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Wild_Farm.Core
{
    public class Engine
    {
        private BirdFactory birdFactory;
        private FelinesFactory felineFactory;
        private MammalFactory mammalFactory;
        private FoodFactory foodFactory;
        private List<Animal> animals;
        private Animal animal;

        public Engine()
        {
            this.birdFactory = new BirdFactory();
            this.felineFactory = new FelinesFactory();
            this.mammalFactory = new MammalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
           
        }

        public void Run()
        {
    //• Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
    //• Birds - "{Type} {Name} {Weight} {WingSize}";
    //• Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";

            string input = Console.ReadLine();
            
            while (input != "End")
            {
                try
                {
                    string[] animalInfo = input.Split();
                    string[] foodInfo = Console.ReadLine().Split();
                    string type = animalInfo[0];
                    string name = animalInfo[1];
                    double weigth = double.Parse(animalInfo[2]);


                    if (type == "Hen" || type == "Owl")
                    {
                        double wingSize = double.Parse(animalInfo[3]);
                        animal = this.birdFactory.CreateBirds(type, name, weigth, wingSize);

                    }
                    else if (type == "Mouse" || type == "Dog")
                    {
                        string livingRegion = animalInfo[3];
                        animal = this.mammalFactory.CreateMammal(type, name, weigth, livingRegion);
                    }
                    else if (type == "Cat" || type == "Tiger")
                    {
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];
                        animal = this.felineFactory.CreateFeline(type, name, weigth, livingRegion, breed);
                    }
                    var food = foodFactory.CreateFood(foodInfo[0], int.Parse(foodInfo[1]));

                    animals.Add(animal);
                    animal.AskForFood();
                    animal.Eat(food);
                    
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
                


                input = Console.ReadLine();
                
            }


            foreach (var animal in animals)
            {

                Console.WriteLine(animal);
            }

        }
    }
}
