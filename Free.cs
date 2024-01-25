using UnityEngine;
using UnityEngine.EventSystems;

public class Free : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler, IBeginDragHandler
{
    private DraggingComponent drag;
    private Drag dg;
    private SpriteRenderer spRen;
    private RaycastHit2D hit;
    private void Awake()
    {
        drag = transform.parent.parent.GetComponent<DraggingComponent>();
        dg = Camera.main.GetComponent<Drag>();
        spRen = GetComponent<SpriteRenderer>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!dg.isDragging)
        {
            dg.SelectedObject = transform.gameObject;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (eventData.pointerId == 0 && !dg.isDragging)
        {
            drag.TakeObjectInHand(spRen);
            dg.isDragging = true;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId == 0 && dg.isDragging)
        {
            if (dg.SelectedObject == transform.gameObject) { drag.MousePos(transform.gameObject, eventData.position); }
            else { dg.isDragging = false; }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (dg.SelectedObject == transform.gameObject)
        {
            hit = drag.Ray(eventData.position);
            if (hit.collider == null) { BackHome(); return; }
            else if (hit.transform.parent.gameObject.name == "OnScene") { hit.transform.GetComponent<AnyPerson>().CheckingForDrags(); }
            else { BackHome(); }
        }
        else { BackHome(); }
        dg.isDragging = false;
    }
    private void BackHome()
    {
        GetComponent<MyStartPlace>().BackHomeAsSelected();
    }
}
