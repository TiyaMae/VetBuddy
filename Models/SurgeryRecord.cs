class SurgeryRecord : MedicalRecord {
    private string Procedure;
    private string RecoveryStatus;

    public SurgeryRecord (int _recid,string _date,string _vetname,string _diag,string _notes,string _procedure,string _recstatus)
    : base( _recid, _date, _vetname, _diag, _notes) {
        procedure = _procedure; recstatus = _recstatus;
    }

    public string procedure {
        //get; set;
    }

    public string recstatus {
        //get; set;
    }

    public override void DisplayRecord() {
        //Surgery Record Output
    }
}