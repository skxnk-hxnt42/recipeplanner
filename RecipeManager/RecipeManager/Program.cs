using System;
using System.Numerics; // Importing the System.Numerics namespace for complex number calculations
using System.Reflection.Metadata.Ecma335; // Importing the System.Reflection.Metadata.Ecma335 namespace (currently not used in the code)

namespace RecipeManager // Namespace declaration for the project
{

    class Project // Class definition for Project
    {

        // Declare and initialize arrays and variables to store ingredients and steps
        private int numOfIngredients = 0; // Number of ingredients
        private String[] name = new string[20]; // Names of ingredients
        private double[] quantity = new double[20]; // Quantities of ingredients
        private String[] unitMeasurement = new string[20]; // Units of measurement for ingredients

        private int numOfSteps = 0; // Number of steps in the recipe
        private String[] steps = new string[20]; // Steps in the recipe

        public static void Main(string[] args) // Entry point of the program
        {
            Project project = new Project(); // Create an instance of Project
            project.recipe(); // Call the recipe method to enter ingredients and steps
            project.display(); // Call the display method to show the recipe
            project.scale(); // Call the scale method to potentially scale the ingredients
        }

        public void recipe() // Method to enter ingredients and steps
        {
            Console.WriteLine("Please enter the number of ingredients that will be used in your recipe:");
            numOfIngredients = Convert.ToInt32(Console.ReadLine()); // Read the number of ingredients

            // Loop through each ingredient to enter its details
            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine("Ingredient " + (i + 1) + System.Environment.NewLine);

                Console.WriteLine("Please enter the name of ingredient " + (i + 1) + ":");
                name[i] = Console.ReadLine(); // Read the ingredient's name

                Console.WriteLine("Please enter the quantity of ingredient to be used: ");
                quantity[i] = Convert.ToDouble(Console.ReadLine()); // Read the quantity

                Console.WriteLine("Please enter the unit of measurement: ");
                unitMeasurement[i] = Console.ReadLine(); // Read the unit of measurement
            }

            Console.WriteLine("Enter the number of steps needed for the recipe: ");
            numOfSteps = Convert.ToInt32(Console.ReadLine()); // Read the number of steps

            // Loop through each step to enter its details
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine("Enter a description for step " + (i + 1));
                steps[i] = Console.ReadLine(); // Read the step description
            }
        }

        public void display() // Method to display the full recipe
        {
            // Display the full recipe
            Console.WriteLine(System.Environment.NewLine + "Full Recipe: " + System.Environment.NewLine + System.Environment.NewLine);
            Console.WriteLine("This recipe requires " + numOfIngredients + " ingredients" + System.Environment.NewLine);

            // Loop through each ingredient to display its details
            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine("Ingredient " + (i + 1) + System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine(quantity[i] + " " + unitMeasurement[i] + "'s of " + name[i] + System.Environment.NewLine + System.Environment.NewLine);
            }

            // Display the number of steps
            Console.WriteLine("There are " + numOfSteps + " steps to follow for the recipe" + System.Environment.NewLine + System.Environment.NewLine);

            // Loop through each step to display its description
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": " + steps[i] + System.Environment.NewLine + System.Environment.NewLine);
            }
        }

        public void scale() // Method to scale the ingredients
        {
            Console.WriteLine("Would you like to scale the ingredients? (Y/N)");
            char ans = Convert.ToChar(Console.ReadLine()); // Read the user's answer
            char scaleSelection = 'a'; // Default value for the selected scale option

            // Check if the user wants to scale the ingredients
            if (char.ToUpper(ans) == 'Y')
            {
                // Prompt the user for the scale option
                Console.WriteLine("How much would you like to scale by" + System.Environment.NewLine + System.Environment.NewLine);
                Console.WriteLine("How much would you like to scale by, enter the letter of your answer:" + System.Environment.NewLine + "a. Half" + System.Environment.NewLine + "b. Double" + System.Environment.NewLine + "c. Triple" + System.Environment.NewLine + System.Environment.NewLine);
                char scaleAns = Convert.ToChar(Console.ReadLine()); // Read the user's chosen scale option

                // Switch statement to handle scaling based on the user's choice
                switch (scaleAns)
                {
                    case 'a':
                        // Scale the ingredients by half
                        for (int i = 0; i < numOfIngredients; i++)
                        {
                            quantity[i] = (quantity[i] * 0.5);
                            scaleSelection = 'a';
                        }
                        break;

                    case 'b':
                        // Scale the ingredients by double
                        for (int i = 0; i < numOfIngredients; i++)
                        {
                            quantity[i] = (quantity[i] * 2);
                            scaleSelection = 'b';
                        }
                        break;

                    case 'c':
                        // Scale the ingredients by triple
                        for (int i = 0; i < numOfIngredients; i++)
                        {
                            quantity[i] = (quantity[i] * 3);
                            scaleSelection = 'c';
                        }
                        break;
                }

                display(); // Display the updated recipe after scaling
                reset(scaleSelection); // Ask the user if they want to reset the values to their original state
            }
        }

        public void reset(char scaleSelection) // Method to reset the scaled ingredients to their original state
        {
            Console.WriteLine("Would you like to reset the values to their original values? (Y/N)");
            char ans = Convert.ToChar(Console.ReadLine()); // Read the user's answer

            // Check if the user wants to reset the values
            if (char.ToUpper(ans) == 'Y')
            {
                // Switch statement to handle resetting based on the user's choice
                switch (scaleSelection)
                {
                    case 'a':
                        // Reset the ingredients to their original values after scaling by half
                        for (int i = 0; i < numOfIngredients; i++)
                        {
                            quantity[i] = (quantity[i] / 0.5);

                        }
                        break;

                    case 'b':
                        // Reset the ingredients to their original values after scaling by double
                        for (int i = 0; i < numOfIngredients; i++)
                        {
                            quantity[i] = (quantity[i] / 2);

                        }
                        break;

                    case 'c':
                        // Reset the ingredients to their original values after scaling by triple
                        for (int i = 0; i < numOfIngredients; i++)
                        {
                            quantity[i] = (quantity[i] / 3);

                        }
                        break;
                }


            }
            display(); // Display the recipe after resetting the values
            clear(); // Ask the user if they want to clear all data and enter a new recipe
        }

        public void clear() // Method to clear all data and enter a new recipe
        {
            Console.WriteLine("Would you like to clear all data and enter a new recipe? (Y/N)");
            char ans = Convert.ToChar(Console.ReadLine()); // Read the user's answer

            // Check if the user wants to clear all data
            if (char.ToUpper(ans) == 'Y')
            {
                recipe(); // Call the recipe method to enter a new recipe
                display(); // Call the display method to show the new recipe
            }
        }
    }
}