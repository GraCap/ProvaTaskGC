using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProvaTaskGC
{
    
    class TaskManager
    {
        private static int _ID;
        private Dictionary<int, Task> _project = new Dictionary<int, Task>();
        
        private static TaskManager scheduler = new TaskManager();
        
        public Task CreateTask(string descrizione, DateTime scadenza, Level importanza)
        {
            Task activity = new Task(descrizione, scadenza, importanza);
            _project.Add(++_ID, activity);
            
            return activity;

        }

        public bool TaskSearch(int id)
        {
            return _project.ContainsKey(id);
        }

        public string View()    //visualizza l'elenco completo dei task
        {
                string s = "";
                foreach (Task activity in _project.Values)
                {
                    s += activity.ViewInfoTask + '\n'; //richiama la funzione che mostra il singolo task
                }
                return s;
            
        }

        public void Save()       //DA SISTEMARE. Viene creato un file vuoto
        {
                const string fileName = @"task.txt";
                //using chiude il flusso e assicura l'integrità del dato salvato
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine(scheduler.View());
                    sw.Close();
                }
        }

        public string Filtered(Level level)     //l'utente ha inserito il livello dei task da visionare
        {
            
            string s = "";
            //controllo all'interno del dizionario i task confrontando il livello di ciascuno con quello inserito dall'utente e lo restituisco al chiamante
            foreach (Task activity in _project.Values)      
            {
                if (level == Level.Basso) 
                {
                    s += activity.ViewInfoTask + '\n';
                }
                else if (level == Level.Medio)
                {
                    s += activity.ViewInfoTask + '\n';
                }
                else
                    s += activity.ViewInfoTask + '\n';
            }
            return s;
        }


        public void RemoveTask(int id)
        {
            _project.Remove(id);
        }

    }
}
  