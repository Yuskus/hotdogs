using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour // 7
{
    private int index, rec, plan;
    private void OnEnable()
    {
        index = transform.GetSiblingIndex();
        if (index < RecData.plans.Length)
        {
            plan = RecData.plans[index];
            rec = RecData.LoadMyRecord(index);
            transform.GetChild(1).GetComponent<Text>().text = $"Plan: {plan}\nRecord: {rec}";
            if (index > RecData.AvailableLevels) { GetComponent<Button>().interactable = false; }
        }
        else { GetComponent<Button>().interactable = false; }
    }
}
