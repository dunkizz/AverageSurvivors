using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "NewWeapon",menuName = "CreateWeaponData")]
public class WeaponData : ScriptableObject
{
   public int weaponId;
   public string weaponName;
   public ItemType weaponType;
   public float damage;
   public float speed;
   public float critChance;
   public float heavyAtkChance;
   
   public WeaponData CreateInstance()
   {
      return Instantiate(this);
   }
   
}

