using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationStudentAdmission
{
    public class Operations
    {
    public static void TakeAdmission()
        {
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"\tDepartment ID:{department.DepartmentID}\n\tDepartment ID:{department.DepartmentName}\n\tNumber of seat Available:{department.NumberOfSeats}");
            }
            Console.Write("Enter department ID:");
            string studentChooseID=Console.ReadLine().ToUpper();
            bool departmentChecker=false;
            foreach(DepartmentDetails department in departmentList)
            {
                if(studentChooseID==department.DepartmentID)
                {
                    departmentChecker=true;
                    if(department.NumberOfSeats>0)
                    {
                        if(currentStudent.CheckEligibility(75.0))
                        {
                            bool admissionChecker=false;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(admission.StudentID==currentStudent.StudentID && admission.AdmissionStatus==AdmissionStatus.Admitted)
                                {
                                    admissionChecker=true;
                                }
                            }
                            if(admissionChecker)
                            {
                                Console.WriteLine("You have already taken");
                            }
                            else
                            {
                                department.NumberOfSeats--;
                                AdmissionDetails admission=new AdmissionDetails(DateTime.Now,AdmissionStatus.Admitted,currentStudent.StudentID,department.DepartmentID);
                                admissionList.Add(admission);
                                Console.WriteLine($"Admission was succesfull.\nYour Admission ID is:{admission.AdmissionID}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You are not eligible");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Seats are not available!!!");
                    }
                }
            }
            if(!departmentChecker)
            {
                Console.WriteLine("The Department ID is Invalid");
            }
            //Show department details
            //Ask a department ID for process Admission
            //Fetch department details
            //Check it has valid department id no-->invalid DepartmentID
            //yes-->check number of seats-->0 no--> No seat available
            //yes check he is eligible -->no not eligible to take admisssion
            //no fetch admission list -count if he is admissions- yes--> show you have already taken admission
            //no- create admission, reduce seat count in department
            //Show Admission successfull.
        }
    }
}