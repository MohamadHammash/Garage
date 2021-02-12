using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageApplikation
{
    class GarageHandler
    {
        private Garage<Vehicle> garage;
        private ConsoleUI ui;
        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
            ui = new ConsoleUI();
        }
        public void Seed()
        {
            var vehicles = GetVehicles();

            foreach (var vehicle in vehicles)
            {
                garage.Add(vehicle);
            }
        }
        private IEnumerable<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                (new Car("ABC123", "Black", 4, "Petrol")),
                (new AirPlane("a1256", "Grey", 9, 4)),
                (new Bus("XYZ789", "Orange", 6, 36)),
                (new Boat("CGT25", "White and Blue", 1 , 6.8)),
                (new MotorCycle("CT255", "Black and Red", 2, 3.2))
            };
        }
        internal List<Vehicle> GetAll()
        {
            return garage.ToList();
        }
        public Vehicle RemoveVehicle(string regNr) // toDo: check if it's working
        {
            // var vehicleToRemove = garage.Where(v => v.RegNr == regNr).Select(v => regNr.(Equals(v.RegNr, StringComparison.InvariantCultureIgnoreCase)));
            var vehicleToRemove = garage.FirstOrDefault(v => regNr.Equals(v.RegNr, StringComparison.InvariantCultureIgnoreCase));
            garage.ToList().Remove(vehicleToRemove);
           
            return vehicleToRemove;
        }
        internal string GetVehiclesCount()
        {
            return $"The Garage has {GetVehicles().Count()} Vehicles";
        }
        public Car CreateCar(string regNr, string color, int nrOfWheels, string fuelType)
        {
                    var car = new Car(regNr, color, nrOfWheels, fuelType);
                    garage.Add(car);
                    return car;
        }
        public AirPlane CreateAirPlane(string regNr, string color, int nrOfWheels, int nrOfEngines)
        {
            var airPlane = new AirPlane(regNr, color, nrOfWheels, nrOfEngines);
            garage.Add(airPlane);
            return airPlane;
        }
        public MotorCycle CreateMotorCycle(string regNr, string color, int nrOfWheels, double cylinderVolume)
        {
            var motorCycle = new MotorCycle(regNr, color, nrOfWheels, cylinderVolume);
            garage.Add(motorCycle);
            return motorCycle;
        }
        public Bus CreateBus(string regNr, string color, int nrOfWheels, int nrOfSeats)
        {
            var bus = new Bus(regNr, color, nrOfWheels, nrOfSeats);
            garage.Add(bus);
            return bus;
        }
        public Boat CreateBoat(string regNr, string color, int nrOfWheels, double boatLength)
        {
            var boat = new Boat(regNr, color, nrOfWheels, boatLength);
            garage.Add(boat);
            return boat;
        }
        internal bool GarageIsFull()
        {
            //return garage.FirstOrDefault(v => v == null ) is null ? false : true; //NotSure
            return garage.IsFull;

            //foreach (var item in garage)
            //{
            //    if (item is null)
            //    {
            //        return false;
            //    }
            //}

            //return true;
            //garage.ToList().TrimExcess();
            //if (garage.Count() < garage.ToArray().Length)
            //{
            //    return false; 
            //}
            //else
            //{
            //    return true;
            //}
        }

        internal bool RegNrExists(string regNr)
        {
             return garage.FirstOrDefault(v =>  regNr.Equals(v.RegNr, StringComparison.InvariantCultureIgnoreCase)) is null ? false : true;
            #region CodeExplanation

            //Review: this does exactly like the code below:
            //foreach (var vehicle in garage)
            //{
            //    if(vehicle.RegNr == regNr)
            //    {
            //        return true;
            //    }

            //}
            //return false;
            #endregion
        }

        internal void Countdown()
        {
            garage.Count--; // NotSure
        }

        internal string GetNewVehiclesCount()
        {
            return $"The Garage has {garage.Count()} Vehicles";
        }
    }
}
