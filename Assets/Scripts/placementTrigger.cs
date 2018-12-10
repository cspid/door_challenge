using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementTrigger : MonoBehaviour {

    BucketPickup bucketPickup;
    public bool isLeft;
    public Transform placementL;
    public Transform placementR;


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "bucket")
        {
            bucketPickup = other.gameObject.GetComponent<BucketPickup>();
            print("bucket");
            if (isLeft == true && Vector3.Distance(transform.position, placementL.position) < 2)
            {
                bucketPickup.canPlaceLeft = true;
            }

            if (isLeft == false && Vector3.Distance(transform.position, placementR.position) < 2)
            {
                bucketPickup.canPlaceRight = true;
            }
        }
    }


        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "bucket")
            {
                print("bucket Out");
                if (isLeft == true)
                {
                    bucketPickup.canPlaceLeft = false;
                }

                if (isLeft == false)
                {
                    bucketPickup.canPlaceRight = false;
                }
            }
        }
	
	void Update () {
		
	}
}
