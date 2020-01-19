using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection,0)); //raycast(from, to)
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection * EnemySpeed, 0);
        if(hit.distance < 0.7f)
        {
            Flip();
            //Destroy(hit.collider.gameObject); //destroys everything it touches on its sides
            if(hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
            }
        }
        //TODO FIX THIS DISGUSTING CODE
        /*if(gameObject.transform.position.y < -20)
        {
            Debug.Log("enemy Died!");
            Destroy(gameObject);
        }*/ //turns out this won't work because we have code in Player_Move script to disable THIS entire script once you squash the enemy
    }

    void Flip()
    {
        if(XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
