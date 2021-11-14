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
    public int levelIndex;
    public Transform spawnPoint;

    [SerializeField] Trap[] tiletraps;
    Transform[] tiletrap_spawns;

    private void Awake() {

        tiletrap_spawns = new Transform[tiletraps.Length];

        for (int i = 0; i < tiletraps.Length; i++)
        {
            tiletrap_spawns[i] = tiletraps[i].GetComponent<Transform>(); 
        }

        if(instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
        //DontDestroyOnLoad(this.gameObject);

        player = FindObjectOfType<playerMovement>();
    }

    private void Start() {
        deathCount = 0;
        deathCountText.text = deathCount.ToString();
        globalTimer = 0;
    }

    private void Update() {
        globalTimer += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(globalTimer);
        globalTimerText.text = time.ToString(@"hh\:mm\:ss\:ff");
    }

    public void WinLevel(float score) {
        if (highScores.instance.GrabScore(levelIndex + 1) == 0) {
            highScores.instance.UpdateOneScore(levelIndex, score);
            return;
        }

        if(highScores.instance.GrabScore(levelIndex + 1) > score) {
            highScores.instance.UpdateOneScore(levelIndex, score);
        }
    }
    
    public void KillPlayer() {
        deathCount++;
        deathCountText.text = deathCount.ToString();
        print("Player has died");
        RespawnPlayer();
    }

    public void RespawnPlayer() {
        player.transform.position = spawnPoint.position;
        ResetTraps();
    }

    void ResetTraps()
    {
        // for each trap, reset position and rotation, also turn off the in range bool
        for (int i = 0; i < tiletraps.Length; i++)
        {
            // first lets turn off the trap an re-arm it
            tiletraps[i].ResetTrap();
            // now move it back to where it was when the scene loaded. BUT since only the sprite and its collider are moving, move those.
            //tiletrap_spawns[i].SetPositionAndRotation(tiletraps[i].spawn.position, tiletraps[i].spawn.rotation);
        }

    }

}
