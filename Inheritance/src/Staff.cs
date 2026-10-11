
namespace LibrarySystem;

public class Staff : Person
{
    public DateOnly HireDate { get; }
    public decimal MonthlySalary { get; private set; }
    public decimal ResponsibilityAllowance { get; }

    protected Staff(
        string personId,
        string fullName,
        string phone,
        DateOnly hireDate,
        decimal monthlySalary,
        decimal responsibilityAllowance)
        : base(personId, fullName, phone)
    {
        if (monthlySalary <= 0)
            throw new ArgumentException("Monthly salary must be positive.");

        if (responsibilityAllowance < 0)
            throw new ArgumentException("Responsibility allowance cannot be negative.");

        HireDate = hireDate;
        MonthlySalary = monthlySalary;
        ResponsibilityAllowance = responsibilityAllowance;
    }

    public decimal MonthlyPay()
    {
        return MonthlySalary + ResponsibilityAllowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)
            throw new ArgumentException("Raise percentage must be positive.");

        MonthlySalary += MonthlySalary * percentage / 100m;
    }
}
