using System;

class CheckupRecord : MedicalRecord {
    private double Weight; //kg
    private double Temperature; //celsius

    public CheckupRecord (int _recid, string _date, string _diag, string _notes, double _weight, double _temp) 
    :base(_recid, _date, _diag, _notes) {
        weight = _weight;   temp = _temp;
    }

    public double weight {
        get {return Weight;}
        set {
            if (value>=0.01 && value<=7000) Weight = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public double temp {
        get {return Temperature;}
        set {
            if (value>=20.0 && value<=45.0) Temperature = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public override void DisplayRecord() {
        Console.WriteLine("====== CHECK UP RECORD =====");
        Console.WriteLine($"ID: {recordID}"); //temporary
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Weight (kg): {weight}");
        Console.WriteLine($"Temperature (Celsius): {temp}");
        Console.WriteLine($"Diagnosis: {diagnosis}");
        Console.WriteLine($"Notes (200 characters): {notes}");
    }
}