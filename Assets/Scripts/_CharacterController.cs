using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterController : MonoBehaviour
{
    float Inputx;
    float Inputy;

    public Transform model;

    Animator Anim;

    Vector3 StickDirection;

    Camera mainCam;

    public float damp;

    [Range(1, 20)]
    public float rotationSpeed;

    void Start()
    {
        Anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }


    private void LateUpdate()
    {
        Inputx = Input.GetAxis("Horizontal");
        Inputy = Input.GetAxis("Vertical");

        StickDirection = new Vector3(Inputx, 0, Inputy);

        InputMove();
        InputRotation();

    }

    void InputMove()
    {
        Anim.SetFloat("speed", Vector3.ClampMagnitude(StickDirection, 1).magnitude, damp, Time.deltaTime*10);

    }

    void InputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;

        model.forward = Vector3.Slerp(model.forward, rotOfset, Time.deltaTime*rotationSpeed);



    }
}