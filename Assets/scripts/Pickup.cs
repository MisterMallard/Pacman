using UnityEngine;

public class Pickup : MonoBehaviour
{
	public Transform PickupDetect;
	public Transform boxHolder;
	public float rayDist;
	public bool pickedUp = false;

	private PlayerMovement playerMovement;
	private ArrowShoot arrowShoot;

	void Start()
	{
		// Cache components safely
		playerMovement = GetComponent<PlayerMovement>();
		arrowShoot = GetComponent<ArrowShoot>();
	}

	void Update()
	{
		// Safety check for required references
		if (PickupDetect == null || boxHolder == null)
		{
			Debug.LogWarning("PickupDetect or boxHolder is not assigned!");
			return;
		}

		Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

		RaycastHit2D grabCheck = Physics2D.Raycast(PickupDetect.position, direction, rayDist);

		Debug.DrawRay(PickupDetect.position, direction * rayDist, Color.red);

		if (grabCheck.collider == null)
			return;

		// BOX PICKUP
		if (grabCheck.collider.CompareTag("Box"))
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				GrabObject(grabCheck);

				if (playerMovement != null)
				{
					playerMovement.canDash = true;
				}
			}
		}
		// BOW PICKUP
		else if (grabCheck.collider.CompareTag("Bow") && grabCheck.collider.transform.parent != boxHolder)
		{
			GrabObject(grabCheck);
			arrowShoot.pickedUp = true;

			if (arrowShoot != null)
			{
				arrowShoot.pickedUp = true;
			}
		}
	}

	void GrabObject(RaycastHit2D hit)
	{
		Transform obj = hit.collider.transform;

		obj.parent = boxHolder;
		obj.position = boxHolder.position;

		Rigidbody2D rb = hit.collider.GetComponent<Rigidbody2D>();
		if (rb != null)
		{
			rb.bodyType = RigidbodyType2D.Kinematic;
			rb.linearVelocity = Vector2.zero;
			rb.angularVelocity = 0f;
		}
		else
		{
			Debug.LogWarning("Picked object has no Rigidbody2D!");
		}
	}
}