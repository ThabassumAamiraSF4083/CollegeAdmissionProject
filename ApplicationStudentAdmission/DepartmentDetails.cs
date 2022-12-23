using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationStudentAdmission
{
    public class DepartmentDetails
    {
       private static int s_departmentID=101;
        public string DepartmentName{get;set;}
        public string DepartmentID{get;}
        public int NoOfSeats{get;set;}

        public DepartmentDetails(string depratmentName,int numberofseats)
        {
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            DepartmentName=depratmentName;
            NoOfSeats=numberofseats;
        }
    }
}