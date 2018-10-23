using System.Collections;
using System.Collections.Generic;
using CompleteProject;
using UnityEngine;

public class Acid : MonoBehaviour {

    bool hasImpacted;
    public float radius = 1;
    public int damage;
    Rigidbody rb;
    [SerializeField]
    GameObject target;
    public float time = 5f;
    public GameObject Projectile;

    // Use this for initialization
    void Start()
    {
        time = Time.deltaTime;
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(rb.GetComponent<Collider>(), GetComponent<Collider>());
        Projectile.GetComponent<Rigidbody>().velocity = Projectile.transform.forward * 6;
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
        Impact();
        hasImpacted = true;
        Debug.Log(collision.gameObject);
    }

    void Impact()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        //Debug.Log("I IS HEAR");

        foreach (Collider nearbyObjects in colliders)
        {
            PlayerHealth playerHealth = nearbyObjects.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
        Destroy(gameObject);


        //DestroyImmediate(fireEffect);
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

