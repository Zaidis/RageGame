using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScores : MonoBehaviour
{

    public static highScores instance;
    public float score_1, score_2, score_3, score_4;

    private void Awake() {
        if(instance == null) {

            instance = this;
        } else {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        //ResetScores();
        UpdateScores();
    }
    
    public void UpdateScores() {
        score_1 = PlayerPrefs.GetFloat("Score1");
        score_2 = PlayerPrefs.GetFloat("Score2");
        score_3 = PlayerPrefs.GetFloat("Score3");
        score_4 = PlayerPrefs.GetFloat("Score4");
    }

    public void ResetScores() {
        PlayerPrefs.SetFloat("Score1", 0);
        PlayerPrefs.SetFloat("Score2", 0);
        PlayerPrefs.SetFloat("Score3", 0);
        PlayerPrefs.SetFloat("Score4", 0);
    }

    public void UpdateOneScore(int num, float score) {
        switch (num) {
            case 1: 
                PlayerPrefs.SetFloat("Score1", score);
                break;
            case 2:
                PlayerPrefs.SetFloat("Score2", score);
                break;
            case 3:
                PlayerPrefs.SetFloat("Score3", score);
                break;
            case 4:
                PlayerPrefs.SetFloat("Score4", score);
                break;
        }
        PlayerPrefs.Save();
    }
    public float GrabScore(int num) {
        switch (num) {
            case 2:
                return score_1;
            case 3:
                return score_2;
            case 4:
                return score_3;
            case 5:
                return score_4;
        }
        return 0;
    }
}
