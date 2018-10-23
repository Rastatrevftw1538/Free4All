using UnityEngine;
using UnityEngine.AI;


namespace CompleteProject
{

	public class Broom : MonoBehaviour
	{
	    public float pushForce = -50f;

		public string attackButton_Win;
        public string attackButton_Mac;

	    public int damagePerAttack = 1;

	    public bool Attack;

        public ParticleSystem Woosh;

	    void Start()
	    {
	        Attack = true;
	    }

	    void Update()
	    {
            if (Input.GetButton(attackButton_Win) || Input.GetButton(attackButton_Mac))
            {
                if (!HealthManager.instance.earthHealth.isDead)
                {
                    if (Attack != false)
                    {
                        Woosh.Play();
                        Invoke("Stop", 0.25f);
                        Attack = false;
                        Invoke("Cooldown", 2f);
                    }
                }
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if (!HealthManager.instance.earthHealth.isDead)
            {
              
                if (Input.GetButton(attackButton_Win) && col.gameObject.tag == "Enemy" || col.gameObject.tag == "IceBlock" || Input.GetButton(attackButton_Win) && col.gameObject.tag == "Acid")
                {
                
                    
                        EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();

                        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();

                        EnemyMovement enemyMovement = col.gameObject.GetComponent<EnemyMovement>();

                        Acid acid = col.gameObject.GetComponent<Acid>();

                        
                        Invoke("StopFalling", 0f);

                        Invoke("Stop", .5f);
                        //if (Attack == true)
                        //{
                            Attack = false;
                            Woosh.Play();
                            Debug.Log("Broom Firing");
                            if (col.gameObject.tag == "Enemy")
                            {
                                enemyHealth.TakeDamage(damagePerAttack);
                                enemyMovement.StartPushing(gameObject);
                            }

                            if (col.gameObject.tag == "Acid")
                            {
                            acid.StartPushing(gameObject);
                            }
                       
                            
                            //col.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * pushForce, ForceMode.Impulse);
                            rb.constraints = RigidbodyConstraints.None;
                            Invoke("Cooldown", 3f);
                        //}                   
                }


                if (Input.GetButton(attackButton_Mac) && col.gameObject.tag == "Enemy" || col.gameObject.tag == "IceBlock" || Input.GetButton(attackButton_Mac) && col.gameObject.tag == "Acid")
                {


                    EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();

                    Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();

                    EnemyMovement enemyMovement = col.gameObject.GetComponent<EnemyMovement>();

                    Acid acid = col.gameObject.GetComponent<Acid>();

                    Invoke("StopFalling", 0f);

                    if (Attack == true)
                    {
                        Attack = false;
                        Woosh.Play();
                        Debug.Log("Broom Firing");
                        enemyHealth.TakeDamage(damagePerAttack);
                        acid.StartPushing(gameObject);
                        enemyMovement.StartPushing(gameObject);

                        //col.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * pushForce, ForceMode.Impulse);
                        rb.constraints = RigidbodyConstraints.None;
                        Invoke("Cooldown", 3f);
                    }
                }
        }   }

	    

        void Stop()
        {
            Woosh.Stop();
        }

        void StopFalling(Collider col)
        {
            if (col.gameObject.tag == "IceBlock")
            {
                col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }

            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
        }

	    void Cooldown()
	    {
	        Attack = true;
	    }
    }
}
