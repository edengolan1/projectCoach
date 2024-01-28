using Newtonsoft.Json;

namespace ConsoleApp105
{
    internal class GetAllList : Person
    {
        private List<Client> _clients = new List<Client>();
        private List<Coach> _coach = new List<Coach>();
        private List<string> listAttendance = new List<string>();
        public void GetAllClient(string path)
        {
            foreach (var dir in Directory.GetDirectories(path))
            {

                GetAllClient(dir);
                foreach (var file in Directory.GetFiles(dir))
                {
                    using (var reader = new StreamReader(file))
                    {

                        string clientt = reader.ReadToEnd();
                        if (clientt.Contains("TaxId"))
                        {
                            Client client = JsonConvert.DeserializeObject<Client>(clientt);
                            Console.WriteLine(client);
                            _clients.Add(client!);
                        }
                    }
                }
            }
        }
        public void GetAllCoach(string path)
        {
            foreach (var dir in Directory.GetDirectories(path))
            {
                GetAllCoach(dir);
                foreach (var file in Directory.GetFiles(dir))
                {
                    using (var reader = new StreamReader(file))
                    {
                        string coachh = reader.ReadToEnd();
                        if (coachh.Contains("TaxId"))
                        {
                            Coach coach1 = JsonConvert.DeserializeObject<Coach>(coachh);
                            Console.WriteLine(coach1);
                            _coach.Add(coach1!);
                        }
                    }
                }
            }
        }
        public void GetAllAttendances(string path)
        {
            foreach (var dir in Directory.GetDirectories(path))
            {
                GetAllAttendances(dir);
                foreach (var file in Directory.GetFiles(dir))
                {
                    if (file.Contains("Attendances"))
                    {
                        string clientAttendances = File.ReadAllText(file);
                        Console.WriteLine(clientAttendances + "\n");
                        listAttendance.Add(clientAttendances);
                    }
                }
            }
        }
    }
}
