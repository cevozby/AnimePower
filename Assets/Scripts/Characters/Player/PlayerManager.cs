using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManagement
{
    public static bool pushCheck;

    [SerializeField] int pushDamage;

    [SerializeField] List<GameObject> hitBoxes;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetHitBox();
    }

    void SetHitBox()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x >= transform.position.x)
        {
            hitBoxes[1].SetActive(false);
            hitBoxes[0].SetActive(true);
        }
        else
        {
            hitBoxes[0].SetActive(false);
            hitBoxes[1].SetActive(true);
        }
    }

}
