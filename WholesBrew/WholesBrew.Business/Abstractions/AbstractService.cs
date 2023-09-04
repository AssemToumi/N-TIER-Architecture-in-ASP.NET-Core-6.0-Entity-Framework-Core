using WholesBrew.DataAccess.Abstractions;

namespace WholesBrew.Business.Abstractions
{
    public abstract class AbstractService
    {
        protected readonly IWholesBrewUnitOfWork WholesBrewUnitOfWork;

        protected AbstractService(IWholesBrewUnitOfWork wholesBrewUnitOfWork)
            => WholesBrewUnitOfWork = wholesBrewUnitOfWork;
    }
}
