using UnityEngine;
using UnityEngine.EventSystems;

public class StartKotleta : MonoBehaviour, IPointerDownHandler
{
    private Drag dg;
    private GameObject PlitaKotlet;
    private void Awake()
    {
        if (Game.TimelyContinue < RecData.canCookBurger) { transform.gameObject.SetActive(false); }
    }
    private void Start()
    {
        dg = Camera.main.GetComponent<Drag>();
        PlitaKotlet = transform.parent.GetChild(2).gameObject;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!dg.isDragging)
        {
            for (int i = 0; i < 2; i++)
            {
                if (!PlitaKotlet.transform.GetChild(i).gameObject.activeInHierarchy) { PlitaKotlet.transform.GetChild(i).gameObject.SetActive(true); break; }
            }
        }
    }
}
