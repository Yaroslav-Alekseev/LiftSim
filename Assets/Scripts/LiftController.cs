﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Command
{
    FromInside,
    FromOutside
}

public enum Direction
{
    Up,
    Down,
    Stopped
}

public class LiftController : MonoBehaviour
{

    public Text LiftIndicator;
    public InputField PlayerOnFloor;

    public static LiftController Instance;

    private int _currentFloor;
    private Direction _liftDirection;


    private void Awake()
    {
        Instance = this;

        _liftDirection = Direction.Stopped;

        _currentFloor = 1;
        LiftIndicator.text = "1";
        PlayerOnFloor.text = "1";

        PlayerOnFloor.onValueChanged.AddListener(delegate { LimitInputValue(); } );

    }


    public void SetNextFloor(int Floor, Command CommandSource, Direction CallDirection = Direction.Stopped)
    {

        Direction NewDirection = Direction.Stopped;

        switch (CommandSource)
        {
            case Command.FromOutside: 
                {
                    NewDirection = CallDirection;
                    break;
                }
                
            case Command.FromInside:
                {
                    int DirectionSign = Floor - _currentFloor;

                    if (DirectionSign > 0)
                    {
                        NewDirection = Direction.Up;
                        _liftDirection = NewDirection;
                    }
                    else if (DirectionSign < 0)
                    {
                        NewDirection = Direction.Down;
                        _liftDirection = NewDirection;
                    }
                    break;
                }

        }


        bool InsideCall = (CommandSource == Command.FromInside);

        bool StoppedLift = (_liftDirection == Direction.Stopped);

        bool PermittedUpCall = (NewDirection == _liftDirection) && (NewDirection == Direction.Up) && (Floor >= _currentFloor);

        bool PermittedDownCall = (NewDirection == _liftDirection) && (NewDirection == Direction.Down) && (Floor <= _currentFloor);

        if (InsideCall || StoppedLift || PermittedUpCall || PermittedDownCall)
        {
            GoToFloor(Floor, NewDirection);
        }

    }

    private void GoToFloor(int TargetFloor, Direction NewDirection)
    {
        if (TargetFloor == _currentFloor && _liftDirection == Direction.Stopped)
        {
            StopLift();
        }
        else
        {
            _liftDirection = NewDirection;
            CloseDoors();

            StopAllCoroutines();
            StartCoroutine(FloorCounter(TargetFloor));
        }
    }

    public void StopLift()
    {
        StopAllCoroutines();
        _liftDirection = Direction.Stopped;

        OpenDoors();
    }

    private void OpenDoors()
    {
        Debug.Log("Двери открываются!");
    }

    private void CloseDoors()
    {
        Debug.Log("Двери закрываются!");
    }

    private IEnumerator FloorCounter(int TargetFloor)
    {
        while (_currentFloor != TargetFloor)
        {
            yield return new WaitForSeconds(0.5f) /*speed*/;

            if (TargetFloor > _currentFloor)
            {
                _currentFloor++;

            }
            else
            {
                _currentFloor--;
            }

            LiftIndicator.text = _currentFloor.ToString();
        }

        StopLift();
    }

    public Direction GetDirection()
    {
        return _liftDirection;
    }

    private void LimitInputValue()
    {
        int Floors = int.Parse(PlayerOnFloor.text);

        if (Floors > 30)
        {
            Floors = 30;
            PlayerOnFloor.text = "30";
        }
        else if (Floors <= 0)
        {
            Floors = 1;
            PlayerOnFloor.text = "1";
        }
    }


}
