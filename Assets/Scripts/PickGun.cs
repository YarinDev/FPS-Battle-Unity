using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickGun : MonoBehaviour
{
    public GameObject camera;
    public GameObject gunInBox;
    public GameObject gunInHand;
    public Text text ;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnMouseDown()
    {
        Transform child;
        // for (int i = 0; i < camera.transform.childCount; i++)
        // {
        //     child = camera.transform.GetChild(i);
        //     child.gameObject.SetActive(false);
        // }
        
        gunInBox.SetActive(false);
        gunInHand.SetActive(true);
        text.text = "Weapon collected! Attack Enemies!";

    }

    // Update is called once per frame
    void Update()
    {
    }
}