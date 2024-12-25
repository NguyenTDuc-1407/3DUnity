using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDameEnemy : MonoBehaviour
{
    [SerializeField] int minDamage;
    [SerializeField] int maxDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().enemy = other.GetComponent<Enemy>();
            InvokeRepeating("Damage", 0.2f, 0f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().enemy = null;
            CancelInvoke("Damage");
        }
    }
    void Damage()
    {
        int damage = Random.Range(minDamage, maxDamage);
        FindObjectOfType<GameManager>().TakeDameEnemy(damage);
    }

}
