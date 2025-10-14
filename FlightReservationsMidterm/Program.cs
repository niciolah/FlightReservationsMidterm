using System;
using static System.Console;

namespace FlightReservationsMidterm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            WriteLine("Welcome to Reynolds Airlines Booking Service.");

            WriteLine("To begin your booking, please enter your name: ");
            string userName = ReadLine();
            WriteLine($"Hello, {userName}. Let's get started with your booking.");
            WriteLine("Please enter your address so we can select the nearest airport to you: ");
            string userAddress = ReadLine();
            WriteLine($"Thank you, {userName}. Please enter your date of travel");
            string travelDate = ReadLine();
            WriteLine($"Thank you for entering your travel inforamtion, {userName}.");
            WriteLine("Please enter the number of seats you would like to book: ");
            int seatCount = int.Parse(ReadLine());

            WriteLine($"Thank you for selecting to book {seatCount} seats.");
            WriteLine("Please enter the total number of bags you will be checking: \n(enter 0 if you will not be checking any bags)");
            int bagCount = int.Parse(ReadLine());

            double seatPrice = seatDataCalculator(seatCount);

            double bagPrice = bagDataCalculator(bagCount);

            WriteLine("your seat price is $" + seatPrice);  
            WriteLine("your bag price is $" + bagPrice);


        }
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
                WriteLine("You have selected to book 0 seats. There is no charge for this service.");
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
