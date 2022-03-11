using System;
using System.Collections;

namespace Weeh2.Esercitazione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### La tua Agenda! ###");
            ArrayList listaTask = new ArrayList();
            bool continua = true;
            while (continua)
            {
                int scelta = TaskManagement.SchermoMenuTask();

                switch (scelta)
                {
                    case 1:
                        //Visualizzare i tasks
                        TaskManagement.CaricaTaskDaFile();
                        foreach(Task lineaTask in listaTask)
                        {
                            Console.WriteLine(lineaTask);
                        }
                        break;
                    case 2:
                        //Aggiungere un nuovo task
                        listaTask.Add(TaskManagement.InserisciTask());
                        TaskManagement.ScriviTaskSuFile(listaTask);
                        Console.WriteLine("Task aggiunto con successo!");
                        break;
                    case 3:
                        //Eliminare un task esistente
                        TaskManagement.EliminaTask(listaTask);
                        break;
                    case 4:
                        //Filtrare i tasks per importanza
                        TaskManagement.FiltroPriorita(listaTask);
                        break;
                    default:
                        continua = false;
                        Console.WriteLine("Chiusura Agenda.\nArrivederci");
                        break;
                }
            }
        }
    }
}
