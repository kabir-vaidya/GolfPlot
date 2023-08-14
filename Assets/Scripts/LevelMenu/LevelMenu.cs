using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {
    public void ShowPanel() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void TogglePanel() { 
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void HidePanel() { 
        gameObject.SetActive(false);
    }
}
