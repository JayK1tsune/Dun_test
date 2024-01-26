using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class MiniMapLocation : MonoBehaviour
{
    public GameObject DungeonSlot;
    public GameObject Manager;
    public Camera Camera;

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
        Camera = CameraObject.GetComponentInChildren<Camera>();

        
        if (button == null)
        {
            Camera = DungeonSlot.GetComponentInChildren<Camera>();
            Debug.LogError("Button component not found on the GameObject with SpawnRoom script.");
        }
        else
        {
            Debug.Log("Button component found successfully.");
            // Add the listener to the button
            button.onClick.AddListener(CameraMove);
            //button.onClick.AddListener(AddCamera);
        }

        
    }
    void Update()
    {
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
        Camera = CameraObject.GetComponentInChildren<Camera>();

        // Disable all other cameras if they are not the camera attached to the script
        foreach (Camera c in OtherCameraList)
        {
            if (c != Camera)
            {
                c.gameObject.SetActive(false);
            }
        }

        // Reset the list of cameras
        OtherCameraList.Clear();

        // Add the camera to the list only once
        // Don't add the camera that is in the room
        if (!OtherCameraList.Contains(Camera))
        {
            OtherCameraList.Add(Camera);
        }

        AddCamera();
    }

    void AddCamera()
    {
        // Clear the list and repopulate it
        OtherCameraList.Clear();
        GameObject[] otherCameras = GameObject.FindGameObjectsWithTag("DungeonCamera");

        foreach (GameObject c in otherCameras)
        {
            Camera cameraComponent = c.GetComponent<Camera>();

            // Add the camera to the list only once
            // Don't add the camera that is in the room and not the one in CameraObject
            if (c != CameraObject && cameraComponent != null && cameraComponent != Camera)
            {
                OtherCameraList.Add(cameraComponent);
            }
        }
    }



}
