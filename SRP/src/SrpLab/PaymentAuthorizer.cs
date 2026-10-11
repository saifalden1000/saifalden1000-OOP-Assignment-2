
namespace SrpLab;

public sealed class PaymentAuthorizer
{
    public string Authorize(decimal total, string cardLast4, int lineCount)
    {
        var payload = $"{total:0.00}|{cardLast4}|{lineCount}";
        var hash = payload.GetHashCode();
        return $"AUTH-{Math.Abs(hash):X8}";
    }
}
