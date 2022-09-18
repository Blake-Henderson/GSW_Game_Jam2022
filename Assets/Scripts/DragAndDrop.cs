using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Slot slot = null;

    //[SerializeField] private Canvas canvas; 

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); 
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    
    
    // OnPointerDown is called when the mose is pressed down
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
    }

    // Called Every frame of dragging
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (GetComponent<ComponentType>().type == ComponentType.types.spell)
        {
            if(GetComponent<SpellHolder>().spell != null)
            {
                rectTransform.anchoredPosition += eventData.delta; //canvas.scaleFactor;   
            }
        }
        else
        {
            rectTransform.anchoredPosition += eventData.delta; //canvas.scaleFactor;
        }
    }

    //called at drag start
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GetComponent<ComponentType>().type == ComponentType.types.spell)
        {
            if(GetComponent<SpellHolder>().spell != null)
            {
                if (slot != null)
                {
                    slot.Remove();
                    slot = null;
                }
                Debug.Log("BeginDrag");
                canvasGroup.alpha = 0.6f;
                canvasGroup.blocksRaycasts = false;
            }
        }
        else
        {
            if (slot != null)
            {
                slot.Remove();
                slot = null;
            }
            Debug.Log("BeginDrag");
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        } 
        
    }

    //called at drag end
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    // called on drop
    public void OnDrop(PointerEventData eventData)
    {
        
    }
}