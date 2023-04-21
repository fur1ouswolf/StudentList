using System.Xml;
using System.Xml.Serialization;

namespace Students
{
    [XmlInclude(typeof(Bachelor))]
    [XmlInclude(typeof(Master))]
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }

        protected Student()
        {
            Name = "";
            Surname = "";
            Faculty = "";
        }

        protected Student(string name, string surname, string faculty)
        {
            Name = name;
            Surname = surname;
            Faculty = faculty;
        }

        public Student(Student other)
        {
            Name = other.Name;
            Surname = other.Surname;
            Faculty = other.Faculty;
        }
    }
    
    public class Bachelor : Student
    {
        public Bachelor() { }
        public Bachelor(string name, string surname, string faculty) : base(name, surname, faculty) { }
    }

    public class Master : Student
    {
        public string BachelorDegreeNumber { get; set; }
        public Master() { }
    }
}