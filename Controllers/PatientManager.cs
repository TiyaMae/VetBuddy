#nullable disable 
using System.Collections.Generic;

class PatientManager {
    //----------------- PATIENT -------------------------
    private List<Patient> Patients = new List<Patient>();

    public List<Patient> patients
    {
        get {return Patients;}
    }

    public void LoadPatients(List<Patient> _loadedpatients)
    {
        Patients = _loadedpatients;
    }

    public void DisplayPatientList()
    {
        if (Patients.Count == 0)
        {
            Console.WriteLine("No patients found.");
            return;
        }

        foreach (Patient patient in Patients)
        {
            Console.WriteLine($"Patient ID: {patient.patientid}");
            Console.WriteLine($"Name: {patient.name}");
            Console.WriteLine($"Species: {patient.species}");
            Console.WriteLine("--------------------------");
        }
    }

    public Patient GetPatientByID(int id)
    {
        foreach (Patient patient in Patients)
        {
            if (patient.patientid == id) return patient;
        }

        return null;
    }

    public Patient SearchPatient()
    {
        Console.WriteLine();
            Console.Write("Search for patient (0 to go back): ");

            string input = Console.ReadLine();

            foreach (Patient patient in Patients)
        {
            if (patient.patientid == int.Parse(input)) return patient;
            else if (patient.name == input) return patient;
            else if (patient.age == int.Parse(input)) return patient;
            else if (patient.species == input) return patient;
            else if (patient.breed == input) return patient;
            else if (patient.gender == input) return patient;
            else if (patient.gender == input) return patient;
            else if (patient.status == input) return patient;
        }
        return null;
    }

    public Patient AddPatient(int _patientid, string _name, int _age, string _species, string _breed, string _gender, string _status) {
        Patient newPatient = new Patient(_patientid, _name, _age, _species, _breed, _gender, _status);
        Patients.Add(newPatient);
        return newPatient;
    }

    public bool DeletePatient(int id) {
       Patient patient = GetPatientByID(id);

       if (patient == null) return true;

        Patients.Remove(patient);

        return false;
    }

    public bool EditPatient(Patient patient, string name, int age, string species, string breed, string gender, string status) {
        if (patient == null) return false;

        patient.name = name;
        patient.age = age;
        patient.species = species;
        patient.breed = breed;
        patient.gender = gender;
        patient.status = status;

        return true;
    }

    //----------------- MEDICAL RECORDS -------------------------

    public void DisplayRecordList(Patient patient)
    {
        Console.Clear();

        Console.WriteLine($"Medical Records of {patient.name}");
        Console.WriteLine();

        if (patient.medicalRecords.Count == 0)
        {
            Console.WriteLine("No medical records.");
            return;
        }

        foreach (MedicalRecord record in patient.medicalRecords)
        {
            Console.WriteLine($"{record.recordID} {record.recordType} {record.date}");
            Console.WriteLine("--------------------------");
        }
    }

    public MedicalRecord GetRecordByID(Patient patient, int id)
    {
        foreach (MedicalRecord record in patient.medicalRecords)
        {
            if (record.recordID == id) return record;
        }

        return null;
    }

    public void AddRecord(Patient patient, MedicalRecord record) {
        patient.medicalRecords.Add(record);
    }

    public bool DeleteRecord(Patient patient, int recordid) {
        MedicalRecord record = patient.medicalRecords.Find(r => r.recordID == recordid);

        if (record == null) return false;

        patient.medicalRecords.Remove(record);
        return true;
    }

    public void EditPRecord() {
        //code for editing patients
    }
}