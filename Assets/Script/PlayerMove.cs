using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jampForce;
    [SerializeField] private float _mouseSensative;
    private bool _isGrounded;

    private void Update()
    {
        Move();
        Jamp();
        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseY = Input.GetAxis("Mouse X");
        Vector3 rotateVector = Vector3.up * mouseY * _mouseSensative;
        transform.Rotate(rotateVector);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementVector = new Vector3(horizontalInput, 0f, verticalInput) * _speed * Time.deltaTime;
        Vector3 localRotateVector = transform.TransformDirection(movementVector);
        _rigidbody.velocity = localRotateVector;
    }

    private void Jamp()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(Vector3.up * _jampForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
            _isGrounded = true;
    }
}


