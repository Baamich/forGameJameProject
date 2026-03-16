using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
    
    [SerializeField] private string nameObj;
    [SerializeField] private GameObject btn;
    [SerializeField] private bool isHpAdd;
    [SerializeField] private bool isHpRemove;
    [SerializeField] private bool Buff;
    [SerializeField] private bool DeBuff;

    private PlayerCharacteristics playerCharacteristics;
    private BoxTextManager boxTextManager;
    public int zoneId;

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag == null) return;
        playerCharacteristics = FindAnyObjectByType<PlayerCharacteristics>();
        boxTextManager = FindAnyObjectByType<BoxTextManager>();

        var dragged = eventData.pointerDrag.GetComponent<CardManager>();
        if (dragged != null)
        {
            dragged.HandleSuccessfulDrop(zoneId, nameObj);
            boxTextManager._nameObj = nameObj;
            btn.SetActive(true);
            checkChoise();
        }
    }

    private void checkChoise()
    {
        if (isHpAdd)
        {
            playerCharacteristics.hpMax++;
        } else if (isHpRemove)
        {
            playerCharacteristics.hpMax--;
        }else if (Buff)
        {
            
        }else if (DeBuff)
        {
            
        }
        
    }
}