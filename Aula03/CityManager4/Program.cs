using System;
using System.Collections.Generic;

namespace CityManager4
{
    /// <summary>
    /// Test a collection of buildings.
    /// </summary>
    public class Program
    {
        // Private enumeration which determines how to order the buildings.
        // This enumeration can be private and can exist within Program
        // because it is only used in the Program class.
        private enum Ordering
        {
            // Order by value.
            ByValue,
            // Order by type in alphabetical order.
            ByTypeAlpha,
            // Order by type in reverse alphabetical order.
            ByTypeReverseAlpha
        };

        // List of buildings
        private List<Building> buildings;

        // Ordering type
        private Ordering ordering;

        // Object to be passed to the Sort() method to compare buildings by
        // type in alphabetical order
        private IComparer<Building> compareByTypeAlpha;

        // Object to be passed to the Sort() method to compare buildings by
        // type in reverse alphabetical order
        private IComparer<Building> compareByTypeReverseAlpha;

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

            // Set the default ordering type
            ordering = Ordering.ByValue;

            // Instantiate object to compare buildings by type
            compareByTypeAlpha = new CompareByType(true);

            // Instantiate object to compare buildings by type (reverse order)
            compareByTypeReverseAlpha = new CompareByType(false);
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
                        SortBuildings();
                        ListBuildings();
                        break;
                    case "s": // Show buildings with value greater than
                        SortBuildings();
                        ShowBuildingsWithValueGreaterThan();
                        break;
                    case "c": // Change sort order
                        ChangeSortOrder();
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
            Console.WriteLine("(C)hange building sort order");
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
                // We're using the Building.ToString() method to show building
                // info
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
                // We're using the Building.ToString() method to show building
                // info
                Console.WriteLine(building);
            }
            Console.WriteLine("================================");

        }

        /// <summary>
        /// Change building sort order.
        /// </summary>
        private void ChangeSortOrder()
        {
            // Did the user make a valid choice?
            bool validChoice;

            // Ask until players gives valid response
            do
            {
                // User-specified option
                string option;

                // Present options to user and get the user's response
                Console.WriteLine("\nSpecify sort order:");
                Console.WriteLine(" 0 - By value");
                Console.WriteLine(" 1 - By type (alphabetic ordering)");
                Console.WriteLine(" 2 - By type (reverse alphabetic ordering)");
                Console.Write("> ");
                option = Console.ReadLine();

                // Validate user response
                switch (option)
                {
                    case "0":
                        // Valid response, select order by score
                        ordering = Ordering.ByValue;
                        validChoice = true;
                        break;
                    case "1":
                        // Valid response, select order by type
                        ordering = Ordering.ByTypeAlpha;
                        validChoice = true;
                        break;
                    case "2":
                        // Valid response, select order by name (reverse)
                        ordering = Ordering.ByTypeReverseAlpha;
                        validChoice = true;
                        break;
                    default:
                        // Invalid response, warn user
                        Console.WriteLine(
                            "\nInvalid choice! Press a key to chose again...");
                        Console.ReadKey();
                        validChoice = false;
                        break;
                }
            }
            while (!validChoice); // Loop until user gives valid response
        }

        /// <summary>
        /// Sort building list according to the currently specified ordering
        /// criteria.
        /// </summary>
        private void SortBuildings()
        {
            // What is the currently specified ordering criteria?
            switch (ordering)
            {
                case Ordering.ByValue:
                    // Sort by value (default sort)
                    buildings.Sort();
                    break;
                case Ordering.ByTypeAlpha:
                    // Sort by name
                    buildings.Sort(compareByTypeAlpha);
                    break;
                case Ordering.ByTypeReverseAlpha:
                    // Sort by name, in reverse
                    buildings.Sort(compareByTypeReverseAlpha);
                    break;
            }
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
