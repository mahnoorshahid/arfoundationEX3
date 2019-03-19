using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;

public class tapToCollect : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject objectToPlace;
    //public GameObject placementIndicator;

    private ARSessionOrigin arOrigin;
    private PlaceOnPlane placeOnPlane;
    private ObjectsToCollect objectsToCollect;


  // public int count;
    //public Text TotalText;


    public string ObjectName;


    private void Awake()
    {
        placeOnPlane = GameObject.Find("AR Session Origin").GetComponent<PlaceOnPlane>();
        objectsToCollect = GameObject.Find("AR Session Origin").GetComponent<ObjectsToCollect>();
    }


    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        //count = 0;
        SetCountText();

    }

    void Update()
    {
   
        //RegisterModelTouch();

    }


    //TAP TO COLLECT
    public void RegisterModelTouch()
    {

      

        Touch touch = Input.touches[0];
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out hit))
        {
            var noHit = hit.collider.GetComponent<BoxCollider>();
            if (noHit != null)

            {

                // gameObject.name
                registerTouch();
              // SetCountText();
             //  count++;
                placeOnPlane.totalcount++;
                placeOnPlane.SetCountText();

       

               //ObjectName = hit.collider.gameObject.name;

            }
        }
    }


    public void registerTouch()
    {
        // placeOnPlane.spawn();
        placeOnPlane.totalcount++;
        placeOnPlane.instanceCounter--;
        objectsToCollect.ObjectPicked(this.gameObject.name);
        Destroy(this.gameObject);
       // count++;
        
    }

    public void SetCountText()
    {
     //s TotalText.text = "Total " + count.ToString();
        placeOnPlane.TotalText.text = "Total " + placeOnPlane.totalcount.ToString();
    }

 

}


