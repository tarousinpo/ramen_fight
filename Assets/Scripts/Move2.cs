using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{

	[SerializeField] private Vector3 velocity;
	[SerializeField] private float moveSpeed = 10.0f;
	
	// Use this for initializationN
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
		velocity = Vector3.zero;
		if(Input.GetKey(KeyCode.J))
			velocity.x -= 1;
		if(Input.GetKey(KeyCode.K))
			velocity.z -= 1;
		if(Input.GetKey(KeyCode.L))
			velocity.x += 1;
		if(Input.GetKey(KeyCode.I))
			velocity.z += 1;

		// 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
		velocity = velocity.normalized * moveSpeed * Time.deltaTime;

		// いずれかの方向に移動している場合
		if(velocity.magnitude > 0)
		{
			// プレイヤーの位置(transform.position)の更新
			// 移動方向ベクトル(velocity)を足し込みます
			transform.position += velocity;
		}		
	}
}
