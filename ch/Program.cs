// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

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




var utenti = new List<Utente>();
var documenti = new List<Documento>();
var prenotazioni = new List<Prenotazione>();


documenti.Add(new Dvd("La fabbrica di cioccolato", 2005, "Fantastico", 2, "Tim Burton", 122));
documenti.Add(new Dvd("Iron Man", 2008, "Azione", 5, "Jon Favreau", 153));
documenti.Add(new Dvd("The Whale", 2022, "Drammatico", 4, "Darren Aronofsky", 118));
documenti.Add(new Dvd("Troy", 2004, "Avventura", 7, "Wolfgang Petersen", 171));
var documento1 = new Dvd("The Martian", 2015, "Sci-fi", 6, "Andy Weir", 141);
documenti.Add(documento1);
