using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FindingShadersInScene : MonoBehaviour
{
    private void Start()
    {
        Image[] mats = FindObjectsOfType<Image>();
        if (mats != null)
        {
            for (int i = 0; i < mats.Length; i++)
            {
                print("shader name: " + mats[i].material.shader.name);
            }
        }
        SpriteRenderer[] mats2 = FindObjectsOfType<SpriteRenderer>();
        if (mats != null)
        {
            for (int i = 0; i < mats2.Length; i++)
            {
                print("shader name2: " + mats2[i].material.shader.name);
            }
        }
        Text[] mats3 = FindObjectsOfType<Text>();
        if (mats3 != null)
        {
            for (int i = 0; i < mats3.Length; i++)
            {
                print("shader name3: " + mats3[i].material.shader.name);
            }
        }
        TextMeshPro[] mats4 = FindObjectsOfType<TextMeshPro>();
        if (mats != null)
        {
            for (int i = 0; i < mats4.Length; i++)
            {
                print("shader name4: " + mats4[i].fontMaterial.shader.name);
            }
        }
    }
}
