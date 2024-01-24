using UnityEngine;
using UnityEngine.EventSystems;

public class StartOnion : MonoBehaviour, IPointerDownHandler
{
    private Drag dg;
    private GameObject[] Onion;
    private void Awake()
    {
        if (RecData.ContinueGame < RecData.canCookOnion) { transform.gameObject.SetActive(false); }
    }
    private void Start()
    {
        dg = Camera.main.GetComponent<Drag>();
        Onion = new GameObject[2];
        for (int i = 0; i < 2; i++) { Onion[i] = transform.GetChild(i).GetChild(0).gameObject; }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!dg.isDragging)
        {
            for (int i = 0; i < 2; i++)
            {
                if (!Onion[i].activeInHierarchy) { Onion[i].SetActive(true); break; }
            }
        }
    }
}
