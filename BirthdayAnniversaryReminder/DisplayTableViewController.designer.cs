// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BirthdayAnniversaryReminder
{
    [Register ("DisplayTableViewController")]
    partial class DisplayTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnAddScr { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnViewAll { get; set; }

        [Action ("BtnAddScr_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAddScr_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnViewAll_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnViewAll_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAddScr != null) {
                btnAddScr.Dispose ();
                btnAddScr = null;
            }

            if (btnViewAll != null) {
                btnViewAll.Dispose ();
                btnViewAll = null;
            }
        }
    }
}