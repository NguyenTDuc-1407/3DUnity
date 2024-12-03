using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item;
    void PickUpItem()
    {
        Destroy(this.gameObject);
        DataInventory.instance.Add(item);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpItem();
        }
    }
}
