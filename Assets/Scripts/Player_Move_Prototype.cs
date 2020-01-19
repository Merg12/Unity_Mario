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
    public float distanceToBottomOfPlayer = 0.9f;

    // Start is called before the first frame update
    void Start() //no need at this stage
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
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
        /*Debug.Log("Player has collided with " + col.collider.name);
        if(col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }*/ //this is no longer needed because in void PlayerRaycast(), there's a if statement for isGrounded = true
    }

    void PlayerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if(rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "breakbox") //problem with this collider.name is that ONLY the box with this EXACT name can be destroyed this way, if you duplicate this, it will not work because the 2nd box won't have the same name, you'll have to change it to the same name manually
        {
            Destroy(rayUp.collider.gameObject);
            //Debug.Log("Hit box!");
        }

        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if(rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "enemy")
        {
            //Debug.Log("Squished enemy!");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            //Destroy(hit.collider.gameObject); //destroys the enemy
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200); //after jumps on enemy, enemy bounces to the right
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false; //boxcollider is disabled to enemy falls thru the floor
            rayDown.collider.gameObject.GetComponent<enemyMove>().enabled = false; //this will then disable the script tied to the enemy, keep in mind, this causes problems with trying to distroy the enemy when it bounces off the screen in the enemyMove script, instead we should create a new enemyHealth script
        }

        if(rayUp != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "enemy")
        {
            isGrounded = true;
        }
    }
}
