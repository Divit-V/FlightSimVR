using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform cam;

    float yPos;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - cam.position;
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.position + offset;
        pos.y = yPos;
        transform.position = pos;
    }
}
