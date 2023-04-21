using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace Students
{
    public class StudentList
    {
        private List<Student> _students;

        public StudentList()
        {
            _students = new List<Student>();
        }
        
        public int GetSize()
        {
            return _students.Count;
        }
        
        public Student GetStudent(int idx)
        {
            return _students[idx];
        }
        public void ConvStudent(int idx)
        {
            if (idx >= 0 && idx < _students.Count && _students[idx] is Bachelor)
            {
                _students[idx] = new Master
                {
                    Name = _students[idx].Name,
                    Surname = _students[idx].Surname,
                    Faculty = _students[idx].Faculty,
                    BachelorDegreeNumber = ""
                };
            }
        }
        
        public void UpdateStudent(int idx, string name, string surname, string faculty, string bachelorDegreeNumber)
        {
            _students[idx].Name = name;
            _students[idx].Surname = surname;
            _students[idx].Faculty = faculty;
            if (_students[idx] is Master)
            {
                ((Master)_students[idx]).BachelorDegreeNumber = bachelorDegreeNumber;
            }
        }

        public void AddStudent()
        {
            _students.Add(new Bachelor());
        }

        public void AddStudent(string name, string surname, string faculty)
        {
            _students.Add(new Bachelor(name, surname, faculty));
        }
        
        public void RemoveStudent(int idx)
        {
            if (idx >= 0 && idx < _students.Count)
            {
                _students.RemoveAt(idx);
            }
            
        }

        public List<int> SearchStudents(string name, string surname, string faculty)
        {
            var result = new List<int>();

            for (var i = 0; i < _students.Count; i++)
            {
                if (_students[i].Name.Contains(name) &&
                    _students[i].Surname.Contains(surname) &&
                    _students[i].Faculty.Contains(faculty))
                {
                    result.Add(i);
                }
            }
            
            return result;
        }

        public bool LoadStudents(string path)
        {
            try
            {
                using (var fileStream = new StreamReader(path))
                {
                    var serializer = new XmlSerializer(typeof(List<Student>));
                    _students = serializer.Deserialize(fileStream) as List<Student>;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SaveStudents(string path)
        {
            try
            {
                using (var fileStream = new StreamWriter(path))
                {
                    var serializer = new XmlSerializer(typeof(List<Student>));
                    serializer.Serialize(fileStream, _students);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}