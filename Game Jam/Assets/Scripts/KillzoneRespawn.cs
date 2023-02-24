using UnityEngine;

public class KillzoneRespawn : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(-35.49f, 17.33f, 9.47f);
        }


    }
}