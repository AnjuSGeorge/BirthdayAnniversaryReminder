using System;
using SQLite;
namespace BirthdayAnniversaryReminder
{
    public class EventDetails
    {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string relationship
        {
            get; set;
        }
        public string evetype
        {
            get; set;
        }
        public DateTime evedate
        {
            get;set;
        }

    }
}
