using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform dest;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = dest.position;
        }
    }
}
