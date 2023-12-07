using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMotionCapture : MonoBehaviour
{
    private Renderer _renderer;

    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
            _renderer.material = materials[1];
    }private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
            _renderer.material = materials[0];
    }
}
