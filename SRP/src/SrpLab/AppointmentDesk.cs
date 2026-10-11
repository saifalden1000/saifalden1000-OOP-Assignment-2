
namespace SrpLab;

public sealed class AppointmentDesk
{
    private readonly AppointmentScheduler _scheduler;
    private readonly IcsCalendarFormatter _icsFormatter = new();
    private readonly SmsReminderFormatter _smsFormatter = new();

    public TimeOnly Open => _scheduler.Open;
    public TimeOnly Close => _scheduler.Close;
    public int SlotMinutes => _scheduler.SlotMinutes;

    public AppointmentDesk(TimeOnly open, TimeOnly close, int slotMinutes)
    {
        _scheduler = new AppointmentScheduler(open, close, slotMinutes);
    }

    public bool IsWithinBusinessHours(DateTimeOffset when)
    {
        return _scheduler.IsWithinBusinessHours(when);
    }

    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
    {
        return _scheduler.FindNextSlot(from, searchHours);
    }

    public bool TryBook(DateTimeOffset slot)
    {
        return _scheduler.TryBook(slot);
    }

    public string ToIcs(DateTimeOffset slot, string patientName, string clinician)
    {
        return _icsFormatter.Format(slot, SlotMinutes, patientName, clinician);
    }

    public string SmsReminder(DateTimeOffset slot, string clinicPhone)
    {
        return _smsFormatter.Format(slot, clinicPhone);
    }
}
