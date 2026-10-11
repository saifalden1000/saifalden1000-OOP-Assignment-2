
namespace SrpLab;

public sealed class GradePolicy
{
    public string Letter(decimal average)
    {
        if (average >= 90) return "A";
        if (average >= 80) return "B";
        if (average >= 70) return "C";
        if (average >= 60) return "D";
        return "F";
    }

    public bool MeetsHonorRoll(decimal average)
    {
        return average >= 85 && Letter(average) is "A" or "B";
    }
}
