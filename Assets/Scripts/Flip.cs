using UnityEngine;
using UnityEngine.Assertions;

public class Flip : MonoBehaviour
{
    public float flipperSpeed = 1000f;
    public float reverseMod = 1f;
    //flipper has been pressed or not pressed​
    // [HideInInspector] public bool isPressed = false; //hideininspector, doesnt show in unity despite being public. designers can't change it.​
    [System.NonSerialized] public bool isPressed = false; //better way to do the same as above. //seralized means that unity saves the value.​

    private HingeJoint2D hinge;

    private void Awake()
    {
        //type datatype that you want inside <> ​
        //() after = method. ​
        //gets you one or more components from the hinge joint thingie in unity, depending on which command you use. e.g. Component = one.​
        hinge = GetComponent<HingeJoint2D>();
        //make sure it's not Null​
        Assert.IsNotNull(hinge, "Couldn't find the hinge component."); //This will only run in debug mode.​
        //motor = hinge.motor; //- need to specify a value. otherwise value is null which causes runtime crash.​
    }

    private void FixedUpdate()
    {
        if (isPressed)
        {
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = reverseMod * flipperSpeed;
            hinge.motor = motor;
        }
        else
        {
            // View - tasklist shows todo list in comments, when using colon. "hack" "todo" "undone "unresolvedmergeconflict" are key words. can add more keywords.​
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = reverseMod * -flipperSpeed;
            hinge.motor = motor;
        }
    }
}