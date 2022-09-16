using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _IkLook : MonoBehaviour
{
    Animator anim;
    Camera mainCam;
    float weight = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(weight,.5f,1.2f,.5f,.5f);

        Ray lookAtRay = new Ray(transform.position,mainCam.transform.forward);
        anim.SetLookAtPosition(lookAtRay.GetPoint(25));
    }

    public void Plus()
    {
        weight = Mathf.Lerp(weight,1f,Time.fixedDeltaTime);
    }

    public void Less()
    {
        weight = Mathf.Lerp(weight,0,Time.fixedDeltaTime);
    }
}
