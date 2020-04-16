using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private bool active = false;
    public GameObject Inv;
    public static PickUpType[] pickUps;
    public GameObject InvPanel;

    //Sprites
    public Sprite none;
    public Sprite health;
    public Sprite key;

    public AudioClip keyClip;

    // Start is called before the first frame update
    void Start()
    {
        InvPanel = GameObject.FindGameObjectWithTag("GridLayout");
        Inv.SetActive(false);

        if(pickUps == null)
        {
            pickUps = new PickUpType[16];
        }

        GameObject button;
        for(int i = 0; i < pickUps.Length; ++i)
        {
            if(pickUps[i] == null)
            {
                print(i + " null");
                pickUps[i] = new None();
            }

            button = InvPanel.transform.GetChild(i).gameObject;
            button.GetComponent<Image>().sprite = SetSprite(pickUps[i]);

        }
    }

    public void InventoryWindow()
    {
        active = !active;
        Inv.SetActive(active);
    }


    public void AddToInventory(PickUpType p)
    {
        Debug.Log(pickUps.Length);
        for(int i = 0; i < pickUps.Length; ++i)
        {
            GameObject button;
            if (pickUps[i].ReturnString() == "None")
            {
                if(p.ReturnString() == "Key")
                {
                    AudioSource.PlayClipAtPoint(keyClip, transform.position);
                }
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
        button.GetComponent<Image>().sprite = SetSprite(new None());
        pickUps[ind] = new None();
    }

    public bool CheckInventory(string name) {

        bool rv = false;
        foreach (PickUpType p in pickUps) {
            Debug.Log(p.toString() + ": " + name);
            if (p.toString() == name) {
                Debug.Log("yes");
                rv = true;
            }

        }
        return rv;
    }

    public int getItem(string name) {
        int rv = -1;
        for(int ii = 0; ii < pickUps.Length; ++ii) {
            Debug.Log(pickUps[ii].toString() + ": " + name);
            if (pickUps[ii].toString() == name) {
                rv = ii;
                break;
            }
        }
        return rv;
    }

    private Sprite SetSprite(PickUpType p)
    {
        string s = p.ReturnString();
        switch (s)
        {
            case "Key":
                return key;
            case "Health":
                return health;
            case "None":
                return none;
            default:
                return none;
        }
    }

    public string GetDescription(int ind)
    {
         return pickUps[ind].Description();
    }
}
