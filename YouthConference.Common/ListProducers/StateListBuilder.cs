using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace YouthConference.Common.ListProducers
{
    public static class StateListBuilder
    {
        public static IEnumerable<SelectListItem> States()
        {
            ISet<string> states = new HashSet<string>();
            
            states.Add("Abuja");
            states.Add("Anambra");
            states.Add("Enugu");
            states.Add("Adamawa");
            states.Add("Akwa Ibom");
            states.Add("Abia");
            states.Add("Bauchi");
            states.Add("Bayelsa");
            states.Add("Benue");
            states.Add("Borno");
            states.Add("Cross River");
            states.Add("Delta");
            states.Add("Ebonyi");
            states.Add("Edo");
            states.Add("Ekiti");
            states.Add("Gombe");
            states.Add("Imo");
            states.Add("Jigawa");
            states.Add("Kaduna");
            states.Add("Kano");
            states.Add("Katsina");
            states.Add("Kebbi");
            states.Add("Kogi");
            states.Add("Kwara");
            states.Add("Lagos");
            states.Add("Niger");
            states.Add("Nasarawa");
            states.Add("Ogun");
            states.Add("Ondo");
            states.Add("Osun");
            states.Add("Oyo");
            states.Add("Plateau");
            states.Add("Rivers");
            states.Add("Sokoto");
            states.Add("Taraba");
            states.Add("Yobe");
            states.Add("Zamfara");
            IList<SelectListItem> items =
                states.Select(i => new SelectListItem {Text = i, Value = i, Selected = false}).ToList();
            return items;
        }
 
    }
}