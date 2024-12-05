using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HP : MonoBehaviour
{
    private Player player;
    [SerializeField]private TextMeshProUGUI textHp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Health <= 0)
        {
            player.Health = 0;
        }
        textHp.SetText($"{player.Health}");
    }
}
