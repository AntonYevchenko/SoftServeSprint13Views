namespace ViewTask.Models
{
    public class Supermarket
    {
        public string Name { get; private set; }
        public string URL { get; private set; }

        public Supermarket(string name, string url)
        {
            Name = name;
            URL = url;
        }
    }
}
