namespace DnD_Between.wpf
{
    public class Class
    {
        public int ID { get; private set; }
        public string name { get; private set; }


        public Class(int id, string name)
        {
            this.ID = id;
            this.name = name;
        }

    }
}
