using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _FlameEnemy : MonoBehaviour
{
    public GameObject _Fireball;
    // private bool _fireballthrow;
    public Transform _throwdirection;   
    // public static Transform throwdirection; 
    private float _throwspeed = .9f;
    private float _throwspeedactive = 0 ;
 
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        // throwdirection = _throwdirection;
    }

    void Update()
    {
        if (_throwspeedactive > 0)
        {
            _throwspeedactive -= Time.deltaTime /3;
        }

        if(_EnemySc.IsCombat)
        {
            if (_throwspeedactive <= 0)
            {
                GameObject go = Instantiate(_Fireball, _throwdirection.transform.position,new Quaternion());
                _Fireballsc _fireball = go.GetComponent<_Fireballsc>();
                if(_fireball != null)
                {
                    _fireball.Seek(_target);
                }
                _throwspeedactive = _throwspeed;

                // _fireballthrow = true;
                // GameObject go = Instantiate(_Fireball, FireBallAim.dir.transform.position,new Quaternion());
                // if (transform.localScale.z < 0)
                // {
                //     go.GetComponent<_Fireballsc>().fireball_left();
                // }
            }
        }
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        // target = player.transform.position;
        // dir = target;
        // transform.right = dir;
        // else
        // {
        //     _fireballthrow=false;
        // }
    }
}
