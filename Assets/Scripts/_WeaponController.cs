using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _WeaponController : MonoBehaviour
{
    // public float attackIndex;

    bool isStrafe = false;
    bool canAttack = true;

    Animator anim;

    public GameObject trails;
    public GameObject handWeapon;
    public GameObject backWeapon;


    private void Start()
    {
        anim = GetComponent<Animator>();
        trailclose();
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
            GetComponent<_IkLook>().Less();
        }

        if(isStrafe == false)
        {
            GetComponent<_CharacterController>().MoveType=_CharacterController.MovementType.Directional;
            GetComponent<_IkLook>().Plus();
        }

        if(Input.GetKeyUp(KeyCode.Mouse0) && isStrafe==true && canAttack==true)
        {
            // attackIndex = Random.Range(0,6);
            // anim.SetFloat("AttackIndex",attackIndex);
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

    public void trailopen()
    {
        for (int i = 0; i < trails.transform.childCount; i++)
        {
            trails.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = true;
        }
    }

    public void trailclose()
    {
        for (int i = 0; i < trails.transform.childCount; i++)
        {
            trails.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = false;
        }
    }
}
