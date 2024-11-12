using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    
    [SerializeField]private Unit units;
    [Header("Weapon")] 
    [SerializeField]private float damage;
    [SerializeField]private float range;
    [SerializeField]private float speed;
    [SerializeField]private float critChance;
    [SerializeField]private float heavyAttackChance;
    // Start is called before the first frame update
    void Start()
    {
        units = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        ModelMatchId(Id);
        StatPlusToPlayer();
        IdStatWeapon();
    }

    void StatPlusToPlayer()
    {
        units.Damage = units.Damage + damage;
        units.CritChance = units.CritChance + critChance;
        units.HeavyAttackChance = units.HeavyAttackChance + heavyAttackChance;
    }

    void IdStatWeapon()
    {
        switch (Id)
        {
            case 0:
                damage = 5f;
                range = 5f;
                speed = 5f;
                critChance = 5f;
                heavyAttackChance = 5f;
                break;
            case 1:
                damage = 10f;
                range = 10f;
                speed = 10f;
                critChance = 10f;
                heavyAttackChance = 10f;
                break;
        }
    }
}
