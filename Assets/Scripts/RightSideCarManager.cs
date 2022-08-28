using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideCarManager : MonoBehaviour
{
    [Header("Car Holder Settings")]
    [SerializeField] float moveAmountZ;
    [SerializeField] float alignTime;
    [SerializeField] float delayAlign;
    [SerializeField] Transform[] rightSideCars;

    Vector3 _targetPos;
    Vector3 _currentVelocity;

    bool _isAligningPos;
    int _index = 0;

    void Start()
    {
        foreach (Transform car in rightSideCars)
        {
            car.GetComponent<MeshRenderer>().material.color = LevelEditor.Instance.RightSideCarColor;
        }
    }

    void Update()
    {
        if (_isAligningPos)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _targetPos,
                                                    ref _currentVelocity, alignTime * Time.deltaTime);

            if (transform.position == _targetPos)
            {
                _isAligningPos = false;
            }
        }
    }


    public void SendCar()
    {
        StartCoroutine(nameof(ProcessSendCar));
    }

    IEnumerator ProcessSendCar()
    {
        rightSideCars[_index].parent = null;
        rightSideCars[_index].GetComponent<Mover>().enabled = true;
        _index++;

        yield return new WaitForSeconds(delayAlign);

        AlignPosition();
    }

    void AlignPosition()
    {
        _targetPos = new Vector3(transform.position.x, transform.position.y,
                                    transform.position.z + moveAmountZ);
        _isAligningPos = true;
    }
}
