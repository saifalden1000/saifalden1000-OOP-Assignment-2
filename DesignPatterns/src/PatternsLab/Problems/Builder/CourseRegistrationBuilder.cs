
namespace PatternsLab.Problems.Builder;

public sealed class CourseRegistrationBuilder
{
    private string? _studentEmail;
    private string? _courseCode;
    private string? _accessMode;
    private string? _groupCode;
    private string? _discountCode;
    private bool _sendWhatsApp;
    private bool _sendEmailWelcome;
    private string? _mentorNote;
    private DateOnly? _preferredStart;

    public CourseRegistrationBuilder ForStudent(string email)
    {
        _studentEmail = email;
        return this;
    }

    public CourseRegistrationBuilder ForCourse(string courseCode)
    {
        _courseCode = courseCode;
        return this;
    }

    public CourseRegistrationBuilder ForLiveGroup(string groupCode)
    {
        _accessMode = "LiveGroup";
        _groupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder ForVideosOnly()
    {
        _accessMode = "VideosOnly";
        _groupCode = null;
        return this;
    }

    public CourseRegistrationBuilder WithDiscount(string? discountCode)
    {
        _discountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder EnableWhatsApp()
    {
        _sendWhatsApp = true;
        return this;
    }

    public CourseRegistrationBuilder EnableEmailWelcome()
    {
        _sendEmailWelcome = true;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string? note)
    {
        _mentorNote = note;
        return this;
    }

    public CourseRegistrationBuilder WithPreferredStart(DateOnly date)
    {
        _preferredStart = date;
        return this;
    }

    public CourseRegistration Build()
    {
        if (string.IsNullOrWhiteSpace(_studentEmail))
            throw new ArgumentException("email required");

        if (string.IsNullOrWhiteSpace(_courseCode))
            throw new ArgumentException("course required");

        if (_accessMode is not ("LiveGroup" or "VideosOnly"))
            throw new InvalidOperationException("Choose an access mode");

        if (_accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");

        if (_accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        return new CourseRegistration(
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendEmailWelcome,
            _mentorNote,
            _preferredStart);
    }
}
