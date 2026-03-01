using System;
using System.Collections.Generic;
using System.Linq;
using MedScheduler;

public class AppointmentScheduler
{
	private List<Appointment> appointments = new List<Appointment>();

	public void Add(Appointment appt)
	{
		if (appt.Start.Hour < 8 || appt.End.Hour >= 17)
			throw new InvalidAppointmentTimeException("Outside clinic hours.");

		if ((appt.End - appt.Start).TotalMinutes < 15)
			throw new InvalidAppointmentTimeException("Minimum duration is 15 minutes.");

		bool conflict = appointments.Any(a =>
			(a.ProviderName == appt.ProviderName || a.Room == appt.Room) &&
			appt.Start < a.End && appt.End > a.Start);

		if (conflict)
			throw new DoubleBookingException("Provider or room double-booked.");

		appointments.Add(appt);
		Logger.Info($"Added {appt.Id} {appt.Start:HH:mm}-{appt.End:HH:mm} {appt.ProviderName} Room {appt.Room}");
	}

	public void Cancel(string id)
	{
		var appt = appointments.FirstOrDefault(a => a.Id == id);
		if (appt != null)
		{
			appointments.Remove(appt);
			Logger.Info($"Cancelled appointment {id}");
		}
	}

	public void Reschedule(string id, DateTime newStart, DateTime newEnd)
	{
		var appt = appointments.FirstOrDefault(a => a.Id == id);
		if (appt == null) return;

		appt.Reschedule(newStart, newEnd);
		Logger.Info($"Rescheduled appointment {id}");
	}

	public void ListAll()
	{
		foreach (var a in appointments)
			Console.WriteLine(a);
	}

	public void ListByProvider(string provider)
	{
		foreach (var a in appointments.Where(a => a.ProviderName == provider))
			Console.WriteLine(a);
	}

	public void ListByDay(DateTime day)
	{
		foreach (var a in appointments.Where(a => a.Start.Date == day.Date))
			Console.WriteLine(a);
	}
}