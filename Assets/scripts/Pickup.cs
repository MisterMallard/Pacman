using UnityEngine;

public class Pickup : MonoBehaviour
{
	public Transform PickupDetect;
	public Transform boxHolder;
	public float rayDist;

	void Update()
	{
		Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

		RaycastHit2D grabCheck = Physics2D.Raycast(PickupDetect.position, direction, rayDist);

		Debug.DrawRay(PickupDetect.position, direction * rayDist, Color.red);

		if (grabCheck.collider != null && grabCheck.collider.CompareTag("Box"))
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				grabCheck.collider.transform.parent = boxHolder;
				grabCheck.collider.transform.position = boxHolder.position;

				Rigidbody2D rb = grabCheck.collider.GetComponent<Rigidbody2D>();
				rb.bodyType = RigidbodyType2D.Kinematic;

				GetComponent<PlayerMovement>().canDash = true;
			}
		}
		else if (grabCheck.collider != null && grabCheck.collider.CompareTag("Bow") && grabCheck.collider.transform.parent != boxHolder)
		{
				grabCheck.collider.transform.parent = boxHolder;
				grabCheck.collider.transform.position = boxHolder.position;
				Rigidbody2D rb = grabCheck.collider.GetComponent<Rigidbody2D>();
				rb.bodyType = RigidbodyType2D.Kinematic;
		}

		//else if (grabCheck.collider != null && grabCheck.collider.CompareTag("arrow") && grabCheck.collider.transform.parent != boxHolder)
		//{
		//	grabCheck.collider.transform.parent = boxHolder;
		//	grabCheck.collider.transform.position = boxHolder.position;
			
		//	Rigidbody2D rb = grabCheck.collider.GetComponent<Rigidbody2D>();
		//	rb.bodyType = RigidbodyType2D.Kinematic;
		//}
	}
}	