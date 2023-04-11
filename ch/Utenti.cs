using System;
using ch;
using Internal;





public class Utente
{
    bool registrato = false;
    public string Cognome { get; set; } = "";
    public string Nome { get; set; } = "";
    public string Email { get; set; } = "";
    private string Password { get; set; } = "";
    public string NumeroDiTelefono { get; set; } = "";
    public Prenotazione? Prenotazione { get; set; }



    public Utente(string name, string surname, string email, string password, string phoneNumber)
    {
        Nome = name;
        Cognome = surname;
        Email = email;
        Password = password;
        NumeroDiTelefono = phoneNumber;
        registrato = true;
    }

    public override string ToString()
    {
        var nl = Environment.NewLine;

        return $"Nome = {Nome}" + nl
            + $"Cognome = {Cognome}" + nl
            + $"E-mail = {Email}" + nl
            + $"Numero di telefono = {NumeroDiTelefono}";
    }


    public void Checkpassword(Utente utente)
    {
        bool checkPassword = false;

        Console.WriteLine("Iserire la password per completare l'accesso:");

        while (!checkPassword)
        {
            var insertedPassword = Console.ReadLine();

            if (insertedPassword == utente.Password)
            {
                Console.WriteLine("Accesso Riuscito!");
                checkPassword = true;
            }
            else
            {
                Console.WriteLine("Password non corretta ritentare:");
            }
        }

    }

}

