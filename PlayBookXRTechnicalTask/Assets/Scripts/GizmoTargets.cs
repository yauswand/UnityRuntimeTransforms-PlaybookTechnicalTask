using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoTargets : MonoBehaviour
{
    private GameObject alltarget;
    public GameObject scaletarget;
    public GameObject translatetarget;
    public GameObject rotatetarget;

    private void Start()
    {
        scaletarget.GetComponent<GizmoScaleScript>();
    }


}
