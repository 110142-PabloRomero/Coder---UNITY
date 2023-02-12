using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed_Walk;
    [SerializeField] private float speed_Run;
    //[SerializeField] private Animator ninjaAnimator;
    private static readonly int Speed = 5;//Animator.StringToHash("Speed");
    [SerializeField] private Camera m_camera;
    [SerializeField] private float rotationSpeed;


    private void Start()
    {

    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.None : CursorLockMode.Confined;
    }

    void Update()
    {
        Move(GetMovementInput());
        Rotate(GetRotationInput());
        
    }

    

    private Vector2 GetRotationInput()
    {
        var l_mouseX = Input.GetAxis("Mouse X") * 3;
        var l_mouseY = Input.GetAxis("Mouse Y") * 3;
        return new Vector2(l_mouseX, l_mouseY);
    }

    private Vector3 GetMovementInput()
    {
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");
        return new Vector3(l_horizontal, 0, l_vertical).normalized;
    }

    private void Move(Vector3 p_inputMovement)
    {
        if (Input.GetKey(KeyCode.LeftShift))

        {
            var transform1 = transform;
            transform1.position += (p_inputMovement.z * transform1.forward + p_inputMovement.x * transform1.right) *
                                   (speed_Run * Time.deltaTime);
            // ninjaAnimator.SetFloat(Speed, p_inputMovement.magnitude);
        }
        else
        {
            var transform1 = transform;
            transform1.position += (p_inputMovement.z * transform1.forward + p_inputMovement.x * transform1.right) *
                                   (speed_Walk * Time.deltaTime);
            // ninjaAnimator.SetFloat(Speed, p_inputMovement.magnitude);
        }

    }
    private void Rotate(Vector2 p_scrollDelta)
    {
        transform.Rotate(Vector3.up, p_scrollDelta.x * rotationSpeed * Time.deltaTime, Space.Self);
    }

    

}
