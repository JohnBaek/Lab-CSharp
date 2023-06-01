
// Target of test multicore 
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Process the array using multiple cores
Parallel.ForEach(numbers , number =>
{
    // Simulation Performence Delay
    int result = Compute(number);
    
    // Show output
    Console.WriteLine("Result for {0}: {1}", number, result);
    
    // Wait for all parallel tasks to complete
    Parallel.ForEach(numbers, num => Console.WriteLine("Task for {0} completed", num));

    Console.WriteLine("All tasks completed. Press any key to exit.");
    Console.ReadKey();
});


static int Compute(int number)
{
    // Simulate some time-consuming computation
    Task.Delay(1000).Wait();

    // Perform some computation on the number
    int result = number * number;

    return result;
}