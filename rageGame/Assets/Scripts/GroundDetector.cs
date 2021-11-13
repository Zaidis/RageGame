using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool onGround;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("ground")) {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("ground")) {
            onGround = false;
        }
    }
}
