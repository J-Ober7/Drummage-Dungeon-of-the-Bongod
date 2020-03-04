using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonEvent : MonoBehaviour
{
    private Button butt;
    private Inventory inv;
    private int ind;
    // Start is called before the first frame update
    void Start()
    {
        ind = transform.GetSiblingIndex();
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        butt = GetComponent<Button>();
        butt.onClick.AddListener(() => inv.RemoveFromInventory(ind));
    }

    
}
