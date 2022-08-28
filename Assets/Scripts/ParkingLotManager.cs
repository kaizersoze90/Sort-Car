using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingLotManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] leftSideLots;
    [SerializeField] SpriteRenderer[] rightSideLots;

    void Start()
    {
        foreach (SpriteRenderer lot in leftSideLots)
        {
            lot.color = LevelEditor.Instance.LeftSideLotColor;
        }

        foreach (SpriteRenderer lot in rightSideLots)
        {
            lot.color = LevelEditor.Instance.RightSideLotColor;
        }
    }
}
