using System.Text.RegularExpressions;

namespace ConsoleApp105
{
    abstract class Person
    {
        protected string? _taxId;
        protected string? _firstName;
        protected string? _lastName;
        protected string? _gender;
        protected string? _address;
        protected string? _birthdate;
        protected string? _phone;
        protected string? _email;
        public string TaxId
        {
            get { return _taxId!; }
            set { _taxId = value; }
        }
        public string FirstName
        {
            get { return _firstName!; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName!; }
            set { _lastName = value; }
        }
        public string Gender
        {
            get { return _gender!; }
            set { _gender = value; }
        }
        public string Phone
        {
            get { return _phone!; }
            set { _phone = value; }
        }
        public string Birthdate
        {
            get { return _birthdate!; }
            set { _birthdate = value; }
        }
        public string Address
        {
            get { return _address!; }
            set { _address = value; }
        }
        public string Email
        {
            get { return _email!; }
            set { _email = value; }
        }
        public string GetTaxId()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("1. ID NUMBER: please enter ID number(9 digits)");
                string taxid = Console.ReadLine();
                string pattern = @"^\d{9}$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(taxid!))
                {
                    _taxId = taxid;
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: you enter wrong ID number, please try again!\r\n dont forget to put 9 digits and use only numbers!");
                }
            }
            return _taxId!;
        }
        public string GetFirstName()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("2. FIRST NAME: please enter first name:");
                string firstName = Console.ReadLine();
                string pattern = @"^[A-Za-z]+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(firstName!))
                {
                    _firstName = firstName;
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: You enter wrong Name, please try again!”\r\n“Don't forget to put more than 0 characters!");
                }
            }
            return _firstName!;
        }
        public string GetLastName()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("3. LAST NAME: please enter last name:");
                string lastName = Console.ReadLine();
                string pattern = @"^[A-Za-z]+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(lastName!))
                {
                    _lastName = lastName;
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: You enter wrong Last Name, please try again!” \r\n“Don't forget to put more than 0 characters!");
                }
            }
            return _lastName!;
        }
        public string GetGender()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("4. GENDER: please enter gender (f/m/o)");
                string gender = Console.ReadLine();
                string pattern = @"^[FfMmOo]$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(gender!))
                {
                    _gender = gender.ToLower();
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("errot: You enter unknown character for gender, please try again!”\r\n“remember you can use only this options: f/m/o!");
                }
            }
            return _gender!;
        }
        public string GetPhone()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("5.PHONE: please enter mobile phone number:");
                string phone = Console.ReadLine();
                string pattern = @"^\d{10}$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(phone!))
                {
                    _phone = phone!.ToLower();
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: You enter wrong phone, please try again!”\r\n“don't forget to use only numbers and start with 0!");
                }
            }
            return _phone!;
        }
        public string GetBirthdate()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("6.DATA OF BIRTH: Please enter date of birth (day-month-full year):");
                string birthdate = Console.ReadLine();
                string pattern = @"^(0[1-9]|1[0-9]|2[0-9]|3[01])-(0[1-9]|1[012])-(19|20)\d{2}$";
                // string pattern = @"^\d{4}-\d{2}-\d{2}$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(birthdate!))
                {
                    _birthdate = birthdate.ToLower();
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: input birthdata! please enter (day-month-full year)!");
                }
            }
            return _birthdate!;
        }
        public string GetAddress()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("7.ADDRESS: Please enter Address:");
                string address = Console.ReadLine();
                string pattern = @"^[a-zA-Z0-9\s\.,'-]+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(address!))
                {
                    _address = address.ToLower();
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: input address!");
                }
            }
            return _address!;
        }
        public string GetEmail()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine("8.EMAIL: Please enter email address:");
                string email = Console.ReadLine();
                string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(email!))
                {
                    _email = email!.ToLower();
                    inputValid = true;
                }
                else
                {
                    Console.WriteLine("error: You enter wrong email, please try again!”\r\n“don't forget to use @ .\"\r\n");
                }
            }
            return _email!;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public virtual void Set()
        {
            GetTaxId();
            GetFirstName();
            GetLastName();
            GetGender();
            GetPhone();
            GetEmail();
            GetBirthdate();
            GetAddress();
        }
    }
}