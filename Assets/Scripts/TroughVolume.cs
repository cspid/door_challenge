using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroughVolume : MonoBehaviour {

    public Transform oneThird;
    public Transform twoThirds;
    public Transform full;
    public int volume;
    BucketPickup bucketPickup;
    // Use this for initialization
    void Empty()
    {
        full.gameObject.SetActive(false);
        oneThird.gameObject.SetActive(false);
        twoThirds.gameObject.SetActive(false);

    }

    void Full () {
        full.gameObject.SetActive(true);
        oneThird.gameObject.SetActive(false);
        twoThirds.gameObject.SetActive(false);
        
    }

    void OneThird()
    {
        full.gameObject.SetActive(false);
        oneThird.gameObject.SetActive(true);
        twoThirds.gameObject.SetActive(false);
    }

    void TwoThirds()
    {
        full.gameObject.SetActive(false);
        oneThird.gameObject.SetActive(false);
        twoThirds.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if (volume == 0) Empty();
        if (volume == 1) OneThird();
        if (volume == 2) TwoThirds();
        if (volume == 3) Full();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Bucket Container"){
            print("bucket In Range");
            bucketPickup = other.transform.GetComponent<BucketPickup>();
            if(bucketPickup.held == true){
                bucketPickup.nearTrough = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "bucket")
        {
            bucketPickup = other.transform.GetComponent<BucketPickup>();
            bucketPickup.nearTrough = false;             
        }
    }
}
