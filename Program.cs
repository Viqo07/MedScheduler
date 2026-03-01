using System;
using MedScheduler;

class Program
{
	static void Main()
	{
		AppointmentScheduler scheduler = new AppointmentScheduler();
		bool running = true;

		while (running)
		{
			Console.WriteLine("\n=== Medical Appointment Scheduler ===");
			Console.WriteLine("1. Add Appointment");
			Console.WriteLine("2. List All");
			Console.WriteLine("3. Exit");
			Console.Write("Choose: ");

			string choice = Console.ReadLine();

			try
			{
				switch (choice)
				{
					case "1":
						Console.Write("ID: ");
						string id = Console.ReadLine();

						Console.Write("Patient: ");
						string patient = Console.ReadLine();

						Console.Write("Provider: ");
						string provider = Console.ReadLine();

						Console.Write("Room: ");
						string room = Console.ReadLine();

						Console.Write("Start (yyyy-MM-dd HH:mm): ");
						DateTime start = DateTime.Parse(Console.ReadLine());

						Console.Write("End (yyyy-MM-dd HH:mm): ");
						DateTime end = DateTime.Parse(Console.ReadLine());

						var appt = new Appointment(id, patient, provider, start, end, room);
						scheduler.Add(appt);

						Console.WriteLine("Appointment added.");
						break;

					case "2":
						scheduler.ListAll();
						break;

					case "3":
						running = false;
						break;

					default:
						Console.WriteLine("Invalid choice.");
						break;
				}
			}
			catch (DoubleBookingException ex)
			{
				Console.WriteLine("Double booking error.");
				Logger.Warn(ex.Message);
			}
			catch (InvalidAppointmentTimeException ex)
			{
				Console.WriteLine("Invalid time.");
				Logger.Warn(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unexpected error.");
				Logger.Error(ex.Message);
			}
		}
	}
}