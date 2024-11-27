using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Idle,
    Moving,
    Dashing,
    Die,
    Attack
}

public class Unit : MonoBehaviour
{
    [Header("Unit")]
    [SerializeField]private string name;
    [SerializeField]private string type;
    [SerializeField]private UnitState state;
    public UnitState State { get { return state; } set { state = value; } }
    [SerializeField]protected Rigidbody rb;
    
    [Header("Status")]
    [SerializeField]private int health;
    public int Health { get { return health; } set { health = value; } }
    public int currentUnitHealth;
    [SerializeField]private float damage;
    public float Damage { get { return damage; } set { damage = value; } }
    [SerializeField]public float currentUnitDamage;
    [SerializeField]private float defense;
    public float Defense { get { return defense; } set { defense = value; } }
    [SerializeField]private float critChance;
    public float CritChance { get { return critChance; } set { critChance = value; } }
    public float currentUnitCritChance;
    [SerializeField]private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    [SerializeField]private float heavyAttackChance;
    public float HeavyAttackChance { get { return heavyAttackChance; } set { heavyAttackChance = value; } }
    public float currentUnitHeavyAttackChance;
    
    [Header("Equipment")] 
    [SerializeField]private int unitEquipmentId;
    public int UnitEquipmentId { get { return unitEquipmentId; } set { unitEquipmentId = value; } }
    [SerializeField]public GameObject currentWeapon;
    [SerializeField]public GameObject[] inventoryWeapons;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetBasedStat();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dead()
    {
        
    }

    void animation()
    {
        
    }
    public void SetState(UnitState toState)
    {
        state = toState;
    }

    public void ChangeWeapons()
    {
        //hide every item in inventory
        foreach (GameObject obj in inventoryWeapons)
        {
            obj.SetActive(false);
        }
        
        //show weapons based on id
        if (unitEquipmentId >= 0 && unitEquipmentId < inventoryWeapons.Length)
        {
            inventoryWeapons[unitEquipmentId].SetActive(true);
        }
        else
        {
            foreach (GameObject obj in inventoryWeapons)
            {
                obj.SetActive(false);
            }
            Debug.Log("No equipment selected");
        }
        //just for debug
        currentWeapon = inventoryWeapons[unitEquipmentId];
    }

    public void GetBasedStat()
    {
        currentUnitHealth = health;
        currentUnitDamage = damage;
        currentUnitCritChance = critChance;
        currentUnitHeavyAttackChance = heavyAttackChance;
    }

}
