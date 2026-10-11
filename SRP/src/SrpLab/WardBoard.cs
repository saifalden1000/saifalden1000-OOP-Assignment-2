
namespace SrpLab;

public sealed class WardBoard
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();
    private readonly AcuityScorer _acuityScorer = new();
    private readonly HandoffNoteFormatter _handoffFormatter = new();
    private readonly PagerService _pagerService = new();
    private readonly CensusExporter _censusExporter = new();

    public void AssignBed(int bed, string patientId, int heartRate, int spo2)
    {
        if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
        if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
        _vitalsScore[bed] = _acuityScorer.Score(heartRate, spo2);
        _pagerService.SendAlert(bed, _vitalsScore[bed]);
    }

    public string BuildHandoffNote(int bed)
    {
        if (!_bedPatient.TryGetValue(bed, out var patient))
            return $"Bed {bed}: empty";

        return _handoffFormatter.Format(bed, patient, _vitalsScore[bed]);
    }

    public IReadOnlyList<string> DrainPagerLog()
    {
        return _pagerService.DrainLog();
    }

    public string ExportCensusCsv()
    {
        return _censusExporter.Export(_bedPatient, _vitalsScore);
    }
}
