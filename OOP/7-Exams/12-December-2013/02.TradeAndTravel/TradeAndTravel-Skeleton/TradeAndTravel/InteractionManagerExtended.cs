using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class InteractionManagerExtended : InteractionManager
    {

        //protected override void HandleLocationCreation(string locationTypeString, string locationName)
        //{
        //    Location location = this.CreateLocation(locationTypeString, locationName);

        //    locations.Add(location);
        //    strayItemsByLocation[location] = new List<Item>();
        //    peopleByLocation[location] = new List<Person>();
        //    locationByName[locationName] = location;
        //}

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(actor, commandWords[2]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected void HandleGatherInteraction(Person actor, string itemName)
        {
            if (actor.Location.LocationType == LocationType.Mine
                || actor.Location.LocationType == LocationType.Forest)
            {
                var gatheringLocation = actor.Location.LocationType;
                var requiredItem = false;

                if (gatheringLocation == LocationType.Mine)
                {
                    foreach (var item in actor.ListInventory())
                    {
                        if (item.ItemType == ItemType.Armor)
                        {
                            requiredItem = true;
                            break;
                        }
                    }

                    if (requiredItem == true)
                    {
                        var item = new Iron(itemName);
                        this.AddToPerson(actor, item);
                    }
                }
                else if (gatheringLocation == LocationType.Forest)
                {
                    foreach (var item in actor.ListInventory())
                    {
                        if (item.ItemType == ItemType.Weapon)
                        {
                            requiredItem = true;
                            break;
                        }
                    }

                    if (requiredItem == true)
                    {
                        var item = new Wood(itemName);
                        this.AddToPerson(actor, item);
                    }
                }
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;


        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            return location;
        }
    }
}
