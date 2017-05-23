using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// Player Controller class
    /// This class handles player movement. 
    /// It always follows player's input (Mouse or Touch)
    /// </summary>

    [Range(0, 0.5f)]
    public float followSpeedDelay = 0.1f;       //we want the ball to follow player's input with a small delay.
                                                //delay of 0 leads to immediate follow and delay of 0.5 leads to a lazy follow

    public int fingerOffset = 100;             //Distance between ball and user's input (Mouse or Touch)
                                               //this is required to let player see the ball above the finger

    public float xVelocity = 0.0f;
    public float zVelocity = 0.0f;
    public float yVelocity = 0.0f;
    public Vector3 screenToWorldVector;


    void Start()
    {

        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }


    void Update()
    {



        touchControl();

        screenToWorldVector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + fingerOffset, Input.mousePosition.y + fingerOffset, Input.mousePosition.z + fingerOffset));
        float editorX = Mathf.SmoothDamp(transform.position.x, screenToWorldVector.x, ref xVelocity, followSpeedDelay);
        float editorY = Mathf.SmoothDamp(transform.position.y, screenToWorldVector.y, ref yVelocity, followSpeedDelay);
        float editorZ = Mathf.SmoothDamp(transform.position.z, screenToWorldVector.z, ref zVelocity, followSpeedDelay);

        transform.position = new Vector3(editorX, editorY, editorZ);


        //set offset for ball
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ;



    }



    void touchControl()
    {
        if (Input.touchCount > 0 || Application.isEditor || Application.isWebPlayer)
        {
            screenToWorldVector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + fingerOffset, 10));
            float touchX = Mathf.SmoothDamp(transform.position.x, screenToWorldVector.x, ref xVelocity, followSpeedDelay);
            float touchZ = Mathf.SmoothDamp(transform.position.z, screenToWorldVector.z, ref zVelocity, followSpeedDelay);
            transform.position = new Vector3(touchX, transform.position.y, touchZ);
        }
    }



}
