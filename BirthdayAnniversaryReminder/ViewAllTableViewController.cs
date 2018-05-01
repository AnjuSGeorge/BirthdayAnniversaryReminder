using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.IO;
namespace BirthdayAnniversaryReminder
{
    public partial class ViewAllTableViewController : UITableViewController
    {
        List<EventDetails> eDetails;
        public ViewAllTableViewController (IntPtr handle) : base (handle)
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
            eDetails = db.Query<EventDetails>("SELECT * from EventDetails ORDER BY evedate DESC ");
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
           
                cell.TextLabel.Text = data.name + ", " + data.relationship;
            cell.DetailTextLabel.Text = data.evetype + ", " + data.evedate;

                 return cell;
        }
        public override nint RowsInSection(UITableView tableView, nint section)
        {

            return eDetails.Count;

        }

    }
}