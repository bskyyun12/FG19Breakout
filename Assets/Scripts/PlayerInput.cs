using UnityEngine;
using UnityEngine.Assertions;


public class PlayerInput : MonoBehaviour
{

    private Camera playerCamera; // Defalut value is null​
    private Flip leftFlipper;
    private Flip rightFlipper;
    private const string leftFlipperName = "LeftFlipper";
    private const string rightFlipperName = "RightFlipper";

    private void Awake()
    {
        playerCamera = Camera.main; // Camera.main uses find object of tag internally, super rude.​

        leftFlipper = GetFlipper(leftFlipperName);
        Assert.IsNotNull(leftFlipper, "Child: " + leftFlipperName + " was not found.");

        rightFlipper = GetFlipper(rightFlipperName);
        Assert.IsNotNull(rightFlipper, "Child: " + rightFlipperName + " was not found.");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        /////////////////////////////////////////
        float xPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

        //returns "true" or "false" depending on if button is pressed or not / released or not.​
        leftFlipper.isPressed = Input.GetButton(leftFlipperName);
        rightFlipper.isPressed = Input.GetButton(rightFlipperName);
    }

    private Flip GetFlipper(string flipperName)
    {
        // Transform flipperTransform = transform.Find(flipperName); //look through child objects to find it... or something.. couldnt hear properly.​
        //Assert.IsNotNull(flipperTransform, "Child: " + flipperName + " was not found!");​
        //Flippy flipper = flipperTransform.GetComponent<Flippy>();​
        //Assert.IsNotNull(flipper, "Child: " + flipperName + " missing Flipper script!");​
        //this one line replaces all above commented code in this method.​
        //need "Assert" elsewhere if not in here, though​
        return transform.Find(flipperName)?.GetComponent<Flip>();
    }
}

