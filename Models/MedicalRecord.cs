#nullable disable

public enum RecordType
{
    Checkup,
    Vaccine,
    Surgery
}

abstract class MedicalRecord 
{
    private string RecordID; //make it automatic, make it string (C00123, V00123, S00123)
    private string Date;
    private string Diagnosis;
    private string Notes;

    public MedicalRecord (string _recid, string _date, string _diag,string _notes) 
    {
        recordID = _recid; date = _date; diagnosis = _diag; notes = _notes;
    }

    public string recordID 
    {
        get {return RecordID;}
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                RecordID = value;
            else
                throw new ArgumentException("Record ID cannot be empty.");
        }
    }

    public string date 
    {
        get {return Date;}
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                Date = value;
            else
                throw new ArgumentException("Date cannot be empty.");
        }
    }

    public string diagnosis 
    {
        get {return Diagnosis;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20) Diagnosis = value;
            else throw new ArgumentException("Diagnosis is empty or too long.");
        }
    }

    public string notes 
    {
        get {return Notes;}
        set {
            if (!string.IsNullOrWhiteSpace(value) && value.Length <= 200) Notes = value;
            else throw new ArgumentException("Notes is empty or too long.");
        }
    }

    public abstract RecordType recordType
    {
        get;
    }
    public abstract void DisplayRecord();
}