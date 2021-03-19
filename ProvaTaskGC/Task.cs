using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaTaskGC
{ 
    enum Level
    {
        Basso,
        Medio,
        Alto
    }
    class Task
    {
        private static TaskManager scheduler = new TaskManager();
        public string Descrizione { get; }
        public DateTime Scadenza { get; }
        public Level Importanza { get; }


        public Task(string descrizione, DateTime scadenza, Level importanza)
        {
            Descrizione = descrizione;
            Scadenza = scadenza;
            Importanza = importanza;
            
        }

        public string ViewInfoTask
        {
            get
            {
                return ($"Descrizione: {Descrizione}, Scadenza: {Scadenza}, Livello di Importanza: {Importanza}");
            }
        }

      

    }
}
