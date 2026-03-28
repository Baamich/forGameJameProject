using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image img;
    [HideInInspector] public Sprite imgSprite;
    [HideInInspector] public Sprite[] choiseImgSprite;
    private Canvas _mainCanvas;
    private RectTransform _rectTransform;
    private Vector2 _originalPosition;
    private CanvasGroup _canvasGroup;
    private BoxTextManager BoxTextManager; 
    public UIZoneHighlight zoneHighlight;
    public int[] stickTalk;
    public DialogueShow dialogueShow;
       
    private void OnEnable()
    {
        if (BoxTextManager == null)
        {
            BoxTextManager = FindObjectOfType<BoxTextManager>();
        }
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _originalPosition = _rectTransform.anchoredPosition;
        _canvasGroup = GetComponent<CanvasGroup>();
        if (stickTalk[0] == 1)
            {
                dialogueShow.stickTalk = true;
                dialogueShow.ShowStick();
            }else if (stickTalk[0] == 0)
            {               
                dialogueShow.stickTalk = false;
                dialogueShow.ShowStick();
            } 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _rectTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.9f;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = _originalPosition;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }
   
    public void HandleSuccessfulDrop(int zoneId, string zoneName)
    {   
        
        if (zoneName == "ChoiseVariantLeft")
        {
            BoxTextManager.StopAllCoroutines();
            BoxTextManager.dialogueText.text = "";
            BoxTextManager.StartCoroutine(BoxTextManager.ChangeText(zoneId));
            img.sprite = choiseImgSprite[0];
            PlayerCharacteristics playerCharacteristics = FindAnyObjectByType<PlayerCharacteristics>();
            playerCharacteristics.takeCard();
            if(stickTalk[1] == 1)
            {
                dialogueShow.stickTalk = true;
                dialogueShow.ShowStick();
            }else if (stickTalk[1] == 0)
            {
                dialogueShow.stickTalk = false;
                dialogueShow.ShowStick();
            }            
        }
        else if(zoneName == "ChoiseVariantRight")
            {
                BoxTextManager.StopAllCoroutines();
                BoxTextManager.dialogueText.text = "";
                BoxTextManager.StartCoroutine(BoxTextManager.ChangeText(zoneId));
                img.sprite = choiseImgSprite[1];
                PlayerCharacteristics playerCharacteristics = FindAnyObjectByType<PlayerCharacteristics>();
                playerCharacteristics.takeCard(); 
                if(stickTalk[2] == 1)
                {
                    dialogueShow.stickTalk = true;
                    dialogueShow.ShowStick();
                }else if (stickTalk[2] == 0)
                {
                    dialogueShow.stickTalk = false;
                    dialogueShow.ShowStick();
                }    
            }


            
    }
    
}
