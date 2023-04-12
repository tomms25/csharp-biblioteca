// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using ch;
using Internal;

Console.WriteLine("Hello, World!");

//Si vuole progettare un sistema per la gestione di una biblioteca.
//Gli utenti si possono registrare al sistema, fornendo:
//cognome
//nome
//email
//password
//recapito telefonico
//Gli utenti registrati possono prendere in prestito dei documenti che sono di vario tipo (libri, DVD).
//I documenti sono caratterizzati da:
//un codice identificativo di tipo stringa
//titolo
//anno
//settore (storia, matematica, economia, …)
//uno scaffale in cui è posizionato
//un autore (Nome, Cognome)
//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
//L’utente deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, prendere in prestito registrando il periodo (Dal/Al) del prestito e il documento.
//Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un utente.
//Creiamo anche una classe Biblioteca che contiene la lista dei documenti, la lista degli utenti e la lista dei prestiti. Contiene inoltre i metodi per le ricerche e per l’aggiunta dei documenti, utenti e prestiti.


//Variabili

var utenti = new List<Utente>();
var documenti = new List<Documento>();
var prenotazioni = new List<Prenotazione>();


//Definisco i documenti per i film 


documenti.Add(new Dvd("La fabbrica di cioccolato", 2005, "Fantastico", 2, "Tim Burton", 122));
documenti.Add(new Dvd("Iron Man", 2008, "Azione", 5, "Jon Favreau", 153));
documenti.Add(new Dvd("The Whale", 2022, "Drammatico", 4, "Darren Aronofsky", 118));
documenti.Add(new Dvd("Troy", 2004, "Avventura", 7, "Wolfgang Petersen", 171));
var documento1 = new Dvd("The Martian", 2015, "Sci-fi", 6, "Andy Weir", 141);
documenti.Add(documento1);



//Definisco i documenti per i libri

documenti.Add(new Libro("Il buio oltre la siepe", 1960, "Romanzo", 9, "Harper Lee", 297));
documenti.Add(new Libro("Cent'anni di solitudine", 1967, "Romanzo", 12, "Gabriel García Márquez", 231));
documenti.Add(new Libro("Il Signore degli Anelli", 1954, "Fantasy", 18, " J. R. R. Tolkien", 327));
documenti.Add(new Libro("Dante", 2020, "Biografico", 21, "Alessandro Barbero", 173));



//Variabili 

var prenotazione1 = new Prenotazione(DateOnly.Parse("23, 03, 2023"), DateOnly.Parse("25, 06, 2023"));
prenotazioni.Add(prenotazione1);

var utente1 = new Utente("Paolo", "Rossi", "paolo.rossi@gmail.com", "password1", "3207694037");
utenti.Add(utente1);

utente1.Prenotazione = prenotazione1;
documento1.Prenotazione = prenotazione1;


Console.WriteLine("Benvenuto nella Biblioteca. Accedi o Registrati per continuare (accedi/registrati):");



//Creo ciclo while per l'utente attivo registrazione e accesso

Utente utenteAttivo = null;
var statoAccesso = false;

while (!statoAccesso)
{
    var accesso = Console.ReadLine();

    if (accesso == "registrati")
    {
        var statoRegistrazione = false;

        while (!statoRegistrazione)
        {
            Console.WriteLine("Inserire il proprio nome:");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Inserire il proprio cognome:");
            string surname = Console.ReadLine() ?? "";

            Console.WriteLine("Inserire la propria email:");
            string email = Console.ReadLine() ?? "";

            Console.WriteLine("Inserire la password:");
            string password = Console.ReadLine() ?? "";

            Console.WriteLine("Inserire nuovamente la password:");
            string passwordRewrite = Console.ReadLine() ?? "";

            Console.WriteLine("Inserire il proprio recapito telefonico:");
            string phoneNumber = Console.ReadLine() ?? "";

            bool verificaEmail = true;

            foreach (Utente utente in utenti)
            {
                if (email == utente.Email)
                {
                    verificaEmail = false;
                    statoRegistrazione = true;
                    Console.WriteLine("E-mail già esistente, usare un' altra e-mail o effettuare l'accesso (accedi/registrati):");
                }
            }
            if (verificaEmail)
            {
                if (password == passwordRewrite)
                {
                    Utente obj = new Utente(name, surname, email, password, phoneNumber);

                    utenti.Add(obj);

                    Console.WriteLine("Registrazione effettuata ora puoi accedere (accedi):");

                    statoRegistrazione = true;
                }
                else
                {
                    Console.WriteLine("Le password non corrispondono, ripetere la registrazione");
                }
            }
        }
    }
    else if (accesso == "accedi")
    {
        Console.WriteLine("Per effettuare l'accesso inserire la propria e-mail:");
        bool checkEmail = false;

        while (!checkEmail)
        {
            bool emailTrovata = false;
            var insertedEmail = Console.ReadLine() ?? "";

            foreach (Utente utente in utenti)
            {
                if (insertedEmail == utente.Email)
                {
                    utente.Checkpassword(utente);
                    utenteAttivo = utente;
                    emailTrovata = true;
                    checkEmail = true;
                }
            }
            if (!emailTrovata)
            {
                Console.WriteLine("Email non trovata, ritentare:");
            }
        }

        statoAccesso = true;
    }
    else
    {
        Console.WriteLine("Comando non valido, ritentare (accedi/registrati):");
    }
}



