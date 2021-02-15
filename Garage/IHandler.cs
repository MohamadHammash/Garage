namespace GarageApplikation
{
    interface IHandler
    {
        AirPlane CreateAirPlane(string regNr, string color, int nrOfWheels, int nrOfEngines);
        Boat CreateBoat(string regNr, string color, int nrOfWheels, double boatLength);
        Bus CreateBus(string regNr, string color, int nrOfWheels, int nrOfSeats);
        Car CreateCar(string regNr, string color, int nrOfWheels, string fuelType);
        MotorCycle CreateMotorCycle(string regNr, string color, int nrOfWheels, double cylinderVolume);
        Vehicle RemoveVehicle(string regNr);
        void Seed();
    }
}