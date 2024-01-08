using ADO_Connected_Arch_Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_Connected_Arch_Demo.Util;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using ADO_Connected_Arch_Demo.Exceptions;
namespace ADO_Connected_Arch_Demo.DAO
{
    internal class DepartmentDAO : IDepartmentDAO
    {
        SqlConnection conn;

        public string AddNewDepartment(Department department)
        {
            string response = null;
            try
            {
                using(conn= UtilClass.GetConnection())
                {
              

                   // SqlCommand cmd = new SqlCommand($"insert into Department values ('{department.Name}','{department.Head}');select SCOPE_IDENTITY();", conn);
                    SqlCommand cmd = new SqlCommand($"insert into Department OUTPUT INSERTED.Department_id values ('{department.Name}','{department.Head}');", conn);
                    conn.Open();
                    int rowsCount = cmd.ExecuteNonQuery();
                    object NewId = cmd.ExecuteScalar();
                    //SqlCommand cmd1 = new SqlCommand("select SCOPE_IDENTITY();",conn);
                    //  SqlCommand cmd1 = new SqlCommand("select * from Department order by Department_id desc", conn);
                  //  object NewId = cmd.ExecuteScalar();
                    if(rowsCount>0)
                        response= "Record added successfully. and Your Id is :"+NewId;                        
                    else
                        response = "Record not inserted";
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(  ex.Message);
            }
            return response;
            
        }

        public string DeleteDepartment(int id)
        {
            string response = null;
            try
            {
                using (conn = UtilClass.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $"Delete from Department where department_id={id}";
                    conn.Open();
                    int deletedRows = cmd.ExecuteNonQuery();
                    if (deletedRows > 0)
                        response = "REcord Deleted successfully";
                    else
                    {
                        throw new IdNotFoundException(" ID Not Found Exception :Record not Available in DB");
                        response = " Record not Available in DB";
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
         
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

        public void GetDepartmentById(int id)
        {
            try
            {
                using (conn = UtilClass.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"Select * from Department where Department_id={id}";
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            Console.WriteLine($"{dr[0]}\t {dr[1]}\t {dr[2]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Given Id is not available in DB");
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(  ex.Message);
            }
        }

        public Department UpdateDepartment(Department department)
        {

            Department department1 = new Department();
            try
            {
                using (conn=UtilClass.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection= conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"update Department set Name='{department.Name}',Head='{department.Head}' where department_id={department.DEparmentId}";
                    conn.Open();
                    int updatedRows = cmd.ExecuteNonQuery();
                    if(updatedRows>0)
                    {
                        department1 = department;
                    }
                    else
                    {
                      
                        department1.DEparmentId = 0;
                        department.Name = null;
                        return department1;

                    }
                    
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(  ex.Message);
            }
            return department1;
        }
    }
}
