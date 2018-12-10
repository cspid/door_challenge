using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{

    public TroughVolume trough;
    public GameObject[] doors;
    public Animator animator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (trough.volume == 0){
            doors[0].SetActive(true);
            doors[1].SetActive(false);
            doors[2].SetActive(false);
            doors[3].SetActive(false);
        }
        if (trough.volume == 1)
        {
            doors[0].SetActive(false);
            doors[1].SetActive(true);
            doors[2].SetActive(false);
            doors[3].SetActive(false);
        }

        if (trough.volume == 2)
        {
            doors[0].SetActive(false);
            doors[1].SetActive(false);
            doors[2].SetActive(true);
            doors[3].SetActive(false);
        }

        if (trough.volume == 3)
        {
            doors[0].SetActive(false);
            doors[1].SetActive(false);
            doors[2].SetActive(false);
            doors[3].SetActive(true);
            animator.SetTrigger("open");
        }
    }
}
