using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderApp
{
    internal class ReminderManager
    {

        public ReminderManager()
        { 
        }
            
        private List<Reminder> reminders = new List<Reminder>(); 
       
        public Reminder getReminder(string name)
        {
        
            foreach (Reminder reminder in reminders)
            { 

                if (reminder.Name == name)
                {
                    return reminder;
                }
            }
            return null;
        }

        public List<Reminder> getAllReminders()
        {
            return reminders;
        }

        public void createReminder(string name, string message, DateTime time) {

            reminders.Add(new Reminder(name, message, time));
        }

        public void removeReminder(Reminder reminder) {
            reminders.Remove(reminder);       
        }
    }
}
