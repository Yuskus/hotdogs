using UnityEngine;
using UnityEngine.EventSystems;

public class StartSauceK : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler, IBeginDragHandler
{
    private DraggingComponent drag;
    private Drag dg;
    private SpriteRenderer spRen;
    private RaycastHit2D hit;
    private AudioClip audioClipK;
    private void Start()
    {
        drag = transform.parent.GetComponent<DraggingComponent>();
        dg = Camera.main.GetComponent<Drag>();
        spRen = GetComponent<SpriteRenderer>();
        audioClipK = Resources.Load<AudioClip>("Sounds/sauce 1");
        drag.audioSourceK = GetComponent<AudioSource>();
        drag.audioSourceK.clip = audioClipK;
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
            else if (hit.transform.gameObject.name == "HotDog") { SauceForHotDog(); }
            else if (hit.transform.gameObject.name == "Burger") { SauceForBurger(); }
        }
        BackHome();
    }
    private void SauceForHotDog()
    {
        hit.transform.GetComponent<CreatedBulka>().AddSauce();
        if (hit.transform.GetComponent<SpriteRenderer>().sprite.name != "Bulochka")
        {
            dg.SelectedObject = hit.transform.gameObject;
        }
        dg.isDragging = false;
    }
    private void SauceForBurger()
    {
        hit.transform.GetComponent<CreatedBurger>().AddSauce();
        if (hit.transform.GetComponent<SpriteRenderer>().sprite.name != "BulkaBurger")
        {
            dg.SelectedObject = hit.transform.gameObject;
        }
        dg.isDragging = false;
    }
    private void BackHome()
    {
        GetComponent<MyStartPlace>().BackHomeAsSelected();
        dg.isDragging = false;
    }
}
