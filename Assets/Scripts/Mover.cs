using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    SortManager _sortManager;
    Vector3 _currentVelocity;
    Transform[] _waypoints;

    bool _isMoving;
    int _moveIndex;
    int _faceIndex;
    float _speed;
    float _reachTime;
    float _turnSpeed;

    void OnEnable()
    {
        _sortManager = FindObjectOfType<SortManager>();

        _waypoints = _sortManager.GetWaypoints(gameObject);

        _speed = LevelEditor.Instance.Speed;
        _reachTime = LevelEditor.Instance.ReachTime;
        _turnSpeed = LevelEditor.Instance.TurnSpeed;

        _isMoving = true;
    }

    void Update()
    {
        if (!_isMoving) { return; }

        //Checking if the car matches with the correct parking lot on final position
        if (_moveIndex > _waypoints.Length - 1)
        {
            _isMoving = false;

            _sortManager.CheckMyStatus(gameObject, _waypoints[_waypoints.Length - 1].gameObject);

            return;
        }

        MoveToTarget();
        FaceToTarget();
    }

    void MoveToTarget()
    {
        Vector3 targetPos = new Vector3(_waypoints[_moveIndex].position.x, transform.position.y, _waypoints[_moveIndex].position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos,
                                               ref _currentVelocity, _reachTime, _speed, Time.deltaTime);

        if (Vector3.Distance(transform.position, _waypoints[_moveIndex].position) < 2.5f)
        {
            _moveIndex++;
        }
    }

    void FaceToTarget()
    {
        if (_faceIndex > _waypoints.Length - 1)
        {
            _faceIndex = _waypoints.Length - 1;
        }

        Vector3 direction = (_waypoints[_faceIndex].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 90f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);

        if (Vector3.Distance(transform.position, _waypoints[_faceIndex].position) < 15f)
        {
            _faceIndex++;
        }
    }
}
