using System;
using AppKit;
using Foundation;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace Students
{
    public partial class ViewController : NSViewController
    {
        private int _currViewIndex;
        private readonly StudentList _studentList = new StudentList();
        private List<int> _viewList;
        private string _path = "";
        
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        private void CheckBorders()
        {
            prevButtonOutlet.Enabled = _currViewIndex > 0;

            nextButtonOutlet.Enabled = _currViewIndex != _viewList.Count - 1;
        }
        private void UpdateStudentFields()
        {
            if (0 <= _currViewIndex && _currViewIndex < _viewList.Count && _viewList.Count > 0)
            {
                var currStudent = _studentList.GetStudent(_viewList[_currViewIndex]);
                nameField.Enabled = true;
                surnameField.Enabled = true;
                facultyField.Enabled = true;
                nameField.StringValue = currStudent.Name;
                surnameField.StringValue = currStudent.Surname;
                facultyField.StringValue = currStudent.Faculty;
                switch (currStudent)
                {
                    case Bachelor _:
                        bachelorNumberField.StringValue = "";
                        bachelorNumberField.Enabled = false;
                        break;
                    case Master master:
                        bachelorNumberField.StringValue = master.BachelorDegreeNumber;
                        bachelorNumberField.Enabled = true;
                        break;
                }
            }
            else
            {
                nameField.StringValue = "";
                surnameField.StringValue = "";
                facultyField.StringValue = "";
                bachelorNumberField.StringValue = "";
                nameField.Enabled = false;
                surnameField.Enabled = false;
                facultyField.Enabled = false;
                bachelorNumberField.Enabled = false;
            }
        }

        private void ChangeErrorLabel(bool errorCode, string errorText)
        {
            errorLabel.TextColor = errorCode ? NSColor.Green : NSColor.Red;
            errorLabel.StringValue = string.Format(errorText);
        }
        
        private void UpdateViewList()
        {
            _viewList = _studentList.SearchStudents(nameFindField.StringValue, surnameFindField.StringValue, facultyFindField.StringValue);
        }
        
        partial void NextButton(Foundation.NSObject sender)
        {
            if (_currViewIndex >= _viewList.Count - 1) return;
            ++_currViewIndex;
            UpdateStudentFields();
            CheckBorders();
        }

        partial void PrevButton(Foundation.NSObject sender)
        {
            if (0 >= _currViewIndex) return;
            --_currViewIndex;
            UpdateStudentFields();
            CheckBorders();
        }

        partial void UpdateButton(Foundation.NSObject sender)
        {
            if (0 <= _currViewIndex && _currViewIndex < _viewList.Count)
            {
                _studentList.UpdateStudent(_viewList[_currViewIndex], nameField.StringValue, surnameField.StringValue,
                    facultyField.StringValue, bachelorNumberField.StringValue);
            }
        }
        
        partial void AddButton(Foundation.NSObject sender)
        {
           _studentList.AddStudent(nameFindField.StringValue, surnameFindField.StringValue, facultyFindField.StringValue);
           _viewList.Add(_studentList.GetSize() - 1);
           _currViewIndex = _viewList.Count - 1;
           UpdateStudentFields();
           CheckBorders();
        }
        
        partial void RemoveButton(Foundation.NSObject sender)
        {
            if (0 > _currViewIndex || _currViewIndex >= _viewList.Count) return;
            _studentList.RemoveStudent(_viewList[_currViewIndex]);
            UpdateViewList();
            if (_currViewIndex == _viewList.Count)
            {
                --_currViewIndex;
            }
                
            UpdateStudentFields();
            CheckBorders();
        }
        
        partial void ConvButton(Foundation.NSObject sender)
        {
            if (0 > _currViewIndex || _currViewIndex >= _viewList.Count) return;
            _studentList.ConvStudent(_viewList[_currViewIndex]);
            UpdateStudentFields();
        }
        
        partial void LoadDocument(Foundation.NSObject sender)
        {
            var openPanel = NSOpenPanel.OpenPanel;
            openPanel.CanChooseFiles = true;
            openPanel.CanChooseDirectories = false;
            openPanel.AllowedFileTypes = new[] { "xml" };
            openPanel.AllowsMultipleSelection = false;
            openPanel.Title = "Open file";
            openPanel.Message = "Open file";

            if (openPanel.RunModal() != 1) return;
            if (_studentList.LoadStudents(openPanel.Url.Path))
            {
                _path = openPanel.Url.Path;
                ChangeErrorLabel(true, "Students load successfully.");
                _currViewIndex = 0;
                UpdateViewList();
                UpdateStudentFields();
                CheckBorders();
            }
            else
            {
                ChangeErrorLabel(false, "No students.xml file found!");
            }
        }

        partial void SaveDocumentAs(Foundation.NSObject sender)
        {
            var savePanel = NSSavePanel.SavePanel;
            savePanel.CanCreateDirectories = true;
            savePanel.AllowedFileTypes = new[] { "xml" };
            savePanel.Title = "Save file";
            savePanel.Message = "Save file";
            if (savePanel.RunModal() != 1) return;
            if (_studentList.SaveStudents(savePanel.Url.Path))
            {
                ChangeErrorLabel(true, "Students saved successfully.");
            }
            else
            {
                ChangeErrorLabel(false, "Error!");
            }
        }

        partial void SaveDocument(Foundation.NSObject sender)
        {
            if (_path == "")
            {
                SaveDocumentAs(sender);
                return;
            }
            if (_studentList.SaveStudents(_path))
            {
                ChangeErrorLabel(true, "Students saved successfully.");
            }
            else
            {
                ChangeErrorLabel(false, "Error!");
            }
        }

        partial void FindButton(Foundation.NSObject sender)
        { 
            UpdateViewList();
            if (_viewList.Count > 0)
            {
                _currViewIndex = 0;
                ChangeErrorLabel(true, "Found " + Convert.ToString(_viewList.Count) + " students!");
            }
            else
            {
                _currViewIndex = -1;
                ChangeErrorLabel(false, "No students found!");
            }
            UpdateStudentFields();
            CheckBorders();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _viewList = new List<int>();
            _currViewIndex = -1;

            UpdateStudentFields();
            CheckBorders();
            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get { return base.RepresentedObject; }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}