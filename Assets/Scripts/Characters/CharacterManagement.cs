using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManagement : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHeath;

    [SerializeField] protected int damage;
    [SerializeField] protected int defance;

    [SerializeField] protected Transform resources;

    protected bool pushCheck = false;

    protected Rigidbody2D characterRB;

    [SerializeField] protected float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TakeDamage(int damage)
    {
        int currentDamage = damage - defance;
        if(currentDamage > 0) currentHeath = currentHeath - (damage - defance);
        Debug.Log("Damage aldý: " + currentDamage);
        Die();
    }

    public virtual void Die()
    {
        if(currentHeath<= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void Push(int damage)
    {
        pushCheck = PlayerMovement.pushCheck;
        PlayerMovement.pushCheck = false;
        if (pushCheck)
        {
            pushCheck = false;
            Vector3 dir = (transform.position - resources.position).normalized;
            dir.z = 0f;
            StartCoroutine(PushTimer(dir));
            Debug.Log(PlayerMovement.dashCheck);
            if(!PlayerMovement.dashCheck) TakeDamage(damage);
            
        }
        
    }

    IEnumerator PushTimer(Vector3 dir)
    {
        
        characterRB.AddForce(dir * force);
        yield return new WaitForSeconds(0.25f);
        pushCheck = false;
        characterRB.velocity = Vector2.zero;
        
    }

}
