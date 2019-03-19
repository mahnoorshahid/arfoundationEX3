using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
/// 
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
[RequireComponent(typeof(ARSessionOrigin))]
public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARSessionOrigin m_SessionOrigin;
    

    public GameObject[] m_PlacedPrefab;
    private ARPlaneManager arManager;
    private tapToCollect tapScript;
    public Ray ray;
    public string ObjectName;

    public Text TotalText;
    private int count;


    int planeCounter;
    public int instanceCounter;


  
    public GameObject spawnedObject { get; private set; }

    void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
        arManager = GetComponent<ARPlaneManager>();
        arManager.planeAdded += OnPlaneDetected;
        SetCountText();
        tapScript.SetCountTextTotal();
        InvokeRepeating("TimeDelay", 0, 2);
        InvokeRepeating("spawn", 0, 3);
    }

    private void Start()
    {
        count = 0;
        instanceCounter = 0;
        TotalText.text = "Total " + instanceCounter.ToString();
    }

    void Update()
    {
        RegisterModelTouch();
       

    }



    public void RegisterModelTouch()
    {

        Touch touch = Input.touches[0];
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out hit))
        {
         //var collectScript = GetComponent<tapToCollect>();
           tapScript = hit.collider.gameObject.GetComponent<tapToCollect>();
           var objectsToCollect = hit.collider.gameObject.GetComponent<ObjectsToCollect>();
            var noHit = hit.collider.gameObject.GetComponent<GameObject>();
           
            if (noHit != null)

            {
                //tapScript.RegisterModelTouch();
                tapScript.registerTouch();


              
          //  Destroy(hit.collider.gameObject.GetComponent<GameObject>());
              ObjectName = hit.collider.gameObject.name;

            }
        }
    }


    private void OnPlaneDetected(ARPlaneAddedEventArgs args)
    {
        Instantiate(m_PlacedPrefab[Random.Range(0, m_PlacedPrefab.Length - 1)], args.plane.boundedPlane.Center, Quaternion.identity);
    }

    public void SetCountText()
    {
    tapScript = GetComponent<tapToCollect>();

        TotalText.text = "Total " + tapScript.count.ToString();
        TotalText.text = "Total " + instanceCounter.ToString();
    }

    void TimeDelay()
    {

        if (planeCounter > 1 && instanceCounter <= 100)
        {
            spawn();

        }
        else if (planeCounter > 100)
        {
            CancelInvoke();
        }

    }

    public void spawn()
    {
        var random = Random.Range(-2.0f, 2.0f);
        var tapScriptTwo = GetComponent<tapToCollect>();

        tapScript.count++;

        Instantiate(m_PlacedPrefab[Random.Range(0, m_PlacedPrefab.Length - 1)], transform.position + new Vector3(random, transform.position.y, random), Quaternion.identity);
        instanceCounter++;
    }


}
