namespace DnD_Between.wpf
{
    public class Race
    {
        public int ID { get; private set; }
        public string name { get; private set; }


        public Race(int id, string name)
        {
            this.ID = id;
            this.name = name;
        }

    }
}
