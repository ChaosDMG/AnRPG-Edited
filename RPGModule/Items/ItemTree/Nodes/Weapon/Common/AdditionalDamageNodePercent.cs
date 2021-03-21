﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AnotherRpgMod.Utils;

namespace AnotherRpgMod.Items
{
    class AdditionalDamageNodePercent : ItemNode
    {

        new protected string m_Name = "Bonus Damage";
        new protected string m_Desc = "+ XX% damage";
        new public float rarityWeight = 0.8f;

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

        public override string GetDesc
        {
            get
            {
                return "Add " + (Damage * Utils.Mathf.Clamp(GetLevel, 1, GetMaxLevel)) + "% Damage ";
            }
        }

        public float Damage;

        public override void Passive(Item item)
        {
            item.GetGlobalItem<ItemUpdate>().DamageBuffer += item.GetGlobalItem<ItemUpdate>().DamageFlatBuffer * (Damage * GetLevel) * 0.01f;
        }

        public override void SetPower(float value)
        {
        //    Damage = Utils.Mathf.Clamp(Utils.Mathf.Round(Utils.Mathf.Pow(value,0.5f),2), 2.5f, 10);
            Damage = Utils.Mathf.Clamp(Utils.Mathf.Round(Utils.Mathf.Pow(value,0.15f),2), 1.5f, 10);
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
