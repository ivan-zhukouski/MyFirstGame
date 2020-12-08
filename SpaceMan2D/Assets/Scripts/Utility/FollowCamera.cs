using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0.0f, 0.0f, -8f);

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
