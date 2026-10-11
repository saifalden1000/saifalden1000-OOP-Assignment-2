
namespace SrpLab;

public sealed class KitchenTicket
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();

    private readonly AllergenDetector _allergenDetector = new();
    private readonly KitchenEtaCalculator _etaCalculator = new();
    private readonly ThermalTicketFormatter _ticketFormatter = new();

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        _items.Add((
            item,
            ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(),
            prepMinutes));
    }

    public IReadOnlyList<string> DetectAllergens()
    {
        return _allergenDetector.Detect(
            _items.SelectMany(i => i.Ingredients));
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        return _etaCalculator.Estimate(
            _items.Select(i => i.PrepMinutes),
            openStations,
            DetectAllergens().Count > 0);
    }

    public string RenderThermalTicket(int orderNumber)
    {
        return _ticketFormatter.Format(
            orderNumber,
            EstimatedReadyMinutes(2),
            _items.Select(i => (i.Item, i.PrepMinutes)),
            DetectAllergens());
    }

    public string ExpoLaneHint()
    {
        return DetectAllergens().Count > 0
            ? "LANE-ALLERGY"
            : EstimatedReadyMinutes(2) > 20
                ? "LANE-SLOW"
                : "LANE-FAST";
    }
}
