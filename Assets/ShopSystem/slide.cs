using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slide : MonoBehaviour
{
    public GameObject SellButton;

    public void HideCustomer()
    {
        if (SellButton != null)
        {
            Animator animator = SellButton.GetComponent<Animator>();

            if (animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }

    public void HideandShowCustomer()
    {
        StartCoroutine(HideCustomer2());
    }

    public IEnumerator HideCustomer2()
    {
        GameObject.Find("SellButton").GetComponent<Button>().interactable = false;
        HideCustomer();
        yield return new WaitForSeconds(2F);
        HideCustomer();
        GameObject.Find("SellButton").GetComponent<Button>().interactable = true;
    }
}
