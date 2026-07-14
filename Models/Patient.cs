using System.Collections.Generic;

class Patient {
    public List<MedicalRecord> MedicalRecords = new List<MedicalRecord>();

    private int PatientID;
    private string Name;
    private int Age;
    private string Species;
    private string Breed; 
    private string Gender;
    private string Status;

    public Patient (int _patientid,string _name,int _age,string _species,string _breed,string _gender,string _status) {
        patientid = _patientid; name = _name; age = _age; species = _species; breed = _breed; gender = _gender; status = _status;
    }

    public int patientid {
        //get; set;
    }

    public string name {
        //get; set;
    }

    public int age {
        //get; set;
    }

    public string species {
        //get; set;
    }

    public string breed {
        //get; set;
    }

    public string gender {
        //get; set;
    }

    public string status {
        //get; set;
    }
}