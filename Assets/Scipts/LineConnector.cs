using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class LineConnector  : MonoBehaviour,IDragHandler
{
    public RectTransform point1;
    public RectTransform point2;
    public LineRenderer lineRenderer;

    void Start()
    {
        // Initialize the LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        // Update the line positions based on the UI object positions
        Vector3[] positions = { point1.position, point2.position };
        lineRenderer.SetPositions(positions);
        Debug.Log(positions);
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Update line positions when either UI object is dragged
        Update();
    }
}

