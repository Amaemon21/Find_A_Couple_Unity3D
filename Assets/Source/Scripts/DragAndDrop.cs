using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera _camera;

    private Vector3 _mousePosition;

    private Transform _transform;

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
    }

    private void OnMouseDown()
    {
        _mousePosition = Input.mousePosition - GetMousePosition();
    }

    //private void OnMouseUp()
    //{
    //    _transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5f);
    //}

    private void OnMouseDrag()
    {
        _transform.position = _camera.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
        _transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);
    }

    private Vector3 GetMousePosition()
    {
        return _camera.WorldToScreenPoint(_transform.position);
    }
}