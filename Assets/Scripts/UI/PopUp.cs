using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public GameObject popUp;
    public Animator animator;
    public TMP_Text popUpText;

    public void ShowPopUp(string text){
        popUp.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }
}
