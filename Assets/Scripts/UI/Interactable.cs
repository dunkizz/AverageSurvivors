using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private GameObject eButtonUI;
    [SerializeField]public bool interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable == false)
        {
            eButtonUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eButtonUI = other.GetComponentInChildren<Transform>().Find("CanvasWorldSpace/ButtonE_IMAGE")?.gameObject;
            if (interactable == true)
            {
                if (eButtonUI != null)
                {
                    eButtonUI.SetActive(true);
                }
                else
                {
                    Debug.LogError("EbuttonUI not found in Player hierarchy!");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && eButtonUI != null)
        {
            eButtonUI.SetActive(false);
            eButtonUI = null; // Clear the reference to avoid stale data
        }
    }
}
