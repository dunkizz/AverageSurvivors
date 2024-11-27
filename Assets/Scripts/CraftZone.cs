using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftZone : MonoBehaviour
{
    [SerializeField] private GameObject craftingUI; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        craftingUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        craftingUI.SetActive(false);
    }
}
