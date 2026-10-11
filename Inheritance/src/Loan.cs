
namespace LibrarySystem;

public class Loan
{
    public string LoanId { get; }
    public DateOnly BorrowDate { get; }
    public Member Member { get; }
    public LibraryItem Item { get; }
    public DateOnly DueDate => BorrowDate.AddDays(Item.LoanPeriodDays);
    public LoanStatus Status { get; private set; }
    public DateOnly? ReturnDate { get; private set; }

    public decimal LateFee
    {
        get
        {
            if (Status != LoanStatus.Returned || ReturnDate == null)
                return 0m;

            int lateDays = ReturnDate.Value.DayNumber - DueDate.DayNumber;

            if (lateDays <= 0)
                return 0m;

            decimal fee = lateDays * Item.DailyLateFee();
            decimal discount = Member.LateFeeDiscountPercent / 100m;

            return Math.Round(fee * (1m - discount), 2);
        }
    }

    internal Loan(Member member, LibraryItem item, DateOnly borrowDate)
    {
        if (member == null)
            throw new ArgumentNullException(nameof(member));

        if (item == null)
            throw new ArgumentNullException(nameof(item));

        LoanId = Guid.NewGuid().ToString();
        Member = member;
        Item = item;
        BorrowDate = borrowDate;
        Status = LoanStatus.Borrowed;
    }

    public void Return(DateOnly returnDate)
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only borrowed loans can be returned.");

        if (returnDate < BorrowDate)
            throw new ArgumentException("Return date cannot be before the borrow date.");

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;
        Item.EndLoan();
    }

    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only borrowed loans can be marked as lost.");

        Status = LoanStatus.Lost;
        Item.EndLoan();
    }
}
