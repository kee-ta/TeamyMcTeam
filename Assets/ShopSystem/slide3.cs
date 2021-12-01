using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slide3 : MonoBehaviour
{
    public GameObject SellButton3;

    public void HideThirdCustomer()
    {
        if (SellButton3 != null)
        {
            Animator animator = SellButton3.GetComponent<Animator>();

            if (animator != null)
            {
                bool isOpen = animator.GetBool("show3");
                animator.SetBool("show3", !isOpen);
            }
        }
    }

    public void HideandShowThirdCustomer()
    {
        StartCoroutine(HideThirdCustomer2());
    }

    public IEnumerator HideThirdCustomer2()
    {
        GameObject.Find("SellButton3").GetComponent<Button>().interactable = false;
        HideThirdCustomer();
        yield return new WaitForSeconds(1F);
        HideThirdCustomer();
        GameObject.Find("SellButton3").GetComponent<Button>().interactable = true;
    }
}
