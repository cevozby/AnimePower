using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManagement
{
    [SerializeField] protected float speed;

    [SerializeField] Transform player;

    bool hitBoxCheck, pushAreaCheck, dashCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void FollowPlayer()
    {
        if(Vector3.Distance(transform.position, player.position) >= 1.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
    }

    protected void SetDamage()
    {
        if(hitBoxCheck && Input.GetMouseButtonDown(0))
        {
            TakeDamage(20);
            
        }
        if (pushAreaCheck)
        {
            Push(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox"))
        {
            hitBoxCheck = true;
        }
        else if (collision.gameObject.CompareTag("PushArea"))
        {
            pushAreaCheck = true;
        }
        else if (collision.gameObject.CompareTag("Dash"))
        {
            dashCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox"))
        {
            hitBoxCheck = false;
        }
        else if (collision.gameObject.CompareTag("PushArea"))
        {
            pushAreaCheck = false;
        }
        else if (collision.gameObject.CompareTag("Dash"))
        {
            dashCheck = false;
        }
    }

}
