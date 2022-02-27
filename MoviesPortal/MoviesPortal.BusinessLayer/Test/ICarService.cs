using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.DataLayer.Test
{
    public interface ICarService
    {
        void AddCar();
    }

    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public void AddCar()
        {
            // dodanie samochodu do bazy
            carRepository.AddCarToDatabase();
        }
    }
}
