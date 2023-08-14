using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class Info : MonoBehaviour {
    [SerializeField]
    GameObject _infoPanel;

    [SerializeField]
    GameObject _infoTextField;

    private static List<string> _infoText;

    private void Start() {
        _infoText = new List<string>() { 
            "Equation type: y = mx+c.\nm = slope of the line\nc = elevation.\nIf the slope is 0, a line parallel to x-axis is formed.\nTry using the stars to guess which graph to form.",
            "Equation type: y = mx+c.\nm = slope of the line\nc = elevation.\nChanging the value of c changes the elevation of the line in terms of the y-axis.",
            "Equation type: y = mx+c.\nm = slope of the line\nc = elevation.\nParallel lines will not work here. You might have to change the slope.",
            "Equation type: y = mx+c.\nm = slope of the line\nc = elevation.\nTry experimenting with slope(m) and elevation(c).",
            "Equation type: y = Asin(wx) + c.\nTry adjusting values of A and w to find the right curvature to fit through the gaps",
            "Equation type: y = Acos(wx) + c.\nTry adjusting values of A and w to find the right curvature to fit through the gaps",
            "Equation type: y = Asin(wx) + c.\nTry adjusting values of A and w to find the right curvature to fit through the gaps",
            "Equation type: y = x^n + c.\nThere is no direct route to the hole, you might have to try a different approach",
            "Equation type: y = k^(nx) + c.\nThere is no direct route to the hole, you might have to try a different approach",
            "Equation type: y = x^n + c.\nThere is no direct route to the hole, you might have to try a different approach",
	    };
        _infoTextField.GetComponent<TextMeshProUGUI>().text = _infoText[SceneManager.GetActiveScene().buildIndex - 2];
    }

    public void ShowPanel() {
        _infoPanel.gameObject.SetActive(true);
    }

    public void ClosePanel() {
        _infoPanel.gameObject.SetActive(false);
    }
}

