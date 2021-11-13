using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostTile : MonoBehaviour
{
    // Start is called before the first frame update

    public float att_delay;
    public float spd_mult;
    float damage;
    float spinspd;
    bool inRange;
    Vector2 moveVector;
    Vector2 attack_target;
    [SerializeField] GameObject sprite;
    [SerializeField] GameObject targeter;

    void Start()
    {
       // sprite = transform.GetChild(0); // grab sprite
    }

    
    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("Collider2D entered range");
        if (c.tag == "Player")
        {
            targeter.transform.position = c.transform.position;
            //attack_target = c.transform.position;
            //moveVector = c.transform.position - transform.position;
            inRange = true;
            Debug.Log("BANZAI!!!");
        }
    }

    void AttackRoutine()
    {
        sprite.transform.Rotate(0, 0, 30, Space.World);

        if (att_delay > 0)
        {
            att_delay -= Time.deltaTime;
        } else
        {
            transform.position = Vector2.Lerp(transform.position, targeter.transform.position, Time.deltaTime * spd_mult);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inRange == true) AttackRoutine();
    }
}
