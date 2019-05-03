namespace OnBoarding.Infrastructure.MediatorPipeline
{
    using MediatR;
    using System.Threading.Tasks;
    using Contract.Repository;

    public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork unitOfwork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfwork)
        {
            this.unitOfwork = unitOfwork;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = await next();
            this.unitOfwork.Commit();
            return response;
        }
    }
}
