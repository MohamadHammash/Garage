using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplikation
{
    public class ConsoleUI : IUI
    {


        #region Menus

        internal void ShowExistingMainMenu()
        {
            Print($"Welcome to the main menu!"
                    + "\n Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 0) of your choice"
                    + "\n1. Get the total amount of all the vehicles in the garage"
                    + "\n2. Get a specified list of all the vehicles in the garage"
                    + "\n3. Add a vehicle to the garage"
                    + "\n4. Remove a vehicle from the garage"
                    + "\n5. Find a vehicle in the garage"
                    + "\n0. Exit the application");


        }
        internal void ShowCreateMainMenu()
        {
            Print($"Welcome to the main menu!"
                    + "\n Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 0) of your choice"
                    + "\n1.  Add a vehicle to the garage"
                    + "\n2.  Remove a vehicle from the garage"
                    + "\n3. Get the total amount of all the vehicles in the garage"
                    + "\n4. Get a specified list of all the vehicles in the garage"
                    + "\n5. Find a vehicle in the garage"
                    + "\n0. Exit the application");


        }

        internal void VehiclesMenu()
        {
            Print("Please Choose which vehicle you would like to add");
            Print("Please press 1 to Add a car" +
                "\n Please press 2 to Add an airplane" +
                "\n Please press 3 to Add a motorcycle" +
                "\n Please press 4 to Add a bus" +
                "\n Please press 5 to Add a boat" +
                "\n To Restart the application please press 9" +
                "\n To close the application please press 0");
        }
        public void FindVehicleMenu()
        {
            Print(" please press 1 to search for a vehicle using Registration number" +
                "\n please press 2 to search for a vehicle using it's specifications ");
        }
        public void WhatNextMenu()
        {
            Print("What would you like to do next? " +
                "\n To add a new vehicle please press 1" +
                "\n To remove a vehicle please press 2" +
                "\n To go back to the main menu please press 3" +
                "\n To Restart the application please press 9" +
                "\n To exit the application please press 0");
        }
        public void CreateOrExistingMenu()
        {
            Print("Would you like to create a garage or check the existing one?" +
                "\n please press 1 to create a new garage" +
                "\n please press 2 to check the existing one");
        }
        #endregion
        #region Util
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public string GetInput()
        {
            string message = Console.ReadLine();
            return message;
        }
        public string AskForString()
        {
            bool success = false;
            string answer;
            do
            {
                Console.WriteLine();
                answer = GetInput();

                if (String.IsNullOrWhiteSpace(answer))
                {
                    Print("You must enter something");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }
        public int AskForInteger()
        {
            bool ok = false;
            int choice;
            do
            {
                string input = GetInput();

                if (int.TryParse(input, out choice))
                {

                    ok = true;
                }
                else
                {
                    Print("Please enter a valid choice! ");
                }

            }
            while (!ok);
            return choice;
        }
        public double AskForDouble()
        {
            bool ok = false;
            double choice;
            do
            {
                string input = GetInput();

                if (double.TryParse(input, out choice))
                {

                    ok = true;
                }
                else
                {
                    Print("Please enter a valid choice! ");
                }

            }
            while (!ok);
            return choice;
        }
        #endregion

        #region GetSpecs

        public string GetRegNr()
        {
            Print("Please enter the registration number of the vehicle!");
            string message = AskForString();
            return message;
        }
        public string GetColor()
        {
            Print("Please enter the color of the vehicle!");
            string message = AskForString();
            return message;
        }
        public int GetNrOfWheels()
        {
            Print("Please enter the number of wheels that the vehicle has!");
            int message = AskForInteger();
            return message;
        }
        public string GetFuelType()
        {
            Print("Please enter the vehicle's fuel type!");
            string message = AskForString();
            return message;
        }
        public int GetNrOfEngines()
        {
            Print("Please enter the airplane's number of engines!");
            int message = AskForInteger();
            return message;
        }
        public double GetCylinderVolume()
        {
            Print("Please enter the Motor Cycle's cylinder volume!");
            double message = AskForDouble();
            return message;
        }
        public int GetNrOfSeats()
        {
            Print("Please enter the number of seats that the bus has!");
            int message = AskForInteger();
            return message;
        }
        public double GetBoatLength()
        {
            Print("Please enter the length of the boat!");
            double message = AskForDouble();
            return message;
        }
        #endregion
    }
}
