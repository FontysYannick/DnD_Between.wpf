using DAL_DnD_Between;
using System.Collections.Generic;


namespace DnD_Between.wpf
{
    public class Class_Container
    {
        Class_Context _Context = new Class_Context();

        public List<Class> Getall()
        {
            List<Class> list = new List<Class>();

            foreach (var item in _Context.Getall())
            {
                list.Add(new Class(item.ID, item.name));
            }

            return list;
        }
    }
}
