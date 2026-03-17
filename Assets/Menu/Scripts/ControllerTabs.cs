using UnityEngine;
using UnityEngine.UI;

public class ControllerTabs : MonoBehaviour
{
    [SerializeField] private Image[] tabImgs;
    [SerializeField] private GameObject[] pages;

    void Start()
    {
        ActivateTab(0);
    }

    public void ActivateTab(int tabNo)
    {
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImgs[i].color = Color.grey;   
        }
        pages[tabNo].SetActive(true);
        tabImgs[tabNo].color = Color.white;
    }
}
