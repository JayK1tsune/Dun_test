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
    [SerializeField]private GameObject[] OtherCamera;
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
        }

        
    }
    void Update()
    {
    OtherCamera = GameObject.FindGameObjectsWithTag("DungeonCamera");
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
        Camera.gameObject.SetActive(true);
        foreach (GameObject c in OtherCamera)
        {
            c.SetActive(false);
        }
    }




}
