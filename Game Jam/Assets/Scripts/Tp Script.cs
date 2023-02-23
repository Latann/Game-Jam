using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpScript : MonoBehaviour
{
    [SerializeField] GameObject _TpCollider;
    [SerializeField] int _scenetoTp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == _TpCollider)
        {
            SceneManager.LoadScene(_scenetoTp);
        }
    }
}
