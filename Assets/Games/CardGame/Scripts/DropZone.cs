using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
    
    [SerializeField] private string nameObj;
    [SerializeField] private GameObject btn;
    public int isHpAdd;
    public int isHpRemove;
    public int isDmgAdd;
    public int isDmgRemove;
    public int openLeft;
    public int openRight;
    public int isMoneyAdd;
    public int isMoneyRemove;
    public int Buff;
    public int Debuff;
    public int Debuff2;
    public GameObject[] dropZone;
    public GameObject gates;
    public Animator gateAnim;

    [SerializeField] private PlayerCharacteristics playerCharacteristics;
    [SerializeField] private BoxTextManager boxTextManager;
    public int zoneId;

    public void OnDrop(PointerEventData eventData)
    {   
        if (eventData.pointerDrag == null) return;
        var dragged = eventData.pointerDrag.GetComponent<CardManager>();
        if (dragged != null)
        {
            dragged.HandleSuccessfulDrop(zoneId, nameObj);
            btn.SetActive(true);
        }
        if (isHpAdd == 1)
        {
            playerCharacteristics.hpMax++;
            playerCharacteristics.hp++;
        }
        if (isHpRemove == 1)
        {
            playerCharacteristics.hpMax--;
            playerCharacteristics.hp--;
        }if (isDmgAdd == 1f)
        {

            playerCharacteristics.attack++;   
        }if (isDmgRemove == 1f)
        {
            playerCharacteristics.attack--;
        }if(openLeft == 1f)
        {
            StartCoroutine(openGate());
        }if(openRight == 1f)
        {
            StartCoroutine(openGate());
        }if(isMoneyAdd == 1f)
        {
            playerCharacteristics.money++;
        }if(isMoneyRemove == 1f)
        {
            playerCharacteristics.money--;
        }if(Buff == 1)
        {
            playerCharacteristics.changeSkinWizzard();
        }
        if(Debuff == 1f)
        {
            playerCharacteristics.stop = false;
            playerCharacteristics.StartCoroutine(playerCharacteristics.timerBelching());
            playerCharacteristics.changeSkinBelching();
        }if(Debuff2 == 1f)
        {
            playerCharacteristics.StartCoroutine(playerCharacteristics.ClipClapStart());
            
        }
        

        StartCoroutine(OffZone());
    }
    private IEnumerator openGate()
    {
        gateAnim.SetTrigger("OpenGate");
        yield return new WaitForSeconds(1.5f);
        gates.SetActive(false);
    }

    private IEnumerator OffZone()
    {
        yield return new WaitForSeconds(0.5f);
        dropZone[0].SetActive(false);
        dropZone[1].SetActive(false);
    }

}