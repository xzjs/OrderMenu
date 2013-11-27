using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderMenu
{
    class Menu
    {
        static DataClassesDataContext dc = new DataClassesDataContext();

        /// <summary>
        /// 插入一道菜
        /// </summary>
        /// <param name="m">菜的对象</param>
        /// <returns>插入与否</returns>
        public static bool Add(Menu m)
        {
            try
            {
                dc.Menu.InsertOnSubmit(m);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                var query = from m in dc.Menu
                            where m.ID == id
                            select m;

            }
        }
    }
}
