using System;
using UnityEngine;
public class Pathfinder : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	GameObject objToSpawn;
	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += Vector3.up * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.S))
		{
			transform.position += Vector3.down * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			objToSpawn = new GameObject("Waipoint");
		}

	}
}