//Ricerca dei film o dei libri

Console.WriteLine("Ora puoi effettuare la ricerca di un libro o di un DVD:");
var researchResult = false;

while (!researchResult)
{
    bool trovato = false;

    var research = Console.ReadLine();

    foreach (Documento documento in documenti)
    {
        if (research == documento.Titolo)
        {
            Console.WriteLine();
            Console.WriteLine(documento);
            Console.WriteLine();
            GetPrenotazione(documento, utenteAttivo);
            trovato = true;
            researchResult = true;
        }
    }

    if (!trovato)
    {
        bool exitOrNo = false;
        Console.WriteLine("Nessun risultato, continuare con una nuova ricerca o uscire? (continua/esci)");

        while (!exitOrNo)
        {
            var exit = Console.ReadLine();

            if (exit == "esci")
            {
                Console.WriteLine("Grazie, alla prossima!");
                exitOrNo = true;
                researchResult = true;
            }
            else if (exit == "continua")
            {
                Console.WriteLine("Inserire nuova ricerca:");
                exitOrNo = true;
            }
            else
            {
                Console.WriteLine("Comando non valido ritentare:");
            }
        }
    }
}

ResearchPrenotation();


void GetPrenotazione(Documento documento, Utente utente)
{
    Console.WriteLine("Vuoi prenotarlo? (s/N)");
    string prenotazioneOno = Console.ReadLine();

    if (prenotazioneOno == "s")
    {
        Console.WriteLine("Per procedere con la prenotazione inserire data di inizio della prenotazione:");
        bool primaData = false;
        DateOnly dataInizio = DateOnly.Parse("1, 1, 1");

        while (!primaData)
        {
            var dataInizioInserita = Console.ReadLine() ?? "";
            DateOnly data;

            if (DateOnly.TryParse(dataInizioInserita, out data))
            {
                dataInizio = DateOnly.Parse(dataInizioInserita);
                primaData = true;
            }
            else { Console.WriteLine("Data non valida per favore riprovare:"); }
        }

        Console.WriteLine("Per procedere con la prenotazione inserire data di fine della prenotazione:");
        bool secondaData = false;
        DateOnly dataFine = DateOnly.Parse("1, 1, 1");

        while (!secondaData)
        {
            var dataFineInserita = Console.ReadLine() ?? "";
            DateOnly data;

            if (DateOnly.TryParse(dataFineInserita, out data))
            {
                dataFine = DateOnly.Parse(dataFineInserita);
                secondaData = true;
            }
            else { Console.WriteLine("Data non valida per favore riprovare:"); }
        }

        var prenotazioneAttuale = new Prenotazione(startDate: dataInizio, finishDate: dataFine);

        utente.Prenotazione = prenotazioneAttuale;
        documento.Prenotazione = prenotazioneAttuale;

        prenotazioni.Add(prenotazioneAttuale);

        Console.WriteLine();
        StampaPrenotazione(prenotazioneAttuale, utente, documento);
    }
}

void StampaPrenotazione(Prenotazione prenotazione, Utente utente, Documento documento)
{
    var nl = Environment.NewLine;
    Console.WriteLine($"Prenotazione effettuata da: {utente.Nome} {utente.Cognome}" + nl
        + $"Oggetto prenotato: {documento.Titolo}" + nl
        + $"Data di inizio prenotazione: {prenotazione.DataInizio}" + nl
        + $"Data di fine prenotazione: {prenotazione.DataFine}");
}

void ResearchPrenotation()
{
    Console.WriteLine();
    Console.WriteLine("Ora puoi cercare le prenotazioni inserendo nome e cognome di un utente.");
    Console.WriteLine();

    var researchResultPrenotazione = false;

    while (!researchResultPrenotazione)
    {
        Console.WriteLine("Inserisci il nome di un utente:");
        var insertedName = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome dell'utente:");
        var insertedSurname = Console.ReadLine();
        var utenteTrovato = false;

        foreach (Utente utente in utenti)
        {
            if (insertedName == utente.Nome & insertedSurname == utente.Cognome)
            {
                Prenotazione prenotazioneRicercata = utente.Prenotazione;

                foreach (Documento documento in documenti)
                {
                    if (prenotazioneRicercata == documento.Prenotazione)
                    {
                        Console.WriteLine();
                        StampaPrenotazione(prenotazioneRicercata, utente, documento);
                        utenteTrovato = true;
                    }
                }
            }
        }
        if (utenteTrovato)
        {
            researchResultPrenotazione = true;
        }
        else
        {
            Console.WriteLine("Nessun utente trovato. Riprova:");
            Console.WriteLine();
        }
    }

}