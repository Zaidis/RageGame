using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class levelSelect : MonoBehaviour
{
    public int selectedLevel; //2, 3, 4, 5
    [SerializeField] private GameObject enterButton;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI levelName;

    /// <summary>
    /// Used when player clicks a level button.
    /// </summary>
    public void SelectLevel(int num) {
        selectedLevel = num;
        enterButton.SetActive(true);
        highScore.gameObject.SetActive(true);
        levelName.gameObject.SetActive(true);

        TimeSpan time = TimeSpan.FromSeconds(highScores.instance.GrabScore(num));
        highScore.text = "Highscore: " + time.ToString(@"hh\:mm\:ss\:ff");
        levelName.text = "Selected Level: " + (num - 1).ToString();
    }

    public void StartLevel() {
        SceneManager.LoadScene(selectedLevel);
    }
}
