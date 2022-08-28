using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Header("Barrier Materials")]
    [SerializeField] Material leftBarrierPrimary;
    [SerializeField] Material leftBarrierSecondary;
    [SerializeField] Material rightBarrierPrimary;
    [SerializeField] Material rightBarrierSecondary;

    Animator _animator;
    LeftSideCarManager _leftSideCarManager;
    RightSideCarManager _rightSideCarManager;

    bool _isRightButtonPressed;
    bool _isLeftButtonPressed;
    float _barrierSpeed;
    float _buttonPressSpeed;

    void Start()
    {
        leftBarrierPrimary.color = LevelEditor.Instance.LeftBarrierPrimaryColor;
        leftBarrierSecondary.color = LevelEditor.Instance.LeftBarrierSecondaryColor;
        rightBarrierPrimary.color = LevelEditor.Instance.RightBarrierPrimaryColor;
        rightBarrierSecondary.color = LevelEditor.Instance.RightBarrierSecondaryColor;
        _barrierSpeed = LevelEditor.Instance.BarrierSpeed;
        _buttonPressSpeed = LevelEditor.Instance.ButtonPressSpeed;

        _animator = GetComponent<Animator>();
        _animator.SetFloat("BarrierSpeed", _barrierSpeed);
        _animator.SetFloat("ButtonSpeed", _buttonPressSpeed);

        _leftSideCarManager = FindObjectOfType<LeftSideCarManager>();
        _rightSideCarManager = FindObjectOfType<RightSideCarManager>();
    }


    public void TriggerRightButton()
    {
        if (_isRightButtonPressed) { return; }

        _isRightButtonPressed = true;

        _animator.SetTrigger("RightButton");
    }

    public void TriggerLeftButton()
    {
        if (_isLeftButtonPressed) { return; }

        _isLeftButtonPressed = true;

        _animator.SetTrigger("LeftButton");
    }

    //
    // CALLING BELOW METHODS FROM ANIMATION EVENTS
    //

    void TriggerRightBarrier()
    {
        _animator.SetTrigger("RightBarrier");
    }

    void SetRightButton()
    {
        _isRightButtonPressed = false;
    }

    void TriggerLeftBarrier()
    {
        _animator.SetTrigger("LeftBarrier");
    }

    void SetLeftButton()
    {
        _isLeftButtonPressed = false;
    }

    void SendLeftCar()
    {
        _leftSideCarManager.SendCar();
    }

    void SendRightCar()
    {
        _rightSideCarManager.SendCar();
    }
}
