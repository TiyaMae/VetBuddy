#nullable disable

using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

class MenuManager
{   
    private FileManager fileManager;
    private LoginManager loginManager;
    private PatientManager patientManager;

    public MenuManager (FileManager fm, LoginManager ln, PatientManager pm) {
        fileManager = fm; loginManager = ln; patientManager = pm;
    }
    public void LoginMenu()
    {
        while (true) 
        {
            Console.Clear();
            string topBorder = new string('═',34);
            Console.WriteLine('╔' + topBorder + '╗');
            Console.WriteLine("WELCOME TO VETBUDDY!");
            Console.WriteLine("Please log in.");
            Console.Write("Email: ");
            string inEmail = Console.ReadLine();
            Console.Write("Password: ");
            string inPass = Console.ReadLine();

            if (loginManager.LoginAuth(inEmail, inPass))
            {
                Console.Clear();
                Console.WriteLine("Login successful! Welcome...");
                Console.ReadKey();

                break;
            }
            
            Console.Clear();
            Console.WriteLine("Invalid credentials! \nPress any key to try again...");
            Console.ReadKey();
        }
    }

    public void MainMenu ()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Add Patient\n2. display patient\n3. opt 3");

            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1: 
                {
                    AddPatientMenu();
                    break;
                }
                case 2: 
                {
                    PatientMenu();
                    Console.ReadKey();
                    break;
                }
                case 3:
                    return;
            }
        }
    }

    public void AddPatientMenu()
    {
        while (true)    
        {
            Console.Clear();
            Console.WriteLine("Enter patient information:");
            Console.Write("Patient ID: "); //temporary
            int inPatientID = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string inName = Console.ReadLine();
            Console.Write("Age: ");
            int inAge = int.Parse(Console.ReadLine());
            Console.Write("Species: ");
            string inSpec = Console.ReadLine();
            Console.Write("Breed: ");
            string inBreed = Console.ReadLine();
            Console.Write("Gender: ");
            string inGen = Console.ReadLine();
            Console.Write("Status: ");
            string inStat = Console.ReadLine();

            Patient newPatient = patientManager.AddPatient(inPatientID, inName, inAge, inSpec, inBreed, inGen, inStat);

            Console.WriteLine($"Patient added successfully!");
            Console.ReadKey();
            return;
        }
    }

    public void PatientMenu()
    {
        while (true)
        {
            Console.Clear();

            patientManager.DisplayPatientList();

            if (patientManager.patients.Count == 0)
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.Write("Enter Patient ID (0 to go back): ");

            int id = int.Parse(Console.ReadLine());

            if (id == 0)
                return;

            Patient patient = patientManager.GetPatientByID(id);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                Console.ReadKey();
                continue;
            }

            bool managingPatient = true;

            while (managingPatient)
            {
                Console.Clear();

                Console.WriteLine($"Patient: {patient.name}");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Add Medical Record");
                Console.WriteLine("2. View Medical Records");
                Console.WriteLine("3. Back");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddMedicalRecordMenu(patient);
                        break;

                    case 2:
                        patientManager.DisplayMedicalRecordList(patient);
                        Console.ReadKey();
                        break;

                    case 3:
                        managingPatient = false;
                        break;
                    //default
                }
            }
        }
    }

    public void AddMedicalRecordMenu(Patient patient)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose Record:");
            Console.WriteLine("1. Checkup Record");
            Console.WriteLine("2. Vaccine Record");
            Console.WriteLine("3. Surgery Record");
            Console.WriteLine("4. Back");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                {
                    Console.Clear();
                    Console.WriteLine("Enter Check-up record information:");
                    Console.Write("Record ID: "); //temporary
                    int inRecordID = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Date: ");
                    string inDate = Console.ReadLine();
                    Console.Write("Weight (kg): ");
                    double inWeight = double.Parse(Console.ReadLine());
                    Console.Write("Temperature (Celsius): ");
                    double inTemp = double.Parse(Console.ReadLine());
                    Console.Write("Diagnosis: ");
                    string inDiag = Console.ReadLine();
                    Console.Write("Notes (200 characters): ");
                    string inNotes = Console.ReadLine();

                    CheckupRecord checkup = new CheckupRecord(inRecordID, inDate, inDiag, inNotes, inWeight, inTemp);

                    patientManager.AddMedicalRecord(patient, checkup);

                    Console.WriteLine($"Record added successfully!");
                    Console.ReadKey();
                    break;
                }
                case 2: 
                {
                    Console.Clear();
                    Console.WriteLine("Enter Vaccination record information:");
                    Console.Write("Record ID: "); //temporary
                    int inRecordID = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Date: ");
                    string inDate = Console.ReadLine();
                    Console.Write("Vaccine name: ");
                    string invaccName = Console.ReadLine();
                    Console.Write("Dose: ");
                    string inDose = Console.ReadLine();
                    Console.Write("Next due date: ");
                    string inNextDue = Console.ReadLine();
                    Console.Write("Diagnosis: ");
                    string inDiag = Console.ReadLine();
                    Console.Write("Notes (200 characters): ");
                    string inNotes = Console.ReadLine();

                    VaccineRecord vaccine = new VaccineRecord(inRecordID, inDate, inDiag, inNotes, invaccName, inDose, inNextDue);

                    patientManager.AddMedicalRecord(patient, vaccine);

                    Console.WriteLine($"Record added successfully!");
                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                        Console.Clear();
                        Console.WriteLine("Enter Surgery record information:");
                        Console.Write("Record ID: "); //temporary
                        int inRecordID = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Date: ");
                        string inDate = Console.ReadLine();
                        Console.Write("Procedure name: ");
                        string inProc = Console.ReadLine();
                        Console.Write("Recovery Status: ");
                        string inRecStat = Console.ReadLine();
                        Console.Write("Diagnosis: ");
                        string inDiag = Console.ReadLine();
                        Console.Write("Notes (200 characters): ");
                        string inNotes = Console.ReadLine();

                        SurgeryRecord surgery = new SurgeryRecord(inRecordID, inDate, inDiag, inNotes, inProc, inRecStat);

                        patientManager.AddMedicalRecord(patient, surgery);

                        Console.WriteLine($"Record added successfully!");
                        Console.ReadKey();
                        break;
                }
                case 4:
                    return;
                //default
            }
        }
    }

}