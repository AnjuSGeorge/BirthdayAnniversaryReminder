using Foundation;
using System;
using UIKit;

namespace BirthdayAnniversaryReminder
{
    public partial class EventDetailsCells : UITableViewCell
    {
        public EventDetailsCells (IntPtr handle) : base(handle)
        {
        }
            internal void UpdateCell(EventDetails ed)
            {
                NameLabel.Text = ed.name;
                RelationLabel.Text = ed.relationship;
                EventLabel.Text = ed.evetype;
            }
        
    }
}