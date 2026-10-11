
namespace SrpLab;

public sealed class SupportTicket
{
    public string Id { get; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public DateTimeOffset OpenedAt { get; }
    public string Priority { get; private set; } = "P3";

    private readonly TicketPriorityCalculator _priorityCalculator = new();
    private readonly SlaCalculator _slaCalculator = new();
    private readonly SupportMessageFormatter _messageFormatter = new();

    public SupportTicket(string id, string subject, string body, DateTimeOffset openedAt)
    {
        Id = id;
        Subject = subject;
        Body = body;
        OpenedAt = openedAt;
        RecalculatePriorityFromText();
    }

    public void AppendCustomerMessage(string text)
    {
        Body += "\n---\n" + text;
        RecalculatePriorityFromText();
    }

    public void RecalculatePriorityFromText()
    {
        Priority = _priorityCalculator.Calculate(Subject, Body);
    }

    public DateTimeOffset SlaDeadline()
    {
        return _slaCalculator.Deadline(OpenedAt, Priority);
    }

    public bool IsBreached(DateTimeOffset now)
    {
        return _slaCalculator.IsBreached(OpenedAt, Priority, now);
    }

    public string DraftPublicReply(string agentName)
    {
        return _messageFormatter.DraftPublicReply(
            Id, Priority, agentName, SlaDeadline());
    }

    public string InternalEscalationBlurb()
    {
        return _messageFormatter.InternalEscalationBlurb(
            Id, Priority, SlaDeadline());
    }
}
