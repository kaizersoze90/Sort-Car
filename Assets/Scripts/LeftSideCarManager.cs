using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideCarManager : MonoBehaviour
{
    [Header("Car Holder Settings")]
    [SerializeField] float moveAmountZ;
    [SerializeField] float alignTime;
    [SerializeField] float delayAlign;
    [SerializeField] Transform[] leftSideCars;

    Vector3 _targetPos;
    Vector3 _currentVelocity;

    bool _isAligningPos;
    int _index = 0;

    void Start()
    {
        foreach (Transform car in leftSideCars)
        {
            car.GetComponent<MeshRenderer>().material.color = LevelEditor.Instance.LeftSideCarColor;
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
        leftSideCars[_index].parent = null;
        leftSideCars[_index].GetComponent<Mover>().enabled = true;
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
