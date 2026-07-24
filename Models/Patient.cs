#nullable disable

using System;
using System.Collections.Generic;

class Patient {
    private string PatientID; //make patientID automatic, make string(P00123)
    private string Name;
    private int Age;
    private string Species;
    private string Breed; 
    private string Gender;
    private string Status; //make status automatic
    private List<MedicalRecord> MedicalRecords = new List<MedicalRecord>();

    public Patient(string _patientid, string _name, int _age, string _species, string _breed, string _gender, string _status)
    {
        patientid = _patientid; name = _name; age = _age; species = _species; breed = _breed; gender = _gender; status = _status;
    }

    public string patientid {
        get {return PatientID;}
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                PatientID = value;
            else
                throw new ArgumentException("Patient ID cannot be empty.");
        }
    }

    public string name {
        get {return Name;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Name = value;
            else throw new ArgumentException("Name is empty or too long.");
        }
    }

    public int age {
        get {return Age;}
        set {
            if (value>=0.01 && value<=150) Age = value;
            else throw new ArgumentException("Age must be between 0.01 and 150 years.");
        }
    }

    public string species {
        get {return Species;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Species = value;
            else throw new ArgumentException("Species is empty or too long.");
        }
    }

    public string breed {
        get {return Breed;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Breed = value;
            else throw new ArgumentException("Breed is empty or too long.");
        }
    }

    public string gender {
        get {return Gender;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Gender = value;
            else throw new ArgumentException("Gender is is empty or too long.");
        }
    }

    public string status
    {
        get {return Status;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Status = value;
            else throw new ArgumentException("Status is empty or too long.");
        }
    }

    public List<MedicalRecord> medicalRecords
    {
        get {return MedicalRecords;}
    }
}