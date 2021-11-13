using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    [SerializeField] private Transform wayPointOne, wayPointTwo;
    [SerializeField] private float speed;
    [SerializeField] private bool changeLocation, changeSpeed;
    private float timer;
    private bool stopped;
    private void Update() {
        if (!stopped) {
            timer += Time.deltaTime * speed;
            if(timer >= 1) {
                timer = 0;
                Transform temp = wayPointOne;
                wayPointOne = wayPointTwo;
                wayPointTwo = temp;

                if(changeSpeed)
                    speed = Random.Range(1, 9);
                if(changeLocation)
                    wayPointTwo.position = new Vector2((Random.Range(-5, 5) + 2), (Random.Range(-5, 5) + 2));
            }
            transform.position = Vector2.Lerp(wayPointOne.position, wayPointTwo.position, timer);
        }
    }

}
