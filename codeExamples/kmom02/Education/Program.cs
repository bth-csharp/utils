using Education;

Course[] coursesYear1 =
{
    new Course("DV1670", "python", 7.5F),
    new Course("DV1701", "csharp", 7.5F),
    new Course("DV1704", "databas", 7.5F),
    new Course("DV1702", "algo", 7.5F),
};

/* for (int i = 0; i < coursesYear1.Length; i++)
{
    Console.WriteLine(coursesYear1[i].Information());
}
 */
string[] namesCoursesYear1 = new string[12];
for (int i = 0; i < coursesYear1.Length; i++)
{
    namesCoursesYear1[i] = coursesYear1[i].GetName();
}

// Skapa studenter och sätt kurser
Student student1 = new Student("Beda");
student1.SetCourses(namesCoursesYear1);

Student student2 = new Student("Anna");
student2.SetCourses(namesCoursesYear1);
student2.CompleteCourse("python");
student2.AddNewCourse("Hållbara studiestrategier");

// Skriv ut information om studenterna och deras kurser
Console.WriteLine(student1.Information());
Console.WriteLine(student1.InformationCourses());
Console.WriteLine(student2.Information());
Console.WriteLine(student2.InformationCourses());

