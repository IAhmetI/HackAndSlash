using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _FlameEnemy : MonoBehaviour
{
    public GameObject _Fireball;

    // private bool _fireballthrow;

    private Vector2 dir;
    public Transform _throwdirection;    
    private Vector2 target;

    private float _throwspeed = 0.9f;
    private float _throwspeedactive = 0;
 
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (_throwspeedactive > 0)
        {
            _throwspeedactive -= Time.deltaTime;
        }

        if (_throwspeedactive <= 0)
        {
            // _fireballthrow = true;
            GameObject go = Instantiate(_Fireball, _throwdirection.transform.position,new Quaternion());
            // GameObject go = Instantiate(_Fireball, FireBallAim.dir.transform.position,new Quaternion());

            if (transform.localScale.x < 0)
            {
                go.GetComponent<_Fireballsc>().fireball_left();
            }

            _throwspeedactive = _throwspeed;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform.position;

        dir = target;

        transform.right = dir;

        // else
        // {
        //     _fireballthrow=false;
        // }

    }
}
