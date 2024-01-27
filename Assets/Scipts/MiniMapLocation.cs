using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class MiniMapLocation : MonoBehaviour
{
    public GameObject DungeonSlot;
    public GameObject Manager;
    public Camera MiniMapCamera;

    //these need to be a lsit of cameras
    public List<Camera> OtherCameraList = new List<Camera>();
    //[SerializeField]private GameObject[] OtherCamera;
    private Button button;
    [SerializeField] GameObject CameraObject;
    public GameObject[] Heros;
 
    private Image _image;
    // Start is called before the first frame update

    private void Awake() {
        _image = GetComponent<Image>();
        button = GetComponent<Button>();
        //check the children of the CameraObject for a Camera component
       //get mini map camera
        

        
        if (button == null)
        {
            Debug.LogError("Button component not found on the GameObject with SpawnRoom script.");
        }
        else
        {
            Debug.Log("Button component found successfully.");
            // Add the listener to the button
            button.onClick.AddListener(CameraMove);
            
        }

        
    }
    void Update()
    {
        //if statement to see if the room camera is the one in the room
        //if it is then dont add it to the list
        if (CameraObject.GetComponent<Camera>() != null)
        {
            if (!OtherCameraList.Contains(CameraObject.GetComponent<Camera>()))
            {
                OtherCameraList.Add(CameraObject.GetComponent<Camera>());
            }
        }
        MiniMapCamera = CameraObject.GetComponentInChildren<Camera>();
        //make a list of all the cameras in the scene
        
        GameObject[] OtherCamera = GameObject.FindGameObjectsWithTag("DungeonCamera");
        foreach (GameObject c in OtherCamera)
        {
            //add the camera to the list only once
            //dont add the camera that is in the room
            //add the cameras if the list is empty
            if (c != CameraObject)
            {
                if (!OtherCameraList.Contains(c.GetComponent<Camera>()))
                {
                    OtherCameraList.Add(c.GetComponent<Camera>());
                }
            }

        }
        Heros = GameObject.FindGameObjectsWithTag("Player");

        if (DungeonSlot.GetComponent<DungeonSlot>().roomplayed == true)
        {
            _image.color = Color.green;

            // is hero in the room
            foreach (GameObject hero in Heros)
            {
                // check to see if the hero is in the room
                Collider heroCollider = hero.GetComponent<Collider>();
                Collider CameraCollider = CameraObject.GetComponent<Collider>();

                if (heroCollider != null && CameraCollider != null)
                {
                    if (heroCollider.bounds.Intersects(CameraCollider.bounds))
                    {
                        _image.color = Color.yellow;
                        Debug.Log("Hero in room");
                    }
                }
            }
        }
        else
        {
            _image.color = Color.red;
        }
    }

    void CameraMove()
    {

        //disable all the other cameras
        foreach (Camera c in OtherCameraList)
        {
            c.enabled = false;
        }
        //enable the mini map camera
        MiniMapCamera.enabled = true;

    }


}
