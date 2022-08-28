using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public static LevelEditor Instance { get; private set; }

    public float Speed { get; private set; }
    public float ReachTime { get; private set; }
    public float TurnSpeed { get; private set; }
    public float BarrierSpeed { get; private set; }
    public float ButtonPressSpeed { get; private set; }
    public Color LeftSideCarColor { get; private set; }
    public Color LeftSideLotColor { get; private set; }
    public Color LeftButtonColor { get; private set; }
    public Color LeftBarrierPrimaryColor { get; private set; }
    public Color LeftBarrierSecondaryColor { get; private set; }
    public Color RightSideCarColor { get; private set; }
    public Color RightSideLotColor { get; private set; }
    public Color RightButtonColor { get; private set; }
    public Color RightBarrierPrimaryColor { get; private set; }
    public Color RightBarrierSecondaryColor { get; private set; }

    [Header("Car Settings")]
    [SerializeField] float carSpeed;
    [SerializeField] float destinationReachTime;
    [SerializeField] float turnSpeed;
    [SerializeField] Color leftSideCarColor;
    [SerializeField] Color rightSideCarColor;

    [Header("Platform Settings")]
    [SerializeField] float barrierSpeed;
    [SerializeField] float buttonPressSpeed;
    [SerializeField] Color leftSideLotColor;
    [SerializeField] Color leftButtonColor;
    [SerializeField] Color leftBarrierPrimaryColor;
    [SerializeField] Color leftBarrierSecondaryColor;
    [SerializeField] Color rightSideLotColor;
    [SerializeField] Color rightButtonColor;
    [SerializeField] Color rightBarrierPrimaryColor;
    [SerializeField] Color rightBarrierSecondaryColor;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Speed = carSpeed;
        ReachTime = destinationReachTime;
        TurnSpeed = turnSpeed;
        LeftSideCarColor = leftSideCarColor;
        RightSideCarColor = rightSideCarColor;
        LeftSideLotColor = leftSideLotColor;
        RightSideLotColor = rightSideLotColor;
        LeftButtonColor = leftButtonColor;
        RightButtonColor = rightButtonColor;
        LeftBarrierPrimaryColor = leftBarrierPrimaryColor;
        RightBarrierPrimaryColor = rightBarrierPrimaryColor;
        LeftBarrierSecondaryColor = leftBarrierSecondaryColor;
        RightBarrierSecondaryColor = rightBarrierSecondaryColor;
        BarrierSpeed = barrierSpeed;
        ButtonPressSpeed = buttonPressSpeed;
    }

}
