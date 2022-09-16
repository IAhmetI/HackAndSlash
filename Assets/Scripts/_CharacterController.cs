using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterController : MonoBehaviour
{
    [Header("Metrics")]
    public float damp;
    [Range(1, 20)]
    public float rotationSpeed;
    float normalFov;
    public float runFov;

    float Inputx;
    float Inputy;
    float max_speed;

    public Transform model;

    Animator Anim;

    Vector3 StickDirection;

    Camera mainCam;

    public KeyCode RunButton = KeyCode.LeftShift;
    public KeyCode WalkButton = KeyCode.C;

    void Start()
    {
        Anim = GetComponent<Animator>();
        mainCam = Camera.main;
        normalFov = mainCam.fieldOfView;
    }


    private void LateUpdate()
    {
        InputMove();
        InputRotation();
        Movement();
    }

    void Movement()
    {
        StickDirection = new Vector3(Inputx, 0,Inputy);

        if(Input.GetKey(RunButton))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView,runFov,Time.deltaTime*2);

            max_speed =2f;
            Inputx = 2* Input.GetAxis("Horizontal");
            Inputy = 2* Input.GetAxis("Vertical");
        }

        else if(Input.GetKey(WalkButton))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView,normalFov,Time.deltaTime*2);

            max_speed =0.2f;
            Inputx = Input.GetAxis("Horizontal");
            Inputy = Input.GetAxis("Vertical");
        }
        else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView,normalFov,Time.deltaTime*2);

            max_speed =1f;
            Inputx = Input.GetAxis("Horizontal");
            Inputy = Input.GetAxis("Vertical");
        }
    }

    void InputMove()
    {
        Anim.SetFloat("speed", Vector3.ClampMagnitude(StickDirection, max_speed).magnitude, damp, Time.deltaTime*10);

    }

    void InputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;

        model.forward = Vector3.Slerp(model.forward, rotOfset, Time.deltaTime*rotationSpeed);
    }
}