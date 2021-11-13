using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Trap
{
    public float jumpForce;
    public float deathTimer = 8;
    private void Start() {
        GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Update() {
        deathTimer -= Time.deltaTime;
        if(deathTimer <= 0) {
            Destroy(this.gameObject);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameManager.instance.KillPlayer();
        }
    }
}
