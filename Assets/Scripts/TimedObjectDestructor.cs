using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour {

	public GameObject player;

	void FixedUpdate ()
	{
		if (transform.position.y > 2f)
		{
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			if (GameObject.Find("Player").GetComponent<Renderer>().sharedMaterial != gameObject.GetComponent<Renderer>().sharedMaterial)
				GetComponent<BoxCollider>().isTrigger = false;
			else
				GetComponent<BoxCollider>().isTrigger = true;
			transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
		}
		if (player.transform.position.x > transform.position.x)
			DestroyNow();
	}

	void DestroyNow ()
	{
		Destroy(gameObject);
	}
}