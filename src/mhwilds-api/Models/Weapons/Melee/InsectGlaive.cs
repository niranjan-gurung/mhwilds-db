﻿using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class InsectGlaive : BaseWeapon
    {
        public InsectGlaive()
        {
            WeaponType = WeaponType.InsectGlaive;
        }
        public Sharpness Sharpness { get; set; }
    }
}
