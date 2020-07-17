using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Transform[] views;
    public float transitionspeed;
    Transform currentView;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {

            currentView = views [0];
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {

            currentView = views [1];
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {

            currentView = views [2];
        }
        ZoomIn();


    }
    // Update is called once per frame
    void ZoomIn()
    {

        //lerp position
        transform.position = Vector3.Lerp (transform.position, currentView.position, Time.deltaTime * transitionspeed);





    }
}
