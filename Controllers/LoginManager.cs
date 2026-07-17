#nullable disable

using System.Diagnostics;

class LoginManager
{
    private string Email = "doc@gmail.com";
    private string Password = "zorro123";
    private string VetName = "Johnrode";

    public  string email
    {
        get {return Email;}
    }

    public  string pass
    {
        get {return Password;}
    }

    public  string vetName 
    {
        get {return VetName;}
    }

    public bool LoginAuth(string _email,string _pass)
    {
        return _email==Email && _pass==Password;
    }
}