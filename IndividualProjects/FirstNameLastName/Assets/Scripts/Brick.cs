using UnityEngine;
using UnityEngine.EventSystems;

public class Brick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    void Start()
    {
        transform.position += transform.right * Random.Range(-.1f, .1f);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Plane plane = new Plane(Vector3.up, Vector3.up * eventData.pointerPressRaycast.worldPosition.y);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            transform.position = ray.GetPoint(distance);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}


