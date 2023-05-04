using Zinnia.Action;
using WebXR;
using Unity;

public class WebFloatY : FloatAction
{
    public WebXRController controller;
    private float yAxis;

    // Update is called once per frame
    void Update()
    {
        var vector2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        //print("vector2Y " + vector2);
        yAxis = vector2.y;
        //print("YAXIS " + yAxis);
        Receive(yAxis);
    }
}
