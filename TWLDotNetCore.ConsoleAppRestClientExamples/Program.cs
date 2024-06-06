// See https://aka.ms/new-console-template for more information
using TWLDotNetCore.ConsoleAppRestClientExamples;

Console.WriteLine("Hello, World!");

RestClientExample restClientExample = new RestClientExample();
await restClientExample.RunAsync();
Console.WriteLine();
