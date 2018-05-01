using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.IO;

namespace BirthdayAnniversaryReminder
{
    public partial class DisplayTableViewController : UITableViewController
    {
        List<EventDetails> eDetails;

        int countCells = 0;

        public DisplayTableViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            eDetails = new List<EventDetails>();
            View.BackgroundColor = UIColor.Gray;
        }
        public List<EventDetails> Read(string db_Path)
        {
            List<EventDetails> eDetails = new List<EventDetails>();
            var db = new SQLiteConnection(ViewController.DbPath);
            DateTime localdate = DateTime.Now;
            string CurrentDay = localdate.Day.ToString();
            string CurrentMonth = localdate.Month.ToString();
            eDetails = db.Query<EventDetails>("SELECT * from EventDetails ORDER BY evedate DESC ");
           // eDetails = db.Query<EventDetails>("SELECT * FROM EventDetails WHERE strftime('%d',evedate) = "+ CurrentDay + " AND strftime('%m',evedate) = " + CurrentMonth).ToList();
            return eDetails;
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            eDetails = Read(ViewController.DbPath);
             TableView.ReloadData();
            View.BackgroundColor = UIColor.LightGray;
        }
         public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
         {
            var cell = TableView.DequeueReusableCell("Cell_Id", indexPath);
             var data = eDetails[indexPath.Row];
            DateTime localdate = DateTime.Now;
            int CurrentDay = localdate.Day;
            int CurrentMonth = localdate.Month;
            DateTime dbDate = data.evedate;
            DateTime dateonly = dbDate.Date;
            int day = dateonly.Day;
            int month = dateonly.Month;
            if (CurrentDay == day && CurrentMonth == month)
            {
                cell.TextLabel.Text = data.name + ", " + data.relationship;
                cell.DetailTextLabel.Text = data.evetype ;
                countCells++;
            }
            else
            {
                cell.TextLabel.Text = "";
                cell.DetailTextLabel.Text = "";
            }
            return cell;
          }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            
             return eDetails.Count;
           
        }

      

        partial void BtnViewAll_Activated(UIBarButtonItem sender)
        {
            ViewAllTableViewController contr = this.Storyboard.InstantiateViewController("ViewAll") as ViewAllTableViewController;
            this.NavigationController.PushViewController(contr, true);
        }
    }
}