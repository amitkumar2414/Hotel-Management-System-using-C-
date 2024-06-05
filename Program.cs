using Hotel_Management;
using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Hotel_Management
{
    public class Hotel : Services
    {
        private int option;
        private string name;
        private string phoneNumber;
        private string email;
        private string adhaarNumber;
        private int numberOfDays;
        private string roomClass;
        private double totalBill;


        public Hotel(int option) 
        {
            this.option = option;
            UserData();
            numberOfDays = GetNumberOfDays();

            totalBill = 0;

            /*
            using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=hotel_management;User Id=root;Password=Shyam@123;"))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("INSERT INTO bookings (name, phone_number, email, adhaar_number, number_of_days, room_class) VALUES (@name, @phoneNumber, @email, @adhaarNumber, @numberOfDays, @roomClass)", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@adhaarNumber", adhaarNumber);
                    command.Parameters.AddWithValue("@numberOfDays", numberOfDays);
                    command.Parameters.AddWithValue("@roomClass", GetRoomClass(option));
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Your booking has been successful. Your booking ID is " + GetLastBookingId());

            while (true)
            {
                Console.WriteLine("Do you want to change your room class? (yes/no)");
                string response = Console.ReadLine();

                if (response.ToLower() == "yes")
                {
                    Console.WriteLine("Please select a new room class:");
                    Console.WriteLine("1. Gold");
                    Console.WriteLine("2. Silver");
                    Console.WriteLine("3. Bronze");

                    int newOption = int.Parse(Console.ReadLine());
                    using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=hotel_management;User Id=root;Password=password;"))
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand("UPDATE bookings SET room_class = @roomClass WHERE booking_id = @bookingId", connection))
                        {
                            command.Parameters.AddWithValue("@roomClass", GetRoomClass(newOption));
                            command.Parameters.AddWithValue("@bookingId", GetLastBookingId());
                            command.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("Your room class has been updated successfully.");
                }
                else
                {
                    break;
                }

            }
            */

            for (int i = 0; i < numberOfDays; i++)
            {
                Console.WriteLine("Enter the room class for day " + (i + 1) + ":");
                Console.WriteLine("1. Gold");
                Console.WriteLine("2. Silver");
                Console.WriteLine("3. Bronze");
                int newOption = int.Parse(Console.ReadLine());

                if (newOption == 1)
                {
                    roomClass = "Gold";
                    GoldService();
                    totalBill += CalculateBill(roomClass, 1);
                }
                else if (newOption == 2)
                {
                    roomClass = "Silver";
                    SilverService();
                    totalBill += CalculateBill(roomClass, 1);
                }
                else if (newOption == 3)
                {
                    roomClass = "Bronze";
                    BronzeService();
                    totalBill += CalculateBill(roomClass, 1);
                }
            }

            Console.WriteLine("Total bill: Rs. " + totalBill);
            

            /*
            if (option == 1)
            {
                this.roomClass = "Gold";
                Console.WriteLine("You have selected: " + roomClass + " Class");

                GoldService();
                totalBill = totalBill + CalculateBill(roomClass, numberOfDays);

                Console.WriteLine(totalBill);


            }
            if (option == 2) 
            {
                this.roomClass = "Silver";
                Console.WriteLine("You have selected: " + roomClass + " Class");

                SilverService();
                totalBill = totalBill + CalculateBill(roomClass, numberOfDays);

                Console.WriteLine(totalBill);

            }
            if (option == 3)
            {
                this.roomClass = "Bronze";
                Console.WriteLine("You have selected: " + roomClass + " Class");

                BronzeService();
                totalBill = totalBill + CalculateBill(roomClass, numberOfDays);

                Console.WriteLine(totalBill);
            }*/

        }
        private void UserData()
        {
            Console.Write("Please enter your Name: ");
            name = Console.ReadLine();

            Console.Write("Please enter your Phone Number: ");
            phoneNumber = Console.ReadLine();

            Console.Write("Please enter your E-mail: ");
            email = Console.ReadLine();

            Console.Write("Please enter your Adhaar Number: ");
            adhaarNumber = Console.ReadLine();

        }

        private int GetNumberOfDays()
        {
            Console.Write("Please enter the number of days you want to stay: ");
            return int.Parse(Console.ReadLine());
        }

        private string GetRoomClass(int option)
        {
            if (option == 1)
            {
                return "Gold";
            }
            else if (option == 2)
            {
                return "Silver";
            }
            else
            {
                return "Bronze";
            }
        }


        private int CalculateBill(string roomClass, int days)
        {
            int bill = 0;
            if (roomClass == "Gold")
            {
                bill = 6000 * days;
            }
            else if (roomClass == "Silver")
            {
                bill = 4100 * days;
            }
            else if (roomClass == "Bronze")
            {
                bill = 3100 * days;
            }
            return bill;
        }

        /*
        private int GetLastBookingId()
        {
            using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=hotel_management;User Id=root;Password=password;"))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT MAX(booking_id) FROM bookings", connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }
        */
    }


    public class Services
    {

        public void GoldService()
        {
            int GoldPrice = 6000;
            Console.WriteLine("Service Avalilabe in Gold Class:");
            string[] GoldService = new string[5] {
                "1. Free Wi-Fi",
                "2. Access of Laundry",
                "3. Access of Gym & Pool",
                "4. Breakfast, Lunch & Dinner Included",
                "5. Free SPA"
            };
            int size = GoldService.Length;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(GoldService[i]);
            }
            Console.WriteLine("Rent of Gold Class: Rs. " + GoldPrice + "/day");
        }

        public void SilverService()
        {
            int SilverPrice = 4100;
            Console.WriteLine();
            Console.WriteLine("Service Avalilabe in Silver Class:");

            string[] SilverService = new string[3]
            {
                "1. Free Wi-Fi",
                "2. Access of Laundry",
                "3. Access of Gym & Pool"
            };

            int size = SilverService.Length;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(SilverService[i]);
            }
            Console.WriteLine("Rent of Gold Class: Rs. " + SilverPrice + "/day");

        }

        public void BronzeService()
        {
            int BronzePrice = 3100;
            Console.WriteLine();
            Console.WriteLine("Service Avalilabe in Bronze Class:");


            string[] BronzeService = new string[2]
            {
                "1. Free Wi-Fi",
                "2. Access of Gym"
            };
            int size = BronzeService.Length;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(BronzeService[i]);
            }
            Console.WriteLine("Rent of Gold Class: Rs. " + BronzePrice + "/day");

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            Console.WriteLine("Three types of Room Class available: \n1. Gold \n2. Silver \n3. Bronze");
            Console.Write("Please select your Class out of three: ");
            option = int.Parse(Console.ReadLine());
            Hotel amit = new Hotel(option);


            Console.ReadLine();
        }
    }
}
