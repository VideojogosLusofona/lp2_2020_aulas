using System;
using System.Collections.Generic;

namespace CityManager3
{
    /// <summary>
    /// Test a collection of buildings.
    /// </summary>
    public class Program
    {
        // List of buildings
        private List<Building> buildings;

        /// <summary>
        /// Program starts here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main(string[] args)
        {
            // Create a program and run it
            Program program = new Program();
            program.Run();
        }

        /// <summary>
        /// Program's constructor.
        /// </summary>
        private Program()
        {
            // Initialize the building list with two buildings using the
            // collection initialization syntax
            buildings = new List<Building>() {
                new Building("Small hut", 1000f, 25f),
                new Building("Skyscrapper", 15005f, 2700.2f)
            };
            // Sort list by value
            buildings.Sort();
        }

        /// <summary>
        /// Run the program.
        /// </summary>
        private void Run()
        {
            // The option selected by the user
            string option;

            // Main menu loop
            do
            {
                // Get option from user
                option = Menu();
                // Check option
                switch (option)
                {
                    case "i": // Insert building option
                        InsertBuilding();
                        break;
                    case "l": // List buildings option
                        ListBuildings();
                        break;
                    case "s": // Show buildings with value greater than
                        ShowBuildingsWithValueGreaterThan();
                        break;
                    case "q": // Quit
                        break;
                    default: // Unknown option
                        Console.WriteLine("Unknown option!");
                        break;
                }
                // Keep looping until user quits
            } while (option != "q");
        }

        /// <summary>
        /// Show main menu and get user option.
        /// </summary>
        /// <returns>User option.</returns>
        private string Menu()
        {
            // Show menu
            Console.WriteLine("------------------");
            Console.WriteLine("(I)nsert building");
            Console.WriteLine("(L)ist all buildings");
            Console.WriteLine("(S)how buildings with value greater than x");
            Console.WriteLine("(Q)uit");
            Console.WriteLine("------------------");
            // Ask and return building option, removing whitespace before and
            // after the option and converting the option to lowercase
            return Console.ReadLine().Trim().ToLower();
        }

        /// <summary>
        /// Insert a building in the list.
        /// </summary>
        private void InsertBuilding()
        {
            // Required local variables
            string buildingName;
            float buildingValue, buildingArea;
            Building building;

            // Get building name
            Console.Write("Building type  : ");
            buildingName = Console.ReadLine();

            // Get building value
            buildingValue = GetValidFloat("value");

            // Get building area
            buildingArea = GetValidFloat("area");

            // Instantiate new building
            building = new Building(buildingName, buildingValue, buildingArea);

            // Add building to list
            buildings.Add(building);

            // Sort list by value
            buildings.Sort();
        }

        /// <summary>
        /// Ask the user for a value and convert it to a valid float, asking
        /// again if necessary.
        /// </summary>
        /// <param name="varName">
        /// The name of the parameter we're getting from the user.
        /// </param>
        /// <returns>A float, inserted by the user.</returns>
        private float GetValidFloat(string varName)
        {
            float floatInput;

            while (true)
            {
                string userInput;
                Console.Write($"Building {varName} : ");
                userInput = Console.ReadLine();

                // Check if value is valid integer
                if (float.TryParse(userInput, out floatInput))
                {
                    // If so, get out of loop
                    break;
                }
                // If not, show error message
                Console.WriteLine("Invalid float, please try again");
            };

            return floatInput;
        }

        /// <summary>
        /// List all buildings.
        /// </summary>
        private void ListBuildings()
        {
            // Show building list
            Console.WriteLine("==== Building List ====");
            foreach (Building building in buildings)
            {
                // We're using the Building.ToString() method to show building info
                Console.WriteLine(building);
            }
            Console.WriteLine("=====================");
        }

        /// <summary>
        /// Show building with value greater than a user-specified value.
        /// </summary>
        private void ShowBuildingsWithValueGreaterThan()
        {
            // Required local variables
            int minValue;

            Console.Write("Minimum building value : ");

            // Get minimum building value, must be valid integer
            // In this case we don't verify this, so if user inserts invalid
            // integer, program will crash
            minValue = Convert.ToInt32(Console.ReadLine());

            // Show buildings with at least this value
            Console.WriteLine("=== Buildings with value > {0} ===", minValue);
            foreach (Building building in GetValuableBuildings(minValue))
            {
                // We're using the Building.ToString() method to show building info
                Console.WriteLine(building);
            }
            Console.WriteLine("================================");

        }

        /// <summary>
        /// Get an enumerable containing buildings with value greater than the
        /// specified parameter <paramref name="minValue"/>.
        /// </summary>
        /// <param name="minValue">
        /// The minimum value a building should have to be returned.
        /// </param>
        /// <returns>
        /// An enumerable containing buildings with value greater than the
        /// specified parameter <paramref name="minValue"/>.
        /// </returns>
        private IEnumerable<Building> GetValuableBuildings(int minValue)
        {
            // Cycle through all buildings
            foreach (Building building in buildings)
            {
                // Does the current building have a value greater than minValue?
                if (building.Value > minValue)
                {
                    // If so, return it
                    yield return building;
                }
            }
        }
    }
}
