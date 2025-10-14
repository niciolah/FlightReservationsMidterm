using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;
using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightReservationsMidterm
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Greeting - Introduce Airline
            WriteLine("Welcome to Reynolds Airlines Booking Service.");

            //Prompt and Accempt User's Name
            WriteLine("To begin your booking, please enter your name: ");
            string userName = ReadLine();
            WriteLine($"\nHello, {userName}. Let's get started with your booking.");

            //Prompt and Accept User's Address
            WriteLine("Please enter your address so we can select the nearest airport to you: ");
            string userAddress = ReadLine();
            WriteLine($"\nThank you for entering your address, {userName}.");

            //Prompt and Accept User's Date of Travel
            WriteLine("Please enter your date of travel in mm/dd/yyyy format");
            string travelDate = ReadLine();
            WriteLine("Thank you for entering your booking identification information.");

            //Ask User How Many Seats They want to Book, Calculate Seat Price
            WriteLine("Please enter the number of seats you would like to book: ");
            int seatCount = int.Parse(ReadLine());
            double seatPrice = seatDataCalculator(seatCount);

            //Ask User How Many Bags They want to Check, Calculate Bag Price
            WriteLine("Please enter the total number of bags you will be checking: \n(enter 0 if you will not be checking any bags)");
            int bagCount = int.Parse(ReadLine());
            double bagPrice = bagDataCalculator(bagCount);

            //Calculate Sales Tax and Total Price
            double salesTax = (bagPrice * seatPrice) * 0.05;
            double totalPrice = seatPrice + bagPrice + salesTax;

            //Change Colors and Display Receipt
            ForegroundColor = ConsoleColor.Yellow;
            BackgroundColor = ConsoleColor.DarkRed;

            WriteLine("\n|===================================================================================");
            WriteLine("|\t\t\tREYNOLDS AIRLINES");
            WriteLine("|\t\t\t FLIGHT ITINERARY");
            WriteLine("|\t\t\t ITEMIZED RECEIPT");
            WriteLine("|===================================================================================");
            WriteLine($"BOOKING IDENTIFICATION INFORMATION");
            WriteLine($"|Passenger Name:\t\t{userName}");
            WriteLine($"|Passenger Address:\t\t{userAddress}");
            WriteLine($"|Date of Travel:\t\t{travelDate}");
            WriteLine("|-----------------------------------------------------------------------------------");
            WriteLine($"|Number of Seats Booked:\t{seatCount}");
            WriteLine($"|Number of Bags Checked:\t{bagCount}");
            WriteLine($"|Total Seat Price:\t\t{seatPrice.ToString("C")}");
            WriteLine($"|Total Bag Price:\t\t{bagPrice.ToString("C")}");
            WriteLine($"|Sales Tax (5%):\t\t{(salesTax).ToString("C")}");
            WriteLine("|-----------------------------------------------------------------------------------");
            WriteLine($"|\t\t\t  TOTAL AMOUNT DUE: {totalPrice.ToString("C")}");
            WriteLine("|===================================================================================");
            WriteLine("|\t\tThank you for flying Reynolds Airlines!");
            WriteLine("|-----------------------------------------------------------------------------------");
            //Reset Console Colors so only the receipt is colored
            Console.ResetColor();



        }
        //Method to Calculate Bag Price
        static double bagDataCalculator(int bagCount)
        {
            double bagsTotalPrice = 0.00;
            if (bagCount == 0)
            {
                WriteLine("You have selected to check 0 bags. There is no charge for this service.");
            }
            else if (bagCount >= 1 && bagCount < 15000)
            {
                for (int i = 1; i <= bagCount; i++)
                {
                    bagsTotalPrice += 25.00;
                }
                WriteLine($"You have selected to check {bagCount} bags. The total price for this service is ${bagsTotalPrice}");
            }
            else if (bagCount >= 15000)
            {
                WriteLine("You have selected to check a large number of bags.");
                WriteLine("Passenger flights cannot accomodate this number of bags.");
                WriteLine("Please restart and contact Reynolds Airlines customer service for assistance with booking a cargo flight.");
            }
            else
            {
                WriteLine("Invalid input. Please restart and enter a valid number of bags.");
            }
                return bagsTotalPrice;
        }
        //Method to Calculate Seat Price
        static double seatDataCalculator(int seatCount)
        {
            int counter = 0;
            double seatsTotalPrice = 0.00;
            if (seatCount >= 1 && seatCount < 1000)
            {
                while (counter < seatCount)
                {
                    seatsTotalPrice += 30.00;
                    counter++;
                }
                WriteLine($"You have selected to book {seatCount} seats. The total price for this service is ${seatsTotalPrice}");
            }
            else if (seatCount == 0)
            {
                WriteLine("You have selected to book 0 seats. You will not be charged.");
            }
            else if (seatCount >= 1000)
            {
                WriteLine("You have selected to book a large number of seats.");
                WriteLine("Passenger flights cannot accomodate this number of seats.");
                WriteLine("Please restart and contact Reynolds Airlines customer service for assistance with booking a charter flight.");
            }
            else
            {
                WriteLine("Invalid input. Please restart and enter a valid number of seats.");
            }

            return seatsTotalPrice;
        }
    }
}
