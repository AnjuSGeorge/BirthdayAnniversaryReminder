using System;

using UIKit;
using System.IO;
using SQLite;
namespace BirthdayAnniversaryReminder
{
    public partial class ViewController : UIViewController
    { 
        public static string DbName = "Reminder.db3";
        public static string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DbName);
       

        partial void BtnAdd_TouchUpInside(UIButton sender)
        {
            try
            {
                var db = new SQLiteConnection(DbPath);
                db.CreateTable<EventDetails>();
                string rname = txtName.Text;
                string rrelationship = txtRelation.Text;
                string revent = txtEvent.Text;
                string rdate = txtDate.Date.ToString();
                var rEvent = new EventDetails
                {
                    name = rname,
                    relationship = rrelationship,
                    evetype = revent,
                    evedate = DateTime.Parse(rdate)
                };


                db.Insert(rEvent);
                UIAlertView success = new UIAlertView()
                {
                    Title = "Event",
                    Message = "Added successfully"
                };
                success.AddButton("OK");
                success.Show();

               
            }
            catch (Exception ex)
            {

            }
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            DateTime localdate = DateTime.Now;
            var CurrentDay = localdate.Day;
            var CurrentMonth = localdate.Month;
            // lblCheck.Text = CurrentDay.ToString();
            //lblMonth.Text = CurrentMonth.ToString();
          
           
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
