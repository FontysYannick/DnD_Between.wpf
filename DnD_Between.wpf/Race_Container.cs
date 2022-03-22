using DAL_DnD_Between;
using System.Collections.Generic;

namespace DnD_Between.wpf
{
    public class Race_Container
    {
        Race_Context _Context = new Race_Context();

        public List<Race> Getall()
        {
            List<Race> list = new List<Race>();

            foreach (var item in _Context.Getall())
            {
                list.Add(new Race(item.ID, item.name));
            }

            return list;
        }
    }
}
