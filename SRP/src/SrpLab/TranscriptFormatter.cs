
namespace SrpLab;

public sealed class TranscriptFormatter
{
    public string Format(
        string studentId,
        string fullName,
        decimal average,
        string letter,
        bool honorRoll)
    {
        return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {average}\nLetter: {letter}\nHonor: {honorRoll}\n";
    }

    public string ExportCsv(
        IEnumerable<(string StudentId, decimal Average, string Letter, bool HonorRoll)> records)
    {
        var rows = new List<string> { "studentId,average,letter,honor" };

        foreach (var record in records.OrderBy(x => x.StudentId))
            rows.Add($"{record.StudentId},{record.Average},{record.Letter},{(record.HonorRoll ? 1 : 0)}");

        return string.Join('\n', rows);
    }
}
