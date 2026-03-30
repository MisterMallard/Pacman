using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class SpearKill : MonoBehaviour
{
	public bool inDash = false;
	public int durability = 0;
	void Update()
	{
		if (durability >= 3)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(collision.gameObject);
			durability++;
		}
	}
}