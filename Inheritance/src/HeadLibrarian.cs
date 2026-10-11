
namespace LibrarySystem;

public class HeadLibrarian : Staff
{
    public HeadLibrarian(
        string personId,
        string fullName,
        string phone,
        DateOnly hireDate,
        decimal monthlySalary)
        : base(personId, fullName, phone, hireDate, monthlySalary, 400m)
    {
    }

    public void ChangeLateFee(LibraryItem item, decimal newBaseLateFee)
    {
        item.ChangeBaseLateFee(newBaseLateFee);
    }

    public void WithdrawItem(LibraryItem item)
    {
        item.Withdraw();
    }

    public void RestoreItem(LibraryItem item)
    {
        item.Restore();
    }
}
