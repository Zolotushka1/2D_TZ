using System;
using UnityEngine;
using UnityEngine.Tilemaps;
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
    private Vector3 HorizontalSpeed;

    private int _layer {
        get {return _layerOff;}
        set {_layerOff = Mathf.Clamp(value, -2, 2);}
    }
    public Tilemap TileLayer1;
    public Tilemap TileLayer2;
    public Tilemap TileLayer3;
    // Start is called before the first frame update
    void Start()
    {
        var trans_color_1 = new Color(255, 255, 255, 0.6f);
        var trans_color_2 = new Color(255, 255, 255, 0.7f);
        foreach (Vector3Int tilePosition in TileLayer1.cellBounds.allPositionsWithin)
        {
            TileLayer1.RemoveTileFlags(tilePosition, TileFlags.LockColor);
            TileLayer1.SetColor(tilePosition, trans_color_1);
            TileLayer1.SetTileFlags(tilePosition, TileFlags.LockColor);
        }
        foreach (Vector3Int tilePosition in TileLayer2.cellBounds.allPositionsWithin)
        {
            TileLayer2.RemoveTileFlags(tilePosition, TileFlags.LockColor);
            TileLayer2.SetColor(tilePosition, trans_color_2);
            TileLayer2.SetTileFlags(tilePosition, TileFlags.LockColor);
        }
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
        _rigidbody2D.velocity = HorizontalSpeed;
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
