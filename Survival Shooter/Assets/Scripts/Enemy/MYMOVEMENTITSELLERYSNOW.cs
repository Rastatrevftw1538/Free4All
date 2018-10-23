using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MYMOVEMENTITSELLERYSNOW : MonoBehaviour
{

    public string[] playerTags;
    public GameObject target;
    public Rigidbody myBody;
    public Transform startPoint;
    public Transform endPoint;
    public bool blocked = false;
    public float speed = 10f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag(playerTags[Random.Range(0, 2)]);
        myBody = GetComponent<Rigidbody>();
    }

    IEnumerator GoLeft()
    {
        // This will wait 1 second like Invoke could do, remove this if you don't need it
        yield return new WaitForSeconds(1);


        float timePassed = 0;
        while (timePassed < 1)

        {
            // Code to go left here
            timePassed += Time.deltaTime;
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
            myBody.AddRelativeForce(new Vector3(10, 0, 10));
            yield return null;
        }
    }

    // Update is called once per frame
        void FixedUpdate()
    {

        Vector3 targetDir = target.transform.position - gameObject.transform.position;
        targetDir.Normalize();
        float rotation_z = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        Quaternion targetQuat = Quaternion.Euler(0f, 0f, rotation_z);

        myBody.AddRelativeForce(new Vector3(0, 0, 10));
        blocked = Physics.Linecast(startPoint.position, endPoint.position);
        Debug.DrawLine(startPoint.position, endPoint.position, Color.white);

        if (blocked == true)
        {
            StartCoroutine(GoLeft());

        }
        else if (blocked == false)
        {
            //transform.LookAt(target.transform);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuat, Time.deltaTime);
            myBody.AddRelativeForce(new Vector3(10, 0, 10));
        }

        if (speed > 10f)
        {
            speed = 10f;
        }

    }
}
