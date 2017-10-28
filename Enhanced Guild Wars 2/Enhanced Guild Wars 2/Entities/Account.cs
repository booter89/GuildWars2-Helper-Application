using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using Enhanced_Guild_Wars_2.Routines;

namespace Enhanced_Guild_Wars_2.Entities
{
    public class Account
    {
        public List<Character> Characters;
        public string APIKey;
        public List<Item> Items;
        public List<ShareInventoryItem> SharedInvenotry;
        public List<Tuple<ShareInventoryItem, Item>> SharedInventoryItems;

        public Account()
        {
            this.Characters = new List<Character>();
            this.APIKey = Concrete.Constants.Account.apiKey;
            this.Items = new List<Item>();
            this.SharedInvenotry = new List<ShareInventoryItem>();
            this.SharedInventoryItems = new List<Tuple<ShareInventoryItem, Item>>();
        }

        public void getAccountInformation()
        {
            var url = @"https://api.guildwars2.com/v2/characters?page=0";

            this.Characters = API.getScalarValue<List<Character>>(url);

            url = @"https://api.guildwars2.com/v2/account/inventory";

            this.SharedInvenotry = API.getScalarValue<List<ShareInventoryItem>>(url);

            foreach (Character c in this.Characters)
            {
                c.getCreationInfo();
                c.getHoursPlayed();             

                switch (c.profession)
                {
                    case "Elementalist":
                        c.color = Concrete.Constants.Formatting.ElementalistColor;
                        c.smallPNG = Concrete.Constants.Images.ElementalistSmallPNG;
                        break;
                    case "Mesmer":
                        c.color = Concrete.Constants.Formatting.MesmerColor;
                        c.smallPNG = Concrete.Constants.Images.MesmerSmallPNG;
                        break;
                    case "Necromancer":
                        c.color = Concrete.Constants.Formatting.NecromancerColor;
                        c.smallPNG = Concrete.Constants.Images.NecromancerSmallPNG;
                        break;
                    case "Thief":
                        c.color = Concrete.Constants.Formatting.ThiefColor;
                        c.smallPNG = Concrete.Constants.Images.ThiefSmallPNG;
                        break;
                    case "Ranger":
                        c.color = Concrete.Constants.Formatting.RangerColor;
                        c.smallPNG = Concrete.Constants.Images.RangerSmallPNG;
                        break;
                    case "Engineer":
                        c.color = Concrete.Constants.Formatting.EngineerColor;
                        c.smallPNG = Concrete.Constants.Images.EngineerSmallPNG;
                        break;
                    case "Revenant":
                        c.color = Concrete.Constants.Formatting.RevenantColor;
                        c.smallPNG = Concrete.Constants.Images.RevenantSmallPNG;
                        break;
                    case "Warrior":
                        c.color = Concrete.Constants.Formatting.WarriorColor;
                        c.smallPNG = Concrete.Constants.Images.WarriorSmallPNG;
                        break;
                    case "Guardian":
                        c.color = Concrete.Constants.Formatting.GuardianColor;
                        c.smallPNG = Concrete.Constants.Images.GuardianSmallPNG;
                        break;
                    default:
                        c.color = "#000000";
                        c.smallPNG = Concrete.Constants.Images.GuardianSmallPNG;
                        break;
                }

            }
        }

