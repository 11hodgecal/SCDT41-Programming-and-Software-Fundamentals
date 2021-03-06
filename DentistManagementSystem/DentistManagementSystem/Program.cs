﻿using System;
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
            int LogCur = 0;//current log in attempts
            string user = "";//who is the user

            //initalizes the staff classes
            Admin Admin = new Admin("George", "Admin", "admin");
            List<Receptionist> receptionists = new List<Receptionist> { new Receptionist("Rec1", "Rec1", "Rec1"), new Receptionist("Janed", "JaneDoed", "Rec1d"), new Receptionist("Rec3", "Rec3", "Rec3") };
            List<Nurse> Nurses = new List<Nurse> { new Nurse("jenny", "Jenny", "nurse1"), new Nurse("Nurse2", "Nurse2", "Nurse2"), new Nurse("Nurse3", "Nurse3", "Nurse3") };
            List<Dentist> Dentists = new List<Dentist> { new Dentist("bill", "Bill", "Dent"), new Dentist("billy", "Dentist2", "Dentist2"), };
            List<DentalPractice> Practices = new List<DentalPractice> { new DentalPractice(true,"Taunton Dentist",0,receptionists[0])};
            List<Patient> Patient = new List<Patient> { new Patient ("pat1",1341341,"pat1@gmail.com",true,true,Dentists[0],0,"4 pat rd") };
            //testing vars
            Dentists[0].roomid = 0;
            receptionists[0].PracID = 0;
            receptionists[0].isassined = true;
            Practices[0].pracRooms.Add(new Room(0,true,true,Nurses[0],Dentists[0]));
            Nurses[0].hasroom = true;
            Dentists[0].hasroom = true;
            Patient[0].PatientAppointments.Add(new Appointment("Checkup", 22.70,Dentists[0],Practices[0].pracRooms[0]));
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
                LogCur = 0;
                user = "";
                int curStaffid = 0;

                
                while (LogCur != 4) //while within the ammount of attemts allowed
                {

                    //for user
                    LogCur++;//add one to log current
                    Console.Clear();
                    Console.WriteLine("Please enter your Username and Password:");
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
                        Console.WriteLine();
                        Console.ReadLine();
                    }
                    else if (ispassright == 1) // if password is wrong show error
                    {
                        Console.WriteLine("You have entered your Password wrong");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ReadLine();
                    }
                    else if (ispassright == 0)// if both are wrong show wrong
                    {
                        Console.WriteLine("You entered both your password and Username wrong");
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
                    //login as Admin
                    if (curStaffid == admin) 
                    {
                        SurMenu();
                    }
                    //log in as Receptionist
                    if (curStaffid == rec)
                    {
                        Console.Clear();
                        reclogin();
                        
                    }
                    //log in as dentist
                    if (curStaffid == dentist)
                    {
                        Console.Clear();
                        docLogin();
                    }
                    //log in as Nurse
                    if (curStaffid == nurse)
                    {
                        Console.Clear();
                        nurLogin();
                    }

                }
                
            }
            void SurMenu()
            {

                Console.Clear();
                Console.WriteLine("Choose a practice");
                Console.WriteLine();
                string userchoice = null;
                DentalPractice ChosenPractice = null;//chosen dental practice
                for (int x = 0; x < Practices.Count; x++)
                {
                    Console.WriteLine("{0}.{1}", x, Practices[x].Name);
                    userchoice = x.ToString();
                }
                Console.WriteLine();
                //user selects what they are going to do
                Console.WriteLine("1: Select Practice");
                Console.WriteLine("2: To Create a new Practice");
                Console.WriteLine("3: Employee Management");
                string userinput = Console.ReadLine();
                if (userinput == "1")
                {
                    SelectDentist();
                }
                if (userinput == "2")
                {
                    AddDentist();
                }
                if (userinput == "3")
                {
                    HiAdmin();
                }

                void AddDentist()
                {
                    //user input that creates a new name and id for the new surgery
                    Console.Clear();
                    Console.WriteLine("Enter the name of the new Practice:");
                    string newName = Console.ReadLine();
                    int newsurID = Practices.Count;//the new Surgery id
                    int x;
                    Console.Clear();
                    //Displays the available Receptionists
                    for (x = 0; x < receptionists.Count; x++)
                    {

                        if (receptionists[x].isassined == false)
                        {
                            Console.WriteLine("{0}.{1}", x, receptionists[x].Name);

                        }
                    }

                    // Creates the new Surgery.
                    Console.WriteLine();
                    Console.WriteLine("Which Receptionist will be assined:");
                    string AssinedDent = Console.ReadLine();

                    for (x = 0; x < receptionists.Count; x++)
                    {
                        if (x.ToString() == AssinedDent)
                        {
                            Practices.Add(new DentalPractice(true, newName, newsurID, receptionists[x]));
                            receptionists[x].isassined = true;
                        }
                    }
                    SurMenu();
                };//Add a Dentist Surgery
                void SelectDentist()
                {
                    //user selects a practice to find more details.
                    Console.Clear();
                    Console.WriteLine("Choose a practice");
                    Console.WriteLine();
                    for (int x = 0; x < Practices.Count; x++)
                    {
                        Console.WriteLine("{0}.{1}", x, Practices[x].Name);
                        userchoice = x.ToString();
                    }
                    Console.WriteLine("Select the Practice:");

                    //finds the selected practice on the users input.
                    string Userinput = Console.ReadLine();
                    Console.Clear();
                    for (int X = 0; X < Practices.Count; X++)
                    {
                        if (Userinput == userchoice)
                        {
                            ChosenPractice = Practices[X];
                        }
                    }
                    if (Userinput == userchoice)
                    {
                        selectedDentist();
                    }
                };//selecting a dentist
                void selectedDentist()
                {
                    int x = 0;

                    //displays all of the rooms in the practice
                    Console.WriteLine("Receptionist:{0}", ChosenPractice.AssinedRec.Name);
                    for (x = 0; x < ChosenPractice.pracRooms.Count; x++)
                    {
                        Console.WriteLine("Room: {0} /// Dentist: {1} /// Nurse: {2}", x, ChosenPractice.pracRooms[x].assineddent.Name, ChosenPractice.pracRooms[x].assinednur.Name);

                    }

                    //user choses to add a room
                    Console.WriteLine();
                    Console.WriteLine("1: Add Room");
                    Console.WriteLine("Enter to go back to main menu");
                    string Userchoice = Console.ReadLine();
                    if (Userchoice == "1")
                    {
                        CreateRoom();
                    }

                    void CreateRoom()
                    {


                        //variables 
                        Console.Clear();
                        int newID = ChosenPractice.pracRooms.Count;//new id
                        Nurse assinednur = null;//selected nurse
                        Dentist assineddentist = null;//selected dentist

                        //displays available dentists
                        Console.WriteLine("Available Dentists:");

                        for (x = 0; x < Dentists.Count; x++)
                        {
                            if (Dentists[x].hasroom == false)
                            {
                                Console.WriteLine("{0}. Name: {1}", x, Dentists[x].Name);
                            }
                        }

                        //sets the new dentist and marks the person as assined
                        string AssinedDent = Console.ReadLine();

                        for (x = 0; x < Dentists.Count; x++)
                        {
                            if (x.ToString() == AssinedDent)
                            {
                                Dentists[x].hasroom = true;
                                assineddentist = Dentists[x];

                            }
                        }

                        //displays available nurses
                        Console.Clear();
                        Console.WriteLine("Available Nurses:");
                        for (x = 0; x < Nurses.Count; x++)
                        {
                            if (Nurses[x].hasroom == false)
                            {
                                Console.WriteLine("{0}. Name: {1}", x, Nurses[x].Name);
                            }

                        }

                        //sets the new Marks and marks the person as assined
                        string Assinednur = Console.ReadLine();

                        for (x = 0; x < Nurses.Count; x++)
                        {
                            if (x.ToString() == Assinednur)
                            {
                                Nurses[x].hasroom = true;
                                assinednur = Nurses[x];
                            }
                        }

                        //creates the new room and sets the dentist in having a room
                        for (x = 0; x < Practices.Count; x++)
                        {
                            if (ChosenPractice.Name == Practices[x].Name)
                            {
                                Practices[x].pracRooms.Add(new Room(newID, true, true, assinednur, assineddentist));
                                for (int r = 0; r < Dentists.Count; r++)
                                {
                                    if (Dentists[r].User == assineddentist.User)
                                    {
                                        Dentists[r].hasroom = true;
                                    }
                                }
                            }
                        }
                        Console.Clear();
                        SurMenu();



                    }//create room
                    SurMenu();
                }//what to do when a Dentist is selected
                void HiAdmin() //what admins see's
                {
                    void AddnRemove() //add or remove a user
                    {
                        void ADD() //add user
                        {


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

                                Adddentist();
                            }
                            if (userInput == "3")// if user input == 2 allow admin to use change details function 
                            {

                                AddNurse();
                            }
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
                                UserMenu();

                            }
                            void Adddentist()
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
                                SurMenu();
                            }
                            UserMenu();
                        }
                        void Remove()
                        {
                            
                            Console.WriteLine("Please enter the ID of the User you want to remove");
                            string UserInput = Console.ReadLine();//user sets userinput
                            Console.WriteLine("Press enter to confirm");//confirms the total deletion
                            Console.ReadLine();
                            if (UserInput == "0")//goes back to the main menu and show error
                            {
                                Console.WriteLine("Invalid Input");
                                Console.ReadLine();
                            }
                            Console.Clear();


                            for (int x = 0; x < staffid.Count; x++) //goes throu the id to look for which one non admin is assosiated with that id.
                            {
                                if (staffid[x] != 0)
                                {

                                    if (x == int.Parse(UserInput))
                                    {
                                        
                                        //removes the instance

                                        //check if the entry is a nurse and removes the instance
                                        for (int y = 0; y < Nurses.Count; y++)
                                        {
                                            if (username[x] == Nurses[y].User)
                                            {
                                                Nurses.RemoveAt(y);
                                                SurMenu();
                                            }
                                        }
                                        //checks if the entry is a Dentist and removes the instance
                                        for (int y = 0; y < Dentists.Count; y++)
                                        {
                                            if (username[x] == Dentists[y].User)
                                            {
                                                //removes the room that is attached to the nurse
                                                Dentists.RemoveAt(y);
                                                SurMenu();

                                            }
                                        }
                                        //checks if the entry is a Receptionist and removes the instance
                                        for (int y = 0; y < receptionists.Count; y++)
                                        {
                                            if (username[x] == receptionists[y].User)
                                            {
                                                receptionists.RemoveAt(y);
                                                SurMenu();
                                            }
                                        }

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


                        Console.WriteLine("Do you want to Add or Remove a user:");
                        Console.WriteLine("Add: 1");
                        Console.WriteLine("Remove: 2");
                        string Userinput = Console.ReadLine();
                        if (Userinput == "1")// if user input == 2 allow admin to use add&remove function 
                        {
                            ADD();
                        }
                        if (Userinput == "2")// if user input == 2 allow admin to use change details function 
                        {

                            Remove();
                        }
                    }
                    void ChangeDetails()//change users details
                    {
                        
                        Console.WriteLine("Enter the id of the User you want to change");
                        string UserinputID = Console.ReadLine();
                        if (UserinputID == "0")//goes back to the main menu and show error
                        {
                            Console.WriteLine("Invalid Input");
                            Console.ReadLine();

                            UserMenu();
                        }
                        Console.Clear();
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
                            SurMenu();
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

                                    //updates the classes Username
                                    for (int y = 0; y < Nurses.Count; y++)
                                    {
                                        if (userinfoarray[0] == Nurses[y].User)
                                        {
                                            Nurses[y].User = username[x];
                                        }
                                    }

                                    for (int y = 0; y < Dentists.Count; y++)
                                    {
                                        if (userinfoarray[0] == Dentists[y].User)
                                        {
                                            Dentists[y].User = username[x];
                                        }
                                    }

                                    for (int y = 0; y < receptionists.Count; y++)
                                    {
                                        if (userinfoarray[0] == receptionists[y].User)
                                        {
                                            receptionists[y].User = username[x];
                                        }
                                    }

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
                                    //updates the classes password
                                    for (int y = 0; y < Nurses.Count; y++)
                                    {
                                        if (userinfoarray[1] == Nurses[y].Password1)
                                        {
                                            Nurses[y].Password1 = password[x];
                                        }
                                    }

                                    for (int y = 0; y < Dentists.Count; y++)
                                    {
                                        if (userinfoarray[1] == Dentists[y].Password1)
                                        {
                                            Dentists[y].Password1 = password[x];
                                        }
                                    }

                                    for (int y = 0; y < receptionists.Count; y++)
                                    {
                                        if (userinfoarray[1] == receptionists[y].Password1)
                                        {
                                            receptionists[y].Password1 = password[x];
                                        }
                                    }
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
                                    //updates the classes password
                                    for (int y = 0; y < Nurses.Count; y++)
                                    {
                                        if (userinfoarray[2] == Nurses[y].Name)
                                        {
                                            Nurses[y].Name = Names[x];
                                        }
                                    }

                                    for (int y = 0; y < Dentists.Count; y++)
                                    {
                                        if (userinfoarray[2] == Dentists[y].Name)
                                        {
                                            Dentists[y].Name = Names[x];
                                        }
                                    }

                                    for (int y = 0; y < receptionists.Count; y++)
                                    {
                                        if (userinfoarray[2] == receptionists[y].Name)
                                        {
                                            receptionists[y].Name = Names[x];
                                        }
                                    }
                                }
                            }
                        }
                        UserMenu();

                    }
                    void UserMenu()
                    {

                        Console.Clear();//clears console
                        for (int x = 0; x < username.Count; x++)
                        {
                            if (staffid[x] > 0)// displays a user table
                            {

                                Console.WriteLine("/// ID:{0} ///Username: {1} /// Password: {2} /// Name: {3} /// StaffID: {4}///", x, username[x], password[x], Names[x], staffid[x]);
                                Console.WriteLine();
                            }


                        }
                        Console.WriteLine("/// StaffID 1 = Receptionist ///Staffid 2: Dentist ///Staffid 3: Dental nurses");
                        //user choice
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

                        SurMenu();
                    }


                    UserMenu();

                }//employee Management System

            }
            void docLogin()
            {
                void ManagePatientMenu()
                {
                    Console.Clear();
                    for (int y = 0; y < Dentists.Count; y++) //loops throgh the Dentists
                    {
                        if (user == Dentists[y].User)// finds the user throgh looking for the usernames
                        {
                            for(int r = 0; r < Patient.Count; r++) //loops throgh the patients
                            {
                                if (Patient[r].Dentist1.User == user) // finds the Patients Dentist
                                {
                                    //displays the choices and the patients
                                    Console.WriteLine("Patients:");
                                    for (int x = 0; x < Patient.Count; x++)
                                    {
                                        Console.WriteLine("Num: {0}//Name:{1}///Number: {2}///Email: {3}//Address {4}// Dentist Name: {5}", x, Patient[x].Name1, Patient[x].Number, Patient[x].Email1, Patient[x].Address1, Patient[x].Dentist1.Name);
                                    }
                                    Console.WriteLine("1. Select patient");
                                    Console.WriteLine("2. Logout");

                                    //user choice
                                    string X = Console.ReadLine();

                                    if (X == "1")
                                    {
                                        ViewPatient();
                                    }
                                    if (X == "2")
                                    {
                                        LogIn();
                                    }

                                }
                            }
                                
                            
                        }
                    }
                    LogIn();

                }
                void ViewPatient()
                {
                    Console.Clear();
                    string selected = null;
                    //displays all the available Patients
                    for (int x = 0; x < Patient.Count; x++) //loops throgh the Patients
                    {
                        for (int y = 0; y < Dentists.Count; y++) //loops throgh the Dentists 
                        {
                            if (Patient[x].Dentist1 == Dentists[y])// Matches them together
                            {
                                //displays Patient information
                                Console.WriteLine("/// ID:{0} ///Name: {1}// Email: {2}// Phone: {3}// Address{4}", x, Patient[x].Name1, Patient[x].Email1, Patient[x].Number, Patient[x].Address1);

                            }
                        }
                    }

                    Console.WriteLine("Select the id of the Patient:");
                    string chosenpatient = Console.ReadLine();//user choses a patient

                    for (int x = 0; x < Patient.Count; x++) //loops through the Patients
                    {
                        for (int y = 0; y < Dentists.Count; y++)//loops throgh the Dentists
                        {
                            if (Patient[x].Dentist1 == Dentists[y]) //Matches them
                            {
                                //sets the selected patients name as selected and then uses the view appointments function
                                selected = Patient[int.Parse(chosenpatient)].Name1;//selected patient 
                                MakeAppointmentnote(); //then allows the user to make a note
                            }
                        }
                    }

                    void MakeAppointmentnote()
                    {
                        //displays all appointments for the selected patient
                        Console.Clear();
                        for (int x = 0; x < Patient.Count; x++)//loops throgh the patients
                        {
                            if (selected == Patient[x].Name1) //finds the selected Patient
                            {
                                //displays the selected information
                                Console.WriteLine("appointments for {0}:", selected);
                                for (int r = 0; r < Patient[x].PatientAppointments.Count; r++)//loops throgh the patients appointments 
                                {
                                    //displays them
                                    
                                    Console.WriteLine("ID:{0} /// Appointment for a {1} /// Costs: £{2} // With {3} // In room {4}", r, Patient[x].PatientAppointments[r].Treatment1, Patient[x].PatientAppointments[r].Price, Patient[x].PatientAppointments[r].dentist.Name, Patient[x].PatientAppointments[r].room.roomid);
                                    Console.WriteLine("Notes:");
                                    Console.WriteLine();
                                    for (int t = 0; t < Patient[x].PatientAppointments[r].notes.Count; t++)
                                    {
                                        Console.WriteLine("{0}", Patient[x].PatientAppointments[r].notes[t]);
                                        Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                                    }
                                    Console.WriteLine();
                                     
                                }
                            }
                        }
                        // lets the user Decide whether they want to make a appointment or cancel an Existing one

                        //makes selects a patient then asks the user to confirm or go back
                        Console.WriteLine("To make a Note on a Specific appointment select the appointment ID to go back press enter:");
                        string selectedid = Console.ReadLine();
                        Console.WriteLine("Type 1 to confirm:");
                        Console.WriteLine("Press enter to go back:");  
                        string Userinput = Console.ReadLine();


                        if (Userinput == "1") { }
                        if (Userinput == "") { ManagePatientMenu();}

                        // loops through the patients to find the selected patient the initalizes the new note function which reqires the appointment selected and the patient 
                        for (int x = 0; x < Patient.Count; x++)
                        {
                            if (selected == Patient[x].Name1)
                            {
                                for (int r = 0; r < Patient[x].PatientAppointments.Count; r++)
                                {
                                    if (r == int.Parse(selectedid)) 
                                    {
                                        newnote(x,r);
                                        MakeAppointmentnote();
                                    }


                                }
                            }
                        }
                        void newnote(int Chosenappointment, int selap) 
                        {
                            //asks the user to make the new note
                            Console.Clear();
                            Console.WriteLine("Type the note then press enter");
                            Patient[Chosenappointment].PatientAppointments[selap].notes.Add(Console.ReadLine() + " (Note Made by " + user +")");
                            Console.Clear();
                            ManagePatientMenu();
                        }
                        ManagePatientMenu();
                    }
                    
                    
                    LogIn();
                }
                ManagePatientMenu();
            }
            void nurLogin()
            {
                void ManagePatientMenu()
                {
                    Console.Clear();
                    for (int y = 0; y < Nurses.Count; y++) //loops throgh the nurses 
                    {
                        if (user == Nurses[y].User)// finds the logged in nurse
                        {
                            for (int r = 0; r < Patient.Count; r++)//loops though the Patients
                            {
                                if (Nurses[y].User == user)
                                {
                                    for (int k = 0; k < Dentists.Count;)// loops throgh the dentists
                                    {
                                        if (Dentists[k].User == Patient[r].Dentist1.User) //finds the patients Dentist
                                        {
                                            //displays the choices and the patients
                                            Console.WriteLine("Patients:");
                                            for (int x = 0; x < Patient.Count; x++)
                                            {
                                                Console.WriteLine("Num: {0}//Name:{1}///Number: {2}///Email: {3}//Adress {4}// Dentist Name: {5}", x, Patient[x].Name1, Patient[x].Number, Patient[x].Email1, Patient[x].Address1, Patient[x].Dentist1.Name);
                                            }
                                            Console.WriteLine("1. Select patient");
                                            Console.WriteLine("2. Logout");

                                            //user choice
                                            string X = Console.ReadLine();

                                            if (X == "1")
                                            {
                                                ViewPatient();
                                            }
                                            if (X == "2")
                                            {
                                                LogIn();
                                            }
                                        }
                                    }

                                }
                            }


                        }
                    }
                    LogIn();

                }
                void ViewPatient()
                {
                    Console.Clear();
                    string selected = null;
                    //displays all the available Patients
                    for (int x = 0; x < Patient.Count; x++)
                    {
                        for (int y = 0; y < Dentists.Count; y++)
                        {
                            if (Patient[x].Dentist1 == Dentists[y])
                            {
                                Console.WriteLine("/// ID:{0} ///Name: {1}// Email: {2}// Phone: {3}// Address{4}", x, Patient[x].Name1, Patient[x].Email1, Patient[x].Number, Patient[x].Address1);

                            }
                        }
                    }

                    Console.WriteLine("Select the id of the Patient :");
                    string chosenpatient = Console.ReadLine();//user choses a patient


                    //finds the Selected patients Dentist then allows the nurse to make a note
                    for (int x = 0; x < Patient.Count; x++)
                    {
                        for (int y = 0; y < Dentists.Count; y++)
                        {
                            if (Patient[x].Dentist1 == Dentists[y])
                            {
                                //sets the selected patients name as selected and then uses the view appointments function
                                selected = Patient[int.Parse(chosenpatient)].Name1;
                                MakeAppointmentnote();
                            }
                        }
                    }

                    void MakeAppointmentnote()
                    {
                        //displays all appointments for the selected patient
                        Console.Clear();
                        for (int x = 0; x < Patient.Count; x++)
                        {
                            if (selected == Patient[x].Name1) //finds selected patient
                            {
                                Console.WriteLine("Appointments for {0}:", selected);
                                for (int r = 0; r < Patient[x].PatientAppointments.Count; r++)
                                {
                                    //displays the appointments with the notes and marks who made the note
                                    Console.WriteLine("Id:{0} /// Appointment for a {1} /// Costs: £{2} // With {3} // In room {4}", r, Patient[x].PatientAppointments[r].Treatment1, Patient[x].PatientAppointments[r].Price, Patient[x].PatientAppointments[r].dentist.Name, Patient[x].PatientAppointments[r].room.roomid);
                                    Console.WriteLine("Notes:");
                                    for (int t = 0; t < Patient[x].PatientAppointments[r].notes.Count; t++)
                                    {
                                        Console.WriteLine("{0}", Patient[x].PatientAppointments[r].notes[t]);
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                                }
                            }
                        }
                        // lets the user Decide whether they want to select the appointment to add a note then confirm if they still wanted to do it
                        Console.WriteLine("To make a Note on a Specific appointment select the appointment ID to go back press enter:");
                        string selectedid = Console.ReadLine();
                        Console.WriteLine("Type 1 to confirm press enter to go back:");
                        string Userinput = Console.ReadLine();
                        if (Userinput == "1") { }
                        if (Userinput == "") { ManagePatientMenu(); }
                        for (int x = 0; x < Patient.Count; x++)
                        {
                            if (selected == Patient[x].Name1)
                            {
                                for (int r = 0; r < Patient[x].PatientAppointments.Count; r++)
                                {
                                    if (r == int.Parse(selectedid))
                                    {
                                        newnote(x, r);
                                        MakeAppointmentnote();
                                    }


                                }
                            }
                        }
                        void newnote(int Chosenappointment, int selap)
                        {
                            //creates the new note
                            Console.Clear();
                            Console.WriteLine("Type the note then press enter");
                            Patient[Chosenappointment].PatientAppointments[selap].notes.Add(Console.ReadLine() + " (Note Made by " + user + ")");
                            Console.Clear();
                            ManagePatientMenu();
                        }
                        ManagePatientMenu();
                    }


                    LogIn();
                }
                ManagePatientMenu();
            }
            void reclogin() {
                string X = null;
                void ManagePatientMenu()
                {
                    Console.Clear();
                    for (int y = 0; y < receptionists.Count; y++) 
                    { 
                        if (user == receptionists[y].User) 
                        {
                            if (receptionists[y].isassined == true)
                            {
                                //displays the choices and the patients
                                Console.WriteLine("Patients:");
                                for (int x = 0; x < Patient.Count;x++) 
                                {
                                    Console.WriteLine("Num: {0}//Name:{1}///Number: {2}///Email: {3}//Address {4}// Dentist Name: {5}",x, Patient[x].Name1, Patient[x].Number, Patient[x].Email1,Patient[x].Address1,Patient[x].Dentist1.Name);
                                }
                                Console.WriteLine("1. Select Patient");
                                Console.WriteLine("2. Add Patient");
                                Console.WriteLine("3. Delete Patient");
                                Console.WriteLine("4. Change Patient Details");
                                Console.WriteLine("5. View All Appointments");
                                Console.WriteLine("6. Select Log out");

                                //user choice
                                X = Console.ReadLine();

                                if (X == "1") 
                                {
                                    ViewPatient();
                                }
                                if (X == "2")
                                {
                                    AddPatient();
                                }
                                if (X == "3")
                                {
                                    DeletePatient();
                                }
                                if (X == "4")
                                {
                                    ChangePatDetails();
                                }
                                if (X == "5")
                                {
                                    ViewAllAppointments();
                                }
                                if (X == "6")
                                {
                                    LogIn();
                                }

                            }
                            else 
                            {
                                // if the receptionist is not assined no patients can be a assined to them
                                Console.WriteLine("You are not assined yet please try again later...");
                                Console.ReadLine();
                                user = null;
                                LogIn();
                            }
                        }
                    }
                    LogIn();

                }
                void ViewPatient()
                {
                    Console.Clear();
                    string selected = null;
                    //displays all the available Patients
                    for (int x = 0; x < Patient.Count; x++)
                    {
                        for (int y = 0; y < Dentists.Count; y++)
                        {
                            if (Patient[x].Dentist1 == Dentists[y])
                            {
                                Console.WriteLine("/// ID:{0} ///Name: {1}// Email: {2}// Phone: {3}// Address{4}", x, Patient[x].Name1, Patient[x].Email1, Patient[x].Number, Patient[x].Address1);
                                
                            }
                        }
                    }

                    Console.WriteLine("Select the id of the patient to select:");
                    string chosenpatient = Console.ReadLine();//user choses a patient

                    for (int x = 0; x < Patient.Count; x++)
                    {
                        for (int y = 0; y < Dentists.Count; y++)
                        {
                            if (Patient[x].Dentist1 == Dentists[y])
                            {
                                //sets the selected patients name as selected and then uses the view appointments function
                                selected = Patient[int.Parse(chosenpatient)].Name1;
                                ViewAppointments();
                            }
                        }
                    }

                    void ViewAppointments()
                    {
                        //displays all appointments for the selected patient
                        Console.Clear();
                        for (int x = 0; x < Patient.Count; x++)
                        {
                            if (selected == Patient[x].Name1) 
                            {
                                Console.WriteLine("Appointments for {0}:", selected);
                                for (int r = 0; r < Patient[x].PatientAppointments.Count; r++) 
                                {
                                    Console.WriteLine("ID:{0} /// Appointment for a {1} /// Costs: £{2} // With: {3} // In room {4}", r, Patient[x].PatientAppointments[r].Treatment1, Patient[x].PatientAppointments[r].Price, Patient[x].PatientAppointments[r].dentist.Name, Patient[x].PatientAppointments[r].room.roomid);
                                
                                }
                            }
                        }
                        Console.WriteLine();
                        // lets the user Decide whether they want to make a appointment or cancel an Existing one
                        Console.WriteLine("To make a new appointment type 1");
                        Console.WriteLine("To Cancel An existing appointment type 2");
                        Console.WriteLine("To Go back to the Main menu press enter");
                        string UserChoice = Console.ReadLine();

                        if (UserChoice == "1") 
                        {
                            MakeAppointment();
                        }
                        if (UserChoice == "2") 
                        {
                            Cancel();
                        }
                        ManagePatientMenu();
                    }
                    void MakeAppointment()
                    {
                        //all of the Required variables to make the instance
                        string NewTreatment;
                        double Band1 = 22.70;
                        double Band2 = 62.10;
                        double Band3 = 269.30;
                        double ChosenBand = 0;
                        Dentist AssinedDent = null;
                        Room Room;

                        //user enters the new appointment treatment
                        Console.WriteLine("What is the appointment for:");
                        NewTreatment = Console.ReadLine();
                        

                        //User Selects the price
                        Console.WriteLine();
                        Console.WriteLine("Please select a price:");
                        Console.WriteLine("Band 1 - £22.70 (check-ups, scale and polish etc.)/// Type 3");
                        Console.WriteLine("Band 2 - £62.10 (fillings, repairs etc.)/// Type 2:");
                        Console.WriteLine("Band 3 £269.30 (crowns and other procedures)/// Type 3");

                        string UserInput = Console.ReadLine();
                        if (UserInput == "1") 
                        {
                            ChosenBand = Band1;
                        }
                        if (UserInput == "2") 
                        {
                            ChosenBand = Band2;
                        }
                        if (UserInput == "3") 
                        {
                            ChosenBand = Band3;
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        //displays available Dentists
                        for (int r = 0; r < Dentists.Count; r++)
                        {

                            if (Dentists[r].hasroom == true)
                            {
                                Console.WriteLine("/// ID:{0} ///Username: {1}/// Name: {2} ///", r, Dentists[r].User, Dentists[r].Name);
                                Console.WriteLine();
                            }
                        }

                        
                        //user choses the dentist to be assined to the appointment
                        Console.WriteLine("Select the id of the dentist:");

                        string chosentDentist = Console.ReadLine();


                        //   
                        if (Dentists[int.Parse(chosentDentist)].hasroom == true)
                        {
                            AssinedDent = Dentists[int.Parse(chosentDentist)];

                        }
                        //
                        //displays available rooms
                        for (int r = 0; r < Patient.Count; r++)
                        {
                            for (int x = 0; x < Practices.Count; x++ ) 
                            {
                                if (Practices[x].PracID == Patient[r].pracid)
                                {
                                    for(int y = 0; y < Practices[x].pracRooms.Count; y++) 
                                    {
                                        if (Practices[x].pracRooms[y].assineddent == Patient[r].Dentist1) {

                                            Console.WriteLine("Room: {0} /// Dentist: {1} /// Nurse: {2}", y, Practices[x].pracRooms[y].assineddent.Name, Practices[x].pracRooms[y].assinednur.Name);
                                        
                                        }
                                    }
                                }
                            }
                        }


                        //user choses the dentist to be assined to the appointment
                        Console.WriteLine("Select the id of the room:");

                        string chosentRoom = Console.ReadLine();


                        // sets the room as the chosen room then creates the new instance.
                        for (int r = 0; r < Patient.Count; r++)
                        {
                            for (int x = 0; x < Practices.Count; x++)
                            {
                                if (Practices[x].PracID == Patient[r].pracid)
                                {
                                    for (int y = 0; y < Practices[x].pracRooms.Count; y++)
                                    {
                                        if (Practices[x].pracRooms[y].assineddent == Patient[r].Dentist1)
                                        {
                                            if(int.Parse(chosentRoom) == y) 
                                            {
                                                Room = Practices[x].pracRooms[y];
                                                Patient[r].PatientAppointments.Add(new Appointment(NewTreatment, ChosenBand, AssinedDent, Room));
                                            }
                                        }
                                    }
                                }
                            }
                        }




                    }
                    void Cancel()
                    {
                        //user choses which user to delete
                        Console.WriteLine("Type the ID of the Appointment being Canceled:");
                        string UserInput = Console.ReadLine();//user sets userinput
                        Console.WriteLine("Press enter to confirm:");//confirms the total deletion
                        Console.ReadLine();

                        //removes the user
                        for (int x = 0; x < Patient[x].PatientAppointments.Count; x++) //goes throu the id to look for which one non admin is assosiated with that id.
                        {
                            if (x == int.Parse(UserInput))
                            {
                                Patient[x].PatientAppointments.RemoveAt(int.Parse(UserInput));
                                Console.Clear();
                                ViewAppointments();
                            }
                        }
                    }
                    LogIn();
                }
                void AddPatient()//needs Revisiting
                {
                    Dentist chosen = null;
                    bool Gender = false;
                    int surid = Patient.Count;
                    int x = 0;
                    Console.Clear();

                    //enter the new Patients Details
                    Console.WriteLine("Enter the Name of the new user");
                    string name = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter the number for the new user");
                    string number = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter the e-mail for the new Patient");
                    string Email = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter the address for the new Patient");
                    string address = Console.ReadLine();
                    //chose there Gender
                    Console.WriteLine();
                    Console.WriteLine("1 = Male, 2 = Female");
                    string chosenGen = Console.ReadLine();
                    if (chosenGen == "1") 
                    {
                        //the patient is male
                    }
                    if (chosenGen == "2")
                    {
                        Gender = true; //the patient is female
                    }
                    Console.Clear();

                    //displays available Dentists
                    for (x = 0; x < Dentists.Count; x++)
                    {
                        
                        if (Dentists[x].hasroom == true)
                        {
                            Console.WriteLine("/// ID:{0} ///Username: {1}/// name: {2} ///", x, Dentists[x].User, Dentists[x].Name);
                            Console.WriteLine();
                        }
                    }

                   
                    //user choses the dentist to be assined to the patient
                    Console.WriteLine("Select the id of the Dentist:");

                    string chosentDentist = Console.ReadLine();

                    
                     // if the dentist has a room Create the new Dentist   
                    if (Dentists[int.Parse(chosentDentist)].hasroom == true) 
                    {
                        chosen = Dentists[int.Parse(chosentDentist)];
                        Patient.Add(new Patient(name, int.Parse(number), Email, Gender, true, chosen, surid ,address));
                        Console.Clear();

                    }
                        
                    
                    reclogin();
                }
                void DeletePatient()
                {
                    //user choses which user to delete
                    Console.WriteLine("Type the number of the Patient being deleted:");
                    string UserInput = Console.ReadLine();//user sets userinput
                    Console.WriteLine("Press enter to confirm:");//confirms the total deletion
                    Console.ReadLine();

                    //removes the user
                    for (int x = 0; x < Patient.Count; x++) //goes throu the id to look for which one non admin is assosiated with that id.
                    {
                        if (x == int.Parse(UserInput))
                        {
                            Patient.RemoveAt(x);
                            Console.Clear();
                            ManagePatientMenu();
                        }
                    }
                }
                void ChangePatDetails()
                {
                    //displays all the available Patients
                    Console.Clear();
                    for (int x = 0; x < Patient.Count; x++)
                    {
                        for (int y = 0; y < Dentists.Count; y++)
                        {
                            if (Patient[x].Dentist1 == Dentists[y])
                            {
                                Console.WriteLine("/// ID:{0} ///Name: {1}// Email: {2}// Phone: {3}// Address{4}", x, Patient[x].Name1, Patient[x].Email1, Patient[x].Number,Patient[x].Address1);
                                Console.WriteLine();
                            }
                        }
                    }

                    Console.WriteLine("Select the id of the Patient Details that need to be changed:"); 

                    string chosenpatient = Console.ReadLine();//user choses a patient

                    for (int x = 0; x < Patient.Count; x++)
                    {
                        for (int y = 0; y < Dentists.Count; y++)
                        {
                            if (Patient[x].Dentist1 == Dentists[y])
                            {
                                if(chosenpatient == x.ToString()) 
                                {
                                    //user choses a Detail to Change
                                    Console.WriteLine("Which detail needs to be changed:");
                                    Console.WriteLine("1: Email");
                                    Console.WriteLine("2: Phone Number");
                                    Console.WriteLine("3: Address");
                                    string chosendetail = Console.ReadLine();

                                    if (chosendetail == "1") 
                                    {
                                        //change Email
                                        Console.WriteLine("Enter the new e-mail:");
                                        string NewEmail = Console.ReadLine();
                                        Patient[int.Parse(chosenpatient)].Email1 = NewEmail;
                                        ManagePatientMenu();
                                    }
                                    if (chosendetail == "2") 
                                    {
                                        //Change Phone Number
                                        Console.WriteLine("Enter the new Phone Number:");
                                        string NewPhone = Console.ReadLine();
                                        Patient[int.Parse(chosenpatient)].Number = int.Parse(NewPhone);
                                        ManagePatientMenu();
                                    }
                                    if (chosendetail == "3")
                                    {
                                        //Change Address
                                        Console.WriteLine("Enter the new Adress:");
                                        string Newaddress = Console.ReadLine();
                                        Patient[int.Parse(chosenpatient)].Address1 = (Newaddress);
                                        ManagePatientMenu();
                                    }

                                }   
                            }
                        }
                    }

                }
                void ViewAllAppointments() 
                {
                    //viewing all appointments
                    Console.Clear();
                    Console.WriteLine("All appointments:");
                    for(int y = 0; y < receptionists.Count; y++) 
                    {
                        for (int x = 0; x < Practices.Count; x++)
                        {
                            if (receptionists[y].PracID == Practices[x].PracID) 
                            {
                                if (receptionists[y].User == user )
                                {
                                    for (int r = 0; r < Patient.Count; r++)
                                    {
                                        
                                        Console.WriteLine("ID:{0}// Patient: {1}//  /// Appointment for a {2} /// Costs: £{3} // With: {4} // In room {5}", r, Patient[r].Name1, Patient[r].PatientAppointments[r].Treatment1, Patient[x].PatientAppointments[r].Price, Patient[r].PatientAppointments[r].dentist.Name, Patient[r].PatientAppointments[r].room.roomid);

                                    }

                                }

                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press enter to go back");
                    Console.ReadLine();
                    ManagePatientMenu();
                }
                ManagePatientMenu();
            }
            LogIn();
        }
    }
}
