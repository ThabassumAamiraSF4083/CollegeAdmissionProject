using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationStudentAdmission
{
    public class Operations
    {
        public static void Login()
        {
            System.Console.WriteLine("Enter your ID: ");
            string studentID=Console.ReadLine();
            bool check=true;
            foreach(StudentDetails studentInfo in studentList)
            {
                if(studentInfo.StudentID==studentID)
                {
                    check=false;
                    System.Console.WriteLine("Login Succesfull");
                    currectStudent=studentInfo;
                    SubMenu();

                }
            }
            if(check)
            {
                System.Console.WriteLine("Invalid Student ID: ");
            } 
        }
    public static void DefaultData()
        {
        StudentDetails student1=new StudentDetails("Ravichandran","Ettaparajan",Gender.Male,new DateTime(1999,11,11),57457457575,90,90,90);
        studentList.Add(student1);
        StudentDetails student2=new StudentDetails("Baskaran","Sethurajan",Gender.Male,new DateTime(1999,11,11),6576573635,95,95,95);
        studentList.Add(student2);
        List<DepartmentDetails> departmentList=new List<DepartmentDetails>();
        DepartmentDetails eee=new DepartmentDetails("EEE",29);
        departmentList.Add(eee);
        DepartmentDetails cse=new DepartmentDetails("CSE",29);
        departmentList.Add(cse);
        DepartmentDetails mech=new DepartmentDetails("MECH",30);
        departmentList.Add(mech);
        DepartmentDetails ece=new DepartmentDetails("ECE",30);
        departmentList.Add(ece);
        AdmissionDetails admission1=new AdmissionDetails(student1.StudentID,ece.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
        admissionList.Add(admission1);
        AdmissionDetails admission2=new AdmissionDetails(student2.StudentID,cse.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
        admissionList.Add(admission2);
        }
    
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
    
    public static void CheckEligiblity()
        {
            bool eligiblity = currentStudent.CheckEligiblity(75.0);
            if(eligiblity)
            {
                System.Console.WriteLine("You are eligible for admission");
            }
            else
            {
                System.Console.WriteLine("You are not eligible for admission");
            }
        }
    }

    public static void ShowDetails()
    {
        Console.WriteLine($"Name :  {currentStudent.StudentName} \nFatherName : {currentStudent.FatherName} \nGender : {currentStudent.Gender}");
        Console.WriteLine($"Phone : {currentStudent.Phone} \nDOB : {currentStudent.DOB.ToString("dd/MM/yyyy")} Physics : {currentStudent.Physics}");
        Console.WriteLine($"Chemistry : {currentStudent.Chemistry} \nMaths : {currentStudent.Maths}");
    }
    public static void ShowAdmissionHistory()
    {
        bool condition = true;
        foreach(AdmissionDetails admission in admissionList)
        {
            if(currentStudent.StudentID == admission.StudentID)
            {
                Console.WriteLine($"Admission ID : {admission.AdmissionID} \nStudent ID : {admission.StudentID} \nDepartment ID : {admission.DepartmentID}");
                Console.WriteLine($"\nAdmission Date : {admission.AdmissionDate.ToString("dd/MM/yyyy")} \nStatus : {admission.AdmissionStatus}");
            }
            if(condition)
            {
                System.Console.WriteLine("You have not taken any admission Yet");
            }
        }
    }
}