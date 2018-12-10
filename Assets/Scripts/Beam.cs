using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

    public Transform leftPlatform;
    public Transform rightPlatform;
    public Transform lPos;
    public Transform rPos;
    Quaternion lRot;
    Quaternion rRot;
    public float turnAmount;
    public  int rightWeight = 0;
    public int leftWeight = 0;


    void Start () {
        lRot = leftPlatform.transform.rotation;
        rRot = rightPlatform.transform.rotation;
    }
	
	void Update () {
        //Keep platforms at zero rotation
        leftPlatform.transform.rotation = lRot;
        rightPlatform.transform.rotation = rRot;
        leftPlatform.transform.position = lPos.position;
        rightPlatform.transform.position = rPos.position;

        transform.rotation = new Quaternion(turnAmount, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        //Balance
        if (leftWeight > rightWeight && turnAmount > -0.24f){
            turnAmount -= Time.deltaTime * 0.1f;
        }

        if (leftWeight < rightWeight && turnAmount < 0.24f)
        {
            turnAmount += Time.deltaTime * 0.1f;
        }

        if (leftWeight == rightWeight && turnAmount > 0)
        {
            turnAmount -= Time.deltaTime * 0.1f;
        }

        if (leftWeight == rightWeight && turnAmount < 0)
        {
            turnAmount += Time.deltaTime * 0.1f;
        }
    }
   
    public void AddWeightLeft(){
        leftWeight++;
    }
    public void AddWeightRight()
    {
        rightWeight++;
    }

    public void SubtractWeightLeft()
    {
        leftWeight--;
    }
    public void SubtractWeightRight()
    {
        rightWeight--;
    }
}
