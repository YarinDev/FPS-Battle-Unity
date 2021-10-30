using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject camera;
    public GameObject gunInBox;
    public GameObject gunInHand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        for(int i=0; i<camera.transform.childCount; i++)
        {
            camera.transform.GetChild(i).gameObject.setActive(false);
        }

        gunInHand.SetActive(false);
        gunInBox.SetActive(false);
        gunInHand.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
