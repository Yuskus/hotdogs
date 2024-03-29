using UnityEngine;
using UnityEngine.EventSystems;

public class CreatedKotlet : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler, IBeginDragHandler
{
    private DraggingComponent drag;
    private Drag dg;
    private int i;
    private float time;
    private bool timer;
    private SpriteRenderer sR, childSR;
    private RaycastHit2D hit;
    private AudioClip audioClip, dzinn, burntOut;
    private AudioSource audioSource;
    private Animation anim;
    private void Awake()
    {
        drag = transform.parent.parent.GetComponent<DraggingComponent>();
        dg = Camera.main.GetComponent<Drag>();
        sR = GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animation>();
        childSR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        audioClip = Resources.Load<AudioClip>("Sounds/add sosis or kotlet");
        dzinn = Resources.Load<AudioClip>("Sounds/din");
        burntOut = Resources.Load<AudioClip>("Sounds/burnt out");
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        sR.sprite = drag.kotleta[0];
        i = 0;
        time = 0f;
        timer = true;
        audioSource.clip = audioClip;
        audioSource.Play();
        anim.enabled = false;
        childSR.enabled = false;
    }
    private void Update()
    {
        if (timer)
        {
            time += Time.deltaTime;
            switch (time)
            {
                case > 13.0f:
                    if (i != 3)
                    {
                        ChangeSprite(3);
                        anim.enabled = false;
                        childSR.enabled = false;
                        timer = false;
                        audioSource.clip = burntOut;
                        audioSource.Play();
                    }
                    break;
                case > 6.0f:
                    if (i != 2)
                    {
                        ChangeSprite(2);
                        audioSource.clip = dzinn;
                        audioSource.Play();
                        anim.enabled = true;
                        childSR.enabled = true;
                    }
                    break;
                case > 3.0f: if (i != 1) { ChangeSprite(1); } break;
            }
        }
    }
    private void ChangeSprite(int ind)
    {
        i = ind;
        sR.sprite = drag.kotleta[i];
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
            drag.TakeObjectInHand(sR);
            timer = false;
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
            else if (hit.transform.gameObject.name == "Burger") { FoodIsDone(); }
            else if (hit.transform.gameObject.name == "Trash") { Trash(); }
            else { BackHome(); }
        }
        else { BackHome(); }
    }
    private void FoodIsDone()
    {
        drag.MakeFoodDone("Kotlet", hit.transform.GetComponent<SpriteRenderer>(), drag.kotleta, drag.burger);
        dg.isDragging = false;
    }
    private void Trash()
    {
        hit.transform.GetComponent<Trash>().TrashForDrags();
        dg.isDragging = false;
    }
    private void BackHome()
    {
        GetComponent<MyStartPlace>().BackHomeAsSelected();
        dg.isDragging = false;
        timer = true;
    }
}
