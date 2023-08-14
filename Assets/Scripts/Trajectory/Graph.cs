using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Graph : MonoBehaviour {

    [SerializeField]
    Transform pointTransform;

    [SerializeField]
    Rigidbody2D ball;

    [SerializeField]
    Slider slider;

    [SerializeField]
    GameObject inputField;

    [SerializeField]
    bool ShowPathOnPlay;

    string inputExpression;
    public static Transform[] points;
    Vector3 StartPosition;
    Vector3 FirstPointPosition;
    bool SetBallPosition;

    Vector3 CurrentPositionHolder;
    Vector3 IntermediatePlayerPosition;
    int CurrentPoint;

    float timer;
    float MoveSpeed;

    bool Play;

    private void Awake() {
        Play = false;
        MoveSpeed = 10f;
        StartPosition = ball.transform.localPosition;
    }

    private void Start() {
        timer = 0;
    }

    private void Update() {
        if(SetBallPosition) {
            ball.transform.position = FirstPointPosition;
            SetBallPosition = false;
	    }

        timer += Time.deltaTime * MoveSpeed;
        if (Play) {
            if(!ShowPathOnPlay)
                foreach (Transform child in transform) {
                    child.gameObject.SetActive(false);
                }
            ball.transform.DetachChildren();
            foreach (Transform child in transform){
            }
            if(ball.transform.position == StartPosition) {
                Debug.Log("Something went wrong");
	        }
            if(ball.transform.position != CurrentPositionHolder) {
                //ball.transform.position = Vector3.Lerp(IntermediatePlayerPosition, CurrentPositionHolder, timer);
                ball.velocity = CurrentPositionHolder;
	        } else { 
                if(CurrentPoint < slider.value - 1) {
                    CurrentPoint++;
                    CheckPoint();
		        } else {
                    ball.gravityScale = 1f;
                    Play = false;
		        }
	        }
	    }
    }

    void CheckPoint() {
        timer = 0;
        CurrentPositionHolder = points[CurrentPoint].transform.position;
        IntermediatePlayerPosition = ball.transform.localPosition;
    }

    public void CreateTrajectory() {
        points = new Transform[100];
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        Play = false;

        string inputExpression = GetInputExpressionFromInputField();

        Solver solver = new Solver();
        var scale = Vector2.one / 5f;
        var position = new Vector3(0,0, -0.01f);

        Debug.Log(ball.transform.position);

        for(int i=0; i<slider.value; i++) {
            //position.x = ball.position.x+(((i + 0.05f ) / 5f )+1f);
            position.x = StartPosition.x + (i/5f)-1f;
            position.y = solver.CalculateY(inputExpression, position.x);
            if (points[i] == null) { 
                points[i] = Instantiate(pointTransform);
            }
            Transform point = points[i];
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
	    }
        FirstPointPosition =  new Vector3(StartPosition.x, points[0].position.y, -2f);
        SetBallPosition = true;
    }

    private string GetInputExpressionFromInputField() { 
        string inputExpression = "Unassigned";
        inputExpression = inputField.GetComponent<TMP_InputField>().text;
        if(inputExpression == "Unassigned") {
            throw new UnassignedReferenceException("Input expression not set");
        }

        return inputExpression;
    }

    public void InitialisePlay() {
        CurrentPoint = 0;
        //CheckPoint();
        Debug.Log(ball.transform.localPosition);
        ball.transform.position = FirstPointPosition;
        IntermediatePlayerPosition = FirstPointPosition;
        Play = true;
    }
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Colliding");
    }
}
