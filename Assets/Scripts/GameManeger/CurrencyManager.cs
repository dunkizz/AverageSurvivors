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
    [SerializeField]public int rock;
    public int Rock{ get { return rock; } set { rock = value; } }
    [Header("UI TEXT")]
    [SerializeField]private TextMeshProUGUI GoldText;
    [SerializeField]private TextMeshProUGUI WoodText;
    [SerializeField]private TextMeshProUGUI RockText;
    
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
    }
}
