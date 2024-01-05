using ADO_Connected_Arch_Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_Connected_Arch_Demo.Util;
using System.Data.SqlClient;
namespace ADO_Connected_Arch_Demo.DAO
{
    internal class DepartmentDAO : IDepartmentDAO
    {
        SqlConnection conn;

        public Department AddNewDepartment(Department customer)
        {
            throw new NotImplementedException();
        }

        public Department DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

      

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            conn = UtilClass.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Department";
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                departments.Add(new Department() { DEparmentId = (int)dr[0], Name = dr[1].ToString(), Head = dr[2].ToString() });
            }
            dr.Close();
            conn.Close();
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Department UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
