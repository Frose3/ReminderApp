 using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderApp
{
    internal class Reminder
    {
        private string name;
        private string message;
        private DateTime time;
        private bool isDone;

        public Reminder(string name, string message, DateTime time)
        { 
            this.Name = name;
            this.Message = message;
            this.Time = time;
            this.IsDone = false;

        }

        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public bool IsDone { get; set; }
    }

}

