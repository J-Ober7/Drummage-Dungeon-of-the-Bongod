using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUp : MonoBehaviour 
{
    public PickUpType put;
    public TextMeshProUGUI text;
    private string PickUpMessage = "Press [E] to pick up item";

    private void Start()
    {
        put = GetComponent<PickUpType>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.text = PickUpMessage;
            text.gameObject.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.text = "";
            text.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Inventory>().AddToInventory(put);
            text.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}


