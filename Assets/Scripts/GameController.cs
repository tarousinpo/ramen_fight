using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	private Transform player; //注視対象プレイヤー

	private float distance = 15.0f; //注視対象プレイヤーからカメラ
	private Quaternion vRotation; //カメラの垂直回転
	private Quaternion hRotation; //カメラの水平回転
		
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
