using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyMovement : MonoBehaviour
{
    //public Rigidbody2D rb;
    public Transform target;
    public Transform spawn;

    public bool isActive;
    private void Awake() {
       // rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        isActive = true;
        Invoke("KillBody", 15);
    }
    public float speed;
    private void Update() {
        if(isActive)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void Respawn() {
        isActive = false;
        transform.position = spawn.position;
        this.gameObject.SetActive(false);
    }

    public void KillBody() {
        Destroy(this.gameObject);
    }
    
}
