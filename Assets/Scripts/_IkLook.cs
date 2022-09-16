using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _IkLook : MonoBehaviour
{
    Animator anim;
    Camera mainCam;

    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(.6f,.5f,1.2f,.5f,.5f);

        Ray lookAtRay = new Ray(transform.position,mainCam.transform.forward);
        anim.SetLookAtPosition(lookAtRay.GetPoint(25));
    }
}
