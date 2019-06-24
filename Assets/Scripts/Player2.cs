using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player2 : MonoBehaviour
{

	[SerializeField] private Vector3 velocity;
	[SerializeField] private float moveSpeed = 10.0f;
	[SerializeField] private float butaShotInterval = 1.0f;
	[SerializeField] private float narutoShotInterval = 5.0f;
	[SerializeField] private float noriShotTmpTime = 0;
	[SerializeField] private float rightButaShotTmpTime = 0;
	[SerializeField] private float leftButaShotTmpTime = 0;
	[SerializeField] private float narutoShotTmpTime = 0;

	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;

	// 弾丸発射点
	public Transform muzzle;
	public Transform rightButaMuzzle;
	public Transform leftButaMuzzle;

	// 弾丸の速度
	public float bullet_speed = 1000;
	
	// Use this for initializationN
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		noriShotTmpTime += 1;
		rightButaShotTmpTime += Time.deltaTime;
		leftButaShotTmpTime += Time.deltaTime;
		narutoShotTmpTime += Time.deltaTime;


		
		// WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
		velocity = Vector3.zero;
		if(Input.GetKey(KeyCode.A))
			velocity.x -= 1;
		if(Input.GetKey(KeyCode.S))
			velocity.z -= 1;
		if(Input.GetKey(KeyCode.D))
			velocity.x += 1;
		if(Input.GetKey(KeyCode.W))
			velocity.z += 1;

		// 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整
		velocity = velocity.normalized * moveSpeed * Time.deltaTime;

		// いずれかの方向に移動している場合
		if(velocity.magnitude > 0)
		{
			// プレイヤーの位置(transform.position)の更新
			// 移動方向ベクトル(velocity)を足し込みます
			transform.position += velocity;
		}
		
		// zキー押したら海苔発射
		if (Input.GetKey(KeyCode.Z) && noriShotTmpTime % 20 == 0)
		{
			// 弾丸の複製
			GameObject bullets1 = Instantiate(bullet1) as GameObject;

			Vector3 force;

			force = this.gameObject.transform.forward * bullet_speed / 5;

			// Rigidbodyに力を加えて発射
			bullets1.GetComponent<Rigidbody>().AddForce(force);

			// 弾丸の位置を調整
			bullets1.transform.position = muzzle.position;
			
			Destroy(bullets1, 2.0f);
		}
		
		// xキー押したら左チャーシュー発射
		if (Input.GetKey(KeyCode.X) && leftButaShotTmpTime >= butaShotInterval)
		{
			// 弾丸の複製
			GameObject bullets2 = Instantiate(bullet2) as GameObject;

			Vector3 force;

			force = leftButaMuzzle.gameObject.transform.forward * bullet_speed * 10;

			// Rigidbodyに力を加えて発射
			bullets2.GetComponent<Rigidbody>().AddForce(force);

			// 弾丸の位置を調整
			bullets2.transform.position = leftButaMuzzle.position;

			leftButaShotTmpTime = 0;
		}
		
		// cキー押したら右チャーシュー発射
		if (Input.GetKey(KeyCode.C) && rightButaShotTmpTime >= butaShotInterval)
		{
			// 弾丸の複製
			GameObject bullets2 = Instantiate(bullet2) as GameObject;

			Vector3 force;

			force = rightButaMuzzle.gameObject.transform.forward * bullet_speed * 10;

			// Rigidbodyに力を加えて発射
			bullets2.GetComponent<Rigidbody>().AddForce(force);

			// 弾丸の位置を調整
			bullets2.transform.position = rightButaMuzzle.position;

			rightButaShotTmpTime = 0;

		}
		
		// cキー押したらナルト発射
		if (Input.GetKey(KeyCode.V) && narutoShotTmpTime >= narutoShotInterval)
		{
			// 弾丸の複製
			GameObject bullets3 = Instantiate(bullet3) as GameObject;

			Vector3 force;

			force = this.gameObject.transform.forward * bullet_speed * 50;

			// Rigidbodyに力を加えて発射
			bullets3.GetComponent<Rigidbody>().AddForce(force);

			// 弾丸の位置を調整
			bullets3.transform.position = muzzle.position;

			narutoShotTmpTime = 0;
		}
	}
}
