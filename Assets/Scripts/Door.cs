using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public GameObject player;
    public bool openable;
    public TextMeshProUGUI text;
    public Animator anim;
    public string DoorName;
    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        //anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        openable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            text.gameObject.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            text.text = "";
            text.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!open) {
                Inventory inv = other.GetComponent<Inventory>();
                if (openable) {
                    text.text = "[E] to Open";
                    if (Input.GetKeyDown(KeyCode.E)) {
                        anim.SetTrigger("Open");
                        open = true;
                    }
                }
                else {
                    if (inv.CheckInventory(DoorName)) {
                        text.text = "[E] to Unlock the door";
                        if (Input.GetKeyDown(KeyCode.E)) {
                            inv.RemoveFromInventory(inv.getItem(DoorName));
                        }
                    }
                    else {
                        text.text = "The door is locked. Look for a key";
                    }

                }
            }


        }
    }
}
