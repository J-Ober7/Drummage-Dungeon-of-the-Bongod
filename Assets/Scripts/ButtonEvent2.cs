using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ButtonEvent2 : MonoBehaviour //Electric Boogaloo
{
    private Button butt;
    private Inventory inv;

    void Start()
    {
        butt = GetComponent<Button>();
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        butt.onClick.AddListener(() => inv.InventoryWindow());
    }
}
