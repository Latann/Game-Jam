using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HighlightSelection1 : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Transform _selection;
    [SerializeField] private Transform playersnap;
    [SerializeField] private bool selected = false;
    private Ray Mouseray;

    private Rigidbody rb;
    
    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        Mouseray = Camera.main.ScreenPointToRay(mousePos);    
        
        var ray = Mouseray;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer is not null )
                {
                    if (selectionRenderer != highlightMaterial)
                    {
                       defaultMaterial = selectionRenderer.material; 
                    }
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection; 
            }
        }
        
        if (Mouse.current.leftButton.wasPressedThisFrame & _selection is not null & !selected)
        {
            selected = true;
            Debug.Log("selected");
            rb = _selection.GetComponent<Rigidbody>();
        }
        else if(Mouse.current.leftButton.wasPressedThisFrame&selected)
        {
            selected = false;
            Debug.Log("de selected");
            rb.useGravity = true;
            rb.AddForce(Mouseray.direction.normalized * 30,ForceMode.Impulse);
        }

        /*
        if (Mouse.current.leftButton.wasPressedThisFrame&selected)
        {
            selected = false;
            Debug.Log("de selected");
            //rb.AddForce(transform.position - Worldpos,ForceMode.Impulse);
                
        }
        */
    }

    private void FixedUpdate()
    {
        if (selected)
        {
            rb.useGravity = false;
            rb.AddForce((transform.position + Mouseray.direction.normalized * 2 - rb.position)*10,ForceMode.Force);
            var difference = transform.position - rb.position;
            if (difference.magnitude <= 5)  //Distance de Snap
            {
                rb.position = transform.position + Mouseray.direction * 2;
            }

        }
    }
}
