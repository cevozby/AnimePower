using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : EnemyManager
{
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHealth;
        characterRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        SetDamage();
    }
}
