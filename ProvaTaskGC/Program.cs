using System;

namespace ProvaTaskGC
{
    class Program
    {
        private static TaskManager scheduler = new TaskManager();
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Task Manager\n");
            Console.WriteLine("Indica a quale funzionalità vuoi accedere:\n");
            Console.WriteLine("1. Aggiungere un nuovo Task.");
            Console.WriteLine("2. Visualizzare tutti i Task inseriti.");
            Console.WriteLine("3. Filtrare i Task");
            Console.WriteLine("4. Eliminare un Task");

            do
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Create();
                        //Dato che il salvataggio non è una competenza dell'utente implemento salvataggio automatico nella classe Task Manager
                        break;
                    case '2':
                        ViewAll();
                        break;
                    case '3':
                        Filter();
                        break;
                    case '4':
                        Remove();
                        break;
                    default:
                        break;
                }
            } while (true);
           

        //Datetime.tryparse
    }

        private static void Filter()
        {
            Level level;
            do
            {
                Console.Write(" Quali task vuoi visionare? (Basso, Medio, Alto)");  //dovrebbe filtrare i task per livello di importanza
            } while (!Level.TryParse(Console.ReadLine(), out level));

                Console.WriteLine($"{scheduler.Filtered(level)}");  //stampa comunque tutti i task forse errore nella funzione in task manager
            
        }

        private static void Create()
        {
            string description;
            DateTime deadline;
            Level level;
            
                Console.Write(" Inserisci una breve descrizione del task: ");
                description = (Console.ReadLine());

            do
            {
                Console.Write("Inserisci la data di scadenza del task (mm/gg/aaaa): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out deadline) || DateTime.Compare(DateTime.Today, deadline) > 0); 
            //chiede di inserire la data finchè non viene inserita nel formato corretto e finchè la data inserita è precedente a quella odierna
                

            do
            {
                Console.Write("Inserisci il livello di importanza(Basso, Medio, Alto): ");
            } while (!Level.TryParse(Console.ReadLine(), out level));

            Task t = scheduler.CreateTask(description,deadline,level);
            scheduler.Save();       //Lo salvo ogni volta che l'utente ne crea uno nuovo (DA SISTEMARE)
            Console.WriteLine($"Task: {t.Descrizione}, Scadenza: {t.Scadenza}, Livello di Importanza: {t.Importanza}");
            Console.WriteLine("Task salvato nell'elenco");
            
        }

        private static void ViewAll()
        {
            Console.WriteLine($"\n{scheduler.View()}");
        }

        private static void Remove()
        {
            int id;
            do
                Console.Write(" Inserisci l'id del Task da eliminare:");
            while (!int.TryParse(Console.ReadLine(), out id));

            if (scheduler.TaskSearch(id))   
            {
                scheduler.RemoveTask(id);
                Console.WriteLine("Task rimosso!");
            }
            else
                Console.WriteLine("Il task indicato non è presente nell'elenco.");
        }
    }
}
