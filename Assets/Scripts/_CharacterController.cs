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
    public float StrafeTurnSpeed;


    float Inputx;
    float Inputy;
    float max_speed;

    public Transform model;

    Animator Anim;

    Vector3 StickDirection;

    Camera mainCam;

    public KeyCode RunButton = KeyCode.LeftShift;
    public KeyCode WalkButton = KeyCode.C;

    public enum MovementType {
        Directional,
        Strafe  };
    
    public MovementType MoveType;

    void Start()
    {
        Anim = GetComponent<Animator>();
        mainCam = Camera.main;
        normalFov = mainCam.fieldOfView;
    }

    private void LateUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if(MoveType == MovementType.Strafe)
        {
            Inputx = Input.GetAxis("Horizontal");
            Inputy = Input.GetAxis("Vertical");

            Anim.SetFloat("iX",Inputx,damp,Time.deltaTime*10);
            Anim.SetFloat("iY",Inputy,damp,Time.deltaTime*10);

            var ismove = Inputx != 0 || Inputy != 0 ;

            if(ismove)
            {
                float yawCamera = mainCam.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,yawCamera,0), StrafeTurnSpeed * Time.fixedDeltaTime);
                Anim.SetBool("StrafeMoving",true);
            }

            else
            {
                Anim.SetBool("StrafeMoving",false);
            }

        }

        if(MoveType == MovementType.Directional)
        {

            InputRotation();
            InputMove();

            StickDirection = new Vector3(Inputx, 0,Inputy);

            if(Input.GetKey(RunButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView,runFov,Time.deltaTime*2);

                max_speed =2f;
                Inputx = 2* Input.GetAxis("Horizontal");
                Inputy = 2* Input.GetAxis("Vertical");
            }

            //   else if(Input.GetKey(WalkButton))
            //   {
            //       mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView,normalFov,Time.deltaTime*2);

            //       max_speed =0.2f;
            //       Inputx = Input.GetAxis("Horizontal");
            //       Inputy = Input.GetAxis("Vertical");
            //   }
            else
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView,normalFov,Time.deltaTime*2);

                max_speed =0.5f;
                Inputx = Input.GetAxis("Horizontal");
                Inputy = Input.GetAxis("Vertical");
            }           
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