using UnityEngine;
using UnityEngine.EventSystems;

public class Onion : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    private DraggingComponent drag;
    private Drag dg;
    private int i;
    private float time;
    private bool timer, added;
    private SpriteRenderer sR, childSR;
    private RaycastHit2D hit;
    private AudioClip audioClip, dzinn, burntOut;
    private AudioSource audioSource;
    private Animation anim;
    private void Awake()
    {
        drag = GameObject.FindGameObjectWithTag("Table").GetComponent<DraggingComponent>();
        dg = Camera.main.GetComponent<Drag>();
        anim = transform.GetChild(0).GetComponent<Animation>();
        childSR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        sR = GetComponent<SpriteRenderer>();
        audioClip = Resources.Load<AudioClip>("Sounds/add sosis or kotlet");
        dzinn = Resources.Load<AudioClip>("Sounds/din");
        burntOut = Resources.Load<AudioClip>("Sounds/burnt out");
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        sR.sprite = drag.onion[0];
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
                case > 7.0f:
                    if (i != 2)
                    {
                        ChangeSprite(2);
                        timer = false;
                        AudioAndAnim(burntOut, false);
                    }
                    break;
                case > 3.0f:
                    if (i != 1)
                    {
                        ChangeSprite(1);
                        AudioAndAnim(dzinn, true);
                    }
                    break;
            }
        }
    }
    private void ChangeSprite(int ind)
    {
        i = ind;
        sR.sprite = drag.onion[i];
    }
    private void AudioAndAnim(AudioClip clip, bool isAnimPlay)
    {
        audioSource.clip = clip;
        audioSource.Play();
        anim.enabled = isAnimPlay;
        childSR.enabled = isAnimPlay;
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
        if (eventData.pointerId == 0)
        {
            drag.TakeHelpObjectInHand(sR);
            drag.BackHelpObjectAtPlace();
            timer = false;
            dg.isDragging = true;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId == 0)
        {
            if (dg.SelectedObject == transform.gameObject) { drag.MousePos(transform.gameObject, eventData.position); }
            else { dg.isDragging = false; }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (dg.SelectedObject == transform.gameObject)
        {
            dg.isDragging = false;
            timer = true;
            hit = drag.Ray(eventData.position);
            if (hit.collider == null) { GetComponent<MyStartPlace>().BackHomeAsSelected(); return; }
            else if (hit.transform.gameObject.name == "HotDog") { hit.transform.GetComponent<CreatedBulka>().AddSauce(); added = true; }
            else if (hit.transform.gameObject.name == "Burger") { hit.transform.GetComponent<CreatedBurger>().AddSauce(); added = true; }
            else if (hit.transform.gameObject.name == "Trash") { hit.transform.GetComponent<Trash>().TrashVoid(); }
            GetComponent<MyStartPlace>().BackHomeAsSelected();
            if (added)
            {
                if (hit.transform.GetComponent<SpriteRenderer>().sprite.name is not "Bulochka" or "BulkaBurger") //check
                {
                    dg.SelectedObject = hit.transform.gameObject;
                }
                added = false;
            }
        }
        else { GetComponent<MyStartPlace>().BackHomeAsSelected(); }
    }
}
