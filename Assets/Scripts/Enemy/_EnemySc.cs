using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemySc : MonoBehaviour
{
    public float Menzil;
    public float mesafe;
    public Transform target;
    public GameObject FlameDir;
    public static int EnemyHealth = 100;
    private int _EnemyHealth;
    public int _damage;

    Vector3 pos;

    RaycastHit hit;

    private Animator anim;

    void Start()
    {
        _EnemyHealth = EnemyHealth;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        mesafe = Vector3.Distance(transform.position,target.position);
        pos = new Vector3(target.position.x,target.position.y,target.position.z);

        if(mesafe < 10f)
        {
            transform.LookAt(pos);
            anim.SetBool("IsCombat",true);

            if(Physics.Raycast(FlameDir.transform.position,FlameDir.transform.forward,out hit, Menzil));
            {
                if(hit.transform.tag == "Player")
                {
                    Debug.Log(_CharacterController.PlayerHealth);
                }
                else
                {
                    Debug.Log("Iska");
                }
            }
        }
        else
        {   
            anim.SetBool("IsCombat",false);
        }
    }
}
