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

    public override RecordType recordType => RecordType.Surgery;

    public override void DisplayRecord() 
    { //make parent print inherited information
        LoginManager vet = new LoginManager();

        Console.WriteLine("====== SURGERY RECORD =====");
        Console.WriteLine($"ID: {recordID}"); //temporary
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Vet: {vet.vetName}");
        Console.WriteLine($"Procedure: {procedure}");
        Console.WriteLine($"Recovery status: {recstatus}");
        Console.WriteLine($"Notes (200 characters): ");
    }
}