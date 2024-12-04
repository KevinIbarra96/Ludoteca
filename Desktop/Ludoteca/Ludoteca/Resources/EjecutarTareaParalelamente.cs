using System.Diagnostics;

namespace Ludoteca.Resources
{
    internal class EjecutarTareaParalelamente
    {
        public static async void Ejecutar(Func<Task> Action, TimeSpan intervalo, CancellationTokenSource cts)
        {
            while (!cts.IsCancellationRequested)
            {
                try
                {
                    await Action();
                    await Task.Delay(intervalo, cts.Token);
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
