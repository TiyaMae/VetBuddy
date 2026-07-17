#nullable disable

using System;

class SurgeryRecord : MedicalRecord {
    private string Procedure;
    private string RecoveryStatus;

    public SurgeryRecord (int _recid,string _date,string _diag,string _notes,string _procedure,string _recstatus)
    : base( _recid, _date, _diag, _notes) {
        procedure = _procedure; recstatus = _recstatus;
    }

    public string procedure {
        get {return Procedure;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Procedure = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string recstatus {
        get {return RecoveryStatus;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) RecoveryStatus = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public override void DisplayRecord() {
        Console.WriteLine($"ID: {recordID}"); //temporary
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Weight (kg): ");
        Console.WriteLine($"Temperature (Celsius): ");
        Console.WriteLine($"Diagnosis: ");
        Console.WriteLine($"Notes (200 characters): ");
    }
}