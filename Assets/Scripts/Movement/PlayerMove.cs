using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Rigidbody2D _rigidbody2D = null;
    [SerializeField] private float _speed = 100f;

    private Vector3 _movement;
    private Vector3 _layerSwitch;
    private int _layerOff;
    private int _layer {
        get {return _layerOff;}
        set {_layerOff = Mathf.Clamp(value, -2, 2);}
    }

    private void Update()
    {
        if (_joystick.Horizontal > 0.3 || _joystick.Horizontal < 0.3) // Замена A и D
        {
            float Horizontal = _joystick.Horizontal;
            _animator.SetFloat("Horizontal", Horizontal);
            float HorizontalSpeed = Horizontal * (_speed) * Time.fixedDeltaTime;
            _animator.SetFloat("Speed", MathF.Abs(HorizontalSpeed));
            
            Vector3 tempPosition = transform.position + new Vector3(Horizontal * Time.deltaTime, 0, 0);
            tempPosition.z = _layer;
            transform.position = tempPosition;
            _movement = new Vector3(Horizontal, 0, _layer).normalized;
        }
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement * (_speed) * Time.fixedDeltaTime;
    }

    public void KeyUp() // Замена W
    {
        _layer = _layer + 2;
        _animator.SetTrigger("LayerSwitchBack");
        Vector3 Zpos = transform.position;
        Zpos.z = _layer;
        transform.position = Zpos;
    }

    public void KeyDown() // Замена S
    {
        _layer = _layer - 2;
        _animator.SetTrigger("LayerSwitchFront");
        Vector3 Zpos = transform.position;
        Zpos.z = _layer;
        transform.position = Zpos;
    }
}
