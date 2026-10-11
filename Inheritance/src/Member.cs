
namespace LibrarySystem;

public class Member : Person
{
    private readonly List<Loan> _loans = new();

    public int MaximumLoans { get; }
    public decimal LateFeeDiscountPercent { get; }

    public IReadOnlyList<Loan> Loans => _loans.AsReadOnly();

    protected Member(
        string personId,
        string fullName,
        string phone,
        int maximumLoans,
        decimal lateFeeDiscountPercent)
        : base(personId, fullName, phone)
    {
        if (maximumLoans <= 0)
            throw new ArgumentException("Maximum loans must be positive.");

        if (lateFeeDiscountPercent < 0 || lateFeeDiscountPercent > 100)
            throw new ArgumentException("Discount must be between 0 and 100.");

        MaximumLoans = maximumLoans;
        LateFeeDiscountPercent = lateFeeDiscountPercent;
    }

    public Loan Borrow(LibraryItem item, DateOnly borrowDate)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        int activeLoans = 0;

        foreach (Loan loan in _loans)
        {
            if (loan.Status == LoanStatus.Borrowed)
                activeLoans++;
        }

        if (activeLoans >= MaximumLoans)
            throw new InvalidOperationException("Member has reached the loan limit.");

        item.StartLoan();

        Loan newLoan = new Loan(this, item, borrowDate);
        _loans.Add(newLoan);

        return newLoan;
    }
}
