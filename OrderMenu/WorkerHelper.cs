using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderMenu
{
    class WorkerHelper
    {
        public static DataClassesDataContext dc = new DataClassesDataContext();
        /// <summary>
        /// 插入员工
        /// </summary>
        /// <param name="worker">员工实例</param>
        /// <returns>插入是否成功</returns>
        static bool Add(Worker worker)
        {
            try
            {
                dc.Worker.InsertOnSubmit(worker);
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id">用功id</param>
        /// <returns>删除是否成功</returns>
        public static bool Delete(int id)
        {
            try
            {
                var query = from m in dc.Worker
                            where m.ID == id
                            select m;
                dc.Worker.DeleteOnSubmit(query.First());
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 按员工id查询员工
        /// </summary>
        /// <param name="id">员工id</param>
        /// <returns>包含员工的泛型</returns>
        public static List<Worker> Select()
        {
            try
            {
                
                    var query = from m in dc.Worker
                                select m;
                    return query.ToList();
                }
            
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询返回唯一一个员工对象
        /// </summary>
        /// <param name="id">员工id</param>
        /// <param name="pwd">员工密码（可为空）</param>
        /// <returns>员工对象</returns>
        public static Worker Login(int id,string pwd="")
        {
            try
            {
                if (pwd != "")
                {
                    var query = from m in dc.Worker
                                where (m.ID == id) && (m.Pwd == pwd)
                                select m;
                    return query.SingleOrDefault();
                }
                else
                {
                    var query = from m in dc.Worker
                                where m.ID == id
                                select m;
                    return query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="worker">改密码只需填充pwd，否则填充别的</param>
        /// <returns></returns>
        public static bool Update(Worker worker)
        {
            try
            {
                var query = (from m in dc.Worker
                             where m.ID == worker.ID
                             select m).SingleOrDefault();
                if (worker.Pwd == "")
                {
                    worker.Pwd = query.Pwd;
                    query = worker;
                }
                else
                {
                    query.Pwd = DataHelper.md5(worker.Pwd);
                }
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
