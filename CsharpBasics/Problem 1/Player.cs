using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasics
{
    class Player
    {
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public Dictionary<string, int> cInventory = new Dictionary<string, int>();
        private List<string> blocks;
        private string name;
        private string block;
        private bool reusingPlace;
        private bool reusingPickUp;
        public Random rnd = new Random();


        private Dictionary<string, int> myVar;

        public Dictionary<string, int> Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        public Player(string name)
        {
            this.name = name;
            blocks = new List<string> { "chest", "furnace", "grass", "stone", "wood", "pickaxe", "charcoal" };
        }


        public void Pickup(string block)
        {
            bool wasPicked = false;
            string pickUp = string.Format("Action: {0} picks up {1}", this.name, block);
            if (!this.inventory.ContainsKey(block) && this.blocks.Contains(block))
            {
                if (reusingPickUp == false)
                {
                    Console.WriteLine(pickUp);
                }

                this.inventory.Add(block, 1);
                wasPicked = true;
            }
            else if (block == "grass" || block == "stone" || block == "wood" || block == "charcoal")
            {

                if (reusingPickUp == false)
                {
                    Console.WriteLine(pickUp);
                }
                this.inventory[block]++;
                wasPicked = true;
            }
            if (wasPicked && reusingPickUp == false)
            {
                Console.WriteLine("Result: {0} was picked up", block);
            }
            else if (reusingPickUp == false)
            {
                Console.WriteLine("Result: {0} was not picked up", block);
            }
            Console.WriteLine();
        }

        public void Place(string block)
        {
            bool wasPlaced = false;

            if (this.inventory.ContainsKey(block) && this.inventory[block] == 1)
            {
                this.inventory.Remove(block);
                wasPlaced = true;
            }
            else if (block == "grass" || block == "stone" || block == "wood" || block == "charcoal")
            {
                this.inventory[block]--;
                wasPlaced = true;

            }
            if (reusingPlace == false && wasPlaced && reusingPickUp == false)
            {
                Console.WriteLine("Action: {0} places {1}", this.name, block);

                Console.WriteLine("Result: {0} was placed", block);
            }
            else if (reusingPlace == false && wasPlaced == false && reusingPickUp == false)
            {
                Console.WriteLine("Action: {0} places {1}", this.name, block);

                Console.WriteLine("Result: {0} was not placed", block);
            }
        }

        public void Store(string block)
        {
            Console.WriteLine("Action: {0} stores {1}", this.name, block);
            if (this.inventory.ContainsKey(block) && this.inventory.ContainsKey("chest"))
            {


                Console.WriteLine("Result: {0} was stored", block);

                this.reusingPlace = true;

                ChestInventory(block);
            }
            else
            {
                Console.WriteLine("Result: You Don't have {0} and/or chest in your inventory", block);
            }
            Console.WriteLine();
        }
        public Dictionary<string, int> ChestInventory(string block)
        {
            if (this.blocks.Contains(block) && !cInventory.ContainsKey(block))
            {

                cInventory.Add(block, 1);
            }
            else if (block == "grass" || block == "stone" || block == "wood" || block == "charcoal")
            {
                cInventory[block]++;
            }
            Place(block);


            return this.cInventory;


        }

        public void Break(string block)
        {
            switch (block)
            {
                case "chest":

                    Console.WriteLine("Action: {0} break {1}", this.name, block);
                    if (this.inventory.Keys.Contains("chest"))
                    {
                        foreach (var item in cInventory)
                        {
                            if (!inventory.ContainsKey(item.Key))
                            {
                                inventory.Add(item.Key, item.Value);

                            }
                            else
                            {
                                inventory[item.Key] = inventory[item.Key] + item.Value;
                            }
                        }
                        cInventory.Clear();
                        Console.WriteLine("Result: All chest blocks have been added to  {0}'s inventory", this.name);

                    }
                    break;


                case "furnace":

                    Console.WriteLine();
                    if (this.inventory.ContainsKey(block) && this.inventory.Sum(x => x.Value) >= 2)
                    {
                        Console.WriteLine("Inventory before the melting:");

                        dispayinventory();
                        this.reusingPickUp = true;
                        var randomInventoryRemove = inventory.Keys.ToList()[rnd.Next(inventory.Count)];
                        string firstRemovedBlock = randomInventoryRemove;
                        int randomListAdd = rnd.Next(blocks.Count);

                        Place(randomInventoryRemove);
                        randomInventoryRemove = inventory.Keys.ToList()[rnd.Next(inventory.Count)];
                        string secondRemoveBlock = randomInventoryRemove;
                        Place(randomInventoryRemove);

                        Console.WriteLine("Two random blocks ({1} and {2}) are being melted into {0}", blocks[randomListAdd], firstRemovedBlock, secondRemoveBlock);
                        Pickup(blocks[randomListAdd]);

                        this.reusingPickUp = false;
                    }
                    else
                    {
                        Console.WriteLine("You don't have furnace in your inventory");
                    }
                    break;

                case "grass":
                    Console.WriteLine("Action: {0} break {1}", this.name, block);

                    if (this.inventory.ContainsKey(block))
                    {
                        int AddLIst = rnd.Next(blocks.Count);
                        this.reusingPickUp = true;
                        Place("grass");
                        Pickup(blocks[AddLIst]);
                        this.reusingPickUp = false;
                        Console.WriteLine("Result:stone removed ,picked {0}", blocks[AddLIst]);

                    }
                    break;

                case "stone":
                    Console.WriteLine("Action: {0} break {1}", this.name, block);

                    if (this.inventory.ContainsKey(block) && this.inventory.ContainsKey("pickaxe"))
                    {
                        this.reusingPickUp = true;
                        Place(block);
                        Pickup("grass");
                        this.reusingPickUp = false;
                        Console.WriteLine("Result:stone removed ,picked grass");
                    }
                    else
                    {
                        Console.WriteLine("Result:No pickaxe and/or stone");
                    }
                    break;

                case "wood":
                    Console.WriteLine("Action: {0} break {1}", this.name, block);

                    if (this.inventory.ContainsKey(block) && this.inventory.ContainsKey("furnace"))
                    {
                        this.reusingPickUp = true;
                        Place(block);
                        Pickup("charcoal");
                        this.reusingPickUp = false;
                        Console.WriteLine("Result: wood removed , charcoal picked up");
                    }
                    else
                    {
                        Console.WriteLine("Result: need furnace in order to ger charcoal");
                    }

                    break;

                case "pickaxe":
                    Console.WriteLine("Action: {0} break {1}", this.name, block);

                    if (this.inventory.ContainsKey(block))
                    {
                        int AddLIst1 = rnd.Next(blocks.Count);
                        this.reusingPickUp = true;
                        Place("pickaxe");
                        Pickup(blocks[AddLIst1]);
                        this.reusingPickUp = false;
                        Console.WriteLine("Result: pickaxe removed , {0} picked up", blocks[AddLIst1]);

                    }


                    break;

                case "charcoal":
                    if (this.inventory.ContainsKey(block) && this.inventory.ContainsKey("furnace"))
                    {
                        Console.WriteLine("Action: {0} break {1}", this.name, block);
                        this.reusingPickUp = true;
                        Place(block);
                        Pickup("stone");
                        this.reusingPickUp = false;
                        Console.WriteLine("Result:charcoal removed ,picked stone");
                    }
                    else
                    {
                        Console.WriteLine("Result:U need furnace and/or charcoal to break charcoal");
                    }
                    break;



            }


        }

        public void dispayinventory()
        {
            Console.WriteLine("Inventory Items");
            foreach (var item in this.inventory)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
        }

        public void dispayChest()
        {
            Console.WriteLine("Chest Inventory Items");
            foreach (var item in this.cInventory)
            {
                Console.WriteLine(item);

            }
        }

    }
}
