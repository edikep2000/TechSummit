using System.Collections.Generic;
using System.Web.Mvc;

namespace YouthConference.Common.ListProducers
{
    public class GenderListProducer
    {
        public IEnumerable<SelectListItem> BuildList()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem()
                {
                    Text = "Male",
                    Value = "Male"
                });
            list.Add(new SelectListItem()
                {
                    Value = "Female",
                    Text = "Female"
                });
            return list;
        }
    }
}