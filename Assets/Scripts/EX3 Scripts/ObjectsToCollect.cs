using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.UI;

public class ObjectsToCollect : MonoBehaviour
{

    private ARSessionOrigin arOrigin;
    private PlaceOnPlane placeOnPlane;
    private tapToCollect tapScript;

    public Text coyoteCount;
    private int coyoteNum;

    public Text gooseCount;
    private int gooseNum;

    public Text beaverCount;
    private int beaverNum;

    public Text bluejayCount;
    private int bluejayNum;

    public Text pigeonCount;
    private int pigeonNum;


    public Text raccoonCount;
    private int raccoonNum;

    public Text squirrelCount;
    private int squirrelNum;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        placeOnPlane = GetComponent<PlaceOnPlane>();
        placeOnPlane = GetComponent<PlaceOnPlane>();
        //var Name = placeOnPlane.ObjectName;

        string Name = tapScript.ObjectName;
    }



    public void ObjectPicked(string Name)
    {
        switch (Name)
        {
            case "coyote":
                coyoteNum++;
                coyoteCount.text = coyoteCount.ToString();

                break;

            case "canada_goose":
                gooseNum++;
                gooseCount.text = gooseNum.ToString();

                break;

            case "beaver2":
                beaverNum++;
                beaverCount.text = beaverCount.ToString();

                break;
            case "bluejay 3":
                bluejayNum++;
                bluejayCount.text = bluejayCount.ToString();

                break;

            case "pigeon_coloured":
                pigeonNum++;
                pigeonCount.text = pigeonCount.ToString();

                break;

            case "raccoon":
                raccoonNum++;
                raccoonCount.text = raccoonCount.ToString();

                break;
            case "squirrel_coloured":
                squirrelNum++;
                squirrelCount.text = squirrelCount.ToString();

                break;
        }

    }



    private void Update()
    {

    }


  public void GetRay()
    {
       
      Destroy(this.gameObject);
          
       
    }

}