namespace OnBoarding.Data
{
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using Entity = OnBoarding.Entities;
    using Contract.Repository;
    using Contract;
    using AutoMapper.QueryableExtensions;

    public class GetDashboardFse : IRequestHandler<GetDashboardFseRequest,  DashboardFse> 
    {
        private readonly IRepository repository;

        public GetDashboardFse(IRepository repository) 
        {
            this.repository = repository;
        }

        public DashboardFse Handle(GetDashboardFseRequest query)
        {
            //return Fthis.repository.Query<Entity.AssociateDetails>().Where(i => i.Fse == true).ProjectTo<DashboardFse>().ToList();

           var dashBoardFseCount = this.repository.Query<Entity.AssociateDetails>().Where(i => i.Fse == true).ProjectTo<DashboardFse>().Count();

           var TotalFseCount = this.repository.Query<Entity.AssociateDetails>().Where(i => i.FseEligibility == true).ProjectTo<DashboardFse>().Count(); 


            var result = new DashboardFse
            {
                CompletedFse = dashBoardFseCount,
                FseCount = TotalFseCount
                
            };
            return result;
        }
    }
}
