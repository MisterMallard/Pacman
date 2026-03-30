using UnityEngine;

public class Arrow : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed = 5.0f;
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		//transform.parent = null;
		transform.position += transform.right * speed * Time.deltaTime;
		//rb.AddForce(transform.forward * 10f, ForceMode2D.Force) ;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(collision.gameObject);
			Destroy(gameObject); 
		}
	}
}