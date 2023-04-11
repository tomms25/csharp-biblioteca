using System;
using ch;



public class Documento
{
    public string Codice { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public int NumeroScaffale { get; set; }
    public string Autore { get; set; }
    public Prenotazione? Prenotazione { get; set; }
}

public class Dvd : Documento
{
    public double Durata { get; set; }

    public Dvd(string titolo, int anno, string settore, int numeroScaffale, string Autore, double durata)
    {
        var code = new Random().Next(0, 100000000);
        base.Codice = code.ToString().PadLeft(8, '0');
        base.Titolo = titolo;
        base.Anno = anno;
        base.Settore = settore;
        base.NumeroScaffale = numeroScaffale;
        base.Autore = Autore;
        Durata = durata;
    }

    public override string ToString()
    {
        var nl = Environment.NewLine;

        return $"Titolo: {Titolo}" + nl
            + $"Anno: {Anno}" + nl
            + $"Settore: {Settore}" + nl
            + $"Autore: {Autore}" + nl
            + $"Scaffale numero: {NumeroScaffale}" + nl
            + $"Durata: {Durata} min";
    }
}
public class Libro : Documento
{
    public int NumPagine { get; set; }

    public Libro(string titolo, int anno, string settore, int numeroScaffale, string Autore, int numPagine)
    {
        var code = new Random().Next(0, 100000000);
        base.Codice = code.ToString().PadLeft(8, '0');
        base.Titolo = titolo;
        base.Anno = anno;
        base.Settore = settore;
        base.NumeroScaffale = numeroScaffale;
        base.Autore = Autore;
        NumPagine = numPagine;
    }
    public override string ToString()
    {
        var nl = Environment.NewLine;

        return $"Titolo: {Titolo}" + nl
            + $"Anno: {Anno}" + nl
            + $"Settore: {Settore}" + nl
            + $"Autore: {Autore}" + nl
            + $"Scaffale numero: {NumeroScaffale}" + nl
            + $"Numero di pagine: {NumPagine}";
    }
}

