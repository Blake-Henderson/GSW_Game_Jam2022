using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{ 
       public GameObject contents = null;
       public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
            if (((eventData.pointerDrag != null) && 
            (gameObject.GetComponent<ComponentType>().type == eventData.pointerDrag.GetComponent<ComponentType>().type)) &&
            contents == null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                contents = eventData.pointerDrag;
                contents.GetComponent<DragAndDrop>().slot = gameObject.GetComponent<Slot>();
            }
        }
        public void Remove()
        {
            contents = null;
        }


}
