﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AnotherRpgMod.Utils;

namespace AnotherRpgMod.Items
{
    class UseTimeNode : ItemNode
    {
        new protected string m_Name = "Attack Speed";
        new protected string m_Desc = "+ XX% Attack Speed";
        new protected NodeCategory m_NodeCategory = NodeCategory.Multiplier;
        new public float rarityWeight = 0.5f;
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
                return "+ " + (UseTimeReduction * Utils.Mathf.Clamp(GetLevel, 1, GetMaxLevel)) + "% Attack Speed"; 
            }
        }
        public int UseTimeReduction;

        public override void Passive(Item item)
        {
            item.GetGlobalItem<ItemUpdate>().UseTimeBuffer -= (item.GetGlobalItem<ItemUpdate>().UseTimeBuffer * 0.01f * UseTimeReduction * GetLevel);
        }

        public UseTimeNode()
        {

        }

        public override void SetPower(float value)
        {
            UseTimeReduction = Utils.Mathf.Clamp(Utils.Mathf.RoundInt(value), 1, 10);
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
