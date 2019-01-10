using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Default Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    public string objectName = "Default Item";
    public Sprite itemIcon;
    

}
