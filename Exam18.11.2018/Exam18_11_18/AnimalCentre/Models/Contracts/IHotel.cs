namespace AnimalCentre.Models.Contracts
{
    using AnimalCentre.Models.Animals;
    using System.Collections.Generic;

    public interface IHotel
    {
        IReadOnlyCollection <IAnimal> AnimalsInHotel { get; }
        int Capacit { get; }

        void Accommodate(IAnimal animal);
        void Adopt(string animalName, string owner);
    }
}
