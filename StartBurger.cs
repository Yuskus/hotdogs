using UnityEngine;
using UnityEngine.EventSystems;

public class StartBurger : MonoBehaviour, IPointerDownHandler
{
    private Drag dg;
    private GameObject StolBurger;
    private void Awake()
    {
        if (Game.TimelyContinue < RecData.canCookBurger) { transform.gameObject.SetActive(false); }
    }
    private void Start()
    {
        dg = Camera.main.GetComponent<Drag>();
        StolBurger = transform.parent.GetChild(4).gameObject;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!dg.isDragging)
        {
            for (int i = 0; i < 2; i++)
            {
                if (!StolBurger.transform.GetChild(i).gameObject.activeInHierarchy) { StolBurger.transform.GetChild(i).gameObject.SetActive(true); break; }
            }
        }
    }
}
