using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSwitch : MonoBehaviour {


    public GameObject full;
    public GameObject empty;
    public bool isFull;
    public TroughVolume troughVolume;
    BucketPickup bucketPickup;

    // Use this for initialization
    void Start () {
        bucketPickup = GetComponent<BucketPickup>(); 
	}

    public void Fill()
    {
        full.SetActive(true);
        empty.SetActive(false);
        print("filling");
        if(bucketPickup.nearTrough) troughVolume.volume--;
    }

    public void Empty()
    {
        empty.SetActive(true);
        full.SetActive(false);
        print("emptying");
        if (bucketPickup.nearTrough) troughVolume.volume++;
    }
}
