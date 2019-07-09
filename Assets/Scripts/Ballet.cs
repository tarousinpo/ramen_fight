using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Ballet : MonoBehaviour
{

	[SerializeField] private Vector3 velocity;
	[SerializeField] private float moveSpeed = 10.0f;
	[SerializeField] private float butaShotInterval = 1.0f;
	[SerializeField] private float narutoShotInterval = 5.0f;
	[SerializeField] private float noriShotTmpTime = 0;
	[SerializeField] private float rightButaShotTmpTime = 0;
	[SerializeField] private float leftButaShotTmpTime = 0;
	[SerializeField] private float narutoShotTmpTime = 0;
	[SerializeField] private GameObject rightButaShotInterIntervalText = null;
	[SerializeField] public GameObject leftButaShotInterIntervalText = null;
	[SerializeField] private GameObject narutoShotInterIntervalText = null;
	
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;
	

	// 弾丸発射点
	public Transform muzzle;
	public Transform rightButaMuzzle;
	public Transform leftButaMuzzle;

	// 弾丸の速度
	public float bullet_speed = 1000;

    // SE
    public AudioClip seNoriShot;
    public AudioClip seButaShot;
    public AudioClip seNarutoShot;
    AudioSource audioSource;
	
	// Use this for initializationN
	void Start ()
	{
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
		noriShotTmpTime += 1;
		rightButaShotTmpTime += Time.deltaTime;
		leftButaShotTmpTime += Time.deltaTime;
		narutoShotTmpTime += Time.deltaTime;

		drawIntarvalText();

		// zキー押したら海苔発射
		if (Input.GetKey(KeyCode.Z) && noriShotTmpTime % 20 == 0)
		{
			// 弾丸の複製
			GameObject bullets1 = Instantiate(bullet1) as GameObject;

			Vector3 force;

			force = this.gameObject.transform.forward * bullet_speed / 5;

			// Rigidbodyに力を加えて発射
			bullets1.GetComponent<Rigidbody>().AddForce(force);

            // SE鳴らす
            audioSource.PlayOneShot(seNoriShot);

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

            // SE鳴らす
            audioSource.PlayOneShot(seButaShot);

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

            // SE鳴らす
            audioSource.PlayOneShot(seButaShot);

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

            // SE鳴らす
            audioSource.PlayOneShot(seNarutoShot);

            // 弾丸の位置を調整
            bullets3.transform.position = muzzle.position;

			narutoShotTmpTime = 0;
		}
	}

	void drawIntarvalText()
	{
		TextMeshProUGUI l_buta = leftButaShotInterIntervalText.GetComponent<TextMeshProUGUI>();
		TextMeshProUGUI r_buta = rightButaShotInterIntervalText.GetComponent<TextMeshProUGUI>();
		TextMeshProUGUI naruto = narutoShotInterIntervalText.GetComponent<TextMeshProUGUI>();
		
		Debug.Log(leftButaShotTmpTime);
		Debug.Log(rightButaShotTmpTime);
		Debug.Log(narutoShotTmpTime);
		

		if (leftButaShotTmpTime >= butaShotInterval)
		{
			l_buta.text = "L-ButaREADY";
		}
		else
		{
			l_buta.text = (butaShotInterval - leftButaShotTmpTime).ToString();
		}
		
		if (rightButaShotTmpTime >= butaShotInterval)
		{
			r_buta.text = "R-ButaREADY";
		}
		else
		{
			r_buta.text = (butaShotInterval - rightButaShotTmpTime).ToString();
		}
		
		if (narutoShotTmpTime >= narutoShotInterval)
		{
			naruto.text = "NARUTO";
		}
		else
		{
			naruto.text = (narutoShotInterval - narutoShotTmpTime).ToString();
		}
		
	}
}
