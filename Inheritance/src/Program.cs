
using LibrarySystem;

Console.WriteLine("=== STAFF MONTHLY PAY ===");

Librarian librarian = new Librarian(
    "ST001", "Sara Ahmed", "01010000001",
    new DateOnly(2020, 1, 1), 10000m);

HeadLibrarian headLibrarian = new HeadLibrarian(
    "ST002", "Omar Ali", "01010000002",
    new DateOnly(2018, 5, 1), 15000m);

Shelver shelver = new Shelver(
    "ST003", "Mona Hassan", "01010000003",
    new DateOnly(2022, 3, 1), 7000m, "Fiction");

List<Staff> staffMembers = new List<Staff>
{
    librarian,
    headLibrarian,
    shelver
};

foreach (Staff staff in staffMembers)
{
    Console.WriteLine($"{staff.FullName}: {staff.MonthlyPay():0.00}");
}

Console.WriteLine("\n=== LIBRARY ITEMS ===");

List<LibraryItem> items = new List<LibraryItem>
{
    new Book("B001", "Clean Code", 10m),
    new DVD("D001", "C# Basics", 10m),
    new Magazine("M001", "Tech Monthly", 10m)
};

foreach (LibraryItem item in items)
{
    Console.WriteLine(
        $"{item.Title}: {item.LoanPeriodDays} days, daily fee {item.DailyLateFee():0.00}");
}

Console.WriteLine("\n=== WITHDRAWN ITEM TEST ===");

StudentMember testMember = new StudentMember(
    "MB001", "Ali Hassan", "01020000001");

Book withdrawnBook = new Book("B002", "Old Book", 10m);
headLibrarian.WithdrawItem(withdrawnBook);

try
{
    testMember.Borrow(withdrawnBook, new DateOnly(2026, 10, 12));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n=== ITEM ALREADY ON LOAN TEST ===");

Book borrowedBook = new Book("B003", "C# Guide", 10m);

StudentMember firstMember = new StudentMember(
    "MB002", "Mona Ali", "01020000002");

StudentMember secondMember = new StudentMember(
    "MB003", "Khaled Samir", "01020000003");

firstMember.Borrow(borrowedBook, new DateOnly(2026, 10, 12));

try
{
    secondMember.Borrow(borrowedBook, new DateOnly(2026, 10, 12));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n=== STUDENT LOAN LIMIT TEST ===");

StudentMember student = new StudentMember(
    "MB004", "Youssef Ahmed", "01020000004");

student.Borrow(new Book("B004", "Book One", 10m), new DateOnly(2026, 10, 12));
student.Borrow(new Book("B005", "Book Two", 10m), new DateOnly(2026, 10, 12));
student.Borrow(new Book("B006", "Book Three", 10m), new DateOnly(2026, 10, 12));

try
{
    student.Borrow(
        new Book("B007", "Book Four", 10m),
        new DateOnly(2026, 10, 12));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n=== PREMIUM MEMBER LATE FEE TEST ===");

PremiumMember premiumMember = new PremiumMember(
    "MB005", "Nour Ahmed", "01020000005", 20m);

DVD lateDvd = new DVD("D002", "Database Systems", 10m);

Loan premiumLoan = premiumMember.Borrow(
    lateDvd,
    new DateOnly(2026, 1, 1));

librarian.ProcessReturn(premiumLoan, new DateOnly(2026, 1, 13));

Console.WriteLine($"Due date: {premiumLoan.DueDate}");
Console.WriteLine($"Return date: {premiumLoan.ReturnDate}");
Console.WriteLine($"Late fee: {premiumLoan.LateFee:0.00}");
Console.WriteLine($"Reading points: {premiumMember.ReadingPoints}");

Console.WriteLine("\n=== INVALID LOAN TRANSITIONS ===");

try
{
    librarian.ProcessReturn(premiumLoan, new DateOnly(2026, 1, 14));
}
catch (Exception ex)
{
    Console.WriteLine($"Second return rejected: {ex.Message}");
}

try
{
    librarian.MarkAsLost(premiumLoan);
}
catch (Exception ex)
{
    Console.WriteLine($"Marking returned loan as lost rejected: {ex.Message}");
}

// The following operations must NOT compile:
// new Person("P", "Name", "Phone");
// new Member("M", "Name", "Phone", 3, 0m);
// new Staff("S", "Name", "Phone", DateOnly.Today, 1000m, 0m);
// new LibraryItem("I", "Title", 7, 10m, 1m);
// student.FullName = "Changed Name";
// student.Loans.Add(premiumLoan);
// lateDvd.IsOnLoan = true;
