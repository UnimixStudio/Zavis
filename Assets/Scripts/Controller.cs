using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour
{
    [SerializeField] private int _speed = 3;
    [SerializeField] private float _jumpForce = 10f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private float _horizontal;
    private bool _jump;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        
        if (_horizontal < 0)
            _spriteRenderer.flipX = true;
        else if (_horizontal > 0)
            _spriteRenderer.flipX = false;

        _jump = Input.GetButtonDown("Jump"); // Jump - Пробел
        
        if (_jump)
            _rigidbody2D.AddForce(_jumpForce * Vector2.up);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void FixedUpdate()
    {
      

        
        
        float deltaHorizontalMove = _horizontal * _speed * Time.deltaTime;

        // Velocity - Вектор скорости (имеет направление)
        Vector2 velocity = _rigidbody2D.velocity;
        velocity.x = deltaHorizontalMove;
        _rigidbody2D.velocity = velocity;
    }
}