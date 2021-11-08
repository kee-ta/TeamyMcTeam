using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_System : MonoBehaviour
{
    //words that will be printed
    public Text sticksText;
    public Text stonesText;
    public Text flowersText;
    public Text leavesText;
    public Text bredText;

    //info stored and used
    static public int sticksAmt = 0;
    static public int stonesAmt = 0;
    static public int flowersAmt = 0;
    static public int leavesAmt = 0;
    static public int bredAmt = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //set the number of items into inv canvas
        invSticks();
        invStones();
        invFlowers();
        invLeaves();
        invBred();
    }

    //stores the text into sticksText
    void invSticks()
    {
        sticksText.text = "Sticks: " + sticksAmt.ToString();
    }

    //stores the text into stonesText
    void invStones()
    {
        stonesText.text = "Stones: " + stonesAmt.ToString();
    }

    //stores the text into flowersText
    void invFlowers()
    {
        flowersText.text = "Flowers: " + flowersAmt.ToString();
    }

    //stores the text into leavesText
    void invLeaves()
    {
        leavesText.text = "Leaves: " + leavesAmt.ToString();
    }

    //stores the text into leavesText
    void invBred()
    {
        bredText.text = "Bread: " + bredAmt.ToString();
    }
}