using System;

namespace MedScheduler
{
	public class Appointment
	{
		// Properties
		public string Id { get; }
		public string PatientName { get; }
		public string ProviderName { get; }
		public DateTime Start { get; private set; }
		public DateTime End { get; private set; }
		public string Room { get; }

		// Constructor
		public Appointment(string id, string patientName, string providerName,
						   DateTime start, DateTime end, string room)
		{
			// Validate strings
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentException("Id cannot be empty.");

			if (string.IsNullOrWhiteSpace(patientName))
				throw new ArgumentException("Patient name cannot be empty.");

			if (string.IsNullOrWhiteSpace(providerName))
				throw new ArgumentException("Provider name cannot be empty.");

			if (string.IsNullOrWhiteSpace(room))
				throw new ArgumentException("Room cannot be empty.");

			// Validate times
			if (end <= start)
				throw new ArgumentException("End time must be after start time.");

			Id = id;
			PatientName = patientName;
			ProviderName = providerName;
			Start = start;
			End = end;
			Room = room;
		}

		// Reschedule method
		public void Reschedule(DateTime newStart, DateTime newEnd)
		{
			if (newEnd <= newStart)
				throw new ArgumentException("End time must be after start time.");

			Start = newStart;
			End = newEnd;
		}

		// ToString override
		public override string ToString()
		{
			return $"[ {Id} ] {Start:HH:mm}–{End:HH:mm} {ProviderName} Room {Room}";
		}
	}
}