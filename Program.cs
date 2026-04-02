// See https://aka.ms/new-console-template for more information

using ReminderApp;
using System.Diagnostics;
using System.Runtime.CompilerServices;

ReminderManager reminder = new ReminderManager();
bool running = true;

while (running) { 
Console.WriteLine("Welcome to my reminder app!\n");

Console.WriteLine("What would you like to do? (Type the number of the option)");
Console.WriteLine("1. Create a reminder");
Console.WriteLine("2. View reminders");
Console.WriteLine("3. Edit a reminder");
Console.WriteLine("4. Delete a reminder");
Console.WriteLine("5. Exit\n");
Console.Write("Your option: ");
string? option = Console.ReadLine();

List<Reminder> reminders = reminder.getAllReminders();

    switch (option)
    {
        case "1":
            Console.Write("Choose a name for your reminder: ");
            string? name = Console.ReadLine();
            if (name == null || name == "")
            {
                Console.WriteLine("Invalid name. Please try again.");
                break;
            }
            Console.Write("Choose a message for your reminder: ");
            string? message = Console.ReadLine();
            if (message == null)
            {
                Console.WriteLine("Invalid message. Please try again.");
                break;
            }

            Console.Write("Choose a time for your reminder (in the format of yyyy-MM-dd HH:mm): ");
            string? input_time = Console.ReadLine();
            if (input_time == null)
            {
                Console.WriteLine("Invalid time. Please try again.");
                break;
            }
            else if (input_time == "")
            {
                DateTime time = DateTime.Now;
                reminder.createReminder(name, message, time);
            }
            else
            {
                try
                {
                    DateTime time = DateTime.ParseExact(input_time, "yyyy-MM-dd HH:mm", null);
                    reminder.createReminder(name, message, time);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid time format. Please use yyyy-MM-dd HH:mm");
                    break;
                }
            }

            Console.WriteLine("Reminder successfully created!");
            break;

        case "2":
            Console.WriteLine("Here are your reminders: \n");
            if (reminders.Count == 0)
            {
                Console.WriteLine("You have no reminders.\n");
                break;
            }
            else
            {
                foreach (Reminder rem in reminders)
                {
                    Console.WriteLine("Name: " + rem.Name);
                    Console.WriteLine("Message: " + rem.Message);
                    Console.WriteLine("Time: " + rem.Time);
                    Console.WriteLine("Is Done: " + rem.IsDone);
                    Console.WriteLine("\n");
                }
                break;
            }

        case "3":
            Console.WriteLine("Which reminder would you like to edit? (Type the name of the reminder) ");
            int count = 0;

            foreach (Reminder rem in reminders)
            {
                Console.WriteLine("[" + count + "]" + " - " + rem.Name);
                count++;
            }

            int index = int.Parse(Console.ReadLine());

            if(!int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Invalid index. Please try again.\n");
                break;
            }

            Reminder selected_reminder = reminders[index];
            Console.WriteLine("What would you like to edit? (Type the number of the option)");
            Console.WriteLine("1. Name\n2. Message\n3. Time of completion\n4. Mark as done!");
            string? edit_option = Console.ReadLine();
            switch (edit_option)
            {
                case "1":
                    Console.Write("New name for reminder: ");
                    selected_reminder.Name = Console.ReadLine();
                    Console.WriteLine("Done!\n");
                    break;
                case "2":
                    Console.Write("New message for reminder: ");
                    selected_reminder.Message = Console.ReadLine();
                    Console.WriteLine("Done!\n");
                    break;
                case "3":
                    Console.Write("New time for reminder (in the format of yyyy-MM-dd HH:mm): ");
                    try
                    {
                        string? new_time = Console.ReadLine();
                        if (new_time != null)
                        {
                            selected_reminder.Time = DateTime.ParseExact(new_time, "yyyy-MM-dd HH:mm", null);
                            Console.WriteLine("Done!\n");
                            break;
                        }
                    }
                    catch (FormatException) 
                    {                         
                        Console.WriteLine("Invalid time format. Please use yyyy-MM-dd HH:mm");
                        break;
                    }
                    
                case "4":
                    selected_reminder.IsDone = true;
                    Console.WriteLine("Done!\n");
                    break;
            }

            break;

        case "4":
            Console.WriteLine("Which reminder would you like to delete? (Type the name of the reminder) ");

            count = 0;

            foreach (Reminder rem in reminders)
            {
                Console.WriteLine("[" + count + "]" + " - " + rem.Name);
                count++;
            }

            index = int.Parse(Console.ReadLine());

            if (!int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Invalid index. Please try again.\n");
                break;
            }

            selected_reminder = reminders[index];

            reminder.removeReminder(selected_reminder);

            break;
        case "5":
            Console.WriteLine("Goodbye!");
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}