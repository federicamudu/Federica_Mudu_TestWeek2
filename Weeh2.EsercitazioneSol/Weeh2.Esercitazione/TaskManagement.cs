using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Weeh2.Esercitazione
{
    public class TaskManagement
    {
        public static int SchermoMenuTask()
        {
            Console.WriteLine("1. Visualizzare i tasks;");
            Console.WriteLine("2. Aggiungere un nuovo task;");
            Console.WriteLine("3. Eliminare un task esistente;");
            Console.WriteLine("4. Filtrare i tasks per importanza (ovvero per livello di priorità);");
            Console.WriteLine("5. Leggi i task che hai salvato dal file");
            Console.WriteLine("Qualsiasi altro valore per uscire");
            Console.Write("Scelta: >");
            Int32.TryParse(Console.ReadLine(), out int scelta);
            return scelta;
        }

        internal static Task InserisciTask()
        {
            Task task = new Task();
            bool success;
            DateTime dataScadenza;
            Console.WriteLine("Inserisci descrizione: ");
            task.Descrizione = Console.ReadLine();
            Console.WriteLine("Inserisci data di scadenza: ");
            DateTime.TryParse(Console.ReadLine(), out dataScadenza);
            while (DateTime.Now < task.DataScadenza)
            {
                Console.WriteLine("E' un task, non una macchina del tempo.\nInserisci una data futura: ");
                DateTime.TryParse(Console.ReadLine(), out dataScadenza);
            }
            task.DataScadenza = dataScadenza;
            Console.WriteLine("Inserisci il livello di priorità (1. Alto, 2. Medio, 3. Basso): ");
            success = Int32.TryParse(Console.ReadLine(), out int livelloPriorita);
            while (!success)
            {
                Console.WriteLine("Inserisci il livello di priorità");
                success = Int32.TryParse(Console.ReadLine(), out livelloPriorita);
            }
            task.LivelloPriorita = livelloPriorita;
            return task;
        }

        

        public static void ScriviTaskSuFile(ArrayList task)
        {
            string path = @"C:\Users\Federica\Desktop\Esercitazione\Weeh2.EsercitazioneSol\Weeh2.Esercitazione\AgendaTask.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Task taskDaScrivere in task)
                {
                    sw.WriteLine(taskDaScrivere);
                    
                }
            }
        }

        public static ArrayList CaricaTaskDaFile()
        {
            ArrayList taskCaricatiDaFile = new ArrayList();
            string path = @"C:\Users\Federica\Desktop\Esercitazione\Weeh2.EsercitazioneSol\Weeh2.Esercitazione\AgendaTask.txt";
            string line;
            using (StreamReader sr = File.OpenText(path))
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] valoriTask = line.Split('-');
                    string descrizione = valoriTask[0].Substring(18);
                    int livelloPriorita = Int32.Parse(valoriTask[1].Substring(21));
                    DateTime dataScadenza = DateTime.Parse(valoriTask[2].Substring(17));
                    Task t = new Task()
                    {
                        Descrizione = descrizione,
                        LivelloPriorita = livelloPriorita,
                        DataScadenza = dataScadenza
                    };
                    taskCaricatiDaFile.Add(t);
                    line = sr.ReadLine();

                }
            }
            return taskCaricatiDaFile;
        }

        public static void LeggiTaskDaFile()
        {
            string path = @"C:\Users\Federica\Desktop\Esercitazione\Weeh2.EsercitazioneSol\Weeh2.Esercitazione\AgendaTask.txt";
            string line;
            using (StreamReader sr = File.OpenText(path))
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
            }
        }

        public static Task CarcaTask(ArrayList tasks)
        {
            Console.WriteLine("Cerca task: ");
            string descrizione = Console.ReadLine();

            foreach(Task task in tasks)
            {
                if (task.Descrizione.Equals(descrizione))
                {
                    return task;
                }
            }
            return null;
        }

        public static void FiltroPriorita(ArrayList tasks)
        {
            Console.WriteLine("Inserisci quale livello di priorità vuoi filtrare: ");
            int livelloPrioritaUtente = Int32.Parse(Console.ReadLine());
            foreach (Task task in tasks)
            {
                if (task.LivelloPriorita == livelloPrioritaUtente)
                {
                    Console.WriteLine($"Task: {task.Descrizione}, con priorità: {task.LivelloPriorita} e data di scadenza: {task.DataScadenza}");
                }
            }
        }
        public static void EliminaTask(ArrayList tasks)
        {
            Task taskDaCancellare = TaskManagement.CarcaTask(tasks);
            if (taskDaCancellare != null)
            {
                tasks.Remove(taskDaCancellare);
                Console.WriteLine("Cancellazione avvenuta con successo!\nHai portato a termine il tuo task.");
            }
            else
            {
                Console.WriteLine("Task non trovato!");
            }
        }

        
    }
}
