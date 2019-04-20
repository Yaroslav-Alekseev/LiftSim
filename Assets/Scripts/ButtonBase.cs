using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonBase : MonoBehaviour
{

    public Button ButtonScript;
    public Text TextScript;
    public GameObject Selection;


    public void AddOnClick(UnityAction action)
    {
        ButtonScript.onClick.AddListener(action);
    }

    public void RemoveOnClick(UnityAction action)
    {
        ButtonScript.onClick.RemoveListener(action);
    }

    public void RemoveAllOnClick()
    {
        ButtonScript.onClick.RemoveAllListeners();
    }

}
