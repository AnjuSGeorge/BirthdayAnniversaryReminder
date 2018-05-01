using Foundation;
using System;
using UIKit;

namespace BirthdayAnniversaryReminder
{
    public partial class Eventcell : UITableViewCell
    {
        public EventcellView (IntPtr handle) : base (handle)
        {
        }
        internal void UpdateCell(EventDetails ed)
        {
            NameLabel.Text = ed.name;
        }
    }
}