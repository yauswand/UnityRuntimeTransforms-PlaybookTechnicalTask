using UnityEngine;
using System.Collections;


public class GizmoRotateScript : MonoBehaviour {

  
    public float rotationSpeed = 500.0f;

   
    public GameObject xTorus;

   
    public GameObject yTorus;

  
    public GameObject zTorus;

    public GameObject rotateTarget;

  
    private GizmoClickDetection[] detectors;

    public void Awake() {

        // Get the click detection scripts
        detectors = new GizmoClickDetection[3];
        detectors[0] = xTorus.GetComponent<GizmoClickDetection>();
        detectors[1] = yTorus.GetComponent<GizmoClickDetection>();
        detectors[2] = zTorus.GetComponent<GizmoClickDetection>();

        // Set the same position for the target and the gizmo
        transform.position = rotateTarget.transform.position;
    }

   
    public void Update() {
        for (int i = 0; i < 3; i++) {

            if (Input.GetMouseButton(0) && detectors[i].pressing) {

                // Rotation angle
                float delta = (Input.GetAxis("Mouse X") - Input.GetAxis("Mouse Y")) * (Time.deltaTime);
                delta *= rotationSpeed;

                switch (i) {
                    // X Axis
                    case 0:
                        rotateTarget.transform.Rotate(Vector3.left, delta);
                        
                        break;

                    // Y Axis
                    case 1:
                        rotateTarget.transform.Rotate(Vector3.down, delta);
                        
                        break;

                    // Z Axis
                    case 2:
                        rotateTarget.transform.Rotate(Vector3.back, delta);
                        
                         break;
                }

                break;
            }
        }
    }

}

