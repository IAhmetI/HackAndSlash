using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _WeaponController : MonoBehaviour
{
    bool isStrafe = false;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("IsStrafe",isStrafe);

        if(Input.GetKeyDown(KeyCode.F))
        {
            isStrafe = !isStrafe;
        }

        if(isStrafe == true)
        {
            GetComponent<_CharacterController>().MoveType=_CharacterController.MovementType.Strafe;
        }

        if(isStrafe == false)
        {
            GetComponent<_CharacterController>().MoveType=_CharacterController.MovementType.Directional;
        }
    }
}
