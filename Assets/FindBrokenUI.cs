using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FindBrokenUI : MonoBehaviour
{
    void Start()
    {
        FindBroken();
    }
    [ContextMenu("Find Broken UI Components")]
    void FindBroken()
    {
        Debug.Log("=== Searching for broken UI components ===");

        // Поиск Image
        Image[] images = FindObjectsOfType<Image>(true);
        foreach (var img in images)
        {
            if (img == null)
            {
                Debug.Log("Found null Image component!");
            }
        }

        // Поиск TMP_Text
        TMP_Text[] texts = FindObjectsOfType<TMP_Text>(true);
        foreach (var t in texts)
        {
            if (t == null)
            {
                Debug.Log("Found null TMP_Text component!");
            }
        }

        // Поиск Button
        Button[] buttons = FindObjectsOfType<Button>(true);
        foreach (var b in buttons)
        {
            if (b == null)
            {
                Debug.Log("Found null Button component!");
            }
        }

        // Поиск Dropdown (TMP)
        TMP_Dropdown[] dropdowns = FindObjectsOfType<TMP_Dropdown>(true);
        foreach (var d in dropdowns)
        {
            if (d == null)
            {
                Debug.Log("Found null TMP_Dropdown component!");
            }
        }

        Debug.Log("=== Search complete ===");
    }
}