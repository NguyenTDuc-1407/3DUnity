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
    [SerializeField] float nextWpDis;
    [SerializeField] float moveSpeed;
    Vector3 direction;
    void Start()
    {
        animatiorEnemy = GetComponent<Animator>();
        InvokeRepeating("caculatePath", 0f, 0.5f);

    }
    void Update()
    {

    }
    public void DameEnemy(int damage)
    {
        hpEnemyNow -= damage;
        FindObjectOfType<UIMangager>().UpdateEnemyHealth();
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
            path.vectorPath[currentWp] = new Vector3(path.vectorPath[currentWp].x, 0.554f, path.vectorPath[currentWp].z);
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
}
