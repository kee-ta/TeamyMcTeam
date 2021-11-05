using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5]; // refers to player inventory
    public float coins; // refers to existing player currency
    public float salesLeft; // refers to current sales
    private float salesMade = 0;

    public Text CoinsTxt; // referring to coins text object
    public Text SalesLeftTxt; // referring to sales left text object
    public Text SalesMadeTxt; // referring to sales made text object
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

    void Start()
    {
        randid1 = Random.Range(1, 5); // first type of item for first sell order
        randid2 = Random.Range(1, 5); // second type of item for first sell order
        randid3 = Random.Range(1, 5); // first type of item for second sell order
        randid4 = Random.Range(1, 5); // second type of item for second sell order

        rand1 = Random.Range(1, 5); // amount of item required for first type of item for first sell order
        rand2 = Random.Range(1, 5); // amount of item required for second type of item for first sell order
        rand3 = Random.Range(1, 5); // amount of item required for first type of item for second sell order
        rand4 = Random.Range(1, 5); // amount of item required for second type of item for second sell order

        saleprice1 = Random.Range(100, 200); // amount given for fulfilling first sell order
        saleprice2 = Random.Range(100, 200); // amount given for fulfilling second sell ordeer

        //Item IDs
        shopItems[1, 1] = 1; // Sticks
        shopItems[1, 2] = 2; // Stones
        shopItems[1, 3] = 3; // Leaves
        shopItems[1, 4] = 4; // Flowers

        //Price
        shopItems[2, 1] = Random.Range(5, 50); // cost of buying first type of item
        shopItems[2, 2] = Random.Range(5, 50); // cost of buying second type of item
        shopItems[2, 3] = Random.Range(5, 50); // cost of buying third type of item
        shopItems[2, 4] = Random.Range(5, 50); // cost of buying fourth type of item

        //Quantity
        shopItems[3, 1] = 0; // current amount of first type of item
        shopItems[3, 2] = 0; // current amount of second type of item
        shopItems[3, 3] = 0; // current amount of third type of item
        shopItems[3, 4] = 0; // current amount of fourth type of item
    }

    void Update()
    {
        if (shopItems[3, randid1] >= rand1 && shopItems[3, randid2] >= rand2)
            GameObject.Find("SellButton").GetComponent<Button>().interactable = true; //enable
        else
            GameObject.Find("SellButton").GetComponent<Button>().interactable = false; //disable

        if (shopItems[3, randid3] >= rand3 && shopItems[3, randid4] >= rand4)
            GameObject.Find("SellButton2").GetComponent<Button>().interactable = true; //enable
        else
            GameObject.Find("SellButton2").GetComponent<Button>().interactable = false; //disable

        while (randid1 == randid2) //ensures that both types of items in sell order are different for first sell order
        {
            randid2 = Random.Range(1, 5);
        }

        while (randid3 == randid4) //ensures that both types of items in sell order are different for second sell order
        {
            randid4 = Random.Range(1, 5);
        }

        if (randid1 == 1) { first = "Stick"; } // if first type of first sell order is 1, representing string is "Stick"
        if (randid1 == 2) { first = "Stone"; }
        if (randid1 == 3) { first = "Leaf"; }
        if (randid1 == 4) { first = "Flower"; }

        if (randid2 == 1) { second = "Stick"; } // if first type of second sell order is 1, representing string is "Stick"
        if (randid2 == 2) { second = "Stone"; }
        if (randid2 == 3) { second = "Leaf"; }
        if (randid2 == 4) { second = "Flower"; }

        if (randid3 == 1) { third = "Stick"; } // if first type of second sell order is 1, representing string is "Stick"
        if (randid3 == 2) { third = "Stone"; }
        if (randid3 == 3) { third = "Leaf"; }
        if (randid3 == 4) { third = "Flower"; }

        if (randid4 == 1) { fourth = "Stick"; } // if second type of second sell order is 1, representing string is "Stick"
        if (randid4 == 2) { fourth = "Stone"; }
        if (randid4 == 3) { fourth = "Leaf"; }
        if (randid4 == 4) { fourth = "Flower"; }

        RandTxt.text = "Sell (" + rand1 + " " + first + ", " + rand2 + " "+ second + ": $" + saleprice1; // displays sell order 1
        RandTxt2.text = "Sell (" + rand3 + " " + third + ", " + rand4 + " " + fourth + "): $" + saleprice2; // displays sell order 2
        CoinsTxt.text = "Coins: $" + coins.ToString(); // displays current coins player has
        SalesLeftTxt.text = "Customers Waiting: " + salesLeft.ToString(); // diplays number of sales left
        SalesMadeTxt.text = "Today's Sales: " + salesMade.ToString(); // diplays number of sales left
        StickCount.text = "Stick: " + shopItems[3, 1]; // displays quantity of sticks in inventory
        StoneCount.text = "Stone: " + shopItems[3, 2]; // displays quantity of stone in inventory
        LeafCount.text = "Leaf: " + shopItems[3, 3]; // displays quantity of leaf in inventory
        FlowerCount.text = "Flower: " + shopItems[3, 4]; // displays quantity of flower in inventory

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("sellbutton");

        if (salesLeft == 0) // if no more sales left, find and disable all buttons with "sellbutton" tag (sell orders of customers)
        {
            foreach (GameObject go in gameObjectArray)
            {
                go.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void Sell() // function for first type of sell order
    {
        if (shopItems[3, randid1] >= rand1 && shopItems[3, randid2] >= rand2)
        {
            shopItems[3, randid1] -= rand1; // subtract amount of first item of sell order 1 from inventory amount
            shopItems[3, randid2] -= rand2; // subtract amount of second  item of sell order 1 from inventory amount

            coins += saleprice1; // coins earned after first type of sell order
            salesLeft--;
            salesMade++;

            CoinsTxt.text = "Coins: $" + coins.ToString(); //update coins value on screen
            SalesLeftTxt.text = "Customers Waiting: " + salesLeft.ToString();

            // refresh all ranges upon a sale
            rand1 = Random.Range(1, 5);
            rand2 = Random.Range(1, 5);
            randid1 = Random.Range(1, 5);
            randid2 = Random.Range(1, 5);
            saleprice1 = Random.Range(50, 100);

            shopItems[2, 1] = Random.Range(5, 50);
            shopItems[2, 2] = Random.Range(5, 50);
            shopItems[2, 3] = Random.Range(5, 50);
            shopItems[2, 4] = Random.Range(5, 50);
        }
    }

    public void Sell2() // function for second type of sell order
    {
        if (shopItems[3, randid3] >= rand3 && shopItems[3, randid4] >= rand4)
        {
            shopItems[3, randid3] -= rand3; // subtract amount of first item of sell order 2 from inventory amount
            shopItems[3, randid4] -= rand4; // subtract amount of second  item of sell order 2 from inventory amount

            coins += saleprice2; //coins earned after second type of sell order
            salesLeft--;
            salesMade++;

            CoinsTxt.text = "Coins: $" + coins.ToString(); //update coins value on screen
            SalesLeftTxt.text = "Customers Waiting: " + salesLeft.ToString();

            // refresh all ranges upon a sale
            rand3 = Random.Range(1, 5);
            rand4 = Random.Range(1, 5);
            randid3 = Random.Range(1, 5);
            randid4 = Random.Range(1, 5);
            saleprice2 = Random.Range(50, 100);

            shopItems[2, 1] = Random.Range(5, 50);
            shopItems[2, 2] = Random.Range(5, 50);
            shopItems[2, 3] = Random.Range(5, 50);
            shopItems[2, 4] = Random.Range(5, 50);
        }
    }

    public void Buy() // function for buying items (to have something to sell to customers)
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) //check if enough coins to buy item (item referenced depends on specific button ID)
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]; //subtract coin value with item price

            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++; //incrase quantity of item by 1

            CoinsTxt.text = "Coins: $" + coins.ToString(); //update remaining coins value on screen

            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString(); //update item quantity of button after purchase
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart scene (for testing purposes)
    }
}
