#nullable disable

class LoginManager
{
    private string Email;
    private string Password;
    private string VetName;

    public void LoadAccount()
    {
        if (!File.Exists("Data\\account.txt"))
        {
            Console.WriteLine("account.txt not found");
            Console.ReadKey();
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader("Data\\account.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] data = line.Split(',');

                    if (data.Length<3) continue;

                    Email = data[0];
                    Password = data[1];
                    VetName = data[2];
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to read file.");
            Console.ReadKey();
        }
    }

    public string email
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
        LoadAccount();
        return _email==Email && _pass==Password;
    }
}