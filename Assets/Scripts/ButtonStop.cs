
public class ButtonStop : ButtonBase
{

    private void Awake()
    {
        AddOnClick(Stop);
    }


    private void Stop()
    {
        LiftController.Instance.StopLift();
    }

}
