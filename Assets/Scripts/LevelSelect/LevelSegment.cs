using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSegment : MonoBehaviour {
    [SerializeField]
    GameObject _text;
    [SerializeField]
    GameObject _starOne;
    [SerializeField]
    GameObject _starTwo;
    [SerializeField]
    GameObject _starThree;

    [SerializeField]
    int _levelNumber;

    private void Start() {
        GameManager localGmInstance = GameManager.Instance();
        int thisLevelScore = localGmInstance.GetLevelScore(_levelNumber);
        _text.GetComponent<Text>().text = _levelNumber.ToString();
        Debug.Log(localGmInstance.GetFirstZeroScoreLevel());
        Debug.Log(thisLevelScore);
        switch(thisLevelScore) {
            case 3:
                _starThree.SetActive(true);
                goto case 2;
            case 2:
                _starTwo.SetActive(true);
                goto case 1;
            case 1:
                _starOne.SetActive(true);
                ActivateDefaults();
                break;
            case 0:
                if (_levelNumber == localGmInstance.GetFirstZeroScoreLevel()) {
                    ActivateDefaults();
                }
                break;
	    }
    }

    private void ActivateDefaults() { 
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/lvl_block_hover");
        gameObject.GetComponent<Button>().interactable = true;
        _text.SetActive(true);
    }

    public void LoadLevel() {
        SceneManager.LoadScene(_levelNumber + 1);
    }

}
