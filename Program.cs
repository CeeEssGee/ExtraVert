// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Peace Lily",
        PlantType = "flower",
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
        PlantType = "bush",
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
        PlantType = "tree",
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
        PlantType = "bush",
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
        PlantType = "tree",
        LightNeeds = 5.0,
        AskingPrice = 29.95M,
        City = "Fort Mill",
        ZIP = 29715,
        Sold = false,
        AvailableUntil = new DateTime(2024, 08, 18)
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
    7. App Statistics
    8. Inventory by Species");

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
        try
        {
            PostAPlant();
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The date is invalid. Please try again.");
        }

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
    else if (choice == "8")
    {
        // Explorer
        InventoryBySpecies();

    }
    else
    {
        Console.WriteLine("Please choose from the options in the menu.");
    }

}


void DisplayAllPlants()
{
    Console.WriteLine("Plants:");

    // Console.WriteLine("Please enter a plant number: ");

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
    }
    Console.WriteLine("");
}

void PostAPlant()
{

    string[] plantTypes =
{
    "tree",
    "bush",
    "flower",
    "herb"
};
    int i = 1;
    Console.WriteLine("Please enter the number for the type of plant:");
    foreach (string plantType in plantTypes)
    {
        Console.WriteLine($"{i++}. {plantType}");
    }
    // if else statement or switch statement
    string initialUserPlantType = Console.ReadLine();
    string postUserPlantType = "";
    if (initialUserPlantType == "1")
    {
        postUserPlantType = "tree";
    }
    else if (initialUserPlantType == "2")
    {
        postUserPlantType = "bush";
    }
    else if (initialUserPlantType == "3")
    {
        postUserPlantType = "flower";
    }
    else if (initialUserPlantType == "4")
    {
        postUserPlantType = "herb";
    }
    else
    {
        Console.WriteLine("Please enter a plant type's number");
    }

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

    plants.Add(new Plant()
    {

        PlantType = postUserPlantType,
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
            Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}.");
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
        Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}.");

    }

    int delistedPlant = int.Parse(Console.ReadLine());

    plants.RemoveAt(delistedPlant - 1);
}

void RandomPlantOfTheDay()
{
    int randomPlant = random.Next(0, plants.Count);
    DateTime now = DateTime.Now;

    while (plants[randomPlant].Sold == true && plants[randomPlant].AvailableUntil > now)
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

            Console.WriteLine($"{i++}. {PlantDetails(plant)}.");
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
    Console.Write($"Lowest price plant name = ");
    LowestPrice();
    Console.Write("Number of Plants Available = ");
    NumberOfPlants();
    Console.Write("Name of plant with highest light needs = ");
    HighestLightNeeds();
    Console.Write("Average light needs = ");
    AverageLightNeeds();
    Console.Write("Percentage of plants adopted = ");
    PercentageAdopted();
}

void LowestPrice()
{
    decimal lowestPrice;
    Plant lowestPricedPlant = new Plant();

    if (plants.Any())
    {
        lowestPrice = Decimal.MaxValue;
        foreach (Plant plant in plants)
        {
            if (plant.AskingPrice <= lowestPrice)
            {
                lowestPrice = plant.AskingPrice;
                lowestPricedPlant = plant;
            }
        }
        Console.WriteLine(lowestPricedPlant.Species);
    }
}

void NumberOfPlants()
{
    List<Plant> numberOfAvailablePlants = new List<Plant>();
    DateTime now = DateTime.Now;

    foreach (Plant plant in plants)
    {
        if (plant.Sold == false && plant.AvailableUntil >= now)
            numberOfAvailablePlants.Add(plant);
    }
    Console.WriteLine(numberOfAvailablePlants.Count);
}

void HighestLightNeeds()
{
    Plant highestLightNeeds = new Plant();
    double maxLight = 0;
    if (plants.Any())
    {
        maxLight = double.MinValue;
        foreach (Plant plant in plants)
        {
            if (plant.LightNeeds >= maxLight)
            {
                maxLight = plant.LightNeeds;
                highestLightNeeds = plant;
            }
        }
        Console.WriteLine(highestLightNeeds.Species);
    }
}

// select all of the light needs of each
void AverageLightNeeds()
{
    Console.WriteLine(plants.Select(p => p.LightNeeds).Average());
}

void PercentageAdopted()
{
    int countOfPlants = plants.Count;
    double countOfPlantsAsDouble = (double)countOfPlants;
    List<Plant> SoldPlants = new List<Plant>();
    foreach (Plant plant in plants)
    {
        if (plant.Sold == true)
        {
            SoldPlants.Add(plant);
        }
    }
    int soldPlants = SoldPlants.Count;
    double soldPlantsDouble = (double)soldPlants;
    double decimalSoldPlants = soldPlantsDouble / countOfPlantsAsDouble;
    double percentageAdopted = decimalSoldPlants * 100;
    Console.WriteLine($"{percentageAdopted}%");
}

string PlantDetails(Plant plant)
{


    string plantString = $"{plant.Species} ({plant.PlantType}) in {plant.City} has a light level of {plant.LightNeeds} and {(plant.Sold ? "was sold" : "is available")} for ${plant.AskingPrice}.";

    return plantString;
}

// Explorer
void InventoryBySpecies()
{
    Dictionary<string, int> plantInventory = new Dictionary<string, int>
    {
        {"Peace Lily", 3},
        {"Snake Plant", 4}
    };

    foreach (Plant plant in plants)
    {
        int plantNumber;
        bool plantNumberSuccess = plantInventory.TryGetValue(plant.Species, out plantNumber);
        if (plantNumberSuccess)
        {
            plantInventory[plant.Species] = plantNumber + 1;
        }
        else
        {
            plantInventory.Add(plant.Species, 1);
        }

    }
    foreach (KeyValuePair<string, int> kv in plantInventory)
        Console.WriteLine($"Species: {kv.Key}, Number: {kv.Value}");

}

