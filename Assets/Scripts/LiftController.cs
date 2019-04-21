using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static LiftController Instance;
    private int _currentFloor;
    private Direction _liftDirection;


    private void Awake()
    {
        Instance = this;

        _currentFloor = 1;
        _liftDirection = Direction.Stopped;
    }


    public void SetNextFloor(int Floor, Command CommandSource)
    {

        Direction NewDirection = Direction.Stopped;

        int DirectionSign = Floor - _currentFloor;

        if (DirectionSign > 0)
        {
            NewDirection = Direction.Up;
        }
        else if (DirectionSign < 0)
        {
            NewDirection = Direction.Down;
        }

        
        if (CommandSource == Command.FromInside || NewDirection == _liftDirection || _liftDirection == Direction.Stopped)
        {
            GoToFloor(Floor, NewDirection);
        }

    }

    private void GoToFloor(int TargetFloor, Direction NewDirection)
    {
        if (TargetFloor == _currentFloor && _liftDirection == Direction.Stopped)
        {
            OpenDoors();
        }
        else
        {
            _liftDirection = NewDirection;
            StartCoroutine(FloorCounter(TargetFloor));
        }
    }

    public void StopLift()
    {
        StopCoroutine(FloorCounter(0));
        _liftDirection = Direction.Stopped;
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
                Debug.Log(_currentFloor); ///

            }
            else
            {
                _currentFloor--;
                Debug.Log(_currentFloor); ///
            } 

        }

        StopLift();
        OpenDoors();
    }

    public Direction GetDirection()
    {
        return _liftDirection;
    }



}
