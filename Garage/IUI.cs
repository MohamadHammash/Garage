namespace GarageApplikation
{
    public interface IUI
    {
        double AskForDouble();
        int AskForInteger();
        string AskForString();
        void CreateOrExistingMenu();
        void FindVehicleMenu();
        double GetBoatLength();
        string GetColor();
        double GetCylinderVolume();
        string GetFuelType();
        string GetInput();
        int GetNrOfEngines();
        int GetNrOfSeats();
        int GetNrOfWheels();
        string GetRegNr();
        void Print(string message);
        void WhatNextMenu();
    }
}