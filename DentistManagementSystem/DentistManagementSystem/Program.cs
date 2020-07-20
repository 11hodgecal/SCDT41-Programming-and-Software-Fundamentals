using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int LogMax = 3;// max log in attemptes
            int LogCur = 0;//current log in attempts 
            int LogCD = 3;// how many attempts left
            string user = "";//who is the user
            int num = 0;
            bool userlock = false;//shows whether a computer is locked 

            //initalizes the staff classes
            Admin Admin = new Admin("George", "Admin", "admin");
            List<Receptionist> receptionists = new List<Receptionist> { new Receptionist("Jane", "JaneDoe", "Rec1"), new Receptionist("phillip", "phillipson", "rec2") };
            List<Nurse> Nurses = new List<Nurse> { new Nurse("jenny", "Jenny", "nurse1"), new Nurse("nurse2", "n2", "Nurse2")};
            List<Dentist> Dentists = new List<Dentist> { new Dentist("bill", "bill", "Dentist1"), new Dentist("jill", "jill", "Dentist2") };
            bool DataToggle = true;

            //Merges The Staff Data Into one list
            List<string> Names = new List<string>();
            List<string> username = new List<string>();
            List<string> password = new List<string>();
            List<int> staffid = new List<int>();

            //adds admin data to the list
            Names.Add(Admin.Name);
            password.Add(Admin.Password1);
            username.Add(Admin.User);
            staffid.Add(Admin.staffID);

            //adds Nurse data to the list
            for (int x = 0; x < Nurses.Count; x++)
            {
                Names.Add(Nurses[x].Name);
                password.Add(Nurses[x].Password1);
                username.Add(Nurses[x].User);
                staffid.Add(Nurses[x].staffID);
            }
            //adds Dentist data to the list
            for (int x = 0; x < Dentists.Count; x++)
            {
                Names.Add(Dentists[x].Name);
                password.Add(Dentists[x].Password1);
                username.Add(Dentists[x].User);
                staffid.Add(Dentists[x].staffID);
            }
            //adds Receptionist Data to the list
            for (int x = 0; x < receptionists.Count; x++)
            {
                Names.Add(receptionists[x].Name);
                password.Add(receptionists[x].Password1);
                username.Add(receptionists[x].User);
                staffid.Add(receptionists[x].staffID);
            }
            
            

            void LogIn() //logs a user in
            {
                int isuserright = 0;//show if user is wrong
                int ispassright = 0;// show if pass is wrong
                int FIsAdmin = 0;//check if user is an admin in the while loop
                LogCur = 0;
                user = "";
                int curStaffid = 0;

                while (LogMax > LogCur) //while within the ammount of attemts allowed
                {

                    //for user
                    LogCur++;//add one to log current
                    LogCD--;// add one to log count down
                    Console.Clear();
                    Console.WriteLine("please enter your username and password:");
                    Console.WriteLine();
                    Console.WriteLine("Username:");
                    string Username = Console.ReadLine();//user input = Username
                    Console.WriteLine("Password:");
                    string Password = Console.ReadLine();//user input = password
                    Console.WriteLine();
                    


                    for (int x = 0; x < username.Count; x++)
                    {
                        //if the details where right

                        if (username[x] == Username) // if userinput = username add 1 to is right
                        {
                            user = Username;//checks which user is logging in
                            curStaffid = staffid[x];//saves there id
                            ispassright++;
                            if (password[x] == Password)// if userinput = password add 1 to is right
                            {
                                ispassright++;
                                if (ispassright == 2) //if isright equals 2 login
                                {

                                    LogCur = 4;
                                    

                                }

                            }

                        }
                        if (password[x] == Password) // if password is right
                        {

                            isuserright++;
                            if (username[x] == Username) // if uname is right
                            {
                                isuserright++;
                                if (isuserright == 2) // log in
                                {
                                    LogCur = 4;
                                }

                            }

                        }
                    }

                    //what do do if details are wrong
                    if (isuserright == 1) // if username show user error and the attempts they have left
                    {
                        Console.WriteLine("You have entered your Username wrong");
                        if (LogCD > 1)
                        {
                            Console.WriteLine("remaining Attempts: {0}", LogCD);
                        }
                        Console.WriteLine();
                        Console.ReadLine();
                    }
                    else if (ispassright == 1) // if password is wrong show error
                    {
                        Console.WriteLine("you have entered your Password wrong");
                        if (LogCD > 0)
                        {
                            Console.WriteLine("remaining Attempts: {0}", LogCD);
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ReadLine();
                    }
                    else if (ispassright == 0)// if both are wrong show wrong
                    {
                        Console.WriteLine("you entered both your password and Username wrong");
                        if (LogCD > 0)
                        {
                            Console.WriteLine("remaining Attempts: {0}", LogCD);
                        }
                        Console.WriteLine();
                        Console.ReadLine();
                    }



                }


                if (LogCur == 4)
                {
                    
                    int admin = 0;
                    int rec = 1;
                    int dentist = 2;
                    int nurse = 3;

                    if (curStaffid == admin) 
                    {
                        
                        HiAdmin();
                    }

                    if (curStaffid == rec)
                    {
                        Console.Clear();
                        Console.WriteLine("hi Receptionist");
                    }

                    if (curStaffid == dentist)
                    {
                        Console.Clear();
                        Console.WriteLine("hi Receptionist");
                    }

                    if (curStaffid == nurse)
                    {
                        Console.Clear();
                        Console.WriteLine("hi Receptionist");
                    }

                }
                

                else if (LogCur == LogMax) //tells the user they are out of attempts
                {
                    Console.WriteLine("You are out of attempts restart or get a admin to log in to unlock you...");
                    Console.WriteLine("To login as admin type: 1");
                    Console.WriteLine("Exit: Enter");
                    string Userinput = Console.ReadLine();
                    if (Userinput == "1") //if user input equals 1 log in as only admin
                    {
                        isuserright = 0;//show if user is wrong
                        ispassright = 0;// show if pass is wrong
                        LogCur = 0;
                        user = "";
                        // same as the previous login method but it only works for the admin
                        while (LogMax > LogCur) //while within the ammount of attemts allowed
                        {

                            //for user
                            LogCur++;//add one to log current
                            LogCD--;// add one to log count down
                            Console.Clear();
                            Console.WriteLine("To log in as admin please enter your username and password:");
                            Console.WriteLine();
                            Console.WriteLine("Username:");
                            string Username = Console.ReadLine();//user input = Username
                            Console.WriteLine("Password:");
                            string Password = Console.ReadLine();//user input = password
                            Console.WriteLine();



                            for (int x = 0; x < username.Count; x++)
                            {
                                //if the details where right

                                if (username[0] == Username) // if userinput = username add 1 to is right
                                {
                                    user = Username;//checks which user is logged in
                                    ispassright++;
                                    if (password[0] == Password)// if userinput = password add 1 to is right
                                    {
                                        ispassright++;
                                        if (ispassright == 2) //if isright equals 2 login
                                        {

                                            LogCur = 4;
                                            

                                        }

                                    }

                                }
                                if (password[0] == Password) // if password is right
                                {

                                    isuserright++;
                                    if (username[0] == Username) // if uname is right
                                    {
                                        isuserright++;
                                        if (isuserright == 2) // log in
                                        {
                                            LogCur = 4;
                                        }

                                    }

                                }
                            }

                            //what do do if details are wrong
                            if (isuserright == 1) // if username show user error and the attempts they have left
                            {
                                Console.WriteLine("You have entered your Username wrong");
                                Console.WriteLine();
                                Console.ReadLine();
                            }
                            else if (ispassright == 1) // if password is wrong show error
                            {
                                Console.WriteLine("you have entered your Password wrong");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ReadLine();
                            }
                            else if (ispassright == 0)// if both are wrong show wrong
                            {
                                Console.WriteLine("you entered both your password and Username wrong");
                                Console.WriteLine();
                                Console.ReadLine();
                            }



                        }// same as the previous login method


                        if (LogCur == 4)
                        {
                            int admin = 0;

                            if (curStaffid == admin) {
                                Console.WriteLine("Hi Admin");
                            }

                            

                        }

                    }
                }

                void HiAdmin() //what admins see's
                {
                    void ChangeDetails()//change users details
                    {
                        Console.WriteLine("enter the id of the User you want to change");
                        string UserinputID = Console.ReadLine();
                        if (UserinputID == "0")//goes back to the main menu and show error
                        {
                            Console.WriteLine("Invalid Input");
                            Console.ReadLine();
                            Mainmenu();
                        }
                        else if (int.Parse(UserinputID) > staffid.Max())//goes back to the main menu and show error
                        {
                            Console.WriteLine("Invalid Input");
                            Console.ReadLine();
                        }
                        //stores all infomation assosiated with the id
                        string[] userinfoarray = { username[int.Parse(UserinputID)], password[int.Parse(UserinputID)], Names[int.Parse(UserinputID)] };
                        //shows user the choices
                        Console.WriteLine("What details do you want to change:");
                        Console.WriteLine("Username: 1");
                        Console.WriteLine("Password: 2");
                        Console.WriteLine("Name: 3");
                        string Userinput = Console.ReadLine();
                        if (Userinput == "0") //goes back to the main menu
                        {
                            Mainmenu();
                        }
                        if (Userinput == "1") // lets admin change the username
                        {
                            for (int x = 0; x < staffid.Count; x++)
                            {
                                if (Userinput == "")//shows error goes back to admin menu
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Input press enter to continue");
                                    Console.ReadLine();
                                }
                                else if (username[x] == userinfoarray[0]) //if user name equals user info
                                {
                                    Console.Clear();
                                    Console.WriteLine("New Username:");
                                    Userinput = Console.ReadLine();//the new username
                                    username[x] = Userinput; // sets the new username
                                }
                            }
                        }
                        if (Userinput == "2")// lets admin change the password
                        {
                            for (int x = 0; x < staffid.Count; x++)
                            {
                                if (Userinput == "")//shows error goes back to admin menu
                                {

                                    Console.Clear();
                                    Console.WriteLine("Invalid Input press enter to continue");
                                    Console.ReadLine();
                                }
                                else if (password[x] == userinfoarray[1])//if password equals user info
                                {
                                    Console.Clear();
                                    Console.WriteLine("New Username:");
                                    Userinput = Console.ReadLine();//the new password
                                    password[x] = Userinput;// sets the new password
                                }
                            }
                        }
                        if (Userinput == "3")// lets admin change the first name
                        {
                            for (int x = 0; x < staffid.Count; x++)
                            {
                                if (Userinput == "")//shows error goes back to admin menu
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Input press enter to continue");
                                    Console.ReadLine();
                                }
                                else if (Names[x] == userinfoarray[2])//if firstname equals user info
                                {
                                    Console.Clear();
                                    Console.WriteLine("New Username:");
                                    Userinput = Console.ReadLine();//the new name
                                    Names[x] = Userinput;// sets the new name
                                }
                            }
                        }
                        Mainmenu();

                    }
                    void AddnRemove()// add or remove a user
                    {
                        void ADD() //add user
                        {
                            void ADDReceptionist()
                            {

                                //Create user form
                                Console.Clear();
                                Console.WriteLine("Enter the Name of the new user");
                                string name = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine("Enter the Username for the new user");
                                string Username = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine("Enter the Password for the new user");
                                string Password = Console.ReadLine();


                                receptionists.Add(new Receptionist(name, Username, Password));//creates the new user

                                for (int x = 0; x < receptionists.Count; x++) //finds the new user then adds them to the table
                                {
                                    if (Username == receptionists[x].User)
                                    {
                                        if (Password == receptionists[x].Password1)
                                        {
                                            Names.Add(receptionists[x].Name);
                                            password.Add(receptionists[x].Password1);
                                            username.Add(receptionists[x].User);
                                            staffid.Add(receptionists[x].staffID);
                                        }
                                    }
                                }
                                Mainmenu();

                            }
                            void AddDentist()
                            {
                                //Create user form
                                Console.Clear();
                                Console.WriteLine("Enter the Name of the new user");
                                string name = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine("Enter the Username for the new user");
                                string Username = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine("Enter the Password for the new user");
                                string Password = Console.ReadLine();


                                Dentists.Add(new Dentist(name, Username, Password));//creates the new user

                                for (int x = 0; x < Dentists.Count; x++) //finds the new user then adds them to the table
                                {
                                    if (Username == Dentists[x].User)
                                    {
                                        if (Password == Dentists[x].Password1)
                                        {
                                            Names.Add(Dentists[x].Name);
                                            password.Add(Dentists[x].Password1);
                                            username.Add(Dentists[x].User);
                                            staffid.Add(Dentists[x].staffID);
                                        }
                                    }
                                }
                                UserMenu();
                            }
                            void AddNurse()
                            {
                                //Create user form
                                Console.Clear();
                                Console.WriteLine("Enter the Name of the new user");
                                string name = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine("Enter the Username for the new user");
                                string Username = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine("Enter the Password for the new user");
                                string Password = Console.ReadLine();


                                Nurses.Add(new Nurse(name, Username, Password));//creates the new user

                                for (int x = 0; x < Nurses.Count; x++) //finds the new user then adds them to the table
                                {
                                    if (Username == Nurses[x].User)
                                    {
                                        if (Password == Nurses[x].Password1)
                                        {
                                            Names.Add(Nurses[x].Name);
                                            password.Add(Nurses[x].Password1);
                                            username.Add(Nurses[x].User);
                                            staffid.Add(Nurses[x].staffID);
                                        }
                                    }
                                }
                                Mainmenu();
                            }

                            Console.WriteLine("what type of user need to be added");
                            Console.WriteLine("Add Receptionist: 1");
                            Console.WriteLine("Add Dentist: 2");
                            Console.WriteLine("Add nurse: 3");
                            string userInput = Console.ReadLine();
                            if (userInput == "1")// if user input == 2 allow admin to use add&remove function 
                            {
                                ADDReceptionist();
                            }
                            if (userInput == "2")// if user input == 2 allow admin to use change details function 
                            {

                                AddDentist();
                            }
                            if (userInput == "3")// if user input == 2 allow admin to use change details function 
                            {

                                AddNurse();
                            }
                            Mainmenu();
                        }
                        void Remove()
                        {
                            Console.WriteLine("Please enter the ID of the User you want to remove");
                            string Userinput = Console.ReadLine();//user sets userinput
                            Console.WriteLine("press enter to confirm");//confirms the total deletion
                            Console.ReadLine();

                            if (Userinput == "0")//goes back to the main menu and show error
                            {
                                Console.WriteLine("Invalid Input");
                                Console.ReadLine();
                            }
                            else if (int.Parse(Userinput) > staffid.Max())//goes back to the main menu and show error
                            {
                                Console.WriteLine("Invalid Input");
                                Console.ReadLine();
                            }



                            for (int x = 0; x < staffid.Count; x++) //goes throu the id to look for which one non admin is assosiated with that id.
                            {
                                if (curStaffid == 0)
                                {

                                    if (x == int.Parse(Userinput))
                                    {
                                        //deletes all infomation on the selected ID
                                        username.Remove(username[x]);
                                        password.Remove(password[x]);
                                        Names.Remove(Names[x]);
                                        staffid.Remove(staffid[x]);
                                    }


                                }

                            }


                            UserMenu();
                        }


                        Console.WriteLine("do you want to add or remove a user:");
                        Console.WriteLine("Add: 1");
                        Console.WriteLine("Remove: 2");
                        string userinput = Console.ReadLine();
                        if (userinput == "1")// if user input == 2 allow admin to use add&remove function 
                        {
                            ADD();
                        }
                        if (userinput == "2")// if user input == 2 allow admin to use change details function 
                        {

                            Remove();
                        }
                    }
                    void UserMenu()
                    {
                        
                        Console.Clear();//clears console
                        for (int x = 0; x < username.Count; x++)
                        {
                            if (staffid[x] > 0)// displays a user table
                            {
                                Console.WriteLine("/// ID:{0} ///Username: {1} /// Password: {2} /// name: {3} /// StaffID: {4}", x, username[x], password[x], Names[x], staffid[x]);
                                Console.WriteLine();
                            }


                        }
                        Console.WriteLine("/// StaffID 1 = Receptionist ///Staffid 2: Dentist ///staffid 3: Dental nurses");
                        //user choice
                        Console.WriteLine("what do you want to do next:");
                        Console.WriteLine();
                        Console.WriteLine("To add or remove a user: 1");
                        Console.WriteLine("To Update a users informaton: 2");
                        Console.WriteLine("To Log Out: 3");
                        Console.WriteLine("To exit: press enter");
                        string Userinput = Console.ReadLine();
                        if (Userinput == "1")// if user input == 2 allow admin to use add&remove function 
                        {
                            AddnRemove();
                        }
                        if (Userinput == "2")// if user input == 2 allow admin to use change details function 
                        {
                            ChangeDetails();
                        }
                        if (Userinput == "3")
                        {
                            LogIn();
                        }

                        Mainmenu();
                    }
                    void Mainmenu() 
                    {
                        Console.Clear();//clears console
                        if (userlock == false)//if normal login
                        {
                            for (int x = 0; x < username.Count; x++)
                            {
                                if (username[x] == user)//if username matches the user show a welcome message
                                {
                                    Console.WriteLine("Welcome Admin, {0}", Names[x]);
                                    Console.WriteLine();
                                    Console.WriteLine("These are your users");
                                }
                            }
                            //user choice
                            Console.WriteLine("what do you want to do next:");
                            Console.WriteLine("Manage Practices: 1");
                            Console.WriteLine("Manage Employees: 2");
                            string Userinput = Console.ReadLine();
                            if (Userinput == "1")// if user input == 2 allow admin to use add&remove function 
                            {
                            }
                            if (Userinput == "2")// if user input == 2 allow admin to use change details function 
                            {
                                UserMenu();
                            }
                            
                        }
                        else if (userlock == true) //not a full login the user cannot see the other logins while the admin is loging in
                        {
                            Console.WriteLine("Welcome Admin This computer is locked press 1 to unlock");
                            Console.WriteLine();
                            Console.WriteLine("To Unlock computer: 1");
                            Console.WriteLine("To exit: press enter");
                            string Userinput = Console.ReadLine();//user input
                            if (Userinput == "1")// if user input == 1 unlock computer
                            {
                                userlock = false;
                                LogIn();

                            }
                        }
                    }

                    Mainmenu();

                }

                void HiUser()//#What users see when they log in
                {
                    for (int x = 0; x < username.Count; x++)
                    {
                        if (username[x] == user)//if username matches the user show a welcome message including there status
                        {
                            Console.WriteLine("Welcome, {0} {1}", Names[x]);
                        }
                    }

                    Console.WriteLine("press enter to Logout");
                    Console.ReadLine();
                    LogIn();


                }
            }
            LogIn();

            




        }
    }
}
