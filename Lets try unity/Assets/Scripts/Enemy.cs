using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    int curHP;
    int maxHP;
    public int scoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;

    private List<Vector3> path;

    private Weapon weapon;
    private GameObject target;

    private float dist;
    
    void Start()
    {
        // Gets the Components
        weapon = GetComponent<Weapon> ();
        target = FindObjectOfType<Player>().gameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, target.transform.position);

        if (dist <= attackRange)
        {
            if (weapon.CanShoot())
                weapon.Shoot();
        }
        else
        {
            ChaseTarget();
        }
    }

    void ChaseTarget()
    {
        if (path.Count == 0)
            return;

        // move towards the closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if (transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    void UpdatePath()
    {
        // calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        // save that as a list
        path = navMeshPath.corners.ToList();
    }
}