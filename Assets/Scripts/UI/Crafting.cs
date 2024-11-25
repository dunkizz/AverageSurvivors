using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    private Weapon weaponRef;
    [Header("UI Elements")]
    [Header("TEXT")]
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI dmg;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI critChance;
    [SerializeField] private TextMeshProUGUI heavyChance;
    [SerializeField] private TextMeshProUGUI goldCost;
    [SerializeField] private TextMeshProUGUI woodCost;
    [SerializeField] private TextMeshProUGUI rockCost;
    [SerializeField] private TextMeshProUGUI craftStatus;
    [SerializeField] private TextMeshProUGUI craftButtonStatus;
    [Header("Crafting")]
    [SerializeField] private bool canCraft;
    // Start is called before the first frame update
    void Start()
    {
        //weaponRef = GameObject.Find("Weapon").GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
