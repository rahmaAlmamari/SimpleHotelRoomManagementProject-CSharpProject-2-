using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project2
{
    internal class Program
    {

        // Data Structures ...
        // declare the globle variable needed ...
        static int MAX_ROOMS;
        static int roomCount = 0;
        static int guestCount = 0;
        // declare the array and variable needed ....
        static int[] roomNumbers;
        static double[] roomRates;
        static bool[] isReserved; // fals -> not reserved (Available) ... true -> reserved 
        static string[] guestNames;
        static int[] guestRoomNum;
        static int[] nights;
        static DateTime[] bookingDates;



        static void Main(string[] args)
        {

            
            bool capacity_flag = false;
            Console.WriteLine("Welcome to Hotel Room Management system ... please enter your system capacity:");
            do
            {
                try
                {
                    MAX_ROOMS = int.Parse(Console.ReadLine());
                    capacity_flag = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("choosing option process is stoped due to: " + e.Message + "please click enter key to start over");
                    // Console.ReadLine();//just to hold second ...
                    capacity_flag = true;
                }
            } while (capacity_flag);

            //seting the array size using MAX_ROOMS variable ...
            roomNumbers = new int[MAX_ROOMS];
            roomRates = new double[MAX_ROOMS];
            isReserved = new bool[MAX_ROOMS];
            guestNames = new string[MAX_ROOMS];
            guestRoomNum = new int[MAX_ROOMS];
            nights = new int[MAX_ROOMS];
            bookingDates = new DateTime[MAX_ROOMS];

            // we use while loop to repeat the process and we set true so it will not stop ... 
            while (true)
            {
                //just to clear the screen ...
                Console.Clear();
                Console.WriteLine("System Menu \n");
                Console.WriteLine("Select option: ");
                Console.WriteLine("1. Add a new room");
                Console.WriteLine("2. View all rooms");
                Console.WriteLine("3. Reserve a room for a gues");
                Console.WriteLine("4. View all reservations with total cost");
                Console.WriteLine("5. Search reservation by guest name ");
                Console.WriteLine("6. Find the highest-paying guest");
                Console.WriteLine("7. Cancel a reservation by room number ");
                Console.WriteLine("8. Exit the system");

                int choice = 0;
                // to check if the user int right input or not ... 
                bool option_flag = false;
                // use try and catch to make sure the the user will input the right input ...
                try
                {
                    Console.Write("\nEnter your option: \n");
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("choosing option process is stoped due to: " + e.Message);
                    //Console.ReadLine();//just to hold second ...
                    option_flag = true;
                }


                if (option_flag)//it mean if flag is true do the following.. if not do else ...
                {
                    Console.WriteLine("Try to enter one option in the menu plases ... click enter key to start over");
                    Console.ReadLine();//just to hold second ...
                }
                else
                {
                    //switch condation to choose between the functions ...
                    switch (choice)
                    {
                        case 1: AddNewRoom(); break;
                        case 2: ViewAllRooms(); break;
                        case 3: ReserveRoomForGues(); break;
                        case 4: ViewAllReservationsWithTotalCost(); break;
                        case 5: SearchReservationByGuestName(); break;
                        case 6: FindHighestPayingGuest(); break;
                        case 7: CancelReservationByRoomNumber(); break;
                        case 8: Console.WriteLine("Have a nice day ..."); return;
                        default: Console.WriteLine("\n You enter unaccepted option! ... to try again click enter key"); break;
                    }
                    // we add this line just to stop the program from clear 'Console.Clear();'
                    // the screen before the user see the result ...
                    Console.ReadLine();
                }

            }
        }

        //1. Add a new room ...
        static void AddNewRoom()
        {
            char choice;
            // do loop to repeat the process of adding new Room 
            //based on the user choice ...
            do
            {
                ////declare variables to holde room info ...
                int RoomNumber = 0;
                double roomDailyRate = 0;

                

                ////to make such that the user do not enter record more than
                //// the arrays size ...
                if (roomCount < MAX_ROOMS)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the following room details:");

                    //room number input process code ... 
                    bool flag_rom_number = true;//to know if the room number add or not ...
                    do
                    {
                        try
                        {
                            //to store room number into RoomNumber variable ....
                            Console.WriteLine("Room number (Room number must be unique and > zero):");
                            RoomNumber = int.Parse(Console.ReadLine());
                            //to check if the room number is vailde or not (Room number must be unique) ...
                            if (RoomNumber < 0)
                            {
                                Console.WriteLine("Room number not vaild it must be > zero");
                                flag_rom_number = true;
                            }
                            else
                            {
                                flag_rom_number = false;
                            }
                            //to check if the room number is unique or not ...
                            for(int i = 0; i<roomCount; i++)
                            {
                                if (RoomNumber == roomNumbers[i])
                                {
                                    Console.WriteLine("Room number not vaild it must be unique");
                                    flag_rom_number = true;
                                }
                                else
                                {
                                    flag_rom_number = false;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Student age not add due to: " + e.Message);
                        }

                    } while (flag_rom_number);

                    //room daily rate input process code ... 
                    bool flag_daily_rate = true;//to know if the room daily rate add or not ...
                    do
                    {
                        try
                        {

                            //to store room daily rate into roomDailyRate variable ....
                            Console.WriteLine("Room Daily Rate (Rate must be >= 100):");
                            roomDailyRate = double.Parse(Console.ReadLine());
                            //to check if the room daily rate is vailde or not (Rate must be >= 100) ...
                            if (roomDailyRate < 100)
                            {
                                Console.WriteLine("Room daily rate not vaild");
                            }
                            else
                            {
                                flag_daily_rate = false;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Room daily rate not add due to: " + e.Message);
                        }

                    } while (flag_daily_rate);

                    
                    //to store room info in the arrays ...
                    roomNumbers[roomCount] = RoomNumber;
                    roomRates[roomCount] = roomDailyRate;
                    isReserved[roomCount] = false;
                    // so the system know that there are one more room added ......
                    roomCount++;
                    Console.WriteLine("Room add successfully ...");
                    Console.WriteLine("Do you want to add anther room? y / n");
                    choice = Console.ReadKey().KeyChar;
                    Console.ReadLine();//just to hold second ...
                }
                else
                {
                    Console.WriteLine("Sory you can not add more Room there are no space remain!");
                    Console.WriteLine();
                    choice = 'n';
                }

            } while (choice == 'y' || choice == 'Y');
        }

        // 2. View all rooms ...
        static void ViewAllRooms()
        {
            
            Console.WriteLine("Room Information: \nNumber | Daily Rate | Status  | Status Details\n");
            //to print all the recored based on roomCount ...
            for (int i = 0; i < roomCount; i++)
            {
                string Status;
                //string guestName = "null";
                double totalCost = 0;
                if (isReserved[i] == false)
                {
                    Status = "Available";
                    Console.WriteLine($"{roomNumbers[i]} | {roomRates[i]} | {Status} | Guest Name: Null, Total Cost: 0");
                }
                else
                {
                    Status = "Reserved";
                    Console.WriteLine($"{roomNumbers[i]} | {roomRates[i]} | {Status} | Guest Name: {guestNames[i]}, Total Cost: {nights[i] * roomRates[i]}");
                }
 
            }
        }

        //3. Reserve a room for a gues ...
        static void ReserveRoomForGues()
        {
            char choice;
            // do loop to repeat the process of reseve room 
            //based on the user choice ...
            do
            {

                //part 1 code ... (to display all available room and tell the user if there is no)
                int notAvailable = 0;
                //int isAvailable = 0;
                Console.WriteLine("Room Available: \nNumber | Daily Rate\n");
                //to print all the recored based on roomCount ...
                for (int i = 0; i < roomCount; i++)
                {
                    if (isReserved[i] == false)
                    {
                        Console.WriteLine($"{roomNumbers[i]} | {roomRates[i]}");
                        //isAvailable++;
                    }
                    else
                    {
                        notAvailable++;
                    }

                }
                if (notAvailable == roomCount)
                {
                    Console.WriteLine("Sory there is no more room available ...");
                    //choice = 'n';
                    //break;
                    return;
                }

                //part 2 code ... (to allow the user to Reserve a room)
                string guestName;
                int nights_number = 0;
                int roomNumToReseve = 0;
                DateTime guest_date;
                int index = 0;
                //to make sure that reserve room process can be repeat based on the room number availble ...
                int tryToReseveRoom = 0;
                if (roomCount > tryToReseveRoom)
                {
                    //Console.Clear();
                    Console.WriteLine("Enter the following details:");

                    //guest name input process code ... 
                    bool flag_name = false;//to know if the name add or not ...
                    do
                    {
                        //to store guest name into guestName variable ....
                        Console.WriteLine("Guest Name:");
                        
                        guestName = Console.ReadLine();
                        bool check_name = IsAlpha(guestName);
                        if (check_name == false)
                        {
                            Console.WriteLine("Guest name can not contains number and con not be null ..." +
                                              "please enter student name again");
                            flag_name = true;
                        }
                        else
                        {
                            flag_name = false;
                        }

                    } while (flag_name);

                    //room number input process code ... 
                    bool flag_rom_number = false;//to know if the room number is there or not ...
                    do
                    {
                        try
                        {
                            bool exit = false;
                            bool available = false;
                            //to store room number into RoomNumber variable ....
                            Console.WriteLine("Enter room number you want to reseved:");
                            roomNumToReseve = int.Parse(Console.ReadLine());
                            //to check if the room number is there or not ...
                            for (int i = 0; i < roomCount; i++)
                            {
                                if (roomNumToReseve == roomNumbers[i])
                                {
                                    exit = true;
                                    
                                    if (isReserved[i] == false)
                                    {
                                        //isReserved[i] = true;
                                        available = true;
                                        index = i;
                                        
                                    }
                                    else
                                    {
                                        //Console.WriteLine("This room is alraedy reseved");
                                        flag_rom_number = true;
                                    }
                                    
                                }
                                else
                                {
                                    //Console.WriteLine("This room number do not exit please enter anther number!");
                                    flag_rom_number = true;
                                }
                            }

                            if (exit == false || available == false)
                            {
                                Console.WriteLine("This room number do not exit or it is alraedy reseved please enter anther number!");
                            }
                            else
                            {
                                flag_rom_number = false;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Room number not entered due to: " + e.Message);
                            flag_rom_number = true;
                        }

                    } while (flag_rom_number);

                    //nights number input process code ... 
                    bool flag_nights_number = false;//to know if the nights number is added or not ...
                    do
                    {
                        try
                        {
                            //to store nights number into nights_number variable ....
                            Console.WriteLine("Enter nights number you want to reseved:");
                            nights_number = int.Parse(Console.ReadLine());
                            //to check if the nights number is > zero or not ...
                            if (nights_number < 0)
                            {
                                Console.WriteLine("Nights number should be > zero");
                                flag_nights_number = true;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Nights number not entered due to: " + e.Message);
                        }

                    } while (flag_nights_number);


                    //to store date of taday into guest_date varible ....
                    guest_date = DateTime.Now;

                    //to store guest info in the arrays ...
                    guestNames[index] = guestName;
                    //guestRoomNum[tryToReseveRoom] = roomNumToReseve;
                    nights[index] = nights_number;
                    bookingDates[index] = guest_date;
                    isReserved[index] = true;
                    guestCount++;

                    // so the system know that there are one more room reseved ......
                    tryToReseveRoom++;
                    //so the system know that one room is reseved 
                    //isAvailable--;
                    Console.WriteLine("Room reseve successfully ...");
                    Console.WriteLine("Do you want to reseve anther room? y / n");
                    choice = Console.ReadKey().KeyChar;
                    Console.ReadLine();//just to hold second ...
                }
                else
                {
                    Console.WriteLine("Sory you can not reseve more room there are no room remain!");
                    Console.WriteLine();
                    choice = 'n';
                }

            } while (choice == 'y' || choice == 'Y');
        }

        //4. View all reservations with total cost ...
        static void ViewAllReservationsWithTotalCost()
        {
            string guestName;
            int roomNum;
            int night;
            int index = 0;
            double rate;
            double totalCost;
            Console.WriteLine("Reserved Room Information: \nGuest Name | Room Number | Nights | Daily Rate | Total Cost \n");
            //to get all reserved room details ...
            for(int i = 0; i<roomCount; i++)
            {
                //guestName = guestNames[i];
                //roomNum = guestRoomNum[i];
                //night = nights[i];

                ////to get Daily Rate ...
                //for(int j = 0; j < roomCount; j++)
                //{
                //    if (guestRoomNum[i] == roomNumbers[j])
                //    {
                //        index = j;
                //        break;
                //    }
              
                //}
                //rate = roomRates[index];
                ////to get total cost ...
                //totalCost = rate * night;
                ////Console.WriteLine(isReserved[index]);
                if (isReserved[i] == true)
                {
                    Console.WriteLine($"{guestNames[i]} | {roomNumbers[i]} | {nights[i]} | {roomRates[i]} | {nights[i] * roomRates[i]}");
                }
            }

        }

        //5. Search reservation by guest name ...
        static void SearchReservationByGuestName()
        {
            char choice;
            // do loop to repeat the process of adding new Room 
            //based on the user choice ...
            do
            {

                //guest name input process code ... 
                bool flag_nameSearch = false;//to know if the name add or not ...
            do
            {
                string GuestNameToSearch;
                //to store guest name to search into GuestNameToSearch variable ....
                Console.WriteLine("Enter guest name to search:");
                GuestNameToSearch = Console.ReadLine();

                bool check_name = IsAlpha(GuestNameToSearch);
                if (check_name == false)
                {
                    Console.WriteLine("Guest name can not contains number and con not be null ..." +
                                      "please enter student name again");
                    flag_nameSearch = true;
                }
                else
                {
                    flag_nameSearch = true;
                    bool flag = true;
                    for (int i = 0; i < guestCount; i++)
                    {
                        if (GuestNameToSearch.ToLower() == guestNames[i].ToLower())
                        {
                            flag = false;
                            flag_nameSearch = false;
                            //to get Daily Rate ...
                            int index = 0;
                            double rate;
                            double totalCost;
                            for (int j = 0; j < roomCount; j++)
                            {
                                if (guestRoomNum[i] == roomNumbers[j])
                                {
                                    index = j;
                                    break;
                                }

                            }
                            rate = roomRates[index];
                            //to get total cost ...
                            totalCost = rate * nights[i];
                            Console.WriteLine("Reserved Room Information: \nGuest Name | Room Number | Nights | Daily Rate | Total Cost \n");
                            Console.WriteLine($"{guestNames[i]} | {guestRoomNum[i]} | {nights[i]} | {rate} | {totalCost}");
                        }

                    }
                    if (flag)
                    {
                        Console.WriteLine("Guest name not found");
                        flag_nameSearch = true;
                    }
                }

            } while (flag_nameSearch);

                Console.WriteLine("Do you want to search for anther guest? y / n");
                choice = Console.ReadKey().KeyChar;
                Console.ReadLine();//just to hold second ...

            } while (choice == 'y' || choice == 'Y');

        }

        //6. Find the highest-paying guest ...
        static void FindHighestPayingGuest()
        {
            double maxCost = 0;
            double cost = 0;
            int guestIndex = 0;
            for(int i = 0; i < guestCount; i++)
            {
                cost = roomRates[i] * nights[i];
                if(cost > maxCost)
                {
                    maxCost = cost;
                    guestIndex = i;
                }
            }
            Console.WriteLine("Guest with the highest amount is:" + guestNames[guestIndex]);
        }

        //7. Cancel a reservation by room number ...
        static void CancelReservationByRoomNumber()
        {
            Console.WriteLine("7");
        }


        //ADDITIONAL METHODS ...
        //1. To check of the string contains something other than letters (this methos return true or false)....
        static bool IsAlpha(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }


    }
}
