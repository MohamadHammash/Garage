namespace GarageApplikation
{
    public interface IUI
    {
        double AskForDouble();
        int AskForInteger(string message);
        string AskForString(string message);
        void CreateOrExistingMenu();
        void FindVehicleMenu();
        double GetBoatLength();
        double GetCylinderVolume();
        string GetInput();
       
       
       
        void Print(string message);
        void ShowCreateMainMenu();
        void ShowExistingMainMenu();
        void VehiclesMenu();
        void WhatNextMenu();
        string FindVehiclesByProportiesMenu();
        int GetIntInput();
    }
}