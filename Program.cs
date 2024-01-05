using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ADO_Connected_Arch_Demo.DAO;
using ADO_Connected_Arch_Demo.Entity;


namespace ADO_Connected_Arch_Demo
{
    internal class Program
    {
       static SqlConnection conn;
        static void Main(string[] args)
        {
            GetAllDepartments();
            Console.ReadLine();
        }
      
        
        public static void GetAllDepartments()
        {
            
            IDepartmentDAO departmentDAO = new DepartmentDAO();
            List<Department> departments = departmentDAO.GetAllDepartments();
            foreach (Department department in departments)
            {
                Console.WriteLine($"{department.DEparmentId}\t {department.Name}\t {department.Head}");
            }
        }
    }
}
