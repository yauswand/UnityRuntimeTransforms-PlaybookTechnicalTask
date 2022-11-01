using UnityEngine;
using System.Collections;


public class GizmoScaleScript : MonoBehaviour
{

    
    public float scaleSpeed = 12f;


    public GameObject xHandle;


    public GameObject yHandle;


    public GameObject zHandle;


    public GameObject xSphere, ySphere, zSphere;

    public GameObject centerHandle;


    public GameObject scaleTarget;

    
    private GizmoClickDetection[] detectors;

   
    private float initialScaleX, initialScaleY, initialScaleZ;

  
    private Vector3? previousGizmoScale;

    public GameObject translatescriptobject;
    private GizmoTranslateScript gizmotranslate_;

    public GameObject translatexaxis;
    public GameObject translateyaxis;
    public GameObject translatezaxis;

    

    private Vector3 translateoffset;

 
    public void Awake()
    {

        // Get the initial scales
        initialScaleX = gameObject.transform.localScale.x;
        initialScaleY = gameObject.transform.localScale.y;
        initialScaleZ = gameObject.transform.localScale.z;

        // Get the click detection scripts
        detectors = new GizmoClickDetection[4];
        detectors[0] = xHandle.GetComponent<GizmoClickDetection>();
        detectors[1] = yHandle.GetComponent<GizmoClickDetection>();
        detectors[2] = zHandle.GetComponent<GizmoClickDetection>();
        detectors[3] = centerHandle.GetComponent<GizmoClickDetection>();

        // Set the same position for the target and the gizmo
        transform.position = scaleTarget.transform.position;
        
        


    }


 
    public void Update()
    {
        
        

        // Store the previous local scale of the gizmo
        if (Input.GetMouseButtonDown(0) && detectors[3].pressing) {
            previousGizmoScale = gameObject.transform.localScale;
        } else if(Input.GetMouseButtonUp(0) && previousGizmoScale != null) {
            gameObject.transform.localScale = ((Vector3) previousGizmoScale);
        }

        for (int i = 0; i < 4; i++) {
            if (Input.GetMouseButton(0) && detectors[i].pressing) {

                switch (i) {

                    // X Axis
                    case 0:
                        {
                            
                                // Scale along the X axis
                             float delta = Input.GetAxis("Mouse X") * (Time.deltaTime);
                            delta *= scaleSpeed;


                            if ((scaleTarget.transform.localScale.x - delta) <= 0.01f) return;

                            if (Vector3.Dot(scaleTarget.transform.forward, Vector3.forward) >= 0)
                            {
                                scaleTarget.transform.localScale += new Vector3(-delta, 0.0f, 0.0f);
                            }
                            else
                            {
                                scaleTarget.transform.localScale -= new Vector3(-delta, 0.0f, 0.0f);
                            }


                            previousGizmoScale = null;
                        }
                        break;

                    // Y Axis
                    case 1:
                        {
                            // Scale along the Y axis
                            float delta = Input.GetAxis("Mouse Y") * (Time.deltaTime);
                            delta *= scaleSpeed;

                            if ((scaleTarget.transform.localScale.y + delta) <= 0.01f) return;

                            if (Vector3.Dot(scaleTarget.transform.up, Vector3.up) >= 0)
                            {
                                scaleTarget.transform.localScale += new Vector3(0.0f, delta, 0.0f);
                            }
                            

                            else
                            {
                                scaleTarget.transform.localScale -= new Vector3(0.0f,delta, 0.0f);
                            }



                           


                            previousGizmoScale = null;
                        }
                        break;

                    // Z Axis
                    case 2:
                        {
                            // Scale along the Z axis
                            float delta = Input.GetAxis("Mouse X") * (Time.deltaTime);
                            delta *= scaleSpeed;

                            if ((scaleTarget.transform.localScale.z + delta) <= 0.01f) return;

                            if (Vector3.Dot(scaleTarget.transform.right, Vector3.right) >= 0)
                            {
                                scaleTarget.transform.localScale += new Vector3(0.0f, 0.0f, -delta);
                            }
                                
                            else
                            {
                                scaleTarget.transform.localScale -= new Vector3(0.0f, 0.0f, -delta);
                            }
                            previousGizmoScale = null;
                        }
                         break;

                    // Center (uniform scale)
                    case 3:
                        {
                            float delta = (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y")) * (Time.deltaTime);
                            delta *= scaleSpeed;

                            if ((gameObject.transform.localScale.x + delta) <= (initialScaleX / 25.0f)) return;
                            if ((gameObject.transform.localScale.y + delta) <= (initialScaleY / 25.0f)) return;
                            if ((gameObject.transform.localScale.z + delta) <= (initialScaleZ / 25.0f)) return;

                            scaleTarget.transform.localScale += new Vector3(delta, delta, delta);
                            
                        }
                        break;
                }

                break;
            }
        }
    }

}

