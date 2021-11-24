using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static PlayerController;

public class ShopManagerScript : MonoBehaviour
{
    public GameObject SellButton;
    public GameObject SellButton2;

    public int[,] shopItems = new int[4, 6]; // refers to player inventory
    public int coins; // refers to existing player currency
    public int salesLeft = 6; // refers to current sales
    private int salesMade = 0;

    public Text DayTxt;
    public Text CoinsTxt; // referring to coins text object
    public Text SalesLeftTxt; // referring to sales left text object
    public Text RandTxt; // refers to the first sell order text object
    public Text RandTxt2; // refers to the second sell order text object

    public Text StickCount; // refers to inventory number of stick
    public Text StoneCount; // refers to inventory number of stone
    public Text LeafCount; // refers to inventory number of leaf
    public Text FlowerCount; // refers to inventory number of flower

    private int randid1; // refers to the first type of item in the first sell order
    private int randid2; // refers to the second type of item in the first sell order
    private int randid3; // refers to the first type of item in the second sell order
    private int randid4; //refers to the second type of item in the second sell order

    private int rand1; // refers to the amount of the first type of item in the first sell order
    private int rand2; // refers to the amount of the second type of item in the first sell order
    private int rand3; // refers to the amount of the first type of item in the second sell order
    private int rand4; // refers to the amount of the second type of item in the second sell order

    private string first; // for translating the first type of item in the first sell order to specific text
    private string second; // for translating the second type of item in the first sell order to specific text
    private string third; // for translating the first type of item in the second sell order to specific text
    private string fourth; // for translating the second type of item in the second sell order to specific text

    private int saleprice1; // refers to the price given for fulfilling the first sell order
    private int saleprice2; // refers to the price givin for fulfilling the second sell order

    private int daycount = 1;
    private int highscore;

    void Start()
    {
        randid1 = Random.Range(1, 5); // first type of item for first sell order
        randid2 = Random.Range(1, 5); // second type of item for first sell order
        randid3 = Random.Range(1, 5); // first type of item for second sell order
        randid4 = Random.Range(1, 5); // second type of item for second sell order

        rand1 = Random.Range(1, 3); // amount of item required for first type of item for first sell order
        rand2 = Random.Range(1, 3); // amount of item required for second type of item for first sell order
        rand3 = Random.Range(1, 3); // amount of item required for first type of item for second sell order
        rand4 = Random.Range(1, 3); // amount of item required for second type of item for second sell order

        saleprice1 = Random.Range(20, 31); // amount given for fulfilling first sell order
        saleprice2 = Random.Range(20, 31); // amount given for fulfilling second sell ordeer

        //Item IDs
        shopItems[1, 1] = 1; // Sticks
        shopItems[1, 2] = 2; // Stones
        shopItems[1, 3] = 3; // Leaves
        shopItems[1, 4] = 4; // Flowers

        //Price
        shopItems[2, 1] = Random.Range(1, 5); // cost of buying first type of item
        shopItems[2, 2] = Random.Range(1, 5); // cost of buying second type of item
        shopItems[2, 3] = Random.Range(1, 5); // cost of buying third type of item
        shopItems[2, 4] = Random.Range(1, 5); // cost of buying fourth type of item

        //Quantity
    }

    void Update()
    {
        shopItems[3, 1] = PlayerController.stoneAmount;
        shopItems[3, 2] = PlayerController.leafAmount;
        shopItems[3, 3] = PlayerController.flowerAmount;
        shopItems[3, 4] = PlayerController.stickAmount;
        coins = PlayerController.goldAmount;

        if (shopItems[3, randid1] >= rand1 && shopItems[3, randid2] >= rand2)
            GameObject.Find("SellButton").GetComponent<Button>().interactable = true;
        else
            GameObject.Find("SellButton").GetComponent<Button>().interactable = false;

        if (shopItems[3, randid3] >= rand3 && shopItems[3, randid4] >= rand4)
            GameObject.Find("SellButton2").GetComponent<Button>().interactable = true;
        else
            GameObject.Find("SellButton2").GetComponent<Button>().interactable = false;

        while (randid1 == randid2) //ensures that both types of items in sell order are different for first sell order
        {
            randid2 = Random.Range(1, 5);
        }

        while (randid3 == randid4) //ensures that both types of items in sell order are different for second sell order
        {
            randid4 = Random.Range(1, 5);
        }

        if (randid1 == 1) { first = "Stone"; } // if first type of first sell order is 1, representing string is "Stick"
        if (randid1 == 2) { first = "Leaf"; }
        if (randid1 == 3) { first = "Flower"; }
        if (randid1 == 4) { first = "Stick"; }

        if (randid2 == 1) { second = "Stone"; } // if first type of second sell order is 1, representing string is "Stick"
        if (randid2 == 2) { second = "Leaf"; }
        if (randid2 == 3) { second = "Flower"; }
        if (randid2 == 4) { second = "Stick"; }

        if (randid3 == 1) { third = "Stone"; } // if first type of second sell order is 1, representing string is "Stick"
        if (randid3 == 2) { third = "Leaf"; }
        if (randid3 == 3) { third = "Flower"; }
        if (randid3 == 4) { third = "Stick"; }

        if (randid4 == 1) { fourth = "Stone"; } // if second type of second sell order is 1, representing string is "Stick"
        if (randid4 == 2) { fourth = "Leaf"; }
        if (randid4 == 3) { fourth = "Flower"; }
        if (randid4 == 4) { fourth = "Stick"; }

        RandTxt.text = rand1 + " " + first + " and " + rand2 + " " + second + " for $" + saleprice1; // displays sell order 1
        RandTxt2.text = rand3 + " " + third + " and " + rand4 + " " + fourth + " for $" + saleprice2; // displays sell order 2
        DayTxt.text = daycount.ToString();
        CoinsTxt.text = coins.ToString(); // displays current coins player has
        SalesLeftTxt.text = salesLeft.ToString(); // diplays number of sales left
        StoneCount.text = shopItems[3, 1].ToString(); // displays quantity of sticks in inventory
        LeafCount.text = shopItems[3, 2].ToString(); // displays quantity of stone in inventory
        FlowerCount.text = shopItems[3, 3].ToString(); // displays quantity of leaf in inventory
        StickCount.text = shopItems[3, 4].ToString(); // displays quantity of flower in inventory

        if (salesLeft == 0) // if no more sales left, find and disable all buttons with "sellbutton" tag (sell orders of customers)
        {
            StartCoroutine(HideAll());
            daycount = 2;
        }
    }

