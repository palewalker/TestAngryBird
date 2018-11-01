using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Anim //애니메이션 관련 클래스
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackWard;
    public AnimationClip runRight;
    public AnimationClip runLeft;

}


public class PlayerControl : MonoBehaviour {

    private float h = 0.0f; // x 축키(a,d) 조작 비율
    private float v = 0.0f; // y 축키(w,s) 조작 비율

    private Transform tr;

    public float moveSpeed = 10.0f;

    public float rotSpeed = 500.0f;

    public Anim anim;
    public Animation _animation;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();

        _animation = GetComponentInChildren<Animation>();

        _animation.clip = anim.idle;
        _animation.Play();

	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        PlayerRotate();
	}

    public void PlayerMove()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h); //방향 계산

        Debug.Log("h = " + h);
        Debug.Log("v = " + v);

        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
        //길이가 1인 정규화 벡터로 변환 후 계산
       

    }
    
    public void PlayerRotate()
    {
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
        
        //마우스 위치 따라가게 변경 ScreenToWorldPoint
    }

    public void AnimControl()
    {

    }
}
