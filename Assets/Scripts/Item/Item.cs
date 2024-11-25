using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item,
    Weapon,
    Currency,
    Usable
}
public class Item : MonoBehaviour
{
    [Header("Item")] 
    [SerializeField]protected int id;
    public int Id { get { return id; } set { id = value; } }
    [SerializeField]protected string name;
    public string Name { get { return name; } set { name = value; } }
    [SerializeField]protected ItemType type;
    public ItemType Type { get { return type; } set { type = value; } }
    //[SerializeField]private GameObject[] model;
    //public GameObject[] Model { get { return model; } set { model = value; } }
    //[SerializeField]private BoxCollider[] hitBoxes;
    //public BoxCollider[] HitBoxes { get { return hitBoxes; } set { hitBoxes = value; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ModelMatchId(id);
    }
    
    // void ModelMatchId(int modelId)
    // {
    //     foreach (GameObject obj in model)
    //     {
    //         obj.SetActive(false);
    //     }
    //     
    //     if (modelId >= 0 && modelId < model.Length)
    //     {
    //         model[modelId].SetActive(true);
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Model ID is out of range.");
    //     }
    // }
    public void SetType(ItemType toType)
    {
        type = toType;
    }

    
}
