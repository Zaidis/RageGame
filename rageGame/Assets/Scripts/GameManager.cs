using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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

    [SerializeField] private GameObject deathScreen;
    private bool deathScreenOn;
    [SerializeField] private GameObject winScreen;
    private bool winScreenOn;
    [SerializeField] private Sprite deathSprite;
    [SerializeField] private Sprite aliveSprite;
    [SerializeField] private TextMeshProUGUI highscoreText;
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
        Time.timeScale = 1;
        tiletraps = FindObjectsOfType<Trap>();
    }

    private void Update() {
        globalTimer += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(globalTimer);
        globalTimerText.text = time.ToString(@"hh\:mm\:ss\:ff");
    }

    public void WinLevel(float score) {
        if (highScores.instance.GrabScore(levelIndex + 1) == 0) {
            highScores.instance.UpdateOneScore(levelIndex, score);
            highscoreText.gameObject.SetActive(true);
            TimeSpan time = TimeSpan.FromSeconds(highScores.instance.GrabScore(levelIndex + 1));
            highscoreText.text = "New highscore: " + time.ToString(@"hh\:mm\:ss\:ff");
            return;
        }

        if(highScores.instance.GrabScore(levelIndex + 1) > score) {
            highScores.instance.UpdateOneScore(levelIndex, score);
            highscoreText.gameObject.SetActive(true);
            TimeSpan time = TimeSpan.FromSeconds(highScores.instance.GrabScore(levelIndex + 1));
            highscoreText.text = "New highscore: " + time.ToString(@"hh\:mm\:ss\:ff");
        }

        Time.timeScale = 0;

        ManageWinScreen();
    }
    
    public void RestartLevel() {
        RespawnPlayer();
        globalTimer = 0;
        Time.timeScale = 1;
    }
    public void KillPlayer() {
        deathCount++;
        deathCountText.text = deathCount.ToString();
        print("Player has died");
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<SpriteRenderer>().sprite = deathSprite;
        player.canMove = false;
        //RespawnPlayer();
        ManageDeathScreen();
    }

    public void GiveUp() {
        SceneManager.LoadScene(0);
    }
    public void ManageDeathScreen() {
        if (!deathScreenOn) {
            deathScreenOn = true;
            deathScreen.SetActive(true);
        } else {
            deathScreenOn = false;
            deathScreen.SetActive(false);
        }
    }
    public void ManageWinScreen() {
        if (!winScreenOn) {
            winScreenOn = true;
            winScreen.SetActive(true);
        }
        else {
            winScreenOn = false;
            winScreen.SetActive(false);
        }
    }
    public void RespawnPlayer() {
        player.GetComponent<SpriteRenderer>().sprite = aliveSprite;
        player.GetComponent<Animator>().enabled = true;
        player.canMove = true;
        player.transform.position = spawnPoint.position;

        ManageDeathScreen();
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
