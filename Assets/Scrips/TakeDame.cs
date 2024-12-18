using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDame : MonoBehaviour
{
    [SerializeField] int minDamage;
    [SerializeField] int maxDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().enemy[0] = other.GetComponent<Enemy>();
            InvokeRepeating("Damage", 0, 0.3f);
        }
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().player = other.GetComponent<Player>();
            InvokeRepeating("Damage", 0, 0.3f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().player = null;
            CancelInvoke("Damage");
        }

    }
    void Damage()
    {
        int damage = Random.Range(minDamage, maxDamage);
        FindObjectOfType<GameManager>().TakeDamagePlayer(damage);
        // FindObjectOfType<GameManager>().TakeDameEnemy(damage);
    }

}
