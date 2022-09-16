using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _WeaponController : MonoBehaviour
{
    int attackIndex;
    bool isStrafe = false;
    bool canAttack = true;

    Animator anim;

    public GameObject handWeapon;
    public GameObject backWeapon;


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

        if(Input.GetKeyDown(KeyCode.Mouse0) && isStrafe==true && canAttack==true)
        {
            attackIndex = Random.Range(0,3);
            anim.SetInteger("AttackIndex",attackIndex);
            anim.SetTrigger("Attack");
        }

    }

    void Equip()
    {
        backWeapon.SetActive(false);
        handWeapon.SetActive(true);
    }

    void UnEquip()
    {
        backWeapon.SetActive(true);
        handWeapon.SetActive(false);
    }
}
