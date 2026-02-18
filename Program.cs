/*
 * ====================================================================
 * Codac Logistics Delivery & Fuel Auditor
 * ====================================================================
 */

using System;

namespace CodacLogistics
{
    class DeliveryFuelAuditor
    {
        static void Main(string[] args)
        {
            // TASK 1: Driver Profile & Distance Validation

            // Using 'string' data type for driver name as it stores text data
            string driverFullName;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==============================================");
            Console.WriteLine("  CODAC LOGISTICS - FUEL AUDITOR SYSTEM");
            Console.WriteLine("==============================================\n");
            Console.ResetColor();
            Console.Write("Enter Driver's Full Name: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            driverFullName = Console.ReadLine();
            Console.ResetColor();

            // Using 'decimal' for fuel budget because it provides exact precision
            // for financial calculations, avoiding floating-point rounding errors
            decimal weeklyFuelBudget;
            Console.Write("Enter Weekly Fuel Budget (PHP): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            weeklyFuelBudget = decimal.Parse(Console.ReadLine());
            Console.ResetColor();

            // Using 'double' for distance as it's a measurement that doesn't require
            // exact precision like currency, and allows for decimal values
            double totalDistanceTraveled;

            // Using 'while' loop for validation ensures the user MUST enter valid data
            // before proceeding - the loop continues until validation passes
            // This is better than 'if' because 'if' would only check once
            while (true)
            {
                Console.Write("Enter Total Distance Traveled this week (km): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                totalDistanceTraveled = double.Parse(Console.ReadLine());
                Console.ResetColor();

                // Validation: Distance must be between 1.0 and 5000.0
                if (totalDistanceTraveled >= 1.0 && totalDistanceTraveled <= 5000.0)
                {
                    // Valid input - break out of the loop
                    break;
                }
                else
                {
                    // Invalid input - show error and loop continues
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR Distance must be between 1.0 and 5000.0 km. Please try again.\n");
                    Console.ResetColor();
                }
            }

            Console.WriteLine(); 

            // TASK 2: Fuel Expense Tracking

            // Using array to store 5 days of fuel expense data
            // Array size is fixed at 5 because we always track a 5-day work week
            // Using 'decimal' type for precise financial calculations
            decimal[] fuelExpenses = new decimal[5];

            // Using 'decimal' for totalFuelSpent to accumulate daily expenses
            // Must match the data type of the array for accurate summation
            decimal totalFuelSpent = 0m; // The 'm' suffix indicates a decimal literal

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("  DAILY FUEL EXPENSE INPUT");
            Console.WriteLine("----------------------------------------------");
            Console.ResetColor();

            // Using 'for' loop because we know exactly how many iterations needed (5 days)
            // 'for' is ideal when the number of iterations is predetermined
            for (int i = 0; i < fuelExpenses.Length; i++)
            {
                // (i + 1) converts zero-based array index to human-friendly day number
                // Example: i=0 becomes "Day 1", i=1 becomes "Day 2", etc.
                Console.Write($"Enter fuel cost for Day {i + 1} (PHP): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                fuelExpenses[i] = decimal.Parse(Console.ReadLine());
                Console.ResetColor();

                // Accumulate the total as we input each day's expense
                totalFuelSpent += fuelExpenses[i];
            }

            Console.WriteLine(); 

            // TASK 3: Performance Analysis

            // Calculate average by dividing total by number of days
            // Using 'decimal' to maintain precision in financial calculations
            decimal averageDailyFuelExpense = totalFuelSpent / fuelExpenses.Length;

            // Calculate fuel efficiency: kilometers per peso spent
            // Cast totalDistanceTraveled to decimal for consistent calculation
            decimal fuelEfficiencyRatio = (decimal)totalDistanceTraveled / totalFuelSpent;

            // Using 'string' to store the efficiency rating category
            string efficiencyRating;

            // Using 'if-else if-else' structure to categorize efficiency
            // Checking from highest to lowest efficiency for logical flow
            if (fuelEfficiencyRatio > 15)
            {
                efficiencyRating = "High Efficiency";
            }
            else if (fuelEfficiencyRatio >= 10)
            {
                efficiencyRating = "Standard Efficiency";
            }
            else
            {
                efficiencyRating = "Low Efficiency / Maintenance Required";
            }

            // Using 'bool' to represent a binary state: within budget or not
            // Boolean is perfect for true/false conditions
            bool isWithinBudget = totalFuelSpent <= weeklyFuelBudget;

            // Calculate budget difference for additional insight
            decimal budgetDifference = weeklyFuelBudget - totalFuelSpent;

            // TASK 4: The Audit Report

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==============================================");
            Console.WriteLine("       WEEKLY FUEL AUDIT REPORT");
            Console.WriteLine("==============================================");
            Console.ResetColor();
            Console.WriteLine($"Driver Name:           {driverFullName}");
            Console.WriteLine($"Total Distance:        {totalDistanceTraveled:F2} km");
            Console.WriteLine($"Weekly Fuel Budget:    PHP {weeklyFuelBudget:N2}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------");
            Console.ResetColor();

            // Display daily breakdown using a for loop
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("DAILY FUEL EXPENSE BREAKDOWN:");
            Console.ResetColor();
            for (int i = 0; i < fuelExpenses.Length; i++)
            {
                // String interpolation with formatting: N2 shows 2 decimal places with comma separator
                Console.WriteLine($"  Day {i + 1}:                 PHP {fuelExpenses[i]:N2}");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("FINANCIAL SUMMARY:");
            Console.ResetColor();
            Console.WriteLine($"  Total Fuel Spent:    PHP {totalFuelSpent:N2}");
            Console.WriteLine($"  Average Daily Cost:  PHP {averageDailyFuelExpense:N2}");
            Console.WriteLine($"  Budget Difference:   PHP {budgetDifference:N2}");

            // Using ternary operator for concise budget status display
            Console.ForegroundColor = isWithinBudget ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"  Within Budget:       {(isWithinBudget ? "YES ✓" : "NO ✗")}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("PERFORMANCE METRICS:");
            Console.ResetColor();
            Console.WriteLine($"  Fuel Efficiency:     {fuelEfficiencyRatio:F2} km/PHP");

            // Color-coded efficiency rating
            if (efficiencyRating == "High Efficiency")
                Console.ForegroundColor = ConsoleColor.Green;
            else if (efficiencyRating == "Standard Efficiency")
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  Rating:              {efficiencyRating}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==============================================");
            Console.ResetColor();

            // Additional recommendations based on efficiency
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nRECOMMENDATIONS:");
            Console.ResetColor();
            if (efficiencyRating == "High Efficiency")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excellent performance! Maintain current practices.");
                Console.ResetColor();
            }
            else if (efficiencyRating == "Standard Efficiency")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("• Performance is acceptable. Consider route optimization.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ Vehicle may require maintenance. Schedule inspection.");
                Console.ResetColor();
            }

            if (!isWithinBudget)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"⚠ Budget exceeded by PHP {Math.Abs(budgetDifference):N2}. Review fuel usage.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ Budget surplus: PHP {budgetDifference:N2}. Good cost management!");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==============================================");
            Console.WriteLine("        End of Report - Drive Safely!");
            Console.WriteLine("==============================================");
            Console.ResetColor();

            // Wait for user input before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}