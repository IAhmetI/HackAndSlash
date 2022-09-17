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
        transform.position += new Vector3 (_fireballthrowspeed*Time.fixedDeltaTime, 0, 0);
    }

    public void fireball_left()
    {
        _fireballthrowspeed *= -1;
    }
}
