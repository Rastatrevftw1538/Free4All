using UnityEngine;

namespace CompleteProject
{
	public class Fireball : MonoBehaviour
    {
        bool hasImpacted;
        public GameObject fireEffect;
		public GameObject Explo;
        public float radius = 20;
        public int damage;
        Rigidbody rb;
		[SerializeField]
        GameObject target;
		public float time = 0f;
	

        // Use this for initialization
        void Start()
		{
			time = Time.deltaTime;
            rb = GetComponent<Rigidbody>();
		    Physics.IgnoreCollision(rb.GetComponent<Collider>(), GetComponent<Collider>());
            //rb.AddForce(Vector3.forward,ForceMode.Acceleration);
        }

        private void Update()
        {
		//	transform.Translate(target.transform.position * time);


		}

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.tag == "Target")
        //    {
        //        Impact();
        //        hasImpacted = true;
        //    }
        //}

        private void OnCollisionEnter(Collision collision)
        {
			if (collision.gameObject.tag == "Shootable") {
				HealthPack healthPack = collision.collider.GetComponent<HealthPack> ();
				Treasure loot = GetComponent<Treasure> ();

				if (healthPack != null) {
					Debug.Log ("I am hit");
					healthPack.Die();
				}
				if (loot != null)
				{
					loot.Die();
				}
			}

            Impact();
            hasImpacted = true;
        }

        void Impact()
        {
			Instantiate (Explo, transform.position, transform.rotation);
            var myFire = Instantiate(fireEffect, transform.position, transform.rotation);

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

			Debug.Log("I IS HEAR");

            foreach (Collider nearbyObjects in colliders)
            {
                EnemyHealth enemyHealth = nearbyObjects.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
            Destroy(gameObject);

            Destroy(myFire , 1f);
            //DestroyImmediate(fireEffect);
        }
    }
}
