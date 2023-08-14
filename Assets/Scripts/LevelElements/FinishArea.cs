using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishArea : MonoBehaviour {

    [SerializeField]
    GameObject LevelEndUI;

    [SerializeField]
    GameObject StarThree;
    
    [SerializeField]
    GameObject StarTwo;

    [SerializeField]
    GameObject StarOne;

    private void OnTriggerEnter2D(Collider2D collision) {
        GameManager localGMInstance = GameManager.Instance();
        LevelEndUI.SetActive(true);
        Debug.Log("Total stars collected: " + localGMInstance.GetStarCount());
        var starCount = localGMInstance.GetStarCount();
        switch(starCount) {
            case 1:
                StarOne.SetActive(true);
                break;
            case 2:
                StarTwo.SetActive(true);
                break;
            case 3:
                StarThree.SetActive(true);
                break;
	    }
        localGMInstance.SetScore(SceneManager.GetActiveScene().buildIndex - 2, starCount);
    }
}
