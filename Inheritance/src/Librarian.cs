
namespace LibrarySystem;

public class Librarian : Staff
{
    public Librarian(
        string personId,
        string fullName,
        string phone,
        DateOnly hireDate,
        decimal monthlySalary)
        : base(personId, fullName, phone, hireDate, monthlySalary, 0m)
    {
    }

    public void ProcessReturn(Loan loan, DateOnly returnDate)
    {
        loan.Return(returnDate);
    }

    public void MarkAsLost(Loan loan)
    {
        loan.MarkAsLost();
    }
}
