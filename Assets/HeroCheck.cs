using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCheck : MonoBehaviour
{
    Animator anim;
    GameObject hero;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        hero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(hero == other.gameObject)
        {
            anim.SetBool("EnemyClose", true);
            anim.SetBool("EnemyGone", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (hero == other.gameObject)
        {
            anim.SetBool("EnemyGone", true);
            anim.SetBool("EnemyClose", false);
        }
    }
}
