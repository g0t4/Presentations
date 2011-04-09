namespace LoggingSample
{
	using System;

	public class AuditEntry
	{
		protected DateTime TimeStamp { get; set; }
		protected object Event { get; set; }
		public string UserName { get; set; }
		protected Guid UserId { get; set; }
		protected object[] Artifacts { get; set; }

		public AuditEntry(object auditEvent, params object[] artifacts)
		{
			TimeStamp = DateTime.Now;
			Event = auditEvent;
			Artifacts = artifacts;
			// wire who who done it
		}
	}
}