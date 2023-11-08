using Lesson3.Enums;

namespace Lesson3;

public static class Challenges
{
    public static CoinSide FlipCoin(Random? random = null)
    {
        random ??= new Random();
        throw new NotImplementedException();
    }

    public static int RollNSidedDice(int n, Random? random = null)
    {
        random ??= new Random();
        throw new NotImplementedException();
    }

    public static DateTime GetRenewedReturnDate(DateTime? dateTimeToday = null)
    {
        dateTimeToday ??= DateTime.Today;
        throw new NotImplementedException();
    }

    public static (int years, int months) CalculateAge(
        DateTime dateOfBirth,
        DateTime? dateTimeToday = null
    )
    {
        dateTimeToday ??= DateTime.Today;
        throw new NotImplementedException();
    }

    public static double CalculateSphereVolume(double radius)
    {
        throw new NotImplementedException();
    }

    public static double[] CalculateQuadraticEquationSolutions(double a, double b, double c)
    {
        throw new NotImplementedException();
    }

    public static int GetGuestCount()
    {
        throw new NotImplementedException();
    }

    public static void SplitBillEvenly()
    {
        Console.WriteLine("How many guests will the bill be split between?");
        try
        {
            var guestCount = int.Parse(Console.ReadLine() ?? "");
            if (guestCount < 0)
            {
                Console.WriteLine("The bill cannot be split between a negative number of guests.");
            }
            else
            {
                var billSharePerGuest = 100m / guestCount;
                Console.WriteLine($"That will be {billSharePerGuest:0.00} each, thank you!");
            }
        }
        finally
        {
            throw new NotImplementedException();
        }
    }

    public static void GreetCustomer()
    {
        var options = new[]
        {
            "Purchase some fruit",
            "Find out more about the fruit we sell",
            "Just have a browse",
        };
        Console.WriteLine("Welcome to the greengrocer's store! Your options:");
        for (var index = 0; index < options.Length; index++)
        {
            Console.WriteLine($"{index}. {options[index]}");
        }
        Console.WriteLine("Which option will you choose? Type its number:");
        var chosenOption = Console.ReadLine() ?? "";
        Console.WriteLine($"You selected: {options[int.Parse(chosenOption)]}.");
    }

    public static void ServeCustomer()
    {
        var fruitPrices = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
        {
            { "orange", 1.24m },
            { "apple", 0.95m },
        };
        Console.WriteLine(
            "We're glad you'd like to purchase some fruit. Here are the fruits we sell and their prices:"
        );
        foreach (var (fruit, price) in fruitPrices)
        {
            Console.WriteLine($"- Each {fruit}: {price}");
        }
        Console.WriteLine("Which fruit would you like?");
        var chosenFruit = Console.ReadLine() ?? "";
        Console.WriteLine($"That will be {fruitPrices[chosenFruit]}, please!");
    }

    public static int CountMondaysBetween(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
}
