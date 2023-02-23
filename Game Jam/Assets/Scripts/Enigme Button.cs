using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeButton : MonoBehaviour
{
    [Header("ButtonReferences")]

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;
    public GameObject Button7;
    public GameObject Button8;

    private bool _isInCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CollideBoxCheck();
    }

    private void CollideBoxCheck ()
    {

    }
}
