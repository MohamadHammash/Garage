using System;
using System.Collections.Generic;

namespace GarageApplikation
{
    internal class GarageManager
    {
        private ConsoleUI ui;
        private GarageHandler handler;

       
        public GarageManager()
        {
            ui = new ConsoleUI();
        }
        internal void Run()
        {
            CreateOrExisting();
        }
        private void CreateOrExisting()
        {
            bool success = true;
            do
            {
                ui.CreateOrExisting();
                int input = ui.AskForInteger();
                switch (input)
                {
                    case 1:
                        StartMenu();
                        CreateMainMenu();
                        break;

                    case 2:
                        ExistingMainMenu();
                        break;

                    default:
                        success = false;
                        ui.Print("Please enter a valid choice");
                        break;
                }
            } while (!success);
        }
        private void ExistingMainMenu()
        {
            Seed();
            bool sucess = true;
            ui.ShowExistingMainMenu();
            do
            {
                int input = ui.AskForInteger();
                switch (input)
                {
                    case 1:
                        GetVehiclesNumbers();
                        break;
                    case 2:
                        PrintAll();
                        break;
                    case 3:
                        if (CheckGarageIsFull()) { ExistingMainMenu(); } 
                        AddVehicle();
                        AddAgain(); // ToDo: Change this
                        break;
                    case 4:
                        RemoveVehicle();
                        RemoveAgain();
                        break;
                    case 5:
                        FindExistingVehicle();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        sucess = false;
                        ui.Print("Please enter a valid choice");
                        break;
                }
            } while (!sucess);
        }
        private void FindExistingVehicle() // todo : check here
        {

        }
        private void StartMenu()
        {
            bool sucess = false;
            ui.Print("Welcome! To create a new garage please enter the garage's capacity");
            do
            {

                if (int.TryParse(ui.GetInput(), out int capacity))
                {

                    handler = new GarageHandler(capacity);
                    if (capacity <= 0)
                    {
                        sucess = false;
                        ui.Print("The garage must have a capacity for at least 1 vehicle!");
                    }
                    else
                    {
                        sucess = true;
                    }
                }
                else
                {
                    sucess = false;
                    Console.WriteLine("Please enter a valid choice");
                }

            } while (!sucess);

        }
        private void CreateMainMenu()
        {
            bool sucess = true;
            ui.ShowCreateMainMenu();
            do
            {
                int input = ui.AskForInteger();
                switch (input)
                {
                    case 1:
                        if (CheckGarageIsFull()) { CreateMainMenu(); }
                        AddVehicle();
                        AddAgain();
                        break;
                    case 2:
                        RemoveVehicle();
                        RemoveAgain();
                        break;
                    case 3:
                        GetNewVehiclesNumbers();

                        break;
                    case 4:
                        PrintAll();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        sucess = false;
                        ui.Print("Please enter a valid choice");
                        break;
                }
            } while (!sucess);
        }
        private bool CheckGarageIsFull()
        {
            if (handler.GarageIsFull())
            {
                ui.Print("The garage is already full!");
                return true;
            }
            else
            {
            return false;
            }
        }
        private void RemoveVehicle()
        {
            ui.Print("Please enter the Registration number of the Vehicle you would like to remove.");
            var regNr = ui.AskForString();
            var vehicleToRemove = handler.RemoveVehicle(regNr);
            if (vehicleToRemove != null)
            {
                ui.Print($"a vehicle of type {vehicleToRemove.GetType().Name} and Register number {vehicleToRemove.RegNr} has been removed");
                handler.Countdown();
            }
            else
            {
                ui.Print("The garage is already empty!");
            }
        }
        private void AddVehicle()
        {
            bool success = true;
            ui.VehiclesMenu();
            do
            {
                int input = ui.AskForInteger();

                switch (input)
                {
                    case 1:
                        AddCar();
                        break;
                    case 2:
                        AddAirPlane();
                        break;
                    case 3:
                        AddMotorCycle();
                        break;
                    case 4:
                        AddBus();
                        break;
                    case 5:
                        AddBoat();
                        break;
                    case 9:
                        Console.Clear();
                        Run();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        success = false;
                        ui.Print("Please enter a valid choice");
                        break;
                }
            } while (!success);
        }
        private void AddAgain()
        {
            do
            {
                ui.AddAgainMenu();
                int input = ui.AskForInteger();
                switch (input)
                {
                    case 1:
                        if (CheckGarageIsFull()) { AddAgain(); }
                        AddVehicle();
                        break;
                    case 2:
                        CreateMainMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Run();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        ui.Print("Please enter a valid choice");
                        break;
                }
            } while (true);
        }
        private void RemoveAgain()
        {
            do
            {
                ui.RemoveAginMenu();
                int input = ui.AskForInteger();
                switch (input)
                {
                    case 1:
                        RemoveVehicle();
                        break;
                    case 2:
                        CreateMainMenu(); //ToDo: change this
                        break;
                    case 3:
                        Console.Clear();
                        Run();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        ui.Print("Please enter a valid choice");
                        break;
                }
            } while (true);
        }
        private Boat AddBoat()
        {
            string regNr = CheckRegNr();
            string color = ui.GetColor();
            int nrOfWheels = ui.GetNrOfWheels();
            double boatLength = ui.GetBoatLength();
            return handler.CreateBoat(regNr, color, nrOfWheels, boatLength);
        }
        private Bus AddBus()
        {
            string regNr = CheckRegNr();
            string color = ui.GetColor();
            int nrOfWheels = ui.GetNrOfWheels();
            int nrOfSeats = ui.GetNrOfSeats();
            return handler.CreateBus(regNr, color, nrOfWheels, nrOfSeats);
        }
        private MotorCycle AddMotorCycle()
        {
            string regNr = CheckRegNr();
            string color = ui.GetColor();
            int nrOfWheels = ui.GetNrOfWheels();
            double cylinderVolume = ui.GetCylinderVolume();
            return handler.CreateMotorCycle(regNr, color, nrOfWheels, cylinderVolume);
        }
        private Car AddCar()
        {
            string regNr = CheckRegNr();
            string color = ui.GetColor();
            int nrOfWheels = ui.GetNrOfWheels();
            string fuelType = ui.GetFuelType();
            return handler.CreateCar(regNr, color, nrOfWheels, fuelType);
        }
        private AirPlane AddAirPlane()
        {
            string regNr = CheckRegNr();
            string color = ui.GetColor();
            int nrOfWheels = ui.GetNrOfWheels();
            int nrOfEngines = ui.GetNrOfEngines();
            return handler.CreateAirPlane(regNr, color, nrOfWheels, nrOfEngines);
        }
        private string CheckRegNr()
        {
            string regNr;
            do
            {
                regNr = ui.GetRegNr();
                if (handler.RegNrExists(regNr)) { ui.Print("This vehicle already exists in the garage"); }
            } while (handler.RegNrExists(regNr));
            return regNr;
        }
        private void GetVehiclesNumbers()
        {
            ui.Print(handler.GetVehiclesCount());
        }
        private void GetNewVehiclesNumbers()
        {
            ui.Print(handler.GetNewVehiclesCount());
        }
        private void PrintAll()
        {
            try
            {
                IEnumerable<Vehicle> allVehicles = handler.GetAll();
                ui.Print("The Garage contains the following vehicles: ");
                foreach (var item in allVehicles)
                {

                    ui.Print(item.ToString());
                }
            }
            catch (NullReferenceException)
            {
                ui.Print("The garage does not have more vehicles");
            }
        }

        private void Seed()
        {
            handler.Seed();
        }
    }
}