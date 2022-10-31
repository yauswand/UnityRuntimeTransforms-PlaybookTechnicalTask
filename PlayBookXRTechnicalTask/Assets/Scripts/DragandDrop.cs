using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    public GameObject prefabcube;
    public GameObject prefabsphere;
    public GameObject prefabcapsule;
    private GameObject spawn;



    void Update()
    {
        if (Input.GetMouseButton(0) && spawn != null)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            spawn.transform.position = Camera.main.ScreenToWorldPoint(pos);
          
        }

        if (Input.GetMouseButtonUp(0))
        {
            spawn = null;
        }
    }

    


    public void SpawnDragCube()
    {

        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        spawn = Instantiate(prefabcube, pos, Quaternion.identity) as GameObject;
        
    }

    public void SpawnDragSphere()
    {
        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        spawn = Instantiate(prefabsphere, pos, Quaternion.identity) as GameObject;
        
    }

    public void SpawnDragCapsule()
    {
        var pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        spawn = Instantiate(prefabcapsule, pos, Quaternion.identity) as GameObject;
        
    }

}


