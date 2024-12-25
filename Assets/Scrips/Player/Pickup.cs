using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public ItemConfig itemConfig;
    void PickUpItem()
    {
        Destroy(this.gameObject);
        GameManager.instance.itemData.id = itemConfig.id;
        DataMangager.instance.Add(itemConfig);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpItem();
        }
    }
}
