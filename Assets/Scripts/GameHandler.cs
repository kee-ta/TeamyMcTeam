using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public TextMeshProUGUI moneyCount;
    public GameObject playerInventoryUI;
    public int playerMoney = 10;
    public TextMeshProUGUI stickQtn;
    public TextMeshProUGUI leafQtn;
    public TextMeshProUGUI flowerQtn;
    public TextMeshProUGUI stoneQtn;
    public void addMoney(int moneyToAdd){
        playerMoney += moneyToAdd;
    }
    private void Awake(){
        SoundManager.Initialize();
        playerMoney =  PlayerController.instance.GetGoldAmount();   
 
    }

    public void updateMoney(){
        playerMoney =  PlayerController.instance.GetGoldAmount(); 
        moneyCount.text = playerMoney.ToString();
    }

    public void ShowInventory(){
        stickQtn.text = PlayerController.instance.GetItemAmount(Item.ItemType.Stick).ToString();
        leafQtn.text = PlayerController.instance.GetItemAmount(Item.ItemType.Leaf).ToString();
        flowerQtn.text = PlayerController.instance.GetItemAmount(Item.ItemType.Flower).ToString();
        stoneQtn.text = PlayerController.instance.GetItemAmount(Item.ItemType.Stone).ToString();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameHandler Started");
        updateMoney();
    }

    // Update is called once per frame
    void Update()
    {
        ShowInventory();
        updateMoney();
    }
}
