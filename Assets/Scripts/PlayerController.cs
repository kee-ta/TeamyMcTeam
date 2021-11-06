using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IShopCustomer
{
    public static PlayerController Instance { get; private set; }
    public event EventHandler OnGoldAmountChanged;
    public float moveSpeed = 4f;
    private Rigidbody2D rgbd;
    private bool isIdle = true;

    private int goldAmount;
    
    Vector2 playerMove;
    // Start is called before the first frame update
    void Awake()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        goldAmount = 500;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }
     void FixedUpdate()
    {
        MovePlayer();
    }

   
    public void AddGoldAmount(int addGoldAmount) {
    goldAmount += addGoldAmount;
    OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetGoldAmount() {
        return goldAmount;
    }

    private void UpdateMovement(){
        playerMove.x = Input.GetAxisRaw("Horizontal");
        playerMove.y = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        rgbd.MovePosition(rgbd.position + playerMove * moveSpeed * Time.fixedDeltaTime);
        float moveX=0, movey = 0;
        if(Input.GetKey(KeyCode.W)){
            movey=1;
        }
        if(Input.GetKey(KeyCode.A)){
            moveX = -1;
        }
        if(Input.GetKey(KeyCode.S)){
            movey = -1;
        }
        if(Input.GetKey(KeyCode.D)){
            moveX = 1;
        }
        isIdle = moveX == 0 && movey == 0;
        if(!isIdle){
            SoundManager.PlayClip(SoundManager.Sound.PlayerWalkGrass);
        }
    }

    public void BoughtItem(Item.ItemType itemType){
        Debug.Log("Bought Item!" + goldAmount.ToString());
    }

    public bool TrySpendGoldAmount(int spendGoldAmount) {
        if (GetGoldAmount() >= spendGoldAmount) {
            goldAmount -= spendGoldAmount;
            OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
            return true;
        } else {
            return false;
        }
    }

}
