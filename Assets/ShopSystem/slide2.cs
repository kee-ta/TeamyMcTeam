using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slide2 : MonoBehaviour
{
    public GameObject SellButton2;

    public void HideSecondCustomer()
    {
        if (SellButton2 != null)
        {
            Animator animator = SellButton2.GetComponent<Animator>();

            if (animator != null)
            {
                bool isOpen = animator.GetBool("show2");
                animator.SetBool("show2", !isOpen);
            }
        }
    }

    public void HideandShowSecondCustomer()
    {
        StartCoroutine(HideSecondCustomer2());
    }

    public IEnumerator HideSecondCustomer2()
    {
        GameObject.Find("SellButton2").GetComponent<Button>().interactable = false;
        HideSecondCustomer();
        yield return new WaitForSeconds(1F);
        HideSecondCustomer();
        GameObject.Find("SellButton2").GetComponent<Button>().interactable = true;
    }
}
