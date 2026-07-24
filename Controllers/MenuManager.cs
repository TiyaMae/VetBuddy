#nullable disable

using System.Runtime.Intrinsics.X86;

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
            Format();
            Console.SetCursorPosition(25,5);
            Console.WriteLine("WELCOME TO VETBUDDY!");
            Console.ResetColor();
            Console.SetCursorPosition(25,6);
            Console.WriteLine("Please log in.");
            Console.SetCursorPosition(20,7);
            Console.Write("Email: ");
            string inEmail = Console.ReadLine();
            Console.SetCursorPosition(20,8);
            Console.Write("Password: ");
            string inPass = Console.ReadLine();

            if (loginManager.LoginAuth(inEmail, inPass))
            {
                Console.Clear();   
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successful! Welcome...");
                Console.ResetColor();
                Console.ReadKey();

                break;
            }
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid credentials!");
            Console.ResetColor();
            Console.Write(" Press any key to try again...");
            Console.ReadKey();
        }
     }

    public void MainMenu ()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Add Patient\n2. display patient\n3. Exit");

            int choice = 0;
                try 
                {
                    choice = int.Parse(Console.ReadLine());
                } 
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter numbers only.");
                    Console.ResetColor();
                    Console.ReadKey();
                }

            switch (choice)
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

    //------------- PATIENT ------------

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
            Console.Write("Enter Patient ID");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" (0 to go back): ");
            Console.ResetColor();

            string id = Console.ReadLine();

            if (id == "0")
                return;

            Patient patient = patientManager.GetPatientByID(id);

            if (patient == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient not found.");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

            bool managingPatient = true;

            while (managingPatient)
            {
                Console.Clear();

                    
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== PATIENT INFORMATION ===");
                Console.ResetColor();
                Console.WriteLine($"Patient ID: {patient.patientid}");
                Console.WriteLine($"Patient: {patient.name}");
                Console.WriteLine($"Age: {patient.age}");
                Console.WriteLine($"Species: {patient.species}");
                Console.WriteLine($"Breed: {patient.breed}");
                Console.WriteLine($"Gender: {patient.gender}");
                Console.WriteLine($"Status: {patient.status}");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Edit Patient");
                Console.WriteLine("2. Delete Patient");
                Console.WriteLine("3. Add Medical Records");
                Console.WriteLine("4. View Medical Records");
                Console.WriteLine("5. Back");

                int choice = 0;
                    try 
                    {
                        choice = int.Parse(Console.ReadLine());
                    } 
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter numbers only.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                switch (choice)
                {
                    case 1:
                        EditPatientMenu(patient);
                        break;

                    case 2:
                        Console.Clear();
                        if (patientManager.DeletePatient(patient.patientid))
                        {
                            try
                            {
                                fileManager.SavePatients(patientManager.patients);
                                fileManager.SaveRecords(patientManager.patients);
                                Console.WriteLine("Patient deleted successfully.");

                                Console.ReadKey();
                                managingPatient = false;
                            }
                            catch (IOException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unable to save data.");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                        }   else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error deleting the patient.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        AddRecordMenu(patient);
                        break;

                    case 4:
                        MedicalRecordMenu(patient);
                        break;

                    case 5:
                        managingPatient = false;
                        break;
                    //default
                }
            }
        }
    }

    public void AddPatientMenu()
    {
        while (true)    
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter patient information:");
            Console.ResetColor();
            string inPatientID = fileManager.PatientIDGenerator();
            Console.WriteLine($"Patient ID: {inPatientID}");
            Console.Write("Name: ");
            string inName = Console.ReadLine();
            Console.Write("Age: ");
            int inAge = 1;
                try
                {
                    inAge = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter numbers only.");
                        Console.ResetColor();
                        Console.ReadKey();
                }
            Console.Write("Species: ");
            string inSpec = Console.ReadLine();
            Console.Write("Breed: ");
            string inBreed = Console.ReadLine();
            Console.Write("Gender: ");
            string inGen = Console.ReadLine();
            Console.Write("Status: ");
            string inStat = Console.ReadLine();

            try
            {
                Patient newPatient = patientManager.AddPatient(inPatientID, inName, inAge, inSpec, inBreed, inGen, inStat);
                fileManager.SavePatients(patientManager.patients);

                Console.WriteLine("Patient added successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to save patient.");
                Console.ResetColor();
            }

            Console.ReadKey();
            return;
        }
    }

    public void EditPatientMenu(Patient patient)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== Edit Patient ===");
        Console.ResetColor();
        Console.Write($"Name ({patient.name}): ");
        string name = Console.ReadLine();
        Console.Write($"Age ({patient.age}): ");
        int age = patient.age;
            try
            {
                age = int.Parse(Console.ReadLine());
            } 
            catch (FormatException)
            {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter numbers only.");
                    Console.ResetColor();
                    Console.ReadKey();
            }
        Console.Write($"Species ({patient.species}): ");
        string species = Console.ReadLine();
        Console.Write($"Breed ({patient.breed}): ");
        string breed = Console.ReadLine();
        Console.Write($"Gender ({patient.gender}): ");
        string gender = Console.ReadLine();
        Console.Write($"Status ({patient.status}): ");
        string status = Console.ReadLine();

        try
        {
            patientManager.EditPatient(patient, name, age, species, breed, gender, status);
            fileManager.SavePatients(patientManager.patients);
            Console.WriteLine("Patient updated!");
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
        catch (IOException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unable to edit patient.");
            Console.ResetColor();
        }

        Console.ReadKey();
        return;
    }

    //------------- MEDICAL RECORD -------------

    public void MedicalRecordMenu(Patient patient)
    {
        while(true)
        {
            Console.Clear();

            patientManager.DisplayRecordList(patient);

            Console.WriteLine();
            Console.Write("Enter Record ID");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" (0 to go back): ");
            Console.ResetColor();

            string id = Console.ReadLine();

            if (id == "0")
                return;

            MedicalRecord record = patientManager.GetRecordByID(patient, id);

            if (record == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Record not found.");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

            bool managingRecord = true;

            while (managingRecord)
            {
                Console.Clear();
                record.DisplayRecord();
                
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Edit Record");
                Console.WriteLine("2. Delete Record");
                Console.WriteLine("3. Back");

                int choice = 0;
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter numbers only.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        EditRecordMenu(record);
                        break;
                    case 2:
                        Console.Clear();
                        if (patientManager.DeleteRecord(patient, record.recordID))
                        {
                            try 
                            {
                                fileManager.SaveRecords(patientManager.patients);
                                Console.WriteLine("Patient deleted successfully.");
                            }
                            catch (IOException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unable to delete patient.");
                                Console.ResetColor();
                            }

                            Console.ReadKey();
                        }   else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error record not found.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        return;
                }
            }
        }
    }

    public void AddRecordMenu(Patient patient)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose Record:");
            Console.ResetColor();
            Console.WriteLine("1. Checkup Record");
            Console.WriteLine("2. Vaccine Record");
            Console.WriteLine("3. Surgery Record");
            Console.WriteLine("4. Back");

            int choice = 0;
                try 
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter numbers only.");
                    Console.ResetColor();
                    Console.ReadKey();
                }

            switch (choice)
            {
                case 1: 
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter Check-up record information:");
                    Console.ResetColor();
                    string inRecordID = fileManager.RecordIDGenerator(RecordType.Checkup);
                    Console.WriteLine($"Record ID: {inRecordID}");
                    string inDate = DateTime.Now.ToString("yyyy-MM-dd");
                    Console.Write("Weight (kg): ");
                    double inWeight = double.Parse(Console.ReadLine());
                    Console.Write("Temperature (Celsius): ");
                    double inTemp = double.Parse(Console.ReadLine());
                    Console.Write("Diagnosis: ");
                    string inDiag = Console.ReadLine();
                    Console.Write("Notes (200 characters): ");
                    string inNotes = Console.ReadLine();

                    
                    try
                    {
                        CheckupRecord checkup = new CheckupRecord(inRecordID, inDate, inDiag, inNotes, inWeight, inTemp);
                        patientManager.AddRecord(patient, checkup);
                        fileManager.SaveRecords(patientManager.patients);

                        Console.WriteLine($"Record added successfully!");
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Weight and temperature invalid.");
                        Console.ResetColor();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (IOException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unable to save record.");
                        Console.ResetColor();
                    }
                    
                    Console.ReadKey();
                    break;
                }
                case 2: 
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter Vaccination record information:");
                    Console.ResetColor();
                    string inRecordID = fileManager.RecordIDGenerator(RecordType.Vaccine);
                    Console.WriteLine($"Record ID: {inRecordID}");
                    string inDate = DateTime.Now.ToString("yyyy-MM-dd");
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

                    VaccineRecord vaccine = new VaccineRecord(inRecordID, inDate,  inDiag, inNotes, invaccName, inDose, inNextDue);

                    try
                    {
                        patientManager.AddRecord(patient, vaccine);
                        fileManager.SaveRecords(patientManager.patients);

                        Console.WriteLine($"Record added successfully!");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                    catch (IOException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unable to save record.");
                        Console.ResetColor();
                    }
                    
                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter Surgery record information:");
                    Console.ResetColor();
                    string inRecordID = fileManager.RecordIDGenerator(RecordType.Surgery);
                    Console.WriteLine($"Record ID: {inRecordID}");
                    string inDate = DateTime.Now.ToString("yyyy-MM-dd");
                    Console.Write("Procedure name: ");
                    string inProc = Console.ReadLine();
                    Console.Write("Recovery Status: ");
                    string inRecStat = Console.ReadLine();
                    Console.Write("Diagnosis: ");
                    string inDiag = Console.ReadLine();
                    Console.Write("Notes (200 characters): ");
                    string inNotes = Console.ReadLine();

                    SurgeryRecord surgery = new SurgeryRecord(inRecordID, inDate, inDiag, inNotes, inProc, inRecStat);

                    try
                    {
                        patientManager.AddRecord(patient, surgery);
                        fileManager.SaveRecords(patientManager.patients);

                        Console.WriteLine($"Record added successfully!");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                    catch (IOException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unable to save record.");
                        Console.ResetColor();
                    }

                    Console.ReadKey();
                    break;
                }
                case 4:
                    return;
                //default
            }
        }
    }

    public void EditRecordMenu (MedicalRecord record)
    {
        try 
        {
            switch(record.recordType)
            {
                case RecordType.Checkup:
                    CheckupRecord c = (CheckupRecord)record;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("=== Edit Record ===");
                    Console.ResetColor();
                    Console.Write("Weight: ");
                    c.weight = double.Parse(Console.ReadLine());
                    Console.Write("Temperature: ");
                    c.temp = double.Parse(Console.ReadLine());
                    Console.Write("Diagnosis: ");
                    c.diagnosis = Console.ReadLine();
                    Console.Write("Notes: ");
                    c.notes = Console.ReadLine();
                    break;
                case RecordType.Vaccine:
                    VaccineRecord v = (VaccineRecord)record;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("=== Edit Record ===");
                    Console.ResetColor();
                    Console.Write("Vaccine Name: ");
                    v.vaccname = Console.ReadLine();
                    Console.Write("Dose: ");
                    v.dose = Console.ReadLine();
                    Console.Write("Next due date: ");
                    v.nextdue = Console.ReadLine();
                    Console.Write("Diagnosis: ");
                    v.diagnosis = Console.ReadLine();
                    Console.Write("Notes: ");
                    v.notes = Console.ReadLine();
                    break;
                case RecordType.Surgery:
                    SurgeryRecord s = (SurgeryRecord)record;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("=== Edit Record ===");
                    Console.ResetColor();
                    Console.Write("Procedure: ");
                    s.procedure = Console.ReadLine();
                    Console.Write("Recovery Status: ");
                    s.recstatus = Console.ReadLine();
                    Console.Write("Diagnosis: ");
                    s.diagnosis = Console.ReadLine();
                    Console.Write("Notes: ");
                    s.notes = Console.ReadLine();
                    break;
            }

                fileManager.SaveRecords(patientManager.patients);
                Console.WriteLine("Medical record updated!");
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter numbers only.");
            Console.ResetColor();
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
        catch (IOException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unable to edit record.");
            Console.ResetColor();
        }
        
        Console.ReadKey();
    }



    // Formatting
    public void Format()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(8,3);
        string topBorder = new string('═',50);
        Console.WriteLine('╔' + topBorder + '╗');
        int y=4;
        for (int j=0;j<7;j++)
        {
            Console.SetCursorPosition(8,y);
            Console.WriteLine('║' + new string(' ',50) + '║');
            y++;
        }
        Console.SetCursorPosition(8,y);
        Console.WriteLine('╚' + topBorder + '╝');

    }
}
