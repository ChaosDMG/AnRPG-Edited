﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnotherRpgMod.Utils;
using Terraria;

namespace AnotherRpgMod.Items
{
    class AdditionalDamageNode : ItemNode
    {
        new protected string m_Name = "Additional Damage";
        new protected string m_Desc = "Add";


        public override NodeCategory GetNodeCategory 
        {
            get
            {
                
                return NodeCategory.Flat;
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
                return "Add " + (FlatDamage * Utils.Mathf.Clamp(GetLevel,1,GetMaxLevel)) + " Damage";
            } }

        

        public int FlatDamage;

        public override void Passive(Item item)
        {
            item.GetGlobalItem<ItemUpdate>().DamageFlatBuffer += FlatDamage * GetLevel;
        }

        public override void SetPower(float value)
        {
         //   FlatDamage = Utils.Mathf.Clamp((int)Utils.Mathf.Pow(value*0.8,0.8f),1,999);
            FlatDamage = Utils.Mathf.Clamp((int)Utils.Mathf.Pow(value*0.2,0.4f),1,999);
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
