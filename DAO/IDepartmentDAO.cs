using ADO_Connected_Arch_Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Connected_Arch_Demo.DAO
{
    internal interface IDepartmentDAO
    {
         List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        Department AddNewDepartment(Department department);
        Department UpdateDepartment(Department department);
        Department DeleteDepartment(int id);

    }
}
