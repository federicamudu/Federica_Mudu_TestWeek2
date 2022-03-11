using System;
using System.Collections.Generic;
using System.Text;

namespace Weeh2.Esercitazione
{
    public class Task
    {
        public string Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
        public int LivelloPriorita { get; set; }

        public override string ToString()
        {
            return $"Descrizione task: {Descrizione}-Livello di priorità: {LivelloPriorita}-Data di scadenza {DataScadenza}";
        }

    }

    
}
