using System.Text.Json;
using System.Text.RegularExpressions;

namespace ConsoleApp105
{
    internal class Coach : Person
    {
        protected string? _bankdetails;
        protected string? _profession;
        private bool _isActiveCoach = true;
        public bool IsActiveCoach
        {
            get { return _isActiveCoach; }
            set { _isActiveCoach = value; }
        }
        public string BankDetails
        {
            get { return _bankdetails!; }
            set { _bankdetails = value; }
        }
        public string Profession
        {
            get { return _profession!; }
            set { _profession = value; }
        }
        public string GetBankDetails()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("9.BANK ACOUNT: Please enter your bank account details:");
                string bankdetails = Console.ReadLine();
                string pattern = @"^[0-9]{6,}$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(bankdetails!))
                {
                    _bankdetails = bankdetails;
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("wrong name of bank, please try again.\"\r\n\"wrong branch, please try again.\"\r\n\"wrong account number, please try again!");
                }
            }
            return _bankdetails!;
        }
        public string GetProfession()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("10. PROFESSION: “Please enter profession!");
                string profession = Console.ReadLine();
                string pattern = @"^[A-Za-z\s]+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(profession!))
                {
                    _profession = profession;
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("wrong profession, please try again!");
                }
            }
            return _profession!;
        }
        public override void Set()
        {
            base.Set();
            GetBankDetails();
            GetProfession();
            SaveCoach();
            ProgramCoach();
        }
        public void ProgramCoach()
        {
            // תוכנית מאמן 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("whice trainer program will you train: legs/belly/hands/back? choose one");
            Console.ResetColor();
            string choosecoach = Console.ReadLine();
            string coachprogram = "";
            switch (choosecoach)
            {
                case "legs":
                    Console.WriteLine(TaxId + " " + "legs training");
                    coachprogram = TaxId + " coach Program:" + "legs training";
                    string path6 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{TaxId}";
                    string filename6 = $"ProgramCoach.json";
                    string fullpath6 = Path.Combine(path6, filename6);
                    string coach6 = JsonSerializer.Serialize(coachprogram);
                    File.WriteAllText(fullpath6, coach6);
                    Console.WriteLine();
                    break;
                case "belly":
                    Console.WriteLine(TaxId + " " + "belly training");
                    coachprogram = TaxId + " coach Program:" + "belly training";
                    string path7 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{TaxId}";
                    string filename7 = $"ProgramCoach.json";
                    string fullpath7 = Path.Combine(path7, filename7);
                    string coach7 = JsonSerializer.Serialize(coachprogram);
                    File.WriteAllText(fullpath7, coach7);
                    Console.WriteLine();
                    break;
                case "hands":
                    Console.WriteLine(TaxId + " " + "hands training");
                    coachprogram = TaxId + " coach Program:" + "hands training";
                    string path8 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{TaxId}";
                    string filename8 = $"ProgramCoach.json";
                    string fullpath8 = Path.Combine(path8, filename8);
                    string coach8 = JsonSerializer.Serialize(coachprogram);
                    File.WriteAllText(fullpath8, coach8);
                    Console.WriteLine();
                    break;
                case "back":
                    Console.WriteLine(TaxId + " " + "back training");
                    coachprogram = TaxId + " coach Program:" + "back training";
                    string path9 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{TaxId}";
                    string filename9 = $"ProgramCoach.json";
                    string fullpath9 = Path.Combine(path9, filename9);
                    string coach9 = JsonSerializer.Serialize(coachprogram);
                    File.WriteAllText(fullpath9, coach9);
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("error enter legs/belly/hands/back!");
                    ProgramCoach();
                    break;
            }
        }
        public void SaveCoach()
        {
            string path1 = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{TaxId}";
            if (!Directory.Exists($"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{TaxId}"))
            {
                Directory.CreateDirectory($"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{TaxId}");
            }
            string filename1 = $"InfoCoach.json";
            string fullpath1 = Path.Combine(path1, filename1);
            string coach1 = JsonSerializer.Serialize<Coach>(this);
            File.WriteAllText(fullpath1, coach1);
            Console.WriteLine();
        }
        public void EditCoach()
        {
            Console.WriteLine("enter tax id:");
            string edittaxidcoach = Console.ReadLine();
            string editpathcoach = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{edittaxidcoach}";
            string editfilenamecoach = $"InfoCoach.json";
            string editfullpathcoach = Path.Combine(editpathcoach, editfilenamecoach);
            if (!File.Exists(editfullpathcoach))
            {
                Console.WriteLine("coach not exist please enter again!");
            }
            Coach coachToEdit = JsonSerializer.Deserialize<Coach>(File.ReadAllText(editfullpathcoach));
            Console.WriteLine("choose what to edit (1-9):");
            Console.WriteLine(" 1. First name\n 2. Last name \n 3. Gender\n 4. Phone\n 5. Birthdate\n 6. Address\n 7. Email\n 8. Bankdetails\n 9. Profession\n");
            string anscoachedit = Console.ReadLine();
            switch (anscoachedit)
            {
                case "1":
                    coachToEdit!._firstName = GetFirstName();
                    break;
                case "2":
                    coachToEdit!._lastName = GetLastName();
                    break;
                case "3":
                    coachToEdit!._gender = GetGender();
                    break;
                case "4":
                    coachToEdit!._phone = GetPhone();
                    break;
                case "5":
                    coachToEdit!._birthdate = GetBirthdate();
                    break;
                case "6":
                    coachToEdit!._address = GetAddress();
                    break;
                case "7":
                    coachToEdit!._email = GetEmail();
                    break;
                case "8":
                    coachToEdit!._bankdetails = GetBankDetails();
                    break;
                case "9":
                    coachToEdit!._profession = GetProfession();
                    break;
                default:
                    Console.WriteLine("choose 1-9!");
                    EditCoach();
                    break;
            }
            Console.WriteLine("coach edit is successful");
            coachToEdit.SaveCoach();
            Console.WriteLine(coachToEdit);
        }
        public static void DeleteCoach()
        {
            Console.WriteLine("enter tax id:");
            string deletetaxidcoach = Console.ReadLine();
            string pathcoach = $"C:\\Users\\eden9\\source\\repos\\ConsoleApp105\\DetailsCoach\\{deletetaxidcoach}";
            string filenamecoach = $"InfoCoach.json";
            string fullpathcoach = Path.Combine(pathcoach, filenamecoach);
            if (File.Exists(fullpathcoach))
            {
                Coach coachToDelete = JsonSerializer.Deserialize<Coach>(File.ReadAllText(fullpathcoach));
                coachToDelete.IsActiveCoach = false;
                coachToDelete.SaveCoach();
                Console.WriteLine(coachToDelete);
                Console.WriteLine("coach delete is successful");
            }
            else
            {
                Console.WriteLine("error not find id");
                DeleteCoach();
            }
        }
        public override string ToString()
        {
            return TaxId + " " + FirstName + " " + LastName;
        }
    }
}
