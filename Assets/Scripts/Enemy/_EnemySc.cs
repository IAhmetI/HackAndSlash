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
    public static bool IsCombat;

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
            IsCombat = true;
            transform.LookAt(pos);
            anim.SetBool("IsCombat",IsCombat);

            // if(Physics.Raycast(FlameDir.transform.position,FlameDir.transform.forward,out hit, Menzil));
            // {
            //     if(hit.transform.tag == "Player")
            //     {
            //         Debug.Log(_CharacterController.PlayerHealth);
            //     }
            //     else
            //     {
            //         Debug.Log("Iska");
            //     }
            // }
        }
        else
        {   
            IsCombat = false;
            anim.SetBool("IsCombat",IsCombat);
        }
    }
}
