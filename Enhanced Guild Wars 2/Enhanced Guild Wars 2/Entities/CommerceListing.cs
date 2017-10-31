using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enhanced_Guild_Wars_2.Entities
{
    //--https://api.guildwars2.com/v2/commerce/listings/--ItemIdHere--

    //API Response
    public class CommerceListings
    {
        public int id { get; set; }
        public List<Buy> buys { get; set; }
        public List<Sell> sells { get; set; }
    }

    public class Buy
    {
        //API
        public int listings { get; set; }
        public int unit_price { get; set; }
        public int quantity { get; set; }

        //ADDED
        public GoldSilverCopper value { get; set; }

        public void calculate()
        {
            this.value = new GoldSilverCopper(unit_price);
        }
    }

    public class Sell
    {
        //API
        public int listings { get; set; }
        public int unit_price { get; set; }
        public int quantity { get; set; }

        //Added
        public GoldSilverCopper value { get; set; }

        public void calculate()
        {
            this.value = new GoldSilverCopper(unit_price);
        }
    }
}