    public IEnumerator HideAll()
    {
        HideTrade1();
        HideTrade2();
        yield return new WaitForSeconds(0.3F);
        SellButton.transform.localScale = new Vector3(0, 0, 0); //hide sell button 1
        SellButton2.transform.localScale = new Vector3(0, 0, 0); //hide sell button 2
    }

    public void Sell() // function for first type of sell order
    {
        salesMade++;
        StartCoroutine(Tradeplus());
        PlayerController.stoneAmount = shopItems[3, 1];
        PlayerController.leafAmount = shopItems[3, 2];
        PlayerController.flowerAmount = shopItems[3, 3];
        PlayerController.stickAmount = shopItems[3, 4];
        PlayerController.goldAmount = coins;
    }

    public void Sell2() // function for second type of sell order
    {
        salesMade++;
        StartCoroutine(Tradeplus2());
        PlayerController.stoneAmount = shopItems[3, 1];
        PlayerController.leafAmount = shopItems[3, 2];
        PlayerController.flowerAmount = shopItems[3, 3];
        PlayerController.stickAmount = shopItems[3, 4];
        PlayerController.goldAmount = coins;
    }

    public void Buy() // function for buying items (to have something to sell to customers)
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) //check if enough coins to buy item (item referenced depends on specific button ID)
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]; //subtract coin value with item price

            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++; //incrase quantity of item by 1

            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString(); //update item quantity of button after purchase
        }
    }

    public IEnumerator Tradeplus()
    {
        if (shopItems[3, randid1] >= rand1 && shopItems[3, randid2] >= rand2)
        {
            shopItems[3, randid1] -= rand1;
            shopItems[3, randid2] -= rand2;

            coins += saleprice1;
            salesLeft--;

            shopItems[2, 1] = Random.Range(2, 5);
            shopItems[2, 2] = Random.Range(2, 5);
            shopItems[2, 3] = Random.Range(2, 5);
            shopItems[2, 4] = Random.Range(2, 5);

            yield return new WaitForSeconds(0.3F);
            rand1 = Random.Range(1, 3);
            rand2 = Random.Range(1, 3);
            randid1 = Random.Range(1, 5);
            randid2 = Random.Range(1, 5);
            saleprice1 = Random.Range(8, 13);
        }
    }

    public IEnumerator Tradeplus2()
    {
        if (shopItems[3, randid3] >= rand3 && shopItems[3, randid4] >= rand4)
        {
            shopItems[3, randid3] -= rand3;
            shopItems[3, randid4] -= rand4;

            coins += saleprice2;
            salesLeft--;

            shopItems[2, 1] = Random.Range(2, 5);
            shopItems[2, 2] = Random.Range(2, 5);
            shopItems[2, 3] = Random.Range(2, 5);
            shopItems[2, 4] = Random.Range(2, 5);

            yield return new WaitForSeconds(0.3F);
            rand3 = Random.Range(1, 3);
            rand4 = Random.Range(1, 3);
            randid3 = Random.Range(1, 5);
            randid4 = Random.Range(1, 5);
            saleprice2 = Random.Range(8, 13);
        }
    }

    public void HideTrade1()
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

    public void HideandShowTrade1()
    {
        StartCoroutine(HideTrade1plus());
    }

    public IEnumerator HideTrade1plus()
    {
        GameObject.Find("SellButton").GetComponent<Button>().interactable = false;
        HideTrade1();
        yield return new WaitForSeconds(0.3F);
        HideTrade1();
        GameObject.Find("SellButton").GetComponent<Button>().interactable = true;
    }

    public void HideTrade2()
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

    public void HideandShowTrade2()
    {
        StartCoroutine(HideTrade2plus());
    }

    public IEnumerator HideTrade2plus()
    {
        GameObject.Find("SellButton2").GetComponent<Button>().interactable = false;
        HideTrade2();
        yield return new WaitForSeconds(0.3F);
        HideTrade2();
        GameObject.Find("SellButton2").GetComponent<Button>().interactable = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Show()
    {
        GameObject.Find("PlayerShopCanvas").SetActive(true);
    }

    public void Hide()
    {
        GameObject.Find("PlayerShopCanvas").SetActive(false);
    }
}