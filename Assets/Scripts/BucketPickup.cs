using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketPickup : MonoBehaviour
{

    GameObject player;
    float time = 1;
    float count = 0;
    public bool test;
    public bool canPlaceLeft;
    public bool canPlaceRight;
    public Beam beam;
    public bool wait;
    public bool held;
    public float bucketHeight = 1;
    public Transform pp_l;
    public Transform pp_r;
    public bool locked;
    public BucketPickup otherBucket;
    public bool nearTrough;
    bool isLeft;
    bool placedLeft;
    bool placedRight;
    public bool isEmpty = false;
    public GameObject blocker;
    WaterSwitch waterSwitch;

    Rigidbody rb;


    // Use this for initialization
    // Update is called once per frame
    void Start()
    {
        waterSwitch = GetComponent<WaterSwitch>();
        rb = GetComponent<Rigidbody>();

        if(GameObject.Find("RollerBall") != null)
        {
            player = GameObject.Find("RollerBall");
        }else{
            player = GameObject.Find("ThirdPersonController");
        }


           ;
        print(player.name);
       // canPlaceLeft = true;

    }

    void Update()
    {
        if (wait == true) Timer();
        if (held == true)
        {
            if (nearTrough == true && Input.GetKeyDown(KeyCode.Q))
            {
                if (isEmpty == true)
                {
                    waterSwitch.Fill();
                    isEmpty = false;
                }
                else
                {
                    waterSwitch.Empty();
                    isEmpty = true;
                }
            }
            Holding();
    }
        if(placedLeft == true) transform.position = pp_l.position;
        if(placedRight == true) transform.position = pp_r.position;
 


    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Left Platform")
    //    {
    //        test = true;

    //        canPlaceLeft = true;
    //        print("Near Left");
    //    }

    //    if (other.gameObject.name == "Right Platform")
    //    {
    //        canPlaceRight = true;
    //        print("Near Right");
    //    }


    //}
    void OnTriggerStay(Collider other)
    {
       
        if (wait == false)
        {
            if (locked == false && other.gameObject == player && Input.GetKeyDown(KeyCode.Space))
            {
                if (otherBucket.held == true) return;
                if (held == false)
                {
                    blocker.SetActive(true);

                    print("held is true");
                    held = true;
                }
                else
                {
                    blocker.SetActive(false);

                    Drop();
                    print("held is false");
                    held = false;
                }
              
                print("pressed space");
                count = 0;
                wait = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
            if(other.gameObject.name == "Left Platform")
            {
                canPlaceLeft = false;
                print("exit L");
            }
    
            if (other.gameObject.name == "Right Platform")
            {
                canPlaceRight = false;
                print("exit R");
            }
    }
      
    void Timer(){
        count = count + Time.deltaTime;
        if (count < time)
        {
            wait = true;
        }
        else
        {
            wait = false;
        }
    }
    void Holding()
    {
        print("holding");
        rb.isKinematic = true;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + bucketHeight, player.transform.position.z);
       
        if (placedLeft == true) 
        { 
            placedLeft = false;
            if (isEmpty == false) beam.SubtractWeightLeft();
        }
        if (placedRight == true)
        {
            if (isEmpty == false) beam.SubtractWeightRight();
            placedRight = false;
        }
    }
    void Drop()
    {

        if (canPlaceLeft == true)
        {
            print("placed Left");
            placedLeft = true;
            transform.position = pp_l.position;
            if (isEmpty == false) beam.AddWeightLeft();
            return;
        }

        if (canPlaceRight == true)
        {
            print("placed Right");
            placedRight = true;
            transform.position = pp_r.position;
            if (isEmpty == false) beam.AddWeightRight();
            return;
        }

        print("place null");

        rb.isKinematic = false;
        transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
    }
}
