// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Peace Lily",
        LightNeeds = 3.7,
        AskingPrice = 50.00M,
        City = "Jacksonville",
        ZIP = 32258,
        Sold = false
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 4.5,
        AskingPrice = 20.00M,
        City = "Tallahassee",
        ZIP = 32306,
        Sold = false
    },
    new Plant()
    {
        Species = "Fig Tree",
        LightNeeds = 2.5,
        AskingPrice = 99.95M,
        City = "Fort Mill",
        ZIP = 29715,
        Sold = false
    },
    new Plant()
    {
        Species = "Golden Pothos",
        LightNeeds = 3.8,
        AskingPrice = 19.95M,
        City = "Jacksonville",
        ZIP = 32257,
        Sold = true
    },
    new Plant()
    {
        Species = "Silver Dollar Eucalyptus Tree",
        LightNeeds = 5.0,
        AskingPrice = 29.95M,
        City = "Fort Mill",
        ZIP = 29715,
        Sold = false
    }
};

Console.Clear();
string greeting = @"Welcome to Wet Your Plants!
Your one-stop shop for any and all plants";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
    0. Exit
    1. Display all plants
    2. Post a plant to be adopted
    3. Adopt a plant
    4. Delist a plant");

    choice = Console.ReadLine().Trim();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        DisplayAllPlants();
    }
    else if (choice == "2")
    {
        throw new NotImplementedException("Post a plant to be adopted");
    }
    else if (choice == "3")
    {
        throw new NotImplementedException("Adopt a plant");
    }
    else if (choice == "4")
    {
        throw new NotImplementedException("Delist a plant");
    }
    else
    {
        Console.WriteLine("Please choose from the options in the menu.");
    }

    // switch (choice)
    // {
    //     case = "0":
    //         Console.WriteLine("Goodbye!");
    //         break;

    //     case = "1":
    //         DisplayAllPlants();
    //         break;

    //     case = "2":
    //         throw new NotImplementedException();
    //         break;

    //     case = "3":
    //         throw new NotImplementedException();
    //         break;

    //     case = "4":
    //         throw new NotImplementedException();
    //         break;

    //     case < 0:
    //     case > 5:
    //         Console.WriteLine($"Please choose an existing item only!");

    //     default:
    //         Console.Write($"Do Better!");
    // }


}


void DisplayAllPlants()
{
    Console.WriteLine("Plants:");

    Console.WriteLine("Please enter a plant number: ");

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

    Plant chosenPlant = null;

    while (chosenPlant == null)
    {
        Console.WriteLine("Please enter a plant number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = plants[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }

        Console.WriteLine(@$"You chose: 
    {chosenPlant.Species}");
    }
}