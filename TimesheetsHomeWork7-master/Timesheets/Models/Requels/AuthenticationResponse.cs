namespace Timesheets.Models.Requels
{
    public class AuthenticationResponse
    {
        public AuthenticationStatus Status { get; set; }
        public SessionDto Session { get; set; }
    }
}

