using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionalOffset;
    [SerializeField] private float _length;

    private Ball _ball;
    private Pipe _pipe;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;
    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _pipe = FindObjectOfType<Pipe>();

        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;

        TrackBall();
    }
    private void Update()
    {
        if(_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }
    private void TrackBall()
    {
        Vector3 pipePosition = _pipe.transform.position;
        pipePosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (pipePosition - _ball.transform.position).normalized + _directionalOffset;
        _cameraPosition -= direction * _length;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
