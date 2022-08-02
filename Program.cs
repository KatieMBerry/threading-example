// See https://aka.ms/new-console-template for more information
using ThreadingExample;

//10 files of 1000 rows per file
FileProcessoratorHandler.CreateTestFiles(10, 1000);

var nonThreadingExample = new NonThreadingExample();
nonThreadingExample.DoWork();

var threadingExample = new DoStuffWithMultiThreading();
threadingExample.DoWork();