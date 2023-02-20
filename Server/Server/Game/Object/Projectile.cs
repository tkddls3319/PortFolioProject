﻿using Google.Protobuf.Protocol;
using Server.Game.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Game
{
    public class Projectile : GameObject
    {
        public Data.Skill Data { get; set; }
        public Projectile()
        {
            ObjectType = GameObjectType.Projectile;
        }
        public virtual void Update()
        {

        }
    }
}
