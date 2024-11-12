using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item")] 
    [SerializeField]private int id;
    public int Id { get { return id; } set { id = value; } }
    [SerializeField]private string name;
    [SerializeField]private string type;
    [SerializeField]private GameObject[] model;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ModelMatchId(id);
    }

    public void ModelMatchId(int modelId)
    {
        foreach (GameObject obj in model)
        {
            obj.SetActive(false);
        }
        
        if (modelId >= 0 && modelId < model.Length)
        {
            model[modelId].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Model ID is out of range.");
        }
    }
}
