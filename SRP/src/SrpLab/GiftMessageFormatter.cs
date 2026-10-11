
namespace SrpLab;

public sealed class GiftMessageFormatter
{
    public string Format(string fromName, IEnumerable<string> items, decimal total)
    {
        var itemList = string.Join(", ", items);
        return $"Dear friend,\nA gift from {fromName} awaits ({itemList}).\nTotal surprise value: {total:C}\n";
    }
}
