class VaccineRecord : MedicalRecord {
    private string VaccName;
    private string Dose;
    private string NextDue;

    public VaccineRecord (int _recid,string _date,string _vetname,string _diag,string _notes,string _vaccname,string _dose,string _nextdue) 
    : base( _recid, _date, _vetname, _diag, _notes) {
        vaccname = _vaccname; dose = _dose; nextdue = _nextdue;
    }

    public string vaccname {
        //get; set;
    }

    public string dose {
        //get; set;
    }

    public string nextdue {
        //get; set;
    }

    public override void DisplayRecord() {
        //Vaccine Record Output
    }
}