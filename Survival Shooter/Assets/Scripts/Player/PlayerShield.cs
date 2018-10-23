
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class PlayerShield : MonoBehaviour
    {
        public Rigidbody getRigidBody;
        public GameObject Bubble;
        private GameObject Shield;
        public bool Orb;
        public ArrayList Gm;

        public GameManager Array;
        //public EnemyAttack Ea;
        // Use this for initialization
        void Awake()
        {
            //getRigidBody = GetComponent<Rigidbody>();
            Orb = false;
            //Gm[0] = Array.players[0];


        }

        //Update is called once per frame
        //void Update()
        //{
        //    if (Ea != null)
        //    {
        //        if (Orb == true)
        //        {
        //            Ea.attackDamage = 0;
        //        }
        //        else if (Orb == false)
        //       {
        //            Ea.attackDamage = 10;
        //        }
        //   }
        //}
        private void Update()
        {
            foreach (GameObject player in Array.players)
            {
                //distnace check to each player

                //find the exit dude - campfire
                var Ice = GameObject.FindGameObjectWithTag("Ice");

                var posIce = Ice.gameObject.transform.position;

                var posPlayer = player.gameObject.transform.position;

                var dist = (posIce.x - posPlayer.x) * (posIce.x - posPlayer.x) + (posIce.y - posPlayer.y) * (posIce.y - posPlayer.y);

                float ExitDistSq = 3 * 3;

                Debug.Log(dist);

                var canExit = dist > ExitDistSq;

            }
        }
        void OnTriggerEnter(Collider trig)
        {

			if (trig.gameObject.tag == "Fire" || trig.gameObject.tag == "Ice" || trig.gameObject.tag == "Earth")
            {
                if(Orb == false)
                {
                    Orb = true;
 
                    Shield.transform.parent = getRigidBody.transform;
					Shield.SetActive(true);
                    Debug.Log("Object Entered The Trigger " + trig.gameObject.name);
                }
            }
        }

        void OnTriggerExit(Collider trig)
        {
            if (trig.gameObject.tag == "Fire" || trig.gameObject.tag == "Ice" || trig.gameObject.tag == "Earth")
            {
                if (Orb == true)
                {
                    Orb = false;
                    Destroy(Shield, 0f);
                    Debug.Log("Object Exited the Trigger " + trig.gameObject.name);
                }
            }
        }   
    }   
}