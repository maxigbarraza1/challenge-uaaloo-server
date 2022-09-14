namespace _NET;

public class Cliente
{
    public Cliente(string name, string lastname, string address)
    {
        this.name = name;
        this.lastname = lastname;
        this.address = address;
    }

    public string name { get; set; }
    public string lastname { get; set; }
    public string address { get; set; }

}
