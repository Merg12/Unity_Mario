using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prototype : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = true; //true if player is facing right, false otherwise
    public int playerJumpPower = 1250; //how high player jumps
    private float moveX;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start() //no need at this stage
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal"); //UnityScript: range will be -1 to 1 for keyboard input
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        //animations
        //player directions
        if(moveX > 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if(moveX < 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //jump code
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower); //UnityScript: Vector2.up is same as Vector2(0,1) but can't just put that in because you can't use it as a method in this parameter
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight; //removing this will make face turn back to right after turning left
        Vector2 turnHead = gameObject.transform.localScale;
        turnHead.x *= -1; //this part makes the x-axis inverse
        transform.localScale = turnHead;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player has collided with " + col.collider.name);
        if(col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
