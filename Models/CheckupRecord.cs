class CheckupRecord : MedicalRecord {
    private double Weight;
    private double Temperature;

    public CheckupRecord (int _recid,string _date,string _vetname,string _diag,string _notes,double _weight,double _temp) 
    :base(_recid, _date, _vetname, _diag, _notes) {
        weight = _weight;   temp = _temp;
    }

    public double weight {
        //get; set;
    }

    public double temp {
        //get; set;
    }

    public override void DisplayRecord() {
        //Checkup Record Output
    }
}