#nullable disable

using System;
using System.Collections.Generic;

class Patient {
    private int PatientID; //make patientID automatic
    private string Name;
    private int Age;
    private string Species;
    private string Breed; 
    private string Gender;
    private string Status; //make status automatic
    private List<MedicalRecord> MedicalRecords = new List<MedicalRecord>();

    string[] StatusType = {"Healthy", "Sick", "Recovering", "Medicated", "Qued"};

    public Patient(int _patientid, string _name, int _age, string _species, string _breed, string _gender, string _status)
    {
        patientid = _patientid; name = _name; age = _age; species = _species; breed = _breed; gender = _gender; status = _status;
    }

    public int patientid {
        get {return PatientID;}
        set {
            if (value>=1) PatientID = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string name {
        get {return Name;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Name = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public int age {
        get {return Age;}
        set {
            if (value>=1 && value<=150) Age = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string species {
        get {return Species;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Species = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string breed {
        get {return Breed;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Breed = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string gender {
        get {return Gender;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Gender = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string status
    {
        get {return Status;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Status = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public List<MedicalRecord> medicalRecords
    {
        get {return MedicalRecords;}
    }
}