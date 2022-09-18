using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Fireballsc : MonoBehaviour
{
    [SerializeField] private float _fireballthrowspeed;

    void Start()
    {
        Destroy (gameObject, 5f);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3 (0, 0, _fireballthrowspeed*-Time.deltaTime);
    }

    public void fireball_left()
    {
        _fireballthrowspeed *= -1;
    }
}