        public void getAccountItems()
        {
            List<string> ItemIds = new List<string>();

            foreach (ShareInventoryItem i in SharedInvenotry)
            {
                if (i != null)
                {
                    if (!ItemIds.Contains(i.id.ToString()))
                    {
                        ItemIds.Add(i.id.ToString());
                    }
                }
            }


            foreach (Character c in Characters)
            {
                foreach (Bag b in c.bags)
                {
                    if (b != null)
                    {
                        if (!ItemIds.Contains(b.id.ToString()))
                        {
                            ItemIds.Add(b.id.ToString());
                        }
                    }

                    foreach (Inventory item in b.inventory)
                    {
                        if (item != null)
                        {
                            if (!ItemIds.Contains(item.id.ToString()))
                            {
                                ItemIds.Add(item.id.ToString());
                            }

                        }
                    }
                }
            }

            int itemCount = ItemIds.Count();
            int skipIndex = 0;
            int takeIndex = 0;

            if (itemCount < 200)
            {
                takeIndex = Items.Count();
            }
            else
            {
                takeIndex = 200;
            }

            string JsonUrl = @"https://api.guildwars2.com/v2/items?ids=";

            using (var webClient = new System.Net.WebClient())
            {
                for (int i = 0; i < itemCount;)
                {
                    string idQuery = String.Join(",", ItemIds.Skip(skipIndex).Take(takeIndex));

                    var webResponse = webClient.DownloadString(String.Format("{0}{1}", JsonUrl, idQuery));

                    var idResponse = JsonConvert.DeserializeObject<List<Item>>(webResponse);

                    foreach (Item item in idResponse)
                    {
                        this.Items.Add(item);
                    }

                    i += 200;

                    if ((i + 200) > itemCount)
                    {
                        takeIndex = itemCount - i;
                        skipIndex += 200;
                    }
                    else
                    {
                        takeIndex = 200;
                        skipIndex += 200;
                    }
                }
            }
        }

        public void pairItems()
        {
            foreach (ShareInventoryItem SharedItem in SharedInvenotry)
            {
                Tuple<ShareInventoryItem, Item> SharedInventoryItem;

                if (SharedItem != null)
                {
                    List<Item> result = Items.Where(x => x.id == SharedItem.id).Select(x => x).ToList();

                    SharedInventoryItem = new Tuple<ShareInventoryItem, Item>(SharedItem, result.First());
                }
                else
                {
                    Item item = new Item();

                    item.rarity = "Junk";

                    item.icon = @"C:\Users\kttruedson\Desktop\GuildWars2Helper\GuildWars2Helper\Resources\Images\BlackBox.png";

                    SharedInventoryItem = new Tuple<ShareInventoryItem, Item>(SharedItem, item);
                }

                SharedInventoryItems.Add(SharedInventoryItem);
            }

            foreach (Character c in Characters)
            {
                int usedInventorySlots = 0;
                int totalInventorySlots = 0;

                c.inventoryItems = new List<Tuple<Inventory, Item>>();
                c.bagItems = new List<Tuple<Bag, Item>>();

                foreach (Bag bag in c.bags)
                {
                    totalInventorySlots += bag.size;

                    Tuple<Bag, Item> BagItem;

                    if (bag != null)
                    {
                        List<Item> result = Items.Where(x => x.id == bag.id).Select(x => x).ToList();

                        BagItem = new Tuple<Bag, Item>(bag, result.First());
                    }
                    else
                    {
                        Item i = new Item();

                        BagItem = new Tuple<Bag, Item>(bag, i);
                    }

                    c.bagItems.Add(BagItem);

                    foreach (Inventory item in bag.inventory)
                    {
                        Tuple<Inventory, Item> InventoryItem;

                        if (item != null)
                        {
                            List<Item> result = Items.Where(x => x.id == item.id).Select(x => x).ToList();

                            if (result.Count() != 0)
                            {
                                InventoryItem = new Tuple<Inventory, Item>(item, result.First());
                            }
                            else
                            {
                                Item i = new Item();

                                i.rarity = "Junk";

                                i.icon = @"C:\Users\kttruedson\Desktop\GuildWars2Helper\GuildWars2Helper\Resources\Images\Deleted_Item.png";

                                InventoryItem = new Tuple<Inventory, Item>(item, i);
                            }

                            usedInventorySlots++;
                        }
                        else
                        {
                            Item i = new Item();

                            i.rarity = "Junk";

                            i.icon = @"C:\Users\kttruedson\Desktop\GuildWars2Helper\GuildWars2Helper\Resources\Images\BlackBox.png";

                            InventoryItem = new Tuple<Inventory, Item>(item, i);
                        }

                        c.inventoryItems.Add(InventoryItem);

                    }
                }

                c.totalInventorySlots = totalInventorySlots;
                c.usedInventorySlots = usedInventorySlots;
            }

        }

    
    }
}
