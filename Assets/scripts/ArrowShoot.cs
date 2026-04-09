using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
	public GameObject arrowPrefab;
	public Transform shootPoint;
	public float arrowSpeed = 12f;
	public bool pickedUp = false;
	public GameObject currentBow;

	public int bowDurability = 0;     
	public int maxBowDurability = 3;  
	void Update()
	{
		if (pickedUp && Input.GetKeyDown(KeyCode.F))
		{
			Shoot();

			bowDurability++;

			if (bowDurability >= maxBowDurability)
			{
				if (currentBow != null)
				{
					Destroy(currentBow);
				}
				pickedUp = false;
			}
		}
	}

	void Shoot()
	{
		GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity); 
		//GameObject arrow = Instantiate(arrowPrefab, new Vector3(), Quaternion.identity);
		/*
		Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
		rb.linearVelocity = new Vector2(direction * arrowSpeed, 0f);
		*/
		float direction = Mathf.Sign(transform.localScale.x);
		arrow.transform.localScale = new Vector3(-direction * 0.3f, 0.5f, 1f);
	}
}