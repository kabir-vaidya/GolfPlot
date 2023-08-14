using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator: MonoBehaviour {
    public void GoToLevelSelect() {
        SceneManager.LoadScene(1);
    }

    public void GoToTitle() {
        SceneManager.LoadScene(0);
    }
}
