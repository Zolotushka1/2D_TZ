using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement_script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D physicsBody = null;
    [SerializeField] private float speed = 100f;
    void Start()
    {
        
    }
    private Vector3 _movement;
    private Vector3 _layerSwitch;
    private int layer = 0;
    private void Update()
    {
        float Vertical = Input.GetAxisRaw("Vertical");
        float Horizontal = Input.GetAxisRaw("Horizontal");
        _animator.SetFloat("Horizontal", Horizontal);
        float HorizontalSpeed = Horizontal * (speed) * Time.fixedDeltaTime;
        _animator.SetFloat("Speed", MathF.Abs(HorizontalSpeed));
        if (Input.GetKeyDown(KeyCode.W))
        {
            layer = layer + 2;
            _animator.SetTrigger("LayerSwitchBack");
            Vector3 Zpos = transform.position;
            Zpos.z = layer;
            transform.position = Zpos;
            Debug.Log("Layer" + layer);
        }
        else if(Input.GetKeyDown(KeyCode.S)) {
            layer = layer - 2;
            _animator.SetTrigger("LayerSwitchFront");
            Vector3 Zpos = transform.position;
            Zpos.z = layer;
            transform.position = Zpos;
            Debug.Log("Layer" + layer);
        }
        Vector3 tempPosition = transform.position + new Vector3(Horizontal * Time.deltaTime, 0, 0);
        tempPosition.z = layer;
        transform.position = tempPosition;
        _movement = new Vector3(Horizontal, 0, layer).normalized;
    }
    private void FixedUpdate()
    {
        physicsBody.velocity = _movement * (speed) * Time.fixedDeltaTime;
    }
}
