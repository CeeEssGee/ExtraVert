// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;
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
        Sold = false,
        AvailableUntil = new DateTime(2023, 08, 20)
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 4.5,
        AskingPrice = 20.00M,
        City = "Tallahassee",
        ZIP = 32306,
        Sold = false,
        AvailableUntil = new DateTime(2023, 08, 11)
    },
    new Plant()
    {
        Species = "Fig Tree",
        LightNeeds = 2.5,
        AskingPrice = 99.95M,
        City = "Fort Mill",
        ZIP = 29715,
        Sold = false,
        AvailableUntil = new DateTime(2023, 09, 15)
    },
    new Plant()
    {
        Species = "Golden Pothos",
        LightNeeds = 3.8,
        AskingPrice = 19.95M,
        City = "Jacksonville",
        ZIP = 32257,
        Sold = true,
        AvailableUntil = new DateTime(2023, 07, 26)
    },
    new Plant()
    {
        Species = "Silver Dollar Eucalyptus Tree",
        LightNeeds = 5.0,
        AskingPrice = 29.95M,
        City = "Fort Mill",
        ZIP = 29715,
        Sold = false,
        AvailableUntil = new DateTime(2023, 08, 18)
    }
};

Random random = new Random();

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
    4. Delist a plant
    5. Plant of the day
    6. Search by Light Level
    7. App Statistics");

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
        PostAPlant();
    }
    else if (choice == "3")
    {
        AdoptAPlant();
    }
    else if (choice == "4")
    {
        DelistAPlant();
    }
    else if (choice == "5")
    {
        RandomPlantOfTheDay();
    }
    else if (choice == "6")
    {
        SearchByLightLevel();
    }
    else if (choice == "7")
    {
        AppStatistics();
    }
    else
    {
        Console.WriteLine("Please choose from the options in the menu.");
    }

    // switch (choice)
    // { 
    // need these to be integers??
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
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for ${plants[i].AskingPrice}.");
        //  and is available until {plants[i].AvailableUntil}
    }
    Console.WriteLine("");
}

void PostAPlant()
{
    Console.WriteLine("Please enter the Species");
    string postSpecies = Console.ReadLine().Trim();
    Console.WriteLine("Please enter the Light Needs on a scale of 1.0 (shade) and 5.0 (full sun)");
    double postLightNeeds = double.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the Asking Price");
    decimal postAskingPrice = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the city");
    string postCity = Console.ReadLine().Trim();
    Console.WriteLine("Please enter the 5-digit zip code");
    int postZIP = int.Parse(Console.ReadLine());
    bool postSold = false;
    Console.WriteLine("Please enter the month the plant will be available until");
    int postMonth = int.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the day the plant will be available until");
    int postDay = int.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the year the plant will be available until");
    int postYear = int.Parse(Console.ReadLine());
    DateTime postAvailableUntil = new DateTime(postYear, postMonth, postDay);
    // Console.WriteLine("Please enter the year, month, and day for the Available Until date");
    // new DateTime postAvailableUntil = DateTime.Parse(Console.ReadLine());


    plants.Add(new Plant()
    {
        Species = postSpecies,
        LightNeeds = postLightNeeds,
        AskingPrice = postAskingPrice,
        City = postCity,
        ZIP = postZIP,
        Sold = postSold,
        AvailableUntil = postAvailableUntil
    });

    Console.WriteLine($"Your {postSpecies} has sucessfully been added.");
}

void AdoptAPlant()
{
    Console.WriteLine("Plants:");

    Console.WriteLine("Please enter a plant number for the plant you want to adopt: ");
    DateTime now = DateTime.Now;
    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].Sold == false && plants[i].AvailableUntil > now)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} for ${plants[i].AskingPrice}.");
        }
    }
    Console.WriteLine("");

    int adoptedPlant = int.Parse(Console.ReadLine());

    plants[adoptedPlant - 1].Sold = true;
}

void DelistAPlant()
{
    Console.WriteLine("Plants:");

    Console.WriteLine("Please enter a plant number for the plant you want to remove from the list: ");

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} for ${plants[i].AskingPrice}.");

    }

    int delistedPlant = int.Parse(Console.ReadLine());

    plants.RemoveAt(delistedPlant - 1);
}

void RandomPlantOfTheDay()
{
    int randomPlant = random.Next(0, plants.Count);
    while (plants[randomPlant].Sold == true)
    {
        randomPlant = random.Next(0, plants.Count);
    }
    Console.WriteLine($"{plants[randomPlant].Species} has {plants[randomPlant]} light needs, is in {plants[randomPlant].City}, and {(plants[randomPlant].Sold ? "was sold" : "is available")} for ${plants[randomPlant].AskingPrice}.");

}

void SearchByLightLevel()
{
    Console.WriteLine("Enter a maximum light level between 1.0 (shade) and 5.0 (full sun)");

    double userLightLevel = double.Parse(Console.ReadLine());

    List<Plant> plantsByLight = new List<Plant>();

    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= userLightLevel && plant.Sold == false)
        {
            plantsByLight.Add(plant);
        }
    }

    if (plantsByLight.Count > 0)
    {
        Console.WriteLine("These plants match the criteria:");
        int i = 1;
        foreach (Plant plant in plantsByLight)
        {

            Console.WriteLine($"{i++}. {plant.Species} in {plant.City} has a light level of {plant.LightNeeds} and {(plant.Sold ? "was sold" : "is available")} for ${plant.AskingPrice}.");
        }
    }
    else
    {
        Console.WriteLine("There were no plants that matched your criteria.");
    }
}

void AppStatistics()
{


    Console.WriteLine("Stats");
    Console.WriteLine("Lowest price plant name = ");
    LowestPrice();
    // Console.WriteLine("Number of Plants Available = ");
    // Console.WriteLine("Name of plant with highest light needs = ");
    // Console.WriteLine("Average light needs = ");
    // Console.WriteLine("Percentage of plants adopted = ");
}

// this gets me the lowest price but not the species name
void LowestPrice()
{
    decimal lowestPrice;
    if (plants.Any())
    {
        lowestPrice = Decimal.MaxValue;
        foreach (Plant plant in plants)
        {
            if (plant.AskingPrice <= lowestPrice)
            {
                lowestPrice = plant.AskingPrice;
            }
        }
        Console.WriteLine(lowestPrice);

    }


}