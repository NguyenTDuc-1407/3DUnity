using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParentUI;
    public GameObject inventorySlotUI;
    public void DisplayInventory()
    {
        foreach (Transform itemUI in itemsParentUI)
        {
            Destroy(itemUI.gameObject);
        }
        foreach (Item item in DataInventory.instance.items)
        {
            GameObject itemNewSlot = Instantiate(inventorySlotUI, itemsParentUI);
            var countItemUI = itemNewSlot.transform.Find("CountItem").GetComponent<TextMeshProUGUI>();
            var itemImageUI = itemNewSlot.transform.Find("ImageItem").GetComponent<Image>();
            countItemUI.text = item.amount.ToString();
            itemImageUI.sprite = item.image;
            itemNewSlot.GetComponent<ItemUI>().SetItem(item);
        }
    }
}

