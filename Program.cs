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
            //List<Department> departments = departmentDAO.GetAllDepartments();
            //foreach (Department department in departments)
            //{
            //    Console.WriteLine($"{department.DEparmentId}\t {department.Name}\t {department.Head}");
            //}

            //departmentDAO.GetDepartmentById(50);
            //Console.WriteLine(  "Enter the Department Name,Head for insert into the Database");
            //Department department=new Department();
            //department.Name=Console.ReadLine();
            //department.Head=Console.ReadLine();
            //Console.WriteLine(   departmentDAO.AddNewDepartment(department));


           // Console.WriteLine("Enter the Department ,Id , NewName,NewHead for update into the Database");
           // Department department = new Department();
           // department.DEparmentId=Convert.ToInt32(Console.ReadLine());
           // department.Name = Console.ReadLine();
           // department.Head = Console.ReadLine();
           //Department dept=departmentDAO.UpdateDepartment(department);
           // Console.WriteLine( $"{dept.DEparmentId} \n {dept.Name}\n {dept.Head}" );

            Console.WriteLine("Enter the Department Id ,  for delete from the Database");
            int deptid=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(departmentDAO.DeleteDepartment(deptid));

        }
    }
}
