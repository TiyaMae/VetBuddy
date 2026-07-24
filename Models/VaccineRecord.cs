#nullable disable

using System;

class VaccineRecord : MedicalRecord {
    private string VaccName;
    private string Dose;
    private string NextDue;

    public VaccineRecord (string _recid, string _date, string _diag, string _notes, string _vaccname, string _dose, string _nextdue) 
    : base( _recid, _date, _diag, _notes) {
        vaccname = _vaccname; dose = _dose; nextdue = _nextdue;
    }

    public string vaccname {
        get {return VaccName;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) VaccName = value;
            else throw new ArgumentException("Vaccine name is empty or too long.");
        }
    }

    public string dose {
        get {return Dose;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Dose = value;
            else throw new ArgumentException("Dose is is empty or too long.");
        }
    }

    public string nextdue {
        get {return NextDue;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) NextDue = value;
            else throw new ArgumentException("Next due date is empty or too long.");
        }
    }

    public override RecordType recordType => RecordType.Vaccine;

    public override void DisplayRecord()
    { //make parent print inherited information
        LoginManager vet = new LoginManager();
        vet.LoadAccount();

        Console.WriteLine("====== VACCINE RECORD =====");
        Console.WriteLine($"Record ID: {recordID}"); //temporary
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Vet: Dr. {vet.vetName}");
        Console.WriteLine($"Vaccine name: {vaccname}");
        Console.WriteLine($"Dose: {dose}");
        Console.WriteLine($"Next due date: {nextdue}");
        Console.WriteLine($"Notes (200 characters): {notes}");
    }
}
