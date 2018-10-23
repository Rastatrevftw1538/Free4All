using System.Collections;
using System.Collections.Generic;
using CompleteProject;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{

    public Transform target;
    public GameObject projectile;

    public float maximumLookDistance = 30f;
    public float maximumAttackDistance = 10f;
    public float minimumDistanceFromPlayer = 2;

    public float rotationDamping = 2;

    public float shotInterval = 3f;

    private float shotTime = 1;

    public GameObject[] players;

    public int targetNum;

    public EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    public EnemyMovement enemyMovement;
    public Animator anim;
    public bool shooting;
    public Transform target1;
    public Transform target2;
    public Transform target3;

    void Start()
    {

        enemyHealth = GetComponent<EnemyHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
        anim = GetComponent<Animator>();
        players = new GameObject[3];
        players[0] = GameObject.FindWithTag("Ice");
        players[1] = GameObject.FindWithTag("Fire");
        players[2] = GameObject.FindWithTag("Earth");

        targetNum = Random.Range(0, 3);
        target1 = players[0].transform;
        target2 = players[1].transform;
        target3 = players[2].transform;
        target = players[targetNum].transform;
        shooting = false;
    }
    void Update()
    {
        target = enemyMovement.target;
        var distance = Vector3.Distance(target.position, transform.position);
        var health = target.GetComponent<PlayerHealth>();
        
      
        if (distance <= maximumLookDistance)
        {
            if (enemyMovement.frozen == false)
            {
                LookAtTarget();

                //Check distance and time
                if (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval)
                {
                    
                    enemyMovement.nav.enabled = false;
                    shooting = true;
                    Shoot();
                }
            }
        }
    }


    void LookAtTarget()
    {
        
        var dir = target.position - transform.position;
        dir.y = 0;
        var rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }


    void Shoot()
    {
        //Reset the time when we shoot
        if (enemyMovement.frozen == false) 
        {
         
            shotTime = Time.time;
            LookAtTarget();
            Instantiate(projectile, transform.position + (target.position - transform.position).normalized,
            Quaternion.LookRotation(target.position - transform.position));
            Invoke("Stop", 3f);
        }
    }

    void Stop()
    {
        shooting = false;

    }

}