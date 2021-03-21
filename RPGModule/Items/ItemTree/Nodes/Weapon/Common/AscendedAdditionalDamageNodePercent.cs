﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AnotherRpgMod.Utils;

namespace AnotherRpgMod.Items
{
    class AscendedAdditionalDamageNodePercent : ItemNode
    {
        new protected string m_Name = "(Ascended) Bonus Damage";
        new protected string m_Desc = "+ XX% damage";
        new public float rarityWeight = 0.05f;
        new protected bool m_isAscend = true;

        public override bool IsAscend
        {
            get
            {
                return m_isAscend;
            }
        }

        public override NodeCategory GetNodeCategory 
        {
            get
            {
                
                return NodeCategory.Multiplier;
            }
        }

        public override string GetName
        {
            get
            {
                return m_Name;
            }
        }

        public override string GetDesc { get {
                return "Add " + (Damage + Utils.Mathf.Clamp(GetLevel, 1, GetMaxLevel)) + "% Damage";
            } }

        

        public int Damage;

        public override void Passive(Item item)
        {
            item.GetGlobalItem<ItemUpdate>().DamageBuffer += item.GetGlobalItem<ItemUpdate>().DamageFlatBuffer * (Damage + GetLevel) * 0.01f;
        }

        public override void SetPower(float value)
        {
            Damage = Utils.Mathf.Clamp((int)Utils.Mathf.Pow(value*4.5,1.03f),1,999);
            m_MaxLevel = 1;
            m_RequiredPoints = 1;
            power = value;
        }

        public override void LoadValue(string saveValue)
        {
            power = saveValue.SafeFloatParse();
            SetPower(power);
        }

        public override string GetSaveValue()
        {
            return power.ToString();
        }

    }
}
