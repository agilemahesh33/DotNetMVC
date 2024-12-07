using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace MVCWithLinq3.Models
{
    public class EmployeeDAL
    {
        MVCDBDataContext dc = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);
        public List<EmpDept> GetEmployees(bool? Status)
        {
            try
            {
                dynamic Results;
                if (Status == null)
                    Results = from E in dc.Employees
                              join D in dc.Departments on E.Did equals D.Did
                              select new
                              { E.Eid, E.Ename, E.Job, E.Salary, D.Did, D.Dname, D.Location };
                else
                    Results = from E in dc.Employees join D in dc.Departments on E.Did equals D.Did where E.Status == Status select new { E.Eid, E.Ename, E.Job, E.Salary, D.Did, D.Dname, D.Location };
                List<EmpDept> Emps = new List<EmpDept>();
                foreach (var emp in Results)
                {
                    EmpDept empDept = new EmpDept()
                    {
                        EId = emp.Eid,
                        EName = emp.Ename,
                        Job = emp.Job,
                        Salary = emp.Salary,
                        Did = emp.Did,
                        DName = emp.Dname,
                        DLocation = emp.Location
                    };
                    Emps.Add(empDept);
                }
                return Emps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpDept GetEmployee(int Eid, bool? Status)
        {
            try
            {
                dynamic Result;
                if (Status == null)
                    Result = from E in dc.Employees
                             join D in dc.Departments on E.Did equals D.Did
                             where
                             E.Eid == Eid
                             select new { E.Eid, E.Ename, E.Job, E.Salary, D.Did, D.Dname, D.Location };
                else
                    Result = (from E in dc.Employees
                          join D in dc.Departments on E.Did equals D.Did
                          where
                          E.Eid == Eid && E.Status == Status
                          select new { E.Eid, E.Ename, E.Job, E.Salary, D.Did, D.Dname, D.Location }).Single();
                EmpDept Emps = new EmpDept()
                {
                    EId = Result.Eid,
                    EName = Result.Ename,
                    Job = Result.Job,
                    Salary = Result.Salary,
                    Did = Result.Did,
                    DName = Result.Dname,
                    DLocation = Result.Location
                };
                return Emps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetDepartments()
        {
            try
            {
                dynamic dList = from D in dc.Departments select new { D.Did, D.Dname };
                List<SelectListItem> DList = new List<SelectListItem>();
                foreach (dynamic dept in dList)
                {
                    SelectListItem sl = new SelectListItem()
                    {
                        Text = dept.Dname,
                        Value = dept.Did.ToString()
                    };
                    DList.Add(sl);
                }
                return DList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}