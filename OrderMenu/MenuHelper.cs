using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderMenu
{
    class MenuHelper
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

        /// <summary>
        /// 删除一道菜
        /// </summary>
        /// <param name="id">菜的id</param>
        /// <returns>删除成功与否</returns>
        public static bool Delete(int id)
        {
            try
            {
                var query = from m in dc.Menu
                            where m.ID == id
                            select m;
                dc.Menu.DeleteOnSubmit(query.SingleOrDefault());
                dc.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 查询需要的菜
        /// </summary>
        /// <param name="id">需要查找的菜的id，不填则为查找全部</param>
        /// <returns>包含menu的泛型</returns>
        public static List<Menu> Select(int id = -1)
        {
            try
            {
                if (id == -1)
                {
                    var query = from m in dc.Menu
                                select m;
                    return query.ToList();
                }
                else
                {
                    var query = from m in dc.Menu
                                where m.ID == id
                                select m;
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 修改菜
        /// </summary>
        /// <param name="m">修改后的菜的对象</param>
        /// <returns>修改成功与否</returns>
        public static bool Update(Menu m)
        {
            try
            {
                var query = (from n in dc.Menu
                             where n.ID == m.ID
                             select n).SingleOrDefault();
                query = m;
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
