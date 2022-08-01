using System.Diagnostics;

namespace ThreadingExample;

public class NonThreadingExample
{
    // get a list of all of our files from processorator
    // returns a list of strings that point to the files
    public List<string> Files { get; set; } = FileProcessoratorHandler.GetAllFiles();

    
    // this took 5542 ms with this method
    public void DoWork()
    {
        var watch = Stopwatch.StartNew();
        foreach (var file in Files)
        {
            ProcessFile(file);
        }
        watch.Stop();
        Console.WriteLine($"To process all the files it took :{watch.ElapsedMilliseconds} ms");
    }

    private void ProcessFile(string file)
    {
        FileProcessoratorHandler.ProcessFile(file);
    }
}