using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingLot : MonoBehaviour
{
    [SerializeField] Transform[] leftSideCarWaypoints;
    [SerializeField] Transform[] rightSideCarWaypoints;

    GameObject _greenTick;

    bool _isOccupied;

    void Start()
    {
        _greenTick = transform.GetChild(0).gameObject;
    }

    public Transform[] Path(GameObject car)
    {
        if (car.CompareTag("LeftSideCar") && !_isOccupied)
        {
            _isOccupied = true;
            return leftSideCarWaypoints;
        }
        else if (car.CompareTag("RightSideCar") && !_isOccupied)
        {
            _isOccupied = true;
            return rightSideCarWaypoints;
        }

        return null;
    }

    public void ShowGreenTick()
    {
        _greenTick.SetActive(true);
    }
}
