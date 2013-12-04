using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderMenu
{
    class BasicOperation<T>
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="m">对象</param>
        /// <returns>插入与否</returns>
        public bool Add(T t)
        {
            try
            {
                switch (t.GetType().ToString())
                {
                    case "OrderMenu.Worker":
                        dc.Worker.InsertOnSubmit(t as Worker);
                        break;
                    case "OrderMenu.Menu":
                        dc.Menu.InsertOnSubmit(t as Menu);
                        break;
                    case "OrderMenu.WorkerMenu":
                        dc.WorkerMenu.InsertOnSubmit(t as WorkerMenu);
                        break;
                    case "OrderMenu.DeskMenu":
                        dc.DeskMenu.InsertOnSubmit(t as DeskMenu);
                        break;
                    case "OrderMenu.Room":
                        dc.Room.InsertOnSubmit(t as Room);
                        break;
                    case "OrderMenu.Desk":
                        dc.Desk.InsertOnSubmit(t as Desk);
                        break;
                    case "OrderMenu.OrderDesk":
                        dc.OrderDesk.InsertOnSubmit(t as OrderDesk);
                        break;
                    default:
                        return false;
                }
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t">删除的对象</param>
        /// <returns></returns>
        public bool Delete(T t)
        {
            try
            {
                switch (t.GetType().ToString())
                {
                    case "OrderMenu.Worker":
                        Worker w = t as Worker;
                        var query1 = from m in dc.Worker
                                     where m.ID == w.ID
                                     select m;
                        dc.Worker.DeleteOnSubmit(query1.SingleOrDefault());
                        break;
                    case "OrderMenu.Menu":
                        Menu menu = t as Menu;
                        var query2 = from n in dc.Menu
                                     where n.ID == menu.ID
                                     select n;
                        dc.Menu.DeleteOnSubmit(query2.SingleOrDefault());
                        break;
                    case "OrderMenu.WorkerMenu":
                        WorkerMenu wm = t as WorkerMenu;
                        var query3 = from n in dc.WorkerMenu
                                     where n.ID == wm.ID
                                     select n;
                        dc.WorkerMenu.DeleteOnSubmit(query3.SingleOrDefault());
                        break;
                    case "OrderMenu.DeskMenu":
                        DeskMenu dm = t as DeskMenu;
                        var query4 = from n in dc.DeskMenu
                                     where n.ID == dm.ID
                                     select n;
                        dc.DeskMenu.DeleteOnSubmit(query4.SingleOrDefault());
                        break;
                    case "OrderMenu.Room":
                        Room r = t as Room;
                        var query5 = from n in dc.Room
                                     where n.ID == r.ID
                                     select n;
                        dc.Room.DeleteOnSubmit(query5.SingleOrDefault());
                        break;
                    case "OrderMenu.Desk":
                        Desk d = t as Desk;
                        var query6 = from n in dc.Desk
                                     where n.ID == d.ID
                                     select n;
                        dc.Desk.DeleteOnSubmit(query6.SingleOrDefault());
                        break;
                    case "OrderMenu.OrderDesk":
                        OrderDesk od = t as OrderDesk;
                        var query7 = from n in dc.OrderDesk
                                     where n.ID == od.ID
                                     select n;
                        dc.OrderDesk.DeleteOnSubmit(query7.SingleOrDefault());
                        break;
                    default:
                        return false;
                }
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="t">查找的对象，若id为0则查所有，否则只查id所指定的那一条</param>
        /// <returns></returns>
        public List<T> Select(T t)
        {
            try
            {
                List<T> result = default(List<T>);
                switch (t.GetType().ToString())
                {
                    case "OrderMenu.Worker":
                        Worker w = t as Worker;
                        if (w.ID == 0)
                        {
                            var query = from m in dc.Worker
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        else
                        {
                            var query = from m in dc.Worker
                                        where m.ID == w.ID
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        break;
                    case "OrderMenu.Menu":
                        Menu menu = t as Menu;
                        if (menu.ID == 0)
                        {
                            var query = from m in dc.Menu
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        else
                        {
                            var query = from m in dc.Menu
                                        where m.ID == menu.ID
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        break;
                    case "OrderMenu.WorkerMenu":
                        WorkerMenu wm = t as WorkerMenu;
                        if (wm.ID == 0)
                        {
                            var query = from m in dc.WorkerMenu
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        else
                        {
                            var query = from m in dc.DeskMenu
                                        where m.ID == wm.ID
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        break;
                    case "OrderMenu.DeskMenu":
                        DeskMenu dm = t as DeskMenu;
                        if (dm.ID == 0)
                        {
                            var query = from m in dc.DeskMenu
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        else
                        {
                            var query = from m in dc.DeskMenu
                                        where m.ID == dm.ID
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        break;
                    case "OrderMenu.Room":
                        Room r = t as Room;
                        if (r.ID == 0)
                        {
                            var query = from m in dc.Room
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        else
                        {
                            var query = from m in dc.Room
                                        where m.ID == r.ID
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        break;
                    case "OrderMenu.Desk":
                        Desk d = t as Desk;
                        if (d.ID == 0)
                        {
                            var query = from m in dc.Desk
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        else
                        {
                            var query = from m in dc.Desk
                                        where m.ID == d.ID
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        break;
                    case "OrderMenu.OrderDesk":
                        OrderDesk od = t as OrderDesk;
                        if (od.ID == 0)
                        {
                            var query = from m in dc.OrderDesk
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        else
                        {
                            var query = from m in dc.OrderDesk
                                        where m.ID == od.ID
                                        select m;
                            result = (List<T>)(Object)query.ToList();
                        }
                        break;
                    default:
                        return null;
                }
                return result;
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
        public bool Update(T t)
        {
            try
            {
                switch (t.GetType().ToString())
                {
                    case "OrderMenu.Worker":
                        Worker w = t as Worker;
                        var query1 = (from m in dc.Worker
                                      where m.ID == w.ID
                                      select m).SingleOrDefault();
                        //query1 = w;
                        query1.Name = w.Name;
                        query1.Profession = w.Profession;
                        query1.Pwd = w.Pwd;
                        break;
                    case "OrderMenu.Menu":
                        Menu menu = t as Menu;
                        var query2 = (from n in dc.Menu
                                      where n.ID == menu.ID
                                      select n).SingleOrDefault();
                        //query2 = menu;
                        query2.Name = menu.Name;
                        query2.Price = menu.Price;
                        query2.Style = menu.Style;
                        break;
                    case "OrderMenu.WorkerMenu":
                        WorkerMenu wm = t as WorkerMenu;
                        var query3 = (from n in dc.WorkerMenu
                                      where n.ID == wm.ID
                                      select n).SingleOrDefault();
                        query3 = wm;
                        break;
                    case "OrderMenu.DeskMenu":
                        DeskMenu dm = t as DeskMenu;
                        var query4 = (from n in dc.DeskMenu
                                      where n.ID == dm.ID
                                      select n).SingleOrDefault();
                        query4 = dm;
                        break;
                    case "OrderMenu.Room":
                        Room r = t as Room;
                        var query5 = (from n in dc.Room
                                      where n.ID == r.ID
                                      select n).SingleOrDefault();
                        //query5 = r;
                        query5.Name = r.Name;
                        query5.Specification = r.Specification;
                        break;
                    case "OrderMenu.Desk":
                        Desk d = t as Desk;
                        var query6 = (from n in dc.Desk
                                      where n.ID == d.ID
                                      select n).SingleOrDefault();
                        query6 = d;
                        break;
                    case "OrderMenu.OrderDesk":
                        OrderDesk od = t as OrderDesk;
                        var query7 = (from n in dc.OrderDesk
                                      where n.ID == od.ID
                                      select n).SingleOrDefault();
                        query7 = od;
                        break;
                    default:
                        return false;
                }
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 按条件查找
        /// </summary>
        /// <param name="t">搜索的类型</param>
        /// <param name="str">搜索的内容</param>
        /// <returns></returns>
        public List<T> Vlookup(T t, string str)
        {
            try
            {
                List<T> result = default(List<T>);
                switch (t.GetType().ToString())
                {
                    case "OrderMenu.Worker":
                        Worker w = t as Worker;
                        var query = from m in dc.Worker
                                    where (m.ID.ToString().Contains(str)) || (m.Name.Contains(str)) || (m.Profession.Contains(str))
                                    select m;
                        result = (List<T>)(Object)query.ToList();

                        break;
                    case "OrderMenu.Menu":
                        Menu menu = t as Menu;
                        var query1 = from m in dc.Menu
                                     where (m.ID.ToString().Contains(str)) || (m.Name.Contains(str)) || (m.Price.ToString().Contains(str)) || (m.Style.Contains(str))
                                     select m;
                        result = (List<T>)(Object)query1.ToList();

                        break;
                    //case "OrderMenu.WorkerMenu":
                    //    WorkerMenu wm = t as WorkerMenu;
                    //    var query2 = from m in dc.Worker
                    //        where (m.ID.ToString().Contains(str)) || (m.Name.Contains(str)) || (m.Profession.Contains(str))
                    //        select m;
                    //        result = (List<T>)(Object)query2.ToList();

                    //    break;
                    //case "OrderMenu.DeskMenu":
                    //    DeskMenu dm = t as DeskMenu;
                    //    if (dm.ID == 0)
                    //    {
                    //        var query = from m in dc.DeskMenu
                    //                    select m;
                    //        result = (List<T>)(Object)query.ToList();
                    //    }
                    //    else
                    //    {
                    //        var query = from m in dc.DeskMenu
                    //                    where m.ID == dm.ID
                    //                    select m;
                    //        result = (List<T>)(Object)query.ToList();
                    //    }
                    //    break;
                    case "OrderMenu.Room":
                        Room r = t as Room;
                        var query2 = from m in dc.Room
                                     where (m.ID.ToString().Contains(str)) || (m.Name.Contains(str)) || (m.Specification.Contains(str))
                                     select m;
                        result = (List<T>)(Object)query2.ToList();

                        break;
                    //case "OrderMenu.Desk":
                    //    Desk d = t as Desk;
                    //    var query3 = from m in dc.Desk
                    //                 where (m.ID.ToString().Contains(str)) || (m.Name.Contains(str)) || (m.Profession.Contains(str))
                    //                 select m;
                    //    result = (List<T>)(Object)query3.ToList();

                    //    break;
                    //case "OrderMenu.OrderDesk":
                    //    OrderDesk od = t as OrderDesk;
                    //    if (od.ID == 0)
                    //    {
                    //        var query = from m in dc.OrderDesk
                    //                    select m;
                    //        result = (List<T>)(Object)query.ToList();
                    //    }
                    //    else
                    //    {
                    //        var query = from m in dc.OrderDesk
                    //                    where m.ID == od.ID
                    //                    select m;
                    //        result = (List<T>)(Object)query.ToList();
                    //    }
                    //    break;
                    default:
                        return null;
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
