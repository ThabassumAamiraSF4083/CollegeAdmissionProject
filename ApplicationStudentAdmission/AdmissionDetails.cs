using System;
namespace ApplicationStudentAdmission
{
    public enum AdmissionStatus{Select,Admitted,Cancelled}
    public class AdmissionDetails
    {
        public static int s_admissionID=1001;
        public string AdmissionID { get;}
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }

        public static int s_studentID;
        public static int s_departmentID;
        public DateTime AdmissionDate { get;}
        public AdmissionStatus AdmissionStatus { get; set; }

        public AdmissionDetails(string studentID,string departmentID,DateTime admissiondate,AdmissionStatus admissionstatus)
        {
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            
            
            AdmissionDate=admissiondate;
            AdmissionStatus=admissionstatus;
        }

    }
}