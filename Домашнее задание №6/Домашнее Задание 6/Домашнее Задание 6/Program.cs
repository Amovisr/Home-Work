using System.Diagnostics;

Process[] process = Process.GetProcesses();

for (int i = 0; i < process.Length; i++)

{
    Process current = process[i];

    Console.WriteLine($"{current.Id}\t{current.ProcessName}\t{current.PeakVirtualMemorySize64}");

   
}

Console.WriteLine("Укажите просецц который хотите закрыть");

int executProcess = Int32.Parse(Console.ReadLine());

for (int i = 0;  i < process.Length; i++)
{
    Process current = process[i];

    if (current.Id == executProcess)
    {
        current.Kill();
        Console.WriteLine($"Данный процесс: ({current.Id}), был завершен");
    }

}

return 0;
