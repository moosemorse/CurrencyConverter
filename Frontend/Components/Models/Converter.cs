namespace Frontend.Components.Models;

/* 
    Some notes:
    - right now, our model is very simple and tracks all the required fields with minimal security and design
    - it will records inputs, handle submits, return result to home page

    Ideas:
    - separate class into separate stages i.e. class for input, class for processing, class for output (or records)
    - add validation to model for input
    - create interfaces for each stage
    - dependency injections for processing stage - making call to service/adapter for client api
    - im not sure if this is a c# thing but create separate namespaces for each stage (is everything a model?)
*/

public class Converter
{
    
    public double submit(ConverterInput input)
    {

        // rough way to check that data is being passed correctly, could be done using Logger
        Console.WriteLine("All user input:");
        Console.WriteLine($"Starting rate: {input.StartingRate}");
        Console.WriteLine($"Amount: {input.Amount}");
        Console.WriteLine($"Target rate: {input.TargetRate}");  

        var result = 100; // TODO: placeholder, to be replaced by api client call to backend

        return result;
    }
    
}