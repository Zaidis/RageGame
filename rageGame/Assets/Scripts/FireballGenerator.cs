using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGenerator : MonoBehaviour
{

    [SerializeField] private Fireball ball;

    [SerializeField] private float spawnTimerMax;
    private float spawnTimer;

    private void Start() {
        spawnTimer = spawnTimerMax;
    }

    private void Update() {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0) {
            SpawnFireball();
        }
    }

    private void SpawnFireball() {
        Fireball newBall = Instantiate(ball, transform.position, Quaternion.identity);
        spawnTimer = spawnTimerMax;
    }

}
