using System;
namespace VetBuddy;

class Program {
    static void Main() {
        FileManager fileManager = new FileManager();
        LoginManager loginManager = new LoginManager();
        PatientManager patientManager = new PatientManager();
        MenuManager menu = new MenuManager(fileManager, loginManager, patientManager);

        //LOGIN
        menu.LoginMenu();
        menu.MainMenu();
        
    } 
}