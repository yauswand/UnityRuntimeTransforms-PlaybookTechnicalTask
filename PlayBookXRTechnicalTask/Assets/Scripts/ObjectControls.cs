using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControls : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
   
    public GameObject gizmo;
    private GameObject _gizmo;        
    
    private bool gizmoexists = false;
    

    void Start()
    {
        
        GizmoScaleScript target01 = gizmo.GetComponentInChildren<GizmoScaleScript>();
        GizmoRotateScript target02 = gizmo.GetComponentInChildren<GizmoRotateScript>();
        GizmoTranslateScript target03 = gizmo.GetComponentInChildren<GizmoTranslateScript>();
        target01.scaleTarget = this.gameObject;
        target02.rotateTarget = this.gameObject;
        target03.translateTarget = this.gameObject;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && gizmoexists)
        {
            
            _gizmo.SetActive(false);

        }
    }


    void OnMouseDown()
    {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
       
    }



    void OnMouseOver()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {

                    

                    if (!gizmoexists)
                    {
                        
                        _gizmo = Instantiate(gizmo, this.gameObject.transform.position, Quaternion.identity);
                        _gizmo.transform.localScale = _gizmo.transform.localScale * 7;                        
                        gizmoexists = true;

                    }

                    if (gizmoexists)
                    {
                        _gizmo.SetActive(true);
                    }

                }
               
            }
        }

    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }   
}
