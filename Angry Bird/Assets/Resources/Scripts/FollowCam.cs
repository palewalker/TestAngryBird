using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public static FollowCam inst;

    public GameObject attentionPoint;
    //public float camZ;
    public float easing = 0.01f; //보간 속도
    public Vector3 originCamPos;
    public Vector2 minXY;
    public bool isBallDied = false;
    


    private void Awake()
    {
        inst = this;
        //camZ = this.transform.position.z;
        originCamPos = this.transform.position;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    private void FixedUpdate()
    {
        FollowProjectile();
    }

    public void FollowProjectile()
    {
        if (attentionPoint != null) //카메라 이동
        {
           

            Vector3 dest = attentionPoint.transform.position;

            dest.x = Mathf.Max(minXY.x, dest.x);
            dest.y = Mathf.Max(minXY.y, dest.y);

            dest = Vector3.Lerp(transform.position, dest, easing);

            dest.z = originCamPos.z;

            transform.position = dest;

            this.GetComponent<Camera>().orthographicSize = dest.y + 10;

            //print(attentionPoint.GetComponent<Rigidbody>().velocity);

            //CamInit();

            if(attentionPoint.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                 attentionPoint = null;
            }
        }
        else
        {
    
            Vector3 dest = originCamPos;

            dest = Vector3.Lerp(transform.position, dest, easing);

            transform.position = dest; 
            //수정 요망
        }
       
    }

   
}
