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
    public int count;
    public Text TotalText;


    public string ObjectName;


    private void Awake()
    {
       
    }

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        count = 0;
        SetCountText();

    }

    void Update()
    {
   
        RegisterModelTouch();

    }



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
                SetCountTextTotal();
                count++;
                //placeOnPlane.SetCountText();
                placeOnPlane.instanceCounter++;

                ObjectName = hit.collider.gameObject.name;

            }
        }
    }


    public void registerTouch()
    {
       // placeOnPlane.spawn();
        Destroy(this.gameObject);
        count++;
        placeOnPlane.instanceCounter++;
    }

    public void SetCountText()
    {
      TotalText.text = "Total " + count.ToString();

    }

    public void SetCountTextTotal()
    {
        placeOnPlane.TotalText.text = "Total " + count.ToString();

    }


}


