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
 
    private Image _image;
    // Start is called before the first frame update

    private void Awake() {
        _image = GetComponent<Image>();
        button = GetComponent<Button>();
        Camera = GetComponent<Camera>();
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
        OtherCamera = GameObject.FindGameObjectsWithTag("DungeonCamera");
        
        if(DungeonSlot.GetComponent<DungeonSlot>().roomplayed == true)
        {
            _image.color = Color.green;
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
