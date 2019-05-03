namespace OnBoarding.Contract
{
    using System;
    using System.Collections.Generic;

    public class HomeDashboard
    {
        public IList<Dashboard> Dashboard { get; set;}

        public DashboardFse Fse { get; set; }  

    }

   
}
