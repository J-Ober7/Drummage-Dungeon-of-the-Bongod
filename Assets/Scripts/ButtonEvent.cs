using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Button))]
public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button butt;
    private Inventory inv;
    private int ind;
    public GameObject panel;
    public TextMeshProUGUI description;

    // Start is called before the first frame update
    void Start()
    {
        //panel = GameObject.FindGameObjectWithTag("D");
        //description = GameObject.FindGameObjectWithTag("DT").GetComponent<Text>();
        ind = transform.GetSiblingIndex();
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        butt = GetComponent<Button>();
        butt.onClick.AddListener(() => inv.RemoveFromInventory(ind));


    }

    public void Update()
    {
        panel.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x + 75, Input.mousePosition.y + 75);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.SetActive(true);
        print("active????");
        description.text = inv.GetDescription(ind);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panel.SetActive(false);
    }
}
