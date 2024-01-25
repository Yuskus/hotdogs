using UnityEngine;
using UnityEngine.EventSystems;

public class StartSauceK : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler, IBeginDragHandler
{
    private DraggingComponent drag;
    private Drag dg;
    private SpriteRenderer spRen;
    private RaycastHit2D hit;
    private bool sauceAdded;
    private AudioClip audioClipK;
    private void Start()
    {
        drag = transform.parent.GetComponent<DraggingComponent>();
        dg = Camera.main.GetComponent<Drag>();
        spRen = GetComponent<SpriteRenderer>();
        sauceAdded = false;
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
            else if (hit.transform.gameObject.name == "HotDog") { hit.transform.GetComponent<CreatedBulka>().AddSauce(); sauceAdded = true; }
            else if (hit.transform.gameObject.name == "Burger") { hit.transform.GetComponent<CreatedBurger>().AddSauce(); sauceAdded = true; }
            BackHome();
            if (sauceAdded)
            {
                if (hit.transform.GetComponent<SpriteRenderer>().sprite.name is not "Bulochka" or "BulkaBurger") //check
                {
                    dg.SelectedObject = hit.transform.gameObject;
                }
                sauceAdded = false;
            }
        }
        else { BackHome(); }
        dg.isDragging = false;
    }
    private void BackHome()
    {
        GetComponent<MyStartPlace>().BackHomeAsSelected();
    }
}
