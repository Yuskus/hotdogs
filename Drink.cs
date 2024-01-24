using UnityEngine;
using UnityEngine.EventSystems;

public class Drink : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    private DraggingComponent drag;
    private Drag dg;
    private SpriteRenderer spRen;
    private RaycastHit2D hit;
    private AudioClip audioClip;
    private AudioSource audioSource;
    private void Awake()
    {
        if (RecData.ContinueGame < RecData.canCookDrink) { transform.parent.gameObject.SetActive(false); }
    }
    private void Start()
    {
        drag = transform.parent.parent.GetComponent<DraggingComponent>();
        dg = Camera.main.GetComponent<Drag>();
        spRen = GetComponent<SpriteRenderer>();
        audioClip = Resources.Load<AudioClip>("Sounds/drink");
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!dg.isDragging)
        {
            dg.SelectedObject = transform.gameObject;
            audioSource.Play();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId == 0)
        {
            if (!dg.isDragging)
            {
                drag.TakeHelpObjectInHand(spRen);
                drag.BackHelpObjectAtPlace();
                dg.isDragging = true;
            }
            else if (dg.SelectedObject == transform.gameObject) { drag.MousePos(transform.gameObject, eventData.position); }
            else { dg.isDragging = false; }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (dg.SelectedObject == transform.gameObject)
        {
            dg.isDragging = false;
            hit = drag.Ray(eventData.position);
            if (hit.collider == null) { GetComponent<MyStartPlace>().BackHomeAsSelected(); return; }
            else if (hit.transform.parent.gameObject.name == "OnScene") { hit.transform.GetComponent<AnyPerson>().Checking(); }
            GetComponent<MyStartPlace>().BackHomeAsSelected();
        }
        else { GetComponent<MyStartPlace>().BackHomeAsSelected(); }
    }
}
