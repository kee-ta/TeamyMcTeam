using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    public GameObject Credits1;
    public GameObject Credits2;
    public GameObject Credits3;
    public GameObject NextButt;
    public GameObject MainMenuButt;

    private int creditChk;
    
    
    // Start is called before the first frame update
    void Start()
    {
        creditChk = 1;

        NextButt.SetActive(true);
        MainMenuButt.SetActive(false);

        Credits1.SetActive(true);
        Credits2.SetActive(false);
        Credits3.SetActive(false);
    }

    public void NextCredit()
    {
        switch(creditChk)
        {
            case 1:
            Credits1.SetActive(false);
            Credits2.SetActive(true);
            creditChk++;
            break;

            case 2:
            Credits2.SetActive(false);
            Credits3.SetActive(true);
            NextButt.SetActive(false);
            MainMenuButt.SetActive(true);
            creditChk++;
            break;
        }
    }

}
