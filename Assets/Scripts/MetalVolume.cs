using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalVolume : MonoBehaviour
{



    public GameObject full;
    public GameObject empty;
    public bool isFull;
    public TroughVolume troughVolume;
    BucketPickup bucketPickup;
    WaterSwitch waterSwitch;
    bool canSwitch = true;
    float time = 1;
    float currentTime;
    bool wait;


    void Update()
    {
        if (wait == true) Wait();
    }
    void Start()
    {
        if (isFull) Fill();
        isFull = true;
    }
    public void Fill()
    {
        full.SetActive(true);
        empty.SetActive(false);
        print("filling");
        isFull = true;
    }

    public void Empty()
    {
        empty.SetActive(true);
        full.SetActive(false);
        print("emptying");
        isFull = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag ==  "bucket")
        {
            print("metal Bucket");
            bucketPickup = other.gameObject.GetComponent<BucketPickup>();
            waterSwitch = other.gameObject.GetComponent<WaterSwitch>();

            if (bucketPickup.held == true && Input.GetKeyDown(KeyCode.Q) && wait == false)
            {

                if(isFull == true && bucketPickup.isEmpty == true){
                    waterSwitch.Fill();
                    Empty();
                    bucketPickup.isEmpty = false;
                    wait = true;
                    return;
                }
                if (isFull == false && bucketPickup.isEmpty == false)
                {
                    waterSwitch.Empty();
                    Fill();
                    bucketPickup.isEmpty = true;
                    wait = true;

                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "bucket")
        {

        }
    }

    void Wait(){

        currentTime = currentTime + (Time.deltaTime * 0.2f);
        if(currentTime > time){
            wait = false;
        }
    }
}
