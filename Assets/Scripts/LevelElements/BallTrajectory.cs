using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrajectory : MonoBehaviour {

    Rigidbody2D _ball;

    [SerializeField]
    LineRenderer _line;

    float _timer;
    float _moveSpeed;

    Vector3 _currentPositionHolder;
    Vector3 _intermediatePlayerPosition;
    int _currentPoint;

    int _pointsInLine;
    bool _shouldMove;

    void Start() {
        _ball = GetComponent<Rigidbody2D>();
        _ball.gravityScale = 0f;
        _timer = 0;
        _moveSpeed = 10f;
        _shouldMove = false;
        _currentPoint = 0;
    }


    // Update is called once per frame
    void Update() {
        _pointsInLine = _line.positionCount;
        if (_shouldMove) {
            Move();
        }
    }

    public void ToggleMove() {
        CheckPoint();
        _ball.transform.DetachChildren();
        _shouldMove = !_shouldMove;
    }


    private void Move() {
        _timer += Time.deltaTime * SelectSpeed(points: _pointsInLine);
        if (_ball.transform.position != _currentPositionHolder) {
            _ball.MovePosition(Vector3.Lerp(_intermediatePlayerPosition, _currentPositionHolder, _timer));
        }
        else {
            if (_currentPoint < _pointsInLine - 1) {
                _currentPoint++;
                CheckPoint();
            }
            else {
                _ball.gravityScale = 1f;
                _shouldMove = false;
            }
        }
    }

    void CheckPoint() {
        _timer = 0;
        _currentPositionHolder = _line.GetPosition(_currentPoint);
        _intermediatePlayerPosition = _ball.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        _shouldMove = false;
        _ball.gravityScale = 1f;
    }

    private float SelectSpeed(int points) {
        var pointFactor = Mathf.Floor(points / 50);
        return _moveSpeed * pointFactor;
    }

}








