using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Diagnostics;
using System.Net.Security;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ConsoleApp105
{
    internal class Menu : Person
    {
        private int _selectedIndex;
        private string[] _options;
        private string _title;
        private string[] _optionclient;
        private string [] _optioncoach;
        string clientpath = "C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients";
        string coachpath = "C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach";
        public Menu(string[] options, string title, string[] optionclient, string[] optioncoach)
        {
            _options = options;
            _title = title;
            _selectedIndex = 0;
            _optionclient = optionclient;
            _optioncoach = optioncoach;
        }
        public void DisplayOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{_title}\n");
            Console.ResetColor();
            for (int i = 0; i < _options.Length; i++)
            {
                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine($"******{_options[i]}******");
            }
            Console.ResetColor();
        }
        public void DisplayOptionClient()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < _optionclient.Length; i++)
            {
                Console.WriteLine($"******{_optionclient[i]}******");
            }
            Console.ResetColor();
        }
        public void DisplayOptionCoach()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < _optioncoach.Length; i++)
            {
                Console.WriteLine($"******{_optioncoach[i]}******");
            }
            Console.ResetColor();
        }
        public void Choose()
        {
            Console.WriteLine("what type of user you like to register?\r\nchoose 0 to register new client/\r\nchoose 1 to register new coach/\r\nchoose 2 to see the credits/\r\nchoose 3 to exit.");
            Console.ResetColor();
            int answer = int.Parse(Console.ReadLine());
            if (answer == 0)
            {
                DisplayOptionClient();
                Console.WriteLine("choose what you want to do:\r\n 0 for add new client to gym\r\n 1 for edit client in gym\r\n 2 for delete client in gym\r\n 3 for see list all client in gym\r\n 4 for report attendance \r\n 5 for see all attendances \r\n 6 for back to the menu");
                string chooseans = Console.ReadLine();
                if (chooseans == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("new customer:  enter your details:");
                    Console.ResetColor();
                    Client client1 = new Client();
                    client1.Set();
                    Return();
                }
                else if (chooseans == "1")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("edit client:");
                    Client client2 = new Client();
                    client2.EditClient();
                    Return();
                    // פונקציה לעריכה לקוח
                }
                else if (chooseans == "2")
                {
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("delete client:");
                    Console.ResetColor();
                    Client.DeleteClient();
                    Return();
                    // פונקציה למחיקת לקוח
                }
                else if (chooseans == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("list all client:");
                    Console.ResetColor();
                    GetAllList listclient = new GetAllList();
                    listclient.GetAllClient(clientpath);
                    Return();
                }
                else if (chooseans == "4")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("report attendance");
                    Console.ResetColor();
                    Client.AttendancesClient();
                    Return();
                }
                else if (chooseans == "5")
                {
                    Console.ForegroundColor=ConsoleColor.DarkGreen;
                    Console.WriteLine("see all attendance");
                    GetAllList listattendance=new GetAllList();
                    listattendance.GetAllAttendances(clientpath);
                    Return() ;
                }
                else if (chooseans == "6")
                {
                    Console.WriteLine("back to the menu:");
                    DisplayOptions();
                    Choose();
                }
                else
                {
                    Console.WriteLine("error enter 0/1/2/3/4");
                    Choose();
                }
            }
            else if (answer == 1)
            {
                DisplayOptionCoach();
                Console.WriteLine("choose what you want to do:\r\n 0 for add new coach to gym\r\n 1 for edit coach in gym\r\n 2 for delete coach in gym\r\n 3 for see list all coach in gym\r\n 4 for back to the menu");
                string chooseanscoach= Console.ReadLine();
                if (chooseanscoach == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("new coach: enter your details:");
                    Console.ResetColor();
                    Coach coach1 = new Coach();
                    coach1.Set();
                    Return();
                }
                else if(chooseanscoach == "1")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("edit coach");
                    Console.ResetColor();
                    Coach coach2 = new Coach();
                    coach2.EditCoach();
                    Console.WriteLine("you want edit more? 0 for yes 1 for no");
                    string anscoachexit = Console.ReadLine();
                    if (anscoachexit == "0")
                    {
                        coach2.EditCoach();
                        Return();
                    }
                    else if (anscoachexit == "1")
                    {
                        Return();
                    }
                }
                else if (chooseanscoach == "2")
                {
                    Console.ForegroundColor= ConsoleColor.DarkCyan;
                    Console.WriteLine("delete coach");
                    Console.ResetColor();
                    Coach.DeleteCoach();
                    Return();
                }
                else if (chooseanscoach == "3")
                {
                    Console.ForegroundColor=ConsoleColor.Red;
                    Console.WriteLine("list all coach");
                    Console.ResetColor();
                    GetAllList listcoach=new GetAllList();
                    listcoach.GetAllCoach(coachpath);
                    Return();
                    // פונקציה של רשימה 
                }
                else if (chooseanscoach == "4")
                {
                    Console.WriteLine("back to the menu");
                    DisplayOptions();
                    Choose();
                }
                else
                {
                    Console.WriteLine("error enter 0/1/2/3/4");
                    Choose();
                }
            }
            else if (answer == 2)
            {
                Credits();
                Return();
            }
            else if (answer == 3)
            {
                Exit();
            }
            else
            {
                Console.WriteLine("error : choese 0/1/2/3 ");
                Choose();
            }
        }
        public override void Set()
        {
            base.Set();
        }
        public void Credits()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<< Eden gym version 1.01 >>>>>>>>>>>>>>>>>>>>>>> \r\nThis mini project is an assignment for SELA\r\nThe project is written by one of the students\r\nShout out to the instructor ‘harel’\r\n Project writer: Eden Golan!\r\n the number of the course is 10.91. \r\n <<<<<<<<<<<<<<<<<<<<<< Eden gym version 1.01 >>>>>>>>>>>>>>>>>>>>>>> \r\n");
            Console.ResetColor();
        }
        public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("see you next time bye !");
            Console.ResetColor();
            System.Environment.Exit(0);
        }
        public void Return()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("if you want return menu enter 1, if you want exit enter 2");
            string ansreturn=Console.ReadLine();
            if (ansreturn == "1")
            {
                DisplayOptions();
                Choose();
            }
            else if (ansreturn == "2")
            {
                Exit();
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
