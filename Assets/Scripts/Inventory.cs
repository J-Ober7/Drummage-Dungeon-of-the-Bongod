using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private bool active = false;
    public GameObject Inv;

    public PickUpType[] pickUps;
    public GameObject InvPanel;

    //Sprites
    public Sprite none;
    public Sprite health;

    // Start is called before the first frame update
    void Start()
    {
        pickUps = new PickUpType[16];
        for(int i = 0; i < pickUps.Length; ++i)
        {
            pickUps[i] = PickUpType.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            active = !active;
            Inv.SetActive(active);
        }
    }


    public void AddToInventory(PickUpType p)
    {
        for(int i = 0; i < pickUps.Length; ++i)
        {
            GameObject button;
            if(pickUps[i] == PickUpType.None)
            {
                pickUps[i] = p;
                button = InvPanel.transform.GetChild(i).gameObject;
                button.GetComponent<Image>().sprite = SetSprite(p);
                break;
            }
        }
    }

    public void RemoveFromInventory(int ind)
    {
        print("Removed");
        pickUps[ind].Effect();
        GameObject button = InvPanel.transform.GetChild(ind).gameObject;
        button.GetComponent<Image>().sprite = SetSprite(PickUpType.None);
        pickUps[ind] = PickUpType.None;
    }


    private Sprite SetSprite(PickUpType p)
    {
        switch (p)
        {
            case PickUpType.Health:
                return health;
            case PickUpType.None:
                return none;
            default:
                return none;
        }
    }
}
