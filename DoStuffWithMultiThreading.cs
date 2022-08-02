using System.Diagnostics;

namespace ThreadingExample;

public class DoStuffWithMultiThreading
{
    public List<string> Files { get; set; } = FileProcessoratorHandler.GetAllFiles();
    
    //create threads
    public void DoWork()
    {
        List<Thread> threads = new List<Thread>();
        var watch = Stopwatch.StartNew();
        foreach (var file in Files)
        {
            // take each file and process it with a thread of its own instead of ProcessFiles(file)
            // will be more CPU
            ThreadStart threadStart = () => { ProcessFile(file); };
            var thread = new Thread(threadStart);
            thread.Start();
            //this turns it back into serial processing if we leave it here so need the add below
            // thread.Join();
            threads.Add(thread);
        }
        //wait and join on all these threads and THEN call stopwatch - otherwise was calling stopwatch on only the main thread
        threads.ForEach(thread => thread.Join());
        watch.Stop();
        Console.WriteLine($"To process all the files it took: {watch.ElapsedMilliseconds} ms");
    }
    
    private void ProcessFile(string file)
    {
        FileProcessoratorHandler.ProcessFile(file);
    }
}