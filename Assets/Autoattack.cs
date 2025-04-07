using UnityEngine;

public class AutoAttack : MonoBehaviour   // 클래스 이름도 정확히 맞춰줌 (A 대문자)
{
    public GameObject projectilePrefab;         // 투사체 프리팹 슬롯
    public float attackInterval = 0.8f;         // 공속 0.8
    public float attackRange = 5f;              // 공격 인지 범위 5   
    private float timer = 0f;                   // 공격 주기 측정 타이머

    void Update()
    {
        timer += Time.deltaTime;                // 시간 추적
        if (timer > attackInterval)
        {
            timer = 0f;                         // 주기가 지났으면 다시 공격
            GameObject target = FindClosestEnemy(); // 가까운 적을 target에 저장 (💡 GameObject 대문자 O)
            if (target != null)                 // 적이 있다면 null 아님
            {
                Vector2 direction = (target.transform.position - transform.position).normalized; // 방향벡터, 단위벡터
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity); // 투사체 복사 생성
                projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * 10f; // 사체 발사 velocity: 속도 설정

                // direction * 10f: 방향 + 속도
            }
        }
    }

    GameObject FindClosestEnemy()           // 가까운 적 탐색 함수
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");      // Enemy 태그 오브젝트 검색

        GameObject closest = null;          // 가까운 적 저장 변수
        float minDist = attackRange;        // 최소 거리 저장

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);    // 하나씩 나와의 거리 계산
            if (dist < minDist)             // 지금 계산한 적이 더 가까우면
            {
                minDist = dist;             // 최소 거리 갱신
                closest = enemy;            // 가장 가까운 적으로 closest 저장
            }
        }

        return closest;     // 다 돌고 나면 가장 가까운 적 반환 (없으면 null)
    }
}
