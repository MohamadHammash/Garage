using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageApplikation
{
    public class GarageManager
    {
        private IUI ui;
        private IHandler handler;


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
            ui.CreateOrExistingMenu();
            bool success = true;
            do
            {

                int input = ui.AskForInteger("");
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

            ExistingMenuWithoutSeed();
        }

        private void ExistingMenuWithoutSeed()
        {
            bool sucess = true;
            ui.ShowExistingMainMenu();
            do
            {
                int input = ui.AskForInteger("");
                switch (input)
                {
                    case 1:
                        GetVehiclesNumbers();
                        ExistingWhatNext();
                        break;
                    case 2:
                        PrintAll();
                        ExistingWhatNext();
                        break;
                    case 3:
                        if (CheckGarageIsFull()) { ExistingMainMenu(); }
                        AddVehicle();
                        ExistingWhatNext();
                        break;
                    case 4:
                        RemoveVehicle();
                        ExistingWhatNext();
                        break;
                    case 5:
                        ExistingFindVehicle();
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

        private void CreateFindVehicle()
        {
            bool success = true;
            ui.FindVehicleMenu();
            do
            {
                int input = ui.AskForInteger("");
                switch (input)
                {
                    case 1:
                        bool regNrExist = false;
                        do
                        {

                            string regNr = ui.AskForString("Please enter the registration number of the vehicle!");
                            try
                            {
                                var vehicleToFind = handler.FindVehicleByRegNr(regNr);
                                if (regNr.Equals(regNr, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    ui.Print($"The vehicle yo searched for is a {vehicleToFind.Color} {vehicleToFind.GetType().Name}, that has {vehicleToFind.NrOfWheels} wheels ");
                                    regNrExist = true;
                                    CreateMainMenu();
                                }
                            }
                            catch (NullReferenceException)
                            {
                                ui.Print($"There is no vehicle in the garage that has this registration number: {regNr}. Please try again.");

                                int input1 = ui.AskForInteger($"There is no vehicle in the garage that has this registration number: {regNr}. Please try again.");
                                ui.Print("Press 1 to try again" +
                                    "\n press 2 to go back ");
                                switch (input1)
                                {
                                    case 1:
                                        regNrExist = false;
                                        break;
                                    case 2:
                                        CreateMainMenu();
                                        break;
                                }
                            }
                        } while (!regNrExist);
                        break;
                    case 2:
                        FindVehiclesByProporties();
                        break;
                    default:
                        success = false;
                        ui.Print("Please enter a valid choice!");
                        break;

                }
            } while (!success);
        }

        private void FindVehiclesByProporties()
        {
            /* ToDo:
             *   Check if the user enters wrong inputs.
             */

            ui.Print("Please enter the color of the vehicles you would like to find!");
            var color = ui.GetInput();
            ui.Print("Please enter the number of wheels of the vehicles you would like to find!");
            var NrOfWheels = ui.GetInput();
            ui.Print("Please enter the type of the vehicle would like to find!");
            var type = ui.GetInput();
            IEnumerable<Vehicle> result = handler.GetAll();

            if (!string.IsNullOrWhiteSpace(color))
            {
                result = result.Where(v => v.Color.Equals(color, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!String.IsNullOrWhiteSpace(NrOfWheels) && int.TryParse(NrOfWheels, out int getWheelsNr))
            {
                result = result.Where(v => v.NrOfWheels == getWheelsNr);
            }
          

            if (!String.IsNullOrWhiteSpace(type))
                result = result.Where(v => v.GetType().Name.Equals(type, StringComparison.InvariantCultureIgnoreCase));

            foreach (var itemAllVehicles in result)
            {

                if (itemAllVehicles != null)
                {
                    ui.Print($"A vehicle of type {itemAllVehicles.GetType().Name} with the register number: {itemAllVehicles.RegNr} that has a {itemAllVehicles.Color} color and {itemAllVehicles.NrOfWheels} wheels has been found");
                }
                else
                {
                    ui.Print("No vehicles found in these specifications!");
                }
            }






        }




        private void ExistingFindVehicle()
        {
            bool success = true;
            ui.FindVehicleMenu();
            do
            {
                int input = ui.AskForInteger("");
                switch (input)
                {
                    case 1:
                        bool regNrExist = false;
                        do
                        {

                            string regNr = ui.AskForString("Please enter the registration number of the vehicle!");

                            try
                            {
                                var vehicleToFind = handler.FindVehicleByRegNr(regNr);
                                if (regNr.Equals(regNr, StringComparison.InvariantCultureIgnoreCase))
                                {

                                    ui.Print($"The vehicle yo searched for is a {vehicleToFind.Color} {vehicleToFind.GetType().Name}, that has {vehicleToFind.NrOfWheels} wheels ");
                                    regNrExist = true;
                                    ExistingMainMenu();
                                }


                            }
                            catch (NullReferenceException)
                            {
                                ui.Print($"There is no vehicle in the garage that has this registration number: {regNr}. Please try again.");

                                int input1 = ui.AskForInteger("Press 1 to try again" +
                                    "\n press 2 to go back ");
                                switch (input1)
                                {
                                    case 1:
                                        regNrExist = false;
                                        break;
                                    case 2:
                                        ExistingMainMenu();
                                        break;
                                }
                            }
                        } while (!regNrExist);
                        break;
                    case 2:
                        FindVehiclesByProporties();
                        break;
                    default:
                        success = false;
                        ui.Print("Please enter a valid choice!");
                        break;

                }
            } while (!success);
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
                        ui.Print("The garage must have a capacity for at least 1 vehicle! Please try again");
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
                int input = ui.AskForInteger("");
                switch (input)
                {
                    case 1:
                        if (CheckGarageIsFull()) { CreateMainMenu(); }
                        AddVehicle();
                        CreateWhatNext();
                        break;
                    case 2:
                        RemoveVehicle();
                        CreateWhatNext();
                        break;
                    case 3:
                        GetNewVehiclesNumbers();
                        CreateWhatNext();
                        break;
                    case 4:
                        PrintAll();
                        CreateWhatNext();
                        break;
                    case 5:
                        CreateFindVehicle();
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

        private void CreateWhatNext()
        {
            bool success = true;
            do
            {
                ui.WhatNextMenu();
                int input = ui.AskForInteger("");
                switch (input)
                {
                    case 1:
                        if (CheckGarageIsFull()) { CreateWhatNext(); }
                        AddVehicle();
                        CreateWhatNext();
                        break;
                    case 2:
                        RemoveVehicle();
                        CreateWhatNext();
                        break;
                    case 3:
                        CreateMainMenu();
                        break;

                    case 9:
                        Console.Clear();
                        Run();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        ui.Print("Please enter a valid choice");
                        success = false;
                        break;
                }
            } while (!success);
        }
        private void ExistingWhatNext()
        {
            bool success = true;
            do
            {
                ui.WhatNextMenu();
                int input = ui.AskForInteger("");
                switch (input)
                {
                    case 1:
                        if (CheckGarageIsFull()) { ExistingWhatNext(); }
                        AddVehicle();
                        ExistingWhatNext();
                        break;
                    case 2:
                        RemoveVehicle();
                        ExistingWhatNext();
                        break;
                    case 3:
                        ExistingMenuWithoutSeed();
                        break;

                    case 9:
                        Console.Clear();
                        Run();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        ui.Print("Please enter a valid choice");
                        success = false;
                        break;
                }
            } while (!success);
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

            var regNr = ui.AskForString("Please enter the Registration number of the Vehicle you would like to remove.");
            var vehicleToRemove = handler.RemoveVehicle(regNr);
            if (vehicleToRemove != null)
            {
                ui.Print($"a vehicle of type {vehicleToRemove.GetType().Name} and Register number {vehicleToRemove.RegNr} has been removed");
               // handler.Countdown();
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
                int input = ui.AskForInteger("");

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


        private Boat AddBoat()
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            double boatLength = ui.GetBoatLength();
            return handler.CreateBoat(regNr, color, nrOfWheels, boatLength);
        }
        private Bus AddBus()
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            int nrOfSeats = ui.AskForInteger("Please enter the number of seats that the bus has!");
            return handler.CreateBus(regNr, color, nrOfWheels, nrOfSeats);
        }
        private MotorCycle AddMotorCycle()
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            double cylinderVolume = ui.GetCylinderVolume();
            return handler.CreateMotorCycle(regNr, color, nrOfWheels, cylinderVolume);
        }
        private Car AddCar() // made public for test
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            string fuelType = ui.AskForString("Please enter the vehicle's fuel type!");
            return handler.CreateCar(regNr, color, nrOfWheels, fuelType);
        }
        private AirPlane AddAirPlane()
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            int nrOfEngines = ui.AskForInteger("Please enter the airplane's number of engines!");
            return handler.CreateAirPlane(regNr, color, nrOfWheels, nrOfEngines);
        }
        private string CheckRegNr()
        {
            string regNr;
            do
            {
                regNr = ui.AskForString("Please enter the registration number of the vehicle!");
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
            ui.Print(handler.GetVehiclesCount());
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
            handler = new GarageHandler(10);
            handler.Seed();
        }
    }
}
