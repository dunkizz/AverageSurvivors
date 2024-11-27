using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]private Spawner spawner;
    [SerializeField]private Interactable interactableUI;
    [SerializeField] private Animator anim;
    

    [SerializeField]private bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (isOpened)
        {
            case true:
                anim.SetBool("isOpened",true);
                interactableUI.interactable = false;
                break;
            case false:
                anim.SetBool("isOpened", false);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isOpened == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                spawner.SpawnItem();
                isOpened = true;
                Debug.Log("Opened");
            }
        }
        
        
        
    }
}
