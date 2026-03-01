using System;

namespace MedScheduler
{
	public class DoubleBookingException : Exception
	{
		public DoubleBookingException() { }
		public DoubleBookingException(string message) : base(message) { }
		public DoubleBookingException(string message, Exception innerException)
			: base(message, innerException) { }
	}

	public class InvalidAppointmentTimeException : Exception
	{
		public InvalidAppointmentTimeException() { }
		public InvalidAppointmentTimeException(string message) : base(message) { }
		public InvalidAppointmentTimeException(string message, Exception innerException)
			: base(message, innerException) { }
	}
}