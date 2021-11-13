using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI globalTimerText;
    public TextMeshProUGUI deathCountText;
    public playerMovement player;
    public int deathCount { get; set; }
    public float globalTimer;

    public Transform spawnPoint;
    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        player = FindObjectOfType<playerMovement>();
    }

    private void Start() {
        deathCount = 0;
        deathCountText.text = deathCount.ToString();
    }

    private void Update() {
        globalTimer += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(globalTimer);
        globalTimerText.text = time.ToString(@"hh\:mm\:ss\:ff");
    }

    
    public void KillPlayer() {
        deathCount++;
        deathCountText.text = deathCount.ToString();
        print("Player has died");
        RespawnPlayer();
    }

    public void RespawnPlayer() {
        player.transform.position = spawnPoint.position;
    }

    

}
