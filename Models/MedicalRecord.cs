abstract class MedicalRecord {
    private int RecordID;
    private string Date;
    private string VetName;
    private string Diagnosis;
    private string Notes;
    private static int TotalRecords = 0;

    public MedicalRecord (int _recid,string _date,string _vetname,string _diag,string _notes) {
        recordID = _recid; date = _date; vetname = _vetname; diagnosis = _diag; notes = _notes; TotalRecords++;
    }

    public int recordID {
        get{return RecordID;}
        set{if (value>0) RecordID=value;}
    }

    public string date {
        //get; set;
    }

    public string vetname {
        //get; set;
    }

    public string diagnosis {
        //get; set;
    }

    public string notes {
        //get; set;
    }

    public abstract void DisplayRecord();
}