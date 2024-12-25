using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Path path;
    Coroutine move;
    public Seeker seeker;
    public int hpEnemyNow;
    private Animator animatiorEnemy;
    public GameObject item;
    public bool checkDead = false;
    [SerializeField] float nextWpDis;
    [SerializeField] float moveSpeed;
    [SerializeField] int minDamage;
    [SerializeField] int maxDamage;
    Vector3 direction;
    void Start()
    {
        animatiorEnemy = GetComponent<Animator>();
    }
    void Update()
    {

    }
    public void DameEnemy(int damage)
    {
        hpEnemyNow -= damage;
        InvokeRepeating("caculatePath", 0f, 0.5f);
        if (hpEnemyNow <= 0)
        {
            checkDead = true;
            hpEnemyNow = 0;
            Instantiate(item, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void caculatePath()
    {
        Vector3 target = findTarget();
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target, OnpathCallBack);
            // animatiorEnemy.SetBool("RunWolf", false);
        }
        else
        {
            seeker.StartPath(transform.position, transform.position, OnpathCallBack);
        }
    }

    //location player
    Vector3 findTarget()
    {
        Vector3 playPos = FindObjectOfType<Player>().transform.position;
        // animatiorEnemy.SetBool("RunWolf", true);
        return playPos;
    }
    void OnpathCallBack(Path p)
    {
        if (p.error)
        {
            return;
        }
        path = p;
        moveTager();
    }
    void moveTager()
    {
        if (move != null)
        {
            StopCoroutine(move);
        }
        move = StartCoroutine(moveTagerCoroutine());
    }
    // di chuyen
    IEnumerator moveTagerCoroutine()
    {
        int currentWp = 0;
        while (currentWp < path.vectorPath.Count)
        {
            path.vectorPath[currentWp] = new Vector3(path.vectorPath[currentWp].x, 0.138f, path.vectorPath[currentWp].z);
            direction = (path.vectorPath[currentWp] - transform.position).normalized;
            Vector3 force = direction * moveSpeed * Time.deltaTime;
            transform.position += force;
            float dis = Vector3.Distance(transform.position, path.vectorPath[currentWp]);
            if (dis < nextWpDis)
            {
                currentWp++;
            }
            // if (force.x != 0)
            // {
            //     if (force.x < 0)
            //     {
            //         enemySR.transform.localRotation = Quaternion.Euler(0, 180, 0);
            //     }
            //     else
            //     {
            //         enemySR.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //     }
            // }
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
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
    }
}
