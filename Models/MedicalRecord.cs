#nullable disable

using System;

abstract class MedicalRecord {
    private int RecordID; //make it automatic
    private string Date;
    private string Diagnosis;
    private string Notes;

    public MedicalRecord (int _recid,string _date, string _diag,string _notes) {
        recordID = _recid; date = _date; diagnosis = _diag; notes = _notes;
    }

    public int recordID {
        get {return RecordID;}
        set {
            if (value>=1) RecordID = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string date {
        get {return Date;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 13) Date = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string diagnosis {
        get {return Diagnosis;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Diagnosis = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public string notes {
        get {return Notes;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 200) Notes = value;
            else throw new ArgumentException("Error oi!");
        }
    }

    public abstract void DisplayRecord();
}