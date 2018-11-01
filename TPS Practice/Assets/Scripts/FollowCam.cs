using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public Transform targetTr; //타겟오브젝트(플레이어) transfrom
    public float dist = 10.0f; //카메라와의 거리
    public float height = 3.0f; //카메라 높이
    public float dumpTrace = 20.0f; //카메라의 부드러운 이동을 위한 변수

    private Transform tr; //카메라 transform



	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();	
	}

    //플레이어가 이동 한 후에 카메라가 움직이도록 lateupdate 사용(update 후 들어오는 함수)
    private void LateUpdate()
    {
        CameraMove();
    }

    public void CameraMove()
    {
        tr.position = Vector3.Lerp(tr.position,
                                   targetTr.position - (targetTr.forward * dist)+ (Vector3.up * height),
                                   Time.deltaTime * dumpTrace);
        tr.LookAt(targetTr.position);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
