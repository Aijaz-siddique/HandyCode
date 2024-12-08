/*
Explanation
Student Class: This class holds the properties for each student's marks in different subjects.

StudentComparer Class: This class implements the IComparer<Student> interface and defines the Compare method. The Compare method first compares the ComputerScienceMarks. If they are equal, it then compares the MathMarks.

Main Method: In the Main method, we create a list of Student objects and then sort it using the Sort method, passing an instance of StudentComparer. Finally, we print the sorted list.

This approach ensures that the list is sorted primarily by ComputerScienceMarks and secondarily by MathMarks in case of ties.
*/

using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }
    public int HindiMarks { get; set; }
    public int ComputerScienceMarks { get; set; }
    public int MathMarks { get; set; }
}


public class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        // First compare Computer Science marks
        int result = y.ComputerScienceMarks.CompareTo(x.ComputerScienceMarks);
        
        // If Computer Science marks are the same, compare Math marks
        if (result == 0)
        {
            result = y.MathMarks.CompareTo(x.MathMarks);
        }
        
        return result;
    }
}


public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", HindiMarks = 85, ComputerScienceMarks = 90, MathMarks = 95 },
            new Student { Name = "Bob", HindiMarks = 80, ComputerScienceMarks = 90, MathMarks = 92 },
            new Student { Name = "Charlie", HindiMarks = 75, ComputerScienceMarks = 85, MathMarks = 88 }
        };

        students.Sort(new StudentComparer());

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}: CS = {student.ComputerScienceMarks}, Math = {student.MathMarks}");
        }
    }
}
