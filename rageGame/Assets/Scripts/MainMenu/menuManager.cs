using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    
    public void QuitGame() {
        print("Quitting");
        Application.Quit();
    }

    public void SelectLevel() {
        SceneManager.LoadScene(1);
    }
}
