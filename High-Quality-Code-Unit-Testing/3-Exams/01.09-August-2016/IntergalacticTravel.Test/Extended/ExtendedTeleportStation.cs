﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Test.Extended
{
    public class ExtendedTeleportStation : TeleportStation
    {
        public ExtendedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
            : base(owner, galacticMap, location)
        {
        }


        public IBusinessOwner Owner
        {
            get
            {
                return this.owner;
            }
        }

        public IEnumerable<IPath> Map
        {
            get
            {
                return this.galacticMap;
            }
        }

        public ILocation Location
        {
            get
            {
                return this.location;
            }
        }

        public IResources Resources
        {
            get
            {
                return this.resources;
            }
        }

    }
}
