using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Canvas _mainCanvas;
    private RectTransform _rectTransform;
    private Vector2 _originalPosition;
    private CanvasGroup _canvasGroup;
    private BoxTextManager BoxTextManager;    
    private Sprite _changeCardImage;

    private void Awake()
    {
        if (BoxTextManager == null)
        {
            BoxTextManager = FindObjectOfType<BoxTextManager>();
        }
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _originalPosition = _rectTransform.anchoredPosition;
        _canvasGroup = GetComponent<CanvasGroup>();
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
            BoxTextManager.StartCoroutine(BoxTextManager.ChangeText(zoneId));  
        }
        else if(zoneName == "ChoiseVariantRight")
            {
                BoxTextManager.StartCoroutine(BoxTextManager.ChangeText(zoneId));  
            }
    }
    
}
