using System.Collections.Generic;

class PatientManager {
    private List<Patient> Patients = new List<Patient>();

    public List<Patient> patients
    {
        get {return Patients;}
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
            Console.WriteLine($"ID: {patient.patientid}");
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

    public Patient AddPatient(int _patientid, string _name, int _age, string _species, string _breed, string _gender, string _status) {
        Patient newPatient = new Patient(_patientid, _name, _age, _species, _breed, _gender, _status);
        Patients.Add(newPatient);
        return newPatient;
    }

    public void DeletePatient() {
        //code for deleting patients
    }

    public void EditPatient() {
        //code for editing patients
    }

    public void SearchPatient() {
        //code for searching patients by ID and returns Patient
    }

    public void DisplayMedicalRecordList(Patient patient)
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
            record.DisplayRecord();
            Console.WriteLine("----------------------------");
        }
    }

    public void AddMedicalRecord(Patient patient, MedicalRecord record) {
        patient.medicalRecords.Add(record);
    }

    public void DeleteMedicalRecord() {
        //code for deleting medical records
    }
}