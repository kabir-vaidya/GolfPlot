using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Drawing;
using System;

public class RenderLine : MonoBehaviour {

    [SerializeField]
    GameObject inputField;

    [SerializeField]
    GameObject ball;

    public float xFinish;

    [SerializeField]
    LayerMask TerrainLayer;

    bool ballMoving;
    string inputExpression;

    public LineRenderer line;
    public int points;
    Solver solver;

    void Start() {
        line = GetComponent<LineRenderer>();
        ballMoving = false;
        solver = new Solver();
    }

    // Update is called once per frame
    void Update() {
        if(!ballMoving) {
            gameObject.SetActive(true);
            Draw();
	    } else if(ballMoving) { 
            gameObject.SetActive(false);
        } 
    }

    public void Draw() {
        inputExpression = GetInputExpressionFromInputField();
        float xStart = ball.transform.position.x;
        line.positionCount = points;
        for(int currentPoint = 0; currentPoint < points; currentPoint++) {
            Vector3 currentLinePoint = CalculateLinePoint(currentPoint, xStart, xFinish); 
            line.SetPosition(currentPoint, currentLinePoint);
            if(currentPoint == 0) {
                ball.transform.position = currentLinePoint;
	        }
        }
    }

    private Vector3 CalculateLinePoint(float currentPoint, float xStart, float xFinish) {
        if(inputExpression == "") {
            return new Vector3(0, 0, 0);
        }
        float progress = (float)currentPoint / (points - 1);
        float x = Mathf.Lerp(xStart, xFinish, progress);
        float y = solver.CalculateY(inputExpression, x);
        return new Vector3(x, y, 0);
    }

    public void ToggleMove() {
        ballMoving = !ballMoving;
    }

    private string GetInputExpressionFromInputField() {
        return inputField.GetComponent<TMP_InputField>().text;
    }
}
