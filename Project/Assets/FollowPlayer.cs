using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    void Start() {
        cameraOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = player.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor); 
    }
}
