using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    private float timeBtwEnemy;
    public float timeEnemy = 0.2f;
    int Countenemy = 1;
    [SerializeField] int limitEnemy;

    // Update is called once per frame
    void Update()
    {
        timeBtwEnemy -= Time.deltaTime;
        if (timeBtwEnemy < 0 && Countenemy <= limitEnemy)
        {
            autoEnemy();
        }
    }
    void autoEnemy()
    {
        timeBtwEnemy = timeEnemy;
        Instantiate(enemy, enemyPos.position, Quaternion.identity);
        Countenemy++;
    }
}
