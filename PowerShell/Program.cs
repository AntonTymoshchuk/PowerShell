using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShell
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static string RunScript(string scriptText)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace(); // создание процесса 
            runspace.Open(); // открытие процесса 
            Pipeline pipeline = runspace.CreatePipeline(); // создание конвейера 
            pipeline.Commands.AddScript(scriptText); //добавление сценария 
            pipeline.Commands.Add("Out-String"); // эта команда форматирует вывод. Без нее возвращаются реальные объекты. 
            Collection<PSObject> results = pipeline.Invoke(); // запуск сценария 
            runspace.Close(); // закрыте процесса 
            StringBuilder stringBuilder = new StringBuilder(); // конвертация результата в одну строку с использованием StringBuilder;
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            return stringBuilder.ToString(); // возврат значения
        }
    }
}
