namespace P03_Wild_Farm.Animals
{
    public abstract class Feline : Animal
    {
        private string breed;
        private string livingRegion;


        public Feline(string name, double weight, string livingRegion, string breed) : base(name, weight)
        {
            this.Breed = breed;
            this.LivingRegion = livingRegion;
        }

        public string Breed
        {
            get
            {
                return breed;
            }
            set
            {
                breed = value;
            }
        }

        public string LivingRegion
        {
            get => livingRegion;
            set => livingRegion = value;
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
