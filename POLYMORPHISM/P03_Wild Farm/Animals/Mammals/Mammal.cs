namespace P03_Wild_Farm.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get
            {
                return livingRegion;
            }
            set
            {
                livingRegion = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
