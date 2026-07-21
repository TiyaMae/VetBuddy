using System;
using System.Runtime.Intrinsics.X86;
namespace VetBuddy;

class Program {
    static void Main() {
        FileManager fm = new FileManager();
        LoginManager lm = new LoginManager();
        PatientManager pm = new PatientManager();

        //loading patients from file manager to patient list in patient manager
        pm.LoadPatients(fm.LoadPatients());
        fm.LoadRecords(pm.patients);
        
        MenuManager menu = new MenuManager(fm, lm, pm);

        //LOGIN
        menu.LoginMenu();
        menu.MainMenu();
        
    } 
}