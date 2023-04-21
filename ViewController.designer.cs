// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Students
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet ("addButtonOutlet")]
		AppKit.NSButton AddButtonOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField bachelorNumberField { get; set; }

		[Outlet ("convButtonOutlet")]
		AppKit.NSButton ConvButtonOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField errorLabel { get; set; }

		[Outlet]
		AppKit.NSTextField facultyField { get; set; }

		[Outlet]
		AppKit.NSTextField facultyFindField { get; set; }

		[Outlet]
		AppKit.NSTextField nameField { get; set; }

		[Outlet]
		AppKit.NSTextField nameFindField { get; set; }

		[Outlet]
		AppKit.NSButton nextButtonOutlet { get; set; }

		[Outlet]
		AppKit.NSButton prevButtonOutlet { get; set; }

		[Outlet ("removeButtonOutlet")]
		AppKit.NSButton RemoveButtonOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField surnameField { get; set; }

		[Outlet]
		AppKit.NSTextField surnameFindField { get; set; }

		[Action ("AddButton:")]
		partial void AddButton (Foundation.NSObject sender);

		[Action ("ConvButton:")]
		partial void ConvButton (Foundation.NSObject sender);

		[Action ("facultyField:")]
		partial void FacultyField (AppKit.NSTextField sender);

		[Action ("FindButton:")]
		partial void FindButton (Foundation.NSObject sender);

		[Action ("openDocument:")]
		partial void LoadDocument (Foundation.NSObject sender);

		[Action ("loadStudents:")]
		partial void LoadStudents (Foundation.NSObject sender);

		[Action ("nameField:")]
		partial void NameField (AppKit.NSTextField sender);

		[Action ("nextButton:")]
		partial void NextButton (Foundation.NSObject sender);

		[Action ("prevButton:")]
		partial void PrevButton (Foundation.NSObject sender);

		[Action ("RemoveButton:")]
		partial void RemoveButton (Foundation.NSObject sender);

		[Action ("saveDocument:")]
		partial void SaveDocument (Foundation.NSObject sender);

		[Action ("saveDocumentAs:")]
		partial void SaveDocumentAs (Foundation.NSObject sender);

		[Action ("saveStudents:")]
		partial void SaveStudents (Foundation.NSObject sender);

		[Action ("surenameField:")]
		partial void SurenameField (AppKit.NSTextField sender);

		[Action ("UpdateButton:")]
		partial void UpdateButton (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (AddButtonOutlet != null) {
				AddButtonOutlet.Dispose ();
				AddButtonOutlet = null;
			}

			if (bachelorNumberField != null) {
				bachelorNumberField.Dispose ();
				bachelorNumberField = null;
			}

			if (ConvButtonOutlet != null) {
				ConvButtonOutlet.Dispose ();
				ConvButtonOutlet = null;
			}

			if (errorLabel != null) {
				errorLabel.Dispose ();
				errorLabel = null;
			}

			if (facultyField != null) {
				facultyField.Dispose ();
				facultyField = null;
			}

			if (facultyFindField != null) {
				facultyFindField.Dispose ();
				facultyFindField = null;
			}

			if (nameField != null) {
				nameField.Dispose ();
				nameField = null;
			}

			if (nameFindField != null) {
				nameFindField.Dispose ();
				nameFindField = null;
			}

			if (nextButtonOutlet != null) {
				nextButtonOutlet.Dispose ();
				nextButtonOutlet = null;
			}

			if (prevButtonOutlet != null) {
				prevButtonOutlet.Dispose ();
				prevButtonOutlet = null;
			}

			if (RemoveButtonOutlet != null) {
				RemoveButtonOutlet.Dispose ();
				RemoveButtonOutlet = null;
			}

			if (surnameField != null) {
				surnameField.Dispose ();
				surnameField = null;
			}

			if (surnameFindField != null) {
				surnameFindField.Dispose ();
				surnameFindField = null;
			}

		}
	}
}
