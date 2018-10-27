using NsuGo.Definition.Interfaces.Repositories.Local;

namespace NsuGo.DatabaseAccess.DataMappers.Base
{
    public abstract class BaseDataMapper
    {
        private string _userId;
        private IUserAccountRepository _userAccountRepository;

        protected BaseDataMapper(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        protected string GetUserId()
    	{
    		if (string.IsNullOrWhiteSpace(_userId))
    		{
                var userAccount = _userAccountRepository.Get();
    			_userId = userAccount.Id;
    		}

    		return _userId;
    	}
    }
}
