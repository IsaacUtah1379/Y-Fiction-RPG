using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // TODO: make this work for all resolutions instead of whatever
    // resolution it is that I happen to use when testing.
    public float xFollowDistance;
    public float yFollowDistance;
    public GameObject firstActor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - firstActor.transform.position.x > xFollowDistance) {
            transform.position = new Vector3(firstActor.transform.position.x + xFollowDistance, transform.position.y, transform.position.z);
        } else if (firstActor.transform.position.x - transform.position.x > xFollowDistance) {
            transform.position = new Vector3(firstActor.transform.position.x - xFollowDistance, transform.position.y, transform.position.z);
        }

        if (transform.position.y - firstActor.transform.position.y > yFollowDistance) {
            transform.position = new Vector3(transform.position.x, firstActor.transform.position.y + yFollowDistance, transform.position.z);
        } else if (firstActor.transform.position.y - transform.position.y > yFollowDistance) {
            transform.position = new Vector3(transform.position.x, firstActor.transform.position.y - yFollowDistance, transform.position.z);
        }
    }
}
