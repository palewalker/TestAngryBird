using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour {


    public GameObject pfProjectile;
    public GameObject launchPoint;
    public float velocityMult = 4f;
    //인스펙터창 설정

    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Rigidbody projRigid;
    

    private void Awake()
    {
        launchPoint.SetActive(false);
        launchPos = launchPoint.transform.position;

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(aimingMode)
        {
            Vector3 mousePos2D = Input.mousePosition;

            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            //launchpos에서 마우스 방향으로 방향값 계산
            Vector3 mouseDir = mousePos3D - launchPos;

            //힘 제한
            float maxForce = this.GetComponent<SphereCollider>().radius;

            if(mouseDir.magnitude > maxForce)
            {
                mouseDir.Normalize();
                mouseDir *= maxForce;
            }

            Vector3 projPos = launchPos + mouseDir;
            projectile.transform.position = projPos;

            if(Input.GetMouseButtonUp(0))
            {
                aimingMode = false;
                projRigid.isKinematic = false;
                projRigid.velocity = -mouseDir * velocityMult;
                FollowCam.inst.attentionPoint = projectile;
                projectile = null;
            }
          
        }
	}


    private void OnMouseEnter()
    {
        //print("sling onmouse");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        //print("sling exitmouse");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        aimingMode = true;

        projectile = Instantiate(pfProjectile) as GameObject;

        projectile.transform.position = launchPos;

        projRigid = projectile.GetComponent<Rigidbody>();

        projRigid.isKinematic = true;
    }
}
