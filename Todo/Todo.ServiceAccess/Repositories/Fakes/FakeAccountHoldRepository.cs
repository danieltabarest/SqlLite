using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NsuGo.Definition.Interfaces.Repositories.Remote;
using NsuGo.Definition.Models;

namespace NsuGo.ServiceAccess.Repositories.Fakes
{
    public class FakeAccountHoldRepository : IAccountHoldRepository
    {
        private readonly IEnumerable<AccountHold> _holds;

        public FakeAccountHoldRepository()
        {
            _holds = new List<AccountHold>
            {
                new AccountHold("University Employee Reg Hold", 
                                DateTime.Parse("05/05/2015"), 
                                DateTime.Parse("12/31/2099"), 
                                "Submit reg. to One-Stop-Shop.", 
                                "Registration"),
				new AccountHold("Some other Hold",
								DateTime.Parse("02/20/2015"),
								DateTime.Parse("12/31/2099"),
								"Submit reg. to One-Stop-Shop.",
								"Registration")
            };
        }

        public async Task<IEnumerable<AccountHold>> GetAccountHoldsAsync()
        {
            await Task.Delay(1000);
            return _holds;
        }
    }
}
