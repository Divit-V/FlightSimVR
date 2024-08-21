using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;
    //public float followSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
            // Get the position of the object to follow
            //Vector3 targetPosition = objectToFollow.transform.position;

            // Only update the Z component of the target position
            //targetPosition.z = transform.position.z;

            // Move towards the target position
            //transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.position = new Vector3(objectToFollow.position.x, transform.position.y, objectToFollow.position.z);
            transform.eulerAngles = new Vector3(0, objectToFollow.eulerAngles.y, 0);
        }
    }
}
