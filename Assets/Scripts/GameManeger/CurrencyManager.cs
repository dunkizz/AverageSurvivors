using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [Header("Currency")] 
    [SerializeField]private int gold;
    public int Gold{ get { return gold; } set { gold = value; } }
    [SerializeField]private int wood;
    public int Wood{ get { return wood; } set { wood = value; } }
    [SerializeField]private int rock;
    public int Rock{ get { return rock; } set { rock = value; } }
    [SerializeField]private int key;
    public int Key{ get { return key; } set { key = value; } }
    [Header("UI TEXT")]
    [SerializeField]private TextMeshProUGUI GoldText;
    [SerializeField]private TextMeshProUGUI WoodText;
    [SerializeField]private TextMeshProUGUI RockText;
    [SerializeField]private TextMeshProUGUI KeyText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    private void SetText()
    {
        GoldText.text = gold.ToString();
        WoodText.text = wood.ToString();
        RockText.text = rock.ToString();
        KeyText.text = $"{key.ToString()}/3";
    }
}
