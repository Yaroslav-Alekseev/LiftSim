using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelController : MonoBehaviour
{

    public GameObject LayoutGroup; 
    public ButtonSetFloor ButtonPrefab;
    public Transform ButtonStop;
    public InputField FloorsCount;


    private void Awake()
    {
        FloorsCount.text = "30";
        FloorsCount.onValueChanged.AddListener(delegate { FillLayout(); });
    }

    private void Start()
    {
        FillLayout();
    }


    private void FillLayout()
    {
        var direction = LiftController.Instance.GetDirection();

        if (direction != Direction.Stopped)
        {
            return;
        }


        int Floors = int.Parse(FloorsCount.text);

        if (Floors > 30)
        {
            Floors = 30;
            FloorsCount.text = "30";
        }
        else if (Floors <= 0)
        {
            Floors = 1;
            FloorsCount.text = "1";
        }


        foreach (Transform Button in LayoutGroup.transform)
        {
            if (Button != ButtonStop)
            {
                Destroy(Button.gameObject);
            }
        }


        for (int i = 1; i <= Floors; i++)
        {
            var Button = Instantiate(ButtonPrefab, LayoutGroup.transform);
            Button.TextScript.text = i.ToString();
        }

    }


}
