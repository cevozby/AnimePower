using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed, jumpForce, dashForce;

    Vector2 movement;

    Rigidbody2D playerRB;

    [SerializeField] GameObject player, shadow;

    bool jump = false, top = false;

    public static bool pushCheck, dashCheck = false;

    [SerializeField] Vector3 topPos;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        pushCheck = false;
    }

    private void FixedUpdate()
    {
        if (!dashCheck)
        {
            playerRB.velocity = movement * speed;
        }
         
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Dash();
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void Dash()
    {
        if (Input.GetMouseButtonDown(1) && !dashCheck)
        {
            dashCheck = true;
            StartCoroutine(DashTimer());
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jump = true;
            
        }
        if (jump)
        {
            if (!top)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, 
                    transform.position + topPos, jumpForce * Time.deltaTime);
            }
            else
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, 
                    transform.position, jumpForce * 2 * Time.deltaTime);
                if (player.transform.position == transform.position)
                {
                    jump = false;
                    top = false;
                    pushCheck = true;
                    //StartCoroutine(PushControl());
                }
            }

            if(player.transform.position == transform.position + topPos)
            {
                top = true;
                
            }
        }
    }

    IEnumerator PushControl()
    {
        yield return new WaitForSeconds(0.1f);
        pushCheck = false;
    }

    IEnumerator DashTimer()
    {
        //playerRB.velocity = movement * dashForce * Time.deltaTime;
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
        Debug.Log(dir);
        Collider2D collide = GetComponent<Collider2D>();
        collide.isTrigger = true;
        playerRB.AddForce(dir * dashForce);
        yield return new WaitForSeconds(0.25f);
        collide.isTrigger = false;
        dashCheck = false;
    }
}
