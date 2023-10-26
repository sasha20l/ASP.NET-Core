using Timesheets.Models;
using Timesheets.Models.Requels;
using Timesheets.Models.Request;


namespace Timesheets.Services
{
    public interface IAuthenticateService
    {
        AuthenticationResponse Login(AuthenticationRequest authenticationRequest);

        public SessionDto GetSession(string sessionToken);
    }
}
