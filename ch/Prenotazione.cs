using System;
namespace ch
{
	public class Prenotazione
	{
        public DateOnly DataInizio { get; set; }
        public DateOnly DataFine { get; set; }

        public Prenotazione(DateOnly startDate, DateOnly finishDate)
        {
            DataInizio = startDate;
            DataFine = finishDate;
        }
    }
}

