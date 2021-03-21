﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using AnotherRpgMod.RPGModule.Entities;

namespace AnotherRpgMod.RPGModule
{
    class ImmunityNode : Node
    {
        Immunity immunity;
        public Immunity GetImmunity
        {
            get
            {
                return immunity;
            }
        }
        public ImmunityNode(Immunity _immunity, NodeType _type, bool _unlocked = false, float _value = 1, int _levelrequirement = 0, int _maxLevel = 1, int _pointsPerLevel = 1, bool _ascended = false) : base(_type, _unlocked, _value, _levelrequirement, _maxLevel, _pointsPerLevel, _ascended)
        {
            immunity = _immunity;
        }

    }
}
