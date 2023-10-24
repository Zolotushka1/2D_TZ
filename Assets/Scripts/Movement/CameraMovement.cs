using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    
    private int _layer = -1;

    void Update()
    {
        if (_joystick.Vertical > 0.5)
        {
            _layer = _layer + 2;
            Vector3 Zpos = transform.position;
            Zpos.z = _layer;
            transform.position = Zpos;
            Debug.Log("Layer" + _layer);
        }
        else if (_joystick.Vertical < -0.5)
        {
            _layer = _layer - 2;
            Vector3 Zpos = transform.position;
            Zpos.z = _layer;
            transform.position = Zpos;
            Debug.Log("Layer" + _layer);
        }
    }
}
