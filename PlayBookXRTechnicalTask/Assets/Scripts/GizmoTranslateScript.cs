using UnityEngine;
using System.Collections;


public class GizmoTranslateScript : MonoBehaviour {

 
    public GameObject xAxisObject;

  
    public GameObject yAxisObject;

 
    public GameObject zAxisObject;

 
    public GameObject translateTarget;

    private GizmoClickDetection[] detectors;

    public GameObject gizmoscale;

    private GizmoScaleScript gizmoscale_;

  
    public void Awake() {

        // Get the click detection scripts
        detectors = new GizmoClickDetection[3];
        detectors[0] = xAxisObject.GetComponent<GizmoClickDetection>();
        detectors[1] = yAxisObject.GetComponent<GizmoClickDetection>();
        detectors[2] = zAxisObject.GetComponent<GizmoClickDetection>();

        

        // Set the same position for the target and the gizmo
        transform.position = translateTarget.transform.position;
    }


    public void Update() {
        gizmoscale_ = gizmoscale.GetComponent<GizmoScaleScript>();
        GameObject gizmoscaletarget = gizmoscale_.scaleTarget;

        for (int i = 0; i < 3; i++) {
            if (Input.GetMouseButton(0) && detectors[i].pressing) {

                // Get the distance from the camera to the target (used as a scaling factor in translate)
                float distance = Vector3.Distance(Camera.main.transform.position, translateTarget.transform.position);
                distance = distance * 8.0f;

                // Will store translate values
                Vector3 offset = Vector3.zero;

                switch (i) {
                    // X Axis
                    case 0:
                        {
                            
                                float delta = Input.GetAxis("Mouse X") * (Time.deltaTime * distance);
                                offset = Vector3.right * delta;
                                offset = new Vector3(offset.x, 0.0f, 0.0f);
                                translateTarget.transform.Translate(offset);
                            
                        }
                        break;

                    // Y Axis
                    case 1:
                        {
                            
                                float delta = Input.GetAxis("Mouse Y") * (Time.deltaTime * distance);
                                offset = Vector3.up * delta;
                                offset = new Vector3(0.0f, offset.y, 0.0f);
                                translateTarget.transform.Translate(offset);
                            
                        }
                        break;

                    // Z Axis
                    case 2:
                        {
                            
                                float delta = Input.GetAxis("Mouse X") * (Time.deltaTime * distance);
                                offset = Vector3.forward * delta;
                                offset = new Vector3(0.0f, 0.0f, offset.z);
                                translateTarget.transform.Translate(offset);
                            
                        }
                        break;
                }

                
                transform.position = translateTarget.transform.position;
                
                break;
            }
        }
    }

}

