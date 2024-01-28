// See https://aka.ms/new-console-template for more information
using ConsoleApp105;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        string[] options = new string[4] { "new clients", "new coach", "credits", "exit" };
        string title = "\r\n                 _                                 _                                    \r\n                | |                               | |                                   \r\n__      __  ___ | |  ___   ___   _ __ ___    ___  | |_   ___     __ _  _   _  _ __ ___  \r\n\\ \\ /\\ / / / _ \\| | / __| / _ \\ | '_ ` _ \\  / _ \\ | __| / _ \\   / _` || | | || '_ ` _ \\ \r\n \\ V  V / |  __/| || (__ | (_) || | | | | ||  __/ | |_ | (_) | | (_| || |_| || | | | | |\r\n  \\_/\\_/   \\___||_| \\___| \\___/ |_| |_| |_| \\___|  \\__| \\___/   \\__, | \\__, ||_| |_| |_|\r\n                                                                 __/ |  __/ |           \r\n                                                                |___/  |___/            \r\nEDEN GYM->>> welcom to our gym membership!";
        string[] optionclients = new string[7] { "add client", "edit client", "delete client", "list all client", "report attendance", "See all attendance", "return" };
        string[] optioncoach = new string[5] { "add coach", "edit coach", "delete coach", "list all coach", "return" };
        Menu mainmenu = new Menu(options, title, optionclients, optioncoach);
        mainmenu.DisplayOptions();
        mainmenu.Choose();
    }
}

