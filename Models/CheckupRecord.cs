using System;

class CheckupRecord : MedicalRecord {
    private double Weight; //kg
    private double Temperature; //celsius
    private string CheckupRecID= "C000000";

    public CheckupRecord (int _recid, string _date, string _diag, string _notes, double _weight, double _temp) 
    :base(_recid, _date, _diag, _notes) {
        weight = _weight;   temp = _temp;
    }

    public double weight {
        get {return Weight;}
        set {
            if (value>=0.01 && value<=7000) Weight = value;
            else throw new ArgumentException("Error!");
        }
    }

    public double temp {
        get {return Temperature;}
        set {
            if (value>=20.0 && value<=45.0) Temperature = value;
            else throw new ArgumentException("Error!");
        }
    }

    public override RecordType recordType => RecordType.Checkup;

    public override void DisplayRecord()
    { //make parent print inherited information
        LoginManager vet = new LoginManager();

        Console.WriteLine("====== CHECK UP RECORD =====");
        Console.WriteLine($"Record ID: {recordID}"); //temporary
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Vet: {vet.vetName}");
        Console.WriteLine($"Weight (kg): {weight}");
        Console.WriteLine($"Temperature (Celsius): {temp}");
        Console.WriteLine($"Diagnosis: {diagnosis}");
        Console.WriteLine($"Notes (200 characters): {notes}");
    }
}