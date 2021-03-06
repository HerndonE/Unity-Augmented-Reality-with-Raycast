﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{

    //public int distanceToCastRay = 10;

    private string name = "Name: ";
    private string position = "Position: ";
    private string tag = "Tag: ";

    public Text nameText;
    public Text positionText;
    public Text tagText;

    public AudioSource audioData;

    private bool stopPlaying = false;


    void Start()
    {
        nameText.text = name;
        positionText.text = position;
        tagText.text = tag;
    }

    void Update()
    {
        /* Vector3 fwd = transform.TransformDirection(Vector3.forward);

         if (Physics.Raycast(transform.position, fwd, distanceToCastRay))
             print("There is something in front of the object!");
        */


        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            nameText.text = name + hit.collider.gameObject.name;
            positionText.text = position + hit.collider.transform.position;
            tagText.text = tag + hit.collider.gameObject.tag;


            if (hit.collider.gameObject.tag == "tank")
            {
                if (!stopPlaying)
                {
                    audioData.Play();
                    stopPlaying = true;
                }

            }
            else
            {
                if (stopPlaying)
                {
                    audioData.Stop();
                    stopPlaying = false;
                }
            }

            //Debug.Log(name + hit.collider.gameObject.name);
            //Debug.Log(position + hit.collider.transform.position);
        }
        else
        {
            nameText.text = name;
            positionText.text = position;
            tagText.text = tag;
        }

    }
}
