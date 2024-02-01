using UnityEngine;
using UnityEngine.EventSystems;

public class BlueText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject blueTextObject; //text object to be displayed

    void Start()
    {
        if (blueTextObject != null)
        {
            blueTextObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (blueTextObject != null)
        {
            blueTextObject.SetActive(true);
            Debug.Log("Mouse is over GameObject.");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (blueTextObject != null)
        {
            blueTextObject.SetActive(false);
        }
    }
}

