using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Rendering;


namespace CompleteProject
{
	public class EnemyMovement : MonoBehaviour
    {
        public GameObject[] players;
        EnemyHealth enemyHealth;
		Broom BroomThing;                                   // Reference to this enemy's health.
		public NavMeshAgent nav;            // Reference to the nav mesh agent.

        public Transform target;
        public Transform target1;
        public Transform target2;
        public Transform target3;
        public int targetNum;
		public SkinnedMeshRenderer Skin;
		public Material Frozen, Normal;
		public Transform MahHead;
		public Rigidbody rb;
		public bool slowed = false;
		public bool frozen = false;
        public int hitsUntilFrozen = 3;
		public float slowedSpeed1 = 1.5f;
        public float slowedSpeed2 = .5f;
        public EnemyShoot Shoot;
        public EnemyAttack Attack;
        void Start()
        {
            // Set up the references.
            enemyHealth = GetComponent <EnemyHealth> ();
            players = GameObject.FindGameObjectsWithTag("Player");
            nav = GetComponent <NavMeshAgent> ();
			rb = GetComponent <Rigidbody> ();
            Shoot = GetComponent<EnemyShoot>();
            Attack = GetComponent<EnemyAttack>();

            players[0] = GameObject.FindWithTag("Ice");
            players[1] = GameObject.FindWithTag("Fire");
            players[2] = GameObject.FindWithTag("Earth");
            
            targetNum = Random.Range(0, 3);

            target = players[targetNum].transform;
            target1 = players[0].transform;
            target2 = players[1].transform;
            target3 = players[2].transform;
        }

        void Update ()
        {
            target = players[targetNum].GetComponent<Transform>();
            PathToPlayer ();
			SlowedFrozenCheck ();
			if (frozen)
			{
				//Frozen.transform.position = MahHead.transform.localPosition;
				//Frozen.transform.IsChildOf (MahHead);
				Skin.material = Frozen;

			}
			else
			{
				Skin.material = Normal;
			}
        }

        private void FixedUpdate()
        {
            Mathf.Clamp(rb.velocity.x, 1f, 10f);
            Mathf.Clamp(rb.velocity.y, 1f, 10f);
        }

        void PathToPlayer()
		{
            // ... disable the nav mesh agent.
            var health = target.GetComponent<PlayerHealth>();

            if (health.isDead == true)
            {
          
                targetNum = Random.Range(0, 3);
                return;
            }
            if (hitsUntilFrozen <= 0)
		    {
		        nav.enabled = false;
                return;

		    }


		    if (enemyHealth.currentHealth <= 0 )
		    {
		        nav.enabled = false;
		        return;

		    }

		    if (!HealthManager.instance.allPlayersAlive)
		    {
		        nav.enabled = false;
		        return;
		    }

            if (Shoot.shooting == true)
            {
                nav.enabled = false;
                return;
            }

            var distBetween1 = target1.position - gameObject.transform.position;
            var dist1 = distBetween1.magnitude;
            var distBetween2 = target2.position - gameObject.transform.position;
            var dist2 = distBetween2.magnitude;
            var distBetween3 = target3.position - gameObject.transform.position;
            var dist3 = distBetween3.magnitude;

            var distBetween = target.position - gameObject.transform.position;
            var dist = distBetween.magnitude;
            if (dist1 < dist)
            {
                targetNum = 0;
                
            }
            if (dist2 < dist)
            {
                targetNum = 1;
                
            }
            if (dist3 < dist)
            {
                targetNum = 2;
                
            }


            var capsuleColl = target.GetComponent<CapsuleCollider>();

		    var radius = capsuleColl.radius;

		    if (dist < radius)
		    {
		        nav.enabled = false;
		        return;

		    }
            
           
		    nav.enabled = true;
		    //Debug.Log("I Am talking to the nav mesh bitch");
		    // ... set the destination of the nav mesh agent to the player.

		    nav.SetDestination(target.position);
		    //Debug.Log(gameObject.name + " moving towards " + target.name);
		    return;


        }

		void SlowedFrozenCheck()
		{
			if (slowed && hitsUntilFrozen == 2 && !frozen) 
			{
				nav.speed = slowedSpeed1;
                Debug.Log(gameObject.name + " nav speed is " + nav.speed);
			}

            if (slowed && hitsUntilFrozen == 1 && !frozen)
            {
                nav.speed = slowedSpeed2;
                Debug.Log(gameObject.name + " nav speed is " + nav.speed);
            }

            if (slowed && hitsUntilFrozen == 0 && !frozen) 
			{
				rb.constraints = RigidbodyConstraints.FreezeAll;
				nav.speed = 0;
                Debug.Log(gameObject.name + " nav speed is " + nav.speed);
                frozen = true;
				Instantiate (Frozen);
			}
		}

        void Stun()
        {
            nav.enabled = false;
        }

        void Unstun()
        {
            nav.enabled = true;
        }

        public void StartPushing(GameObject broom)
        {
            StartCoroutine(PushBack(broom));
        }
        public IEnumerator PushBack(GameObject broom)
        {
            int counter = 3;
            while (counter > 0)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + broom.transform.forward.x, gameObject.transform.position.y + broom.transform.forward.y, gameObject.transform.position.z + broom.transform.forward.z);
                counter--;
                yield return null;
            }
            Debug.Log("I am being pushed.");
            yield return null;
        }
    }
}
