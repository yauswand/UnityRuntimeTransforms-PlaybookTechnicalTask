using UnityEngine;
using System.Collections;


public class GizmoRotateScript : MonoBehaviour {

  
    public float rotationSpeed = 500.0f;


    public GameObject xTorus;


    public GameObject yTorus;


    public GameObject zTorus;

    public GameObject rotateTarget;

    private Vector3 offsetx, offsety, offsetz;

    public Vector3 posx, posy, posz;
    public Vector3 startmousepos;
    public Vector3 currentmousepos;

    private GizmoClickDetection[] detectors;
    public GameObject positionconex, positionconey, positionconez;
    public GameObject scalespherex, scalespherey, scalespherez;

    public void Awake()
    {

        positionconex.transform.position = offsetx;
        positionconex.transform.position = offsety;
        positionconez.transform.position = offsetz;
        // Get the click detection scripts
        detectors = new GizmoClickDetection[3];
        detectors[0] = xTorus.GetComponent<GizmoClickDetection>();        

        detectors[1] = yTorus.GetComponent<GizmoClickDetection>();

        detectors[2] = zTorus.GetComponent<GizmoClickDetection>();

        // Set the same position for the target and the gizmo
        transform.position = rotateTarget.transform.position;
    }

   
    public void Update()
    {

        for (int i = 0; i < 3; i++)
        {
            Vector3 mprevpos = Input.mousePosition;
            if (Input.GetMouseButton(0) && detectors[i].pressing)
            {

                //Rotation angle
                float delta = (Input.GetAxis("Mouse X") - Input.GetAxis("Mouse Y")) * Time.deltaTime;
                float Xaxisrotation = Input.GetAxis("Mouse X") * rotationSpeed;
                float Yaxisrotation = Input.GetAxis("Mouse Y") * rotationSpeed;
                delta *= rotationSpeed;




                switch (i)
                {
                    // X Axis
                    case 0:

                        Debug.Log("X pressed");

                        if (Vector3.Dot(rotateTarget.transform.forward, Vector3.forward) >= 0)
                        {

                                Debug.Log("Positive");
                                rotateTarget.transform.Rotate(Vector3.back, delta);
                                gameObject.transform.Rotate(Vector3.back, delta);

                       
                        }





                        else
                        {
                            
                            rotateTarget.transform.Rotate(Vector3.forward, delta);
                            gameObject.transform.Rotate(Vector3.forward, delta);
                        }
                        


                        break;


                    // Y Axis
                    case 1:

                        if (Vector3.Dot(rotateTarget.transform.up, Vector3.up) >= 0)
                        {
                           
                            
                            rotateTarget.transform.Rotate(Vector3.down, delta);
                            gameObject.transform.Rotate(Vector3.down, delta);
                        }

                        


                        else
                        {
                            
                            rotateTarget.transform.Rotate(Vector3.up, delta);
                            gameObject.transform.Rotate(Vector3.up, delta);
                        }



                        break;


                    // Z Axis
                    case 2:
                        if (Vector3.Dot(rotateTarget.transform.right, Vector3.right) >= 0)
                        {
                         
                            rotateTarget.transform.Rotate(Vector3.left, delta);
                            gameObject.transform.Rotate(Vector3.left, delta);
                        }


                        else
                        {
                            Debug.Log("Not R");
                            
                            rotateTarget.transform.Rotate(Vector3.right, delta);
                            gameObject.transform.Rotate(Vector3.right, delta);
                        }


                        break;

                }

                break;
                
            }
            
        }
        positionconex.transform.position = transform.TransformPoint(posx.x - 0.2f, posx.y, posx.z);
        positionconex.transform.rotation = transform.rotation * Quaternion.Euler(0f,270f,0f);
        positionconey.transform.position = transform.TransformPoint(posy.x, posy.y + 0.2f, posy.z);
        positionconey.transform.rotation = transform.rotation * Quaternion.Euler(270f, 0f, 0f);
        positionconez.transform.position = transform.TransformPoint(posz.x, posz.y, posz.z - 0.2f);
        positionconez.transform.rotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);
        scalespherex.transform.position = transform.TransformPoint(posx);
        scalespherey.transform.position = transform.TransformPoint(posy);
        scalespherez.transform.position = transform.TransformPoint(posz);
    }

}

