using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IShopCustomer
{
    public GameObject buyPrompt;
    public GameObject dialoguePrompt;
    private bool canMove= true;
    System.Random var = new System.Random();
    private static PlayerController _instance;
    public static PlayerController instance {get  
         {
             if (_instance == null)
             {
                 _instance = (PlayerController) GameObject.FindObjectOfType(typeof(PlayerController));
 
                 if (_instance == null)
                 {
                     GameObject go = new GameObject("PlayerController");
                     _instance = go.AddComponent<PlayerController>();
                 }
             }
             return _instance;
         }
         set
         {
             _instance = value;
         }
    }

    public event EventHandler OnGoldAmountChanged;
    public float moveSpeed = 40f;
    private Rigidbody2D rgbd;
    private bool isIdle = true;

    public static int goldAmount= 30;
    public static int stickAmount, leafAmount, stoneAmount, flowerAmount;
    
    Vector2 playerMove;
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        buyPrompt.SetActive(false);
        dialoguePrompt.SetActive(false);
        rgbd = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateMovement();
    }
     void FixedUpdate()
    {
        if(canMove)
        MovePlayer();
    }


    public int GetItemAmount(Item.ItemType itemType){
        switch (itemType) {
        default:
        case Item.ItemType.Leaf:     return leafAmount;
        case Item.ItemType.Flower:    return flowerAmount;
        case Item.ItemType.Stick:     return stickAmount;
        case Item.ItemType.Stone:     return stoneAmount;
        }
    }

    public void AddGoldAmount(int addGoldAmount) {
    goldAmount += addGoldAmount;
    OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetGoldAmount() {
        return goldAmount;
    }

    public void StopMovement(bool b){
        canMove = !b;
    }
    private void UpdateMovement(){
        playerMove.x = Input.GetAxisRaw("Horizontal");
        playerMove.y = Input.GetAxisRaw("Vertical");
        playerMove = playerMove.normalized;
    }

    private void MovePlayer(){
        rgbd.MovePosition(rgbd.position + playerMove * moveSpeed * Time.fixedDeltaTime);
        float moveX=0, movey = 0;
        if(Input.GetKey(KeyCode.W)){
            movey=1;
        }
        if(Input.GetKey(KeyCode.A)){
            moveX = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(Input.GetKey(KeyCode.S)){
            movey = -1;
        }
        if(Input.GetKey(KeyCode.D)){
            moveX = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        isIdle = moveX == 0 && movey == 0;
         if(!isIdle){
/*              switch(var.Next(2)){
                case 0:
                SoundManager.PlayClip(SoundManager.Sound.PlayerWalkGrass);
                break; */
/*                 case 1: */
                SoundManager.PlayClip(SoundManager.Sound.PlayerWalkGrass);
/*                 break;
             } */
         }
    }

    public void BoughtItem(Item.ItemType itemType){
        Debug.Log("Bought " + itemType.ToString() + " " + goldAmount.ToString());
        switch (itemType) {
        default:
        case Item.ItemType.Leaf:      
        leafAmount++; 
        Debug.Log( leafAmount.ToString() + "Leaves in inventory");
        return;
        case Item.ItemType.Flower: 
        flowerAmount++; 
        Debug.Log( flowerAmount.ToString() + "Flowers in inventory");  
        return;
        case Item.ItemType.Stick:   
        stickAmount++;  
        Debug.Log( stickAmount.ToString() + "Sticks in inventory");
        return ;
        case Item.ItemType.Stone:   
        stoneAmount++; 
        Debug.Log( stoneAmount.ToString() + "Stones in inventory"); 
        return ;
        }
    }

    public bool TrySpendGoldAmount(int spendGoldAmount) {
        if (GetGoldAmount() >= spendGoldAmount) {
            goldAmount -= spendGoldAmount;
            OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
            AudioManager.instance.PlaySound2D("BreadSpent");
            return true;
        } else {
            return false;
        }
    }

    public void PromptActivate(){
        buyPrompt.SetActive(true);
    }

    public void PromptDeactivate(){
        buyPrompt.SetActive(false);
    }

    public void PromptDialogueActivate(){
        dialoguePrompt.SetActive(true);
    }

    public void PromptDialogueDeactivate(){
        dialoguePrompt.SetActive(false);
    }

    public void SetBreadAmount(int i)
    {
        goldAmount = i;
    }

    public void SetInventoryAmount(int j)
    {
        stickAmount = j;
        leafAmount = j;
        stoneAmount = j;
        flowerAmount = j;
    }

    public int GetStickAmt()
    {
        return stickAmount;
    }
}
