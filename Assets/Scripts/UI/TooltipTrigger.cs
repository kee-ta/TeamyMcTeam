using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string content;
    public string header;
    public void OnPointerEnter(PointerEventData eventData){
        TooltipSystem.Show(content,header);
    }

    public void OnPointerExit(PointerEventData eventData){
        TooltipSystem.Hide();
    }

    private void OnMouseEnter(){
        TooltipSystem.Show(content,header);
    }
    private void OnMouseExit(){
        TooltipSystem.Hide();
    }
}
