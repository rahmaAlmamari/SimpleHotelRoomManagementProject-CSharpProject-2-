using System.Net.NetworkInformation;

namespace Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                bool flag = false;
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
                    flag = true;
                }


                if (flag)//it mean if flag is true do the following.. if not do else ...
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
            Console.WriteLine("1");
        }

        // 2. View all rooms ...
        static void ViewAllRooms()
        {
            Console.WriteLine("2");
        }

        //3. Reserve a room for a gues ...
        static void ReserveRoomForGues()
        {
            Console.WriteLine("3");
        }

        //4. View all reservations with total cost ...
        static void ViewAllReservationsWithTotalCost()
        {
            Console.WriteLine("4");
        }

        //5. Search reservation by guest name ...
        static void SearchReservationByGuestName()
        {
            Console.WriteLine("5");
        }

        //6. Find the highest-paying guest ...
        static void FindHighestPayingGuest()
        {
            Console.WriteLine("6");
        }

        //7. Cancel a reservation by room number ...
        static void CancelReservationByRoomNumber()
        {
            Console.WriteLine("7");
        }
    }
}
