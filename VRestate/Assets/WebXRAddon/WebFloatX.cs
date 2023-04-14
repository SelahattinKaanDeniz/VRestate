using Zinnia.Action;
using WebXR;
using Unity;

public class WebFloatX : FloatAction
{
    public WebXRController controller;
    private float xAxis;



    // Update is called once per frame
    void Update()
    {
        var vector2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        //print("vector2X " + vector2);
        xAxis = vector2.x;
        //print("xAxis " + xAxis);
        Receive(xAxis);
    }
   
}
