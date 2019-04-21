using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{

    private static List<ButtonBase> _selectableFloorButtons = new List<ButtonBase>();
    private static List<ButtonBase> _selectableArrowButtons = new List<ButtonBase>();


    private void OnDestroy()
    {
        _selectableFloorButtons.Clear();
        _selectableArrowButtons.Clear();
    }


    public static void AddFloorButton(ButtonBase button)
    {
        if (!_selectableFloorButtons.Contains(button))
        {
            _selectableFloorButtons.Add(button);
        }
    }

    public static void AddArrowButton(ButtonBase button)
    {
        if (!_selectableArrowButtons.Contains(button))
        {
            _selectableArrowButtons.Add(button);
        }
    }

    public static void RemoveFloorButton(ButtonBase button)
    {
        if (_selectableFloorButtons.Contains(button))
        {
            _selectableFloorButtons.Remove(button);
        }
    }

    public static void RemoveArrowButton(ButtonBase button)
    {
        if (_selectableArrowButtons.Contains(button))
        {
            _selectableArrowButtons.Remove(button);
        }
    }

    public static void DeselectAllFloors()
    {
        foreach (var btn in _selectableFloorButtons)
        {
            btn.Selection.SetActive(false);
        }
    }

    public static void DeselectAllArrows()
    {
        foreach (var btn in _selectableArrowButtons)
        {
            btn.Selection.SetActive(false);
        }
    }

    public static void SelectFloorButton(ButtonBase button)
    {
        DeselectAllFloors();

        button.Selection.SetActive(true);
    }

    public static void SelectArrowButton(ButtonBase button)
    {
        DeselectAllArrows();

        button.Selection.SetActive(true);
    }

}
