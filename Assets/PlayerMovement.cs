using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;        // 기본 이동속도 5
    private Rigidbody2D rb;             // 물리엔진
    private Vector2 moveInput;          // 방향 입력

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); // ← →
        moveInput.y = Input.GetAxisRaw("Vertical");   // ↑ ↓
        moveInput.Normalize();                        // 대각선 속도 보정
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;          // 입력값에 따라 속도 설정
    }
}
