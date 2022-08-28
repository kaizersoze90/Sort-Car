using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortManager : MonoBehaviour
{
    [SerializeField] Transform[] leftSideSortedLots; //all parking lots sorted according left car position
    [SerializeField] Transform[] rightSideSortedLots; //all parking lots sorted according right car position

    ParkingLot[] _lots;

    int _leftIndex = 0;
    int _rightIndex = 0;
    int _successCount;

    void Start()
    {
        _lots = FindObjectsOfType<ParkingLot>();
    }

    public Transform[] GetWaypoints(GameObject car)
    {
        if (car.CompareTag("LeftSideCar"))
        {
            //Getting all waypoints for left side cars
            Transform[] waypoints = leftSideSortedLots[_leftIndex].GetComponent<ParkingLot>().Path(car);

            //If parking lot is occupied, it will return null then skip to next one
            while (waypoints == null)
            {
                _leftIndex++;
                Transform[] nextWaypoints = leftSideSortedLots[_leftIndex].GetComponent<ParkingLot>().Path(car);
                if (nextWaypoints != null)
                {
                    return nextWaypoints;
                }
            }

            //If parking lot is not occupied then return it
            _leftIndex++;

            return waypoints;
        }
        else if (car.CompareTag("RightSideCar"))
        {
            //Same logic with the left side car
            Transform[] waypoints = rightSideSortedLots[_rightIndex].GetComponent<ParkingLot>().Path(car);

            while (waypoints == null)
            {
                _rightIndex++;
                Transform[] nextWaypoints = rightSideSortedLots[_rightIndex].GetComponent<ParkingLot>().Path(car);
                if (nextWaypoints != null)
                {
                    return nextWaypoints;
                }
            }

            _rightIndex++;

            return waypoints;
        }

        return null;
    }

    public void CheckMyStatus(GameObject car, GameObject parkingLot)
    {
        //If car and parking lot matches then show green tick. Otherwise, gameover.
        if (car.CompareTag("LeftSideCar") && parkingLot.CompareTag("LeftSideLot")
            || car.CompareTag("RightSideCar") && parkingLot.CompareTag("RightSideLot"))
        {
            parkingLot.GetComponent<ParkingLot>().ShowGreenTick();
        }
        else
        {
            GameManager.Instance.GameOver();
        }

        CheckVictoryCondition();
    }

    void CheckVictoryCondition()
    {
        _successCount++;

        if (_successCount > _lots.Length - 1)
        {
            GameManager.Instance.Victory();
        }
    }
}
