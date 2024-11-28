using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.Resources
{
    internal class EjecutarTareaParalelamente
    {
        public static async void Ejecutar(Func<Task> Action,TimeSpan intervalo, CancellationTokenSource cts)
        {
            try
            {
                while (!cts.IsCancellationRequested)
                {
                
                    await Action();

                    await Task.Delay(intervalo, cts.Token);
                
                }
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
