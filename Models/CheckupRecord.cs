using System;

class CheckupRecord : MedicalRecord {
    private double Weight; //kg
    private double Temperature; //celsius
 
    public CheckupRecord (string _recid, string _date, string _diag, string _notes, double _weight, double _temp) 
    :base(_recid, _date, _diag, _notes) {
        weight = _weight;   temp = _temp;
    }

    public double weight {
        get {return Weight;}
        set {
            if (value>=0.01 && value<=7000) Weight = value;
            else throw new ArgumentException("Weight must be between 0.01kg and 7000 kg.");
        }
    }

    public double temp {
        get {return Temperature;}
        set {
            if (value>=20.0 && value<=45.0) Temperature = value;
            else throw new ArgumentException("Temperature must be between 20°C and 45°C.");
        }
    }

    public override RecordType recordType => RecordType.Checkup;

    public override void DisplayRecord()
    { //make parent print inherited information
        LoginManager vet = new LoginManager();
        vet.LoadAccount();

        Console.WriteLine("====== CHECK UP RECORD =====");
        Console.WriteLine($"Record ID: {recordID}"); //temporary
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Vet: {vet.vetName}");
        Console.WriteLine($"Weight: {weight} kg");
        Console.WriteLine($"Temperature: {temp} °C");
        Console.WriteLine($"Diagnosis: {diagnosis}");
        Console.WriteLine($"Notes (200 characters): {notes}");
    }
}