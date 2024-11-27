using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    private Weapon weaponRef;
    [Header("UI Elements")]
    [Header("TEXT")]
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dmgText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI critChanceText;
    [SerializeField] private TextMeshProUGUI heavyChanceText;
    [SerializeField] private TextMeshProUGUI goldCostText;
    [SerializeField] private TextMeshProUGUI woodCostText;
    [SerializeField] private TextMeshProUGUI rockCostText;
    [SerializeField] private TextMeshProUGUI craftStatusText;
    [SerializeField] private TextMeshProUGUI craftButtonStatusText;
    [Header("Crafting")]
    [SerializeField] private WeaponData[] weaponsData;
    [SerializeField] private Weapon[] weapon;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private int[] goldCostsCraft;
    [SerializeField] private int[] woodCostsCraft;
    [SerializeField] private int[] rockCostsCraft;
    [SerializeField] private int[] goldCostsUpgrade;
    [SerializeField] private int[] woodCostsUpgrade;
    [SerializeField] private int[] rockCostsUpgrade;
    [SerializeField] private bool[] isCraftable;
    [SerializeField] private bool[] isCrafted;

    [Header("ElementNeed")] 
    [SerializeField] private Unit playerUnit;
    [SerializeField] private GameObject CraftingPanel;
    [SerializeField] private GameObject RecipePanel;
    [SerializeField] private TextMeshProUGUI noViewText;
    [SerializeField] private Button craftButton;
    [SerializeField] private Button equipButton;
    [SerializeField] private int currentId;
    
    public float[] currentWeaponDamage;
    // Start is called before the first frame update
    void Start()
    {
        //weaponRef = GameObject.Find("Weapon").GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        StatRealtime();
        CheckIfCrafted(currentId);
        Debug.Log($"current id : {currentId}");
    }
    public void ClickToViewItemCraft(int id)
    {
        currentId = id;
        noViewText.gameObject.SetActive(false);
        RecipePanel.SetActive(true);
    }

    void StatRealtime()
    {
        nameText.SetText($"{weapon[currentId].Name}");
        dmgText.SetText($"DMG : {weapon[currentId].weaponDamage}");
        speedText.SetText($"Speed : {weapon[currentId].weaponSpeed}");
        critChanceText.SetText($"CritChance : {weapon[currentId].weaponCritChance}");
        heavyChanceText.SetText($"HeavyAttackChance : {weapon[currentId].weaponHeavyAtkChance}");
        if (isCrafted[currentId] == false)
        {
            goldCostText.SetText($"{currencyManager.Gold}/{goldCostsCraft[currentId]}");
            woodCostText.SetText($"{currencyManager.Wood}/{woodCostsCraft[currentId]}");
            rockCostText.SetText($"{currencyManager.Rock}/{rockCostsCraft[currentId]}");
        }

        if (isCrafted[currentId] == true)
        {
            goldCostText.SetText($"{currencyManager.Gold}/{goldCostsUpgrade[currentId]}");
            woodCostText.SetText($"{currencyManager.Wood}/{woodCostsUpgrade[currentId]}");
            rockCostText.SetText($"{currencyManager.Rock}/{rockCostsUpgrade[currentId]}");
        }
    }
    
    public void ClickToCraft()
    {
        if (isCrafted[currentId] == false)
        {
            currencyManager.Gold -= goldCostsCraft[currentId];
            currencyManager.Wood -= woodCostsCraft[currentId];
            currencyManager.Rock -= rockCostsCraft[currentId];
        }

        if (isCrafted[currentId] == true)
        {
            ClickToUpgrade();
        }
        isCrafted[currentId] = true;
        
    }

    public void ClickToUpgrade()
    {
        currencyManager.Gold -= goldCostsUpgrade[currentId];
        currencyManager.Wood -= woodCostsUpgrade[currentId];
        currencyManager.Rock -= rockCostsUpgrade[currentId];
        weapon[currentId].weaponDamage += 2;
        weapon[currentId].weaponSpeed += 2;
        weapon[currentId].weaponCritChance += 2;
        weapon[currentId].weaponHeavyAtkChance += 2;
    }

    public void ClickToExit()
    {
        RecipePanel.SetActive(false);
        noViewText.gameObject.SetActive(true);
        CraftingPanel.SetActive(false);
    }

    public void CheckIfCrafted(int id)
    {
        //craft
        if (isCrafted[id] == false)
        {
            //start setup
            craftButton.interactable = false;
            craftStatusText.SetText("Not enough Materials");
            craftButtonStatusText.SetText("Craft");
            equipButton.interactable = false;
            
            if (currencyManager.Gold < goldCostsCraft[id] && currencyManager.Wood < woodCostsCraft[id] && currencyManager.Rock < rockCostsCraft[id])
            {
                craftStatusText.SetText("Not enough Materials");
                craftButton.interactable = false;
            }
            if (currencyManager.Gold >= goldCostsCraft[id] && currencyManager.Wood >= woodCostsCraft[id] && currencyManager.Rock >= rockCostsCraft[id])
            {
                craftStatusText.SetText("Craftable");
                craftButton.interactable = true;
            }
        }
       //upgrade
        if (isCrafted[id] == true)
        {
            craftButton.interactable = false;
            craftStatusText.SetText("Not enough Materials");
            craftButtonStatusText.SetText("Upgrade");
            equipButton.interactable = true;
            if (currencyManager.Gold < goldCostsUpgrade[id] && currencyManager.Wood < woodCostsUpgrade[id] && currencyManager.Rock < rockCostsUpgrade[id])
            {
                craftStatusText.SetText("Not enough Materials");
                craftButton.interactable = false;
            }
            if (currencyManager.Gold >= goldCostsUpgrade[id] && currencyManager.Wood >= woodCostsUpgrade[id] && currencyManager.Rock >= rockCostsUpgrade[id])
            {
                craftStatusText.SetText("Upgradeable");
                craftButton.interactable = true;
            }
        }
    }

    public void ClickToEquipWeapon()
    {
        playerUnit.UnitEquipmentId = currentId;
    }
}
