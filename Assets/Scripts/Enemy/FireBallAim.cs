using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAim : MonoBehaviour
{
    public static Vector2 dir;
    public Vector2 target;

    public void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform.position;

        dir = target - (Vector2)transform.position;

        transform.right = dir;
    }
}
