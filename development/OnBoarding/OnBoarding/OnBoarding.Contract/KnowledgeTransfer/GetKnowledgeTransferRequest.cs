namespace OnBoarding.Contract
{
    using MediatR;
    using System.Collections.Generic;

    public class GetKnowledgeTransferRequest : IRequest<IList<KnowledgeTransfer>>
    {
    }
}
