using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Fireballsc : MonoBehaviour
{
    [SerializeField] private float _fireballthrowspeed;

    private Transform target;

    void Start()
    {
        Destroy (gameObject, 3f);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void FixedUpdate()
    {
        transform.position += new Vector3 (0,0,_fireballthrowspeed*-Time.fixedDeltaTime);
    }

    public void fireball_left()
    {
        _fireballthrowspeed *= 1;
    }
}
