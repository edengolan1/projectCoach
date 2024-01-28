using System.Text.Json;
using System.Text.RegularExpressions;

namespace ConsoleApp105
{
    internal class Client : Person
    {
        private string? _height;
        private string? _weight;
        private string? _bodyfat;
        private string? _token;
        private string? _fileName;
        private string? _filePath;
        private bool _isActive = true;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public string Height
        {
            get { return _height!; }
            set { _height = value; }
        }
        public string Weight
        {
            get { return _weight!; }
            set { _weight = value; }
        }
        public string BodyFat
        {
            get { return _bodyfat!; }
            set { _bodyfat = value; }
        }
        public string GetHeight()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("9.HEIGHT: Please enter height:");
                string height = Console.ReadLine();
                string pattern = @"^-?\d{1,3}(\.\d+)?$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(height!))
                {
                    _height = height;
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error:");
                }
            }
            return _height!;
        }
        public string GetWeight()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("10.WEIGHT: Please enter weight:");
                string weight = Console.ReadLine();
                string pattern = @"^-?\d{1,3}(\.\d+)?$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(weight!))
                {
                    _weight = weight.ToLower();
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: you enter wrong weight, please try again!");
                }
            }
            return _weight!;
        }
        public string GetBodyFat()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("11.BODYFAT: please enter bodyfat:");
                string bodyfat = Console.ReadLine();
                string pattern = @"^-?\d+(\.\d+)?%?$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(bodyfat!))
                {
                    _bodyfat = bodyfat.ToLower();
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: input number of body fat!");
                }
            }
            return _bodyfat!;
        }
        public bool IsActiveClient()
        {
            return _isActive = false;
        }
        public override void Set()
        {
            base.Set();
            GetHeight();
            GetWeight();
            GetBodyFat();
            SaveClient();
            ProgramClient();
            SubscriptionClient();
            string path = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}";
            string filename9 = $"Attendances.json";
            string fullpath9 = Path.Combine(path, filename9);
            File.WriteAllText(fullpath9, TaxId + " " + "Attendances client : \n");
        }
        public void SaveClient()
        {
            string path = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}";
            if (!Directory.Exists($"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}"))
            {
                Directory.CreateDirectory($"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}");
            }
            string filename = $"Info.json";
            string fullpath = Path.Combine(path, filename);
            string clients = JsonSerializer.Serialize<Client>(this);
            File.WriteAllText(fullpath, clients);
            Console.WriteLine();
        }
        public void ProgramClient()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("welcom to the training program!!!");
            Console.ResetColor();
            Console.WriteLine("please choose training program:\r\n 1--> for legs training: *SQUATS (20 set).\r\n 2--> for hands training: *SPORTS WEIGHTLIFTING(35 set). \r\n 3--> for belly training: *CRUNCHES(25 set).\r\n 4--> for back training: *HAND-WENDING(30 set)");       // להוסיף ולהרחיב את התוכנית אימון לפרט
            string choose = Console.ReadLine();
            string training = "";
            switch (choose)
            {
                case "1":
                    Console.WriteLine("legs training: SQUATS (20 set)");
                    training = TaxId + " Client Program:" + "legs training: SQUATS (20 set)";
                    string path2 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}";
                    string filename2 = $"Programclient.json";
                    string fullpath2 = Path.Combine(path2, filename2);
                    string coach = JsonSerializer.Serialize(training);
                    File.WriteAllText(fullpath2, coach);
                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine("hands training: SPORTS WEIGHTLIFTING(35 set)");
                    training = TaxId + " Client Program:" + "hands training: SPORTS WEIGHTLIFTING(35 set)";
                    string path3 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}";
                    string filename3 = $"Programclient.json";
                    string fullpath3 = Path.Combine(path3, filename3);
                    string coach3 = JsonSerializer.Serialize(training);
                    File.WriteAllText(fullpath3, coach3);
                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine("belly training: CRUNCHES(25 set)");
                    training = TaxId + " Client Program:" + "back training: HAND-WENDING(30 set)";
                    string path4 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}";
                    string filename4 = $"Programclient.json";
                    string fullpath4 = Path.Combine(path4, filename4);
                    string coach4 = JsonSerializer.Serialize(training);
                    File.WriteAllText(fullpath4, coach4);
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine("back training: HAND-WENDING(30 set)");
                    training = TaxId + " Client Program:" + "back training: HAND-WENDING(30 set)";
                    string path5 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}";
                    string filename5 = $"Programclient.json";
                    string fullpath5 = Path.Combine(path5, filename5);
                    string coach5 = JsonSerializer.Serialize(training);
                    File.WriteAllText(fullpath5, coach5);
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("error enter 1/2/3/4!");
                    ProgramClient();
                    break;
            }
        }
        public void SubscriptionClient()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("choose the subscription you want:\r\n");
            Console.ResetColor();
            Console.WriteLine("0--> for Monthly subscription for the price of 249 NIS. \r\n 1--> for Annual subscription at the price of 2499 NIS.");
            Console.ResetColor();
            string _price = "";
            int price = int.Parse(Console.ReadLine());
            if (price == 0)
            {
                Console.WriteLine(TaxId + ": " + "Monthly subscription for the price of 249 NIS");
                _price = TaxId + ": " + "Monthly subscription for the price of 249 NIS";

            }
            else if (price == 1)
            {
                Console.WriteLine(TaxId + ": " + "Annual subscription at the price of 2499 NIS");
                _price = TaxId + ": " + "Annual subscription at the price of 2499 NIS";
            }
            else
            {
                Console.WriteLine("error not found");
                SubscriptionClient();
            }
            string path2 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{TaxId}";
            string filename2 = $"Subscription.json";
            string fullpath2 = Path.Combine(path2, filename2);
            string coach = JsonSerializer.Serialize(_price);
            File.WriteAllText(fullpath2, coach);
            Console.WriteLine();
        }
        public override string ToString()
        {
            return TaxId + " " + FirstName + " " + LastName;
        }
        public void EditClient()
        {
            Console.WriteLine("Enter tax id you want to edit:");
            string taxidedit = Console.ReadLine();
            string pathedit = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{taxidedit}";
            string filenameedit = $"Info.json";
            string fullpathedit = Path.Combine(pathedit, filenameedit);
            if (!File.Exists(fullpathedit))
            {
                Console.WriteLine("client not exist please enter again!");
            }
            Client clienToEdit = JsonSerializer.Deserialize<Client>(File.ReadAllText(fullpathedit));
            Console.WriteLine("choose what to edit (1-10):");
            Console.WriteLine("1.First name\n 2. Last name \n 3. Gender\n 4. Phone\n 5. Birthdate\n 6. Address\n 7. Email\n 8. Height\n 9. weight\n 10. BodyFat");
            string ansedit = Console.ReadLine();
            switch (ansedit)
            {
                case "1":
                    clienToEdit!._firstName = GetFirstName();
                    break;
                case "2":
                    clienToEdit!._lastName = GetLastName();
                    break;
                case "3":
                    clienToEdit!._gender = GetGender();
                    break;
                case "4":
                    clienToEdit!._phone = GetPhone();
                    break;
                case "5":
                    clienToEdit!._birthdate = GetBirthdate();
                    break;
                case "6":
                    clienToEdit!._address = GetAddress();
                    break;
                case "7":
                    clienToEdit!._email = GetEmail();
                    break;
                case "8":
                    clienToEdit!._height = GetHeight();
                    break;
                case "9":
                    clienToEdit!._weight = GetWeight();
                    break;
                case "10":
                    clienToEdit!._bodyfat = GetBodyFat();
                    break;
                default:
                    Console.WriteLine("choose 1-10!");
                    EditClient();
                    break;
            }
            clienToEdit!.SaveClient();
            Console.WriteLine(clienToEdit);
        }
        public static void DeleteClient()
        {
            Console.WriteLine("Enter tax id you want to delete:");
            string yourtaxid = Console.ReadLine();
            string path2 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{yourtaxid}";
            string filename2 = $"Info.json";
            string fullpath2 = Path.Combine(path2, filename2);
            if (File.Exists(fullpath2))
            {
                Client clienToDelete = JsonSerializer.Deserialize<Client>(File.ReadAllText(fullpath2));
                clienToDelete!.IsActive = false;
                clienToDelete.SaveClient();
                Console.WriteLine(clienToDelete);
                Console.WriteLine("client delete is successful");
            }
            else
            {
                Console.WriteLine("error not find id");
                DeleteClient();
            }
        }
        public static void AttendancesClient()
        {
            Console.WriteLine("Enter tax id:");
            string yourtaxidAttendances = Console.ReadLine();
            string path8 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsClients\\{yourtaxidAttendances}";
            string filename8 = $"Attendances.json";
            string fullpath8 = Path.Combine(path8, filename8);
            if (!File.Exists(fullpath8))
            {
                Console.WriteLine("the client not exist please enter tax id");
            }
            File.AppendAllText(fullpath8, " " + yourtaxidAttendances + ": " + DateTime.Now.ToString() + " ");
            Console.WriteLine("the Attendances to succeed!");

        }
    }
}
