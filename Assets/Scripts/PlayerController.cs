using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 4f;
    private Rigidbody2D rgbd;
    private bool isIdle = true;

    Vector2 playerMove;
    // Start is called before the first frame update
    void Awake()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
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
            SoundManager.PlayClip(SoundManager.Sound.PlayerMoveCobble);
        }
    }
}
