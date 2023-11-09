using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Management_system
{

    public interface Istudent

    {
        int StudID { get; set; }
        string StudName { get; set; }
        string StudGender { get; set; }
        int StudAge { get; set; }
        string StudClass { get; set; }

        float StudAvgMark { get; }

        void Print();
    }


    //  Triển khai (implement) inteface Istudent ở bước 1
    public class Student : Istudent
    {
        public int StudID { get { return StudID; } set { StudID = value; } }
        public string StudName { get { return StudName; } set { StudName = value; } }
        public string StudGender { get { return StudGender; } set { StudGender = value; } }
        public int StudAge { get { return StudAge; } set { StudAge = value; } }
        public string StudClass { get { return StudClass; } set { StudClass = value; } }
        public float StudAvgMark { get; private set; }
        private int[] MarkList = new int[3];





        // Method Print() sẽ hiển StudID, StudName, StudGender, StudAge, StudClass và StudAvgMark của student trên console.
        public void Print()
        {
            Console.WriteLine($"Student ID: {StudID}");
            Console.WriteLine($"Student Name: {StudName}");
            Console.WriteLine($"Student Gender: {StudGender}");
            Console.WriteLine($"Student Age: {StudAge}");
            Console.WriteLine($"Student Class: {StudClass}");

            Console.WriteLine($"Student Average Mark: {StudAvgMark:F2}"); // Cau 2e
        }

        //Khai báo mảng MarkList kiểu int kích thước 3
        public int this[int index]
        {
            get { return MarkList[index]; }
            set { MarkList[index] = value; }
        }

        // Tạo method CalAvg đẻ gán giá trị StudAvgMark bằng trung bình cộng của các phần tử trong mảng MarkList.
        public void CalAvg()
        {
            StudAvgMark = (MarkList[0] + MarkList[1] + MarkList[2]) / 3.0f;
        }





        //===========//=============//=============//================//====================//===================//






        // Tạo Hastable(sử dụng chỉ 1 Hastable) để lưu Students trong bước a với key = StudID và value là student

        static void InsertNewStudent()
        {
            Student student = new Student();

            Console.Write("Enter Student ID: ");
            student.StudID = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            student.StudName = Console.ReadLine();

            Console.Write("Enter Student Gender: ");
            student.StudGender = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            student.StudAge = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Class: ");
            student.StudClass = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter Mark {i + 1}: ");
                student[i] = int.Parse(Console.ReadLine());
            }

            student.CalAvg();
            studentHashtable[student.StudID] = student;
        }









        static void DisplayStudentList()
        {
            Console.WriteLine("Student List:");
            foreach (DictionaryEntry entry in studentHashtable)
            {
                int studentID = (int)entry.Key;
                Student student = (Student)entry.Value;
                student.Print();
            }
        }







        static void CalculateAverageMark()
        {
            foreach (DictionaryEntry entry in studentHashtable)
            {
                Student student = (Student)entry.Value;
                student.CalAvg();
                student.Print();
            }
        }







        static void SearchForStudent() { }





        //===========//=============//=============//================//====================//===================//




        //Khoi chay chuong trinh
        class Program
        {

            static void Main(string[] args)
            {
                Student student = new Student();

                while (true)
                {
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("===================================");
                    Console.WriteLine("1. Insert new student...");
                    Console.WriteLine("2. Diplay all the student list...");
                    Console.WriteLine("3. Calculator average mark...");
                    Console.WriteLine("4. Search for a student..."); // Phan khai bao them
                    Console.WriteLine("5. Exit.");
                    Console.WriteLine("===================================");
                    Console.WriteLine("Option:");

                    int option = int.Parse(Console.ReadLine()); //(string ---> int)

                    switch (option)
                    {
                        case 1:
                            InsertNewStudent();
                            break;
                        case 2:
                            DisplayStudentList();
                            break;
                        case 3:
                            CalculateAverageMark();
                            break;
                        case 4:
                            SearchForStudent();
                            break;
                        case 5:
                            Environment.Exit(0); // Cau 8: Chon 5 chuong trinh Quit
                            break;
                        default:
                            Console.WriteLine("Please select a option.");
                            break;
                    }
                }
            }
        }












    }

}