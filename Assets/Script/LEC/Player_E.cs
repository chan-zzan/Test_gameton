using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum STATE
{
    // 캐릭터의 상태를 나눠서 상태에 따라서 행동하도록 함
    Play, Die
}

[System.Serializable]
public class Stat
{
    // 캐릭터 스탯
    // Json 이용 -> 각 사용자마다 데이터 내용이 달라지기 때문에 Json을 이용하여 저장하는 방법을 사용
    // 서버를 사용할 수 있으면 그게 더 좋을 듯?!

    // 체력
    // 공격력
    // 방어력
    // 이동속도
    // 연사력 -> projectileShotTime(투사체 발사주기)
    // (치명타 확률)

    public float HP = 100; // 체력
    public float ATK = 10; // 공격력
    public float DEF = 10; // 방어력
    public float Speed = 15; // 이동속도
}

struct RotData
{
    public float angle;
    public float rotDir;
}

public class Player_E : MonoBehaviour
{
    public STATE myState;
    [Space(20)]

    public Stat myStatus;
    float maxHp;
    [Space(20)]

    [SerializeField] FloatingJoystick joy;
    [SerializeField] SPUM_Prefabs SPUM;

    public Transform playerDir; // 플레이어 방향
    bool isFlip; // 플레이어의 좌우반전 여부

    Vector2 joyInput; // 조이스틱 입력값
    Rigidbody2D rigid;

    public GameObject projectile; // 발사체
    public Transform spawnPos; // 발사체 생성 위치

    public RectTransform Dir; // 현재 캐릭터가 바라보는 방향

    public RectTransform AttackDir; // 공격 방향
    public Transform attackPos; // 공격 시작 위치

    public Detect_E detect; // 몬스터 탐지 콜라이더

    Coroutine coroutine; // 공격 코루틴 저장

    public Slider hpBar;

    public void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;

        switch (myState)
        {
            case STATE.Play:
                break;
            case STATE.Die:
                SPUM.PlayAnimation(2); // die
                break;
        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case STATE.Play:
                MoveJoystick();
                Attack();
                if (myStatus.HP <= 0)
                {
                    ChangeState(STATE.Die);
                }
                break;
            case STATE.Die:                
                break;
        }
    }

    private void Awake()
    {
        // 초기 HP 설정
        hpBar.value = 1;
        maxHp = myStatus.HP;

        rigid = GetComponent<Rigidbody2D>();        
    }

    public void OnDamage(float damage)
    {
        myStatus.HP -= damage;
        hpBar.value -= damage / maxHp;
    }

    private void FixedUpdate()
    {        
        if (myState == STATE.Play)
        {
            // 조이스틱에 따른 캐릭터의 이동
            joyInput = new Vector2(joy.Horizontal, joy.Vertical);
            Vector2 nextPos = joyInput.normalized * Time.fixedDeltaTime * myStatus.Speed;

            rigid.MovePosition(rigid.position + nextPos);
        }
    }

    private void Update()
    {
        StateProcess();
    }

    void Attack()
    {
        // 몬스터가 감지된 경우에만 코루틴 실행
        if (coroutine == null)
        {
            coroutine = StartCoroutine(Shotting());
        }
    }

    void MoveJoystick()
    {
        Vector3 rot;
        Vector3 inputDir;

        if (joy.isMove)
        {
            // 움직이는 중일 때
            inputDir = joyInput;
            SPUM.PlayAnimation(1); // run
        }
        else
        {
            // 멈춰있을 때
            inputDir = joy.lastPos;
            SPUM.PlayAnimation(0); // idle
        }

        // 캐릭터 좌우 반전
        isFlip = inputDir.x > 0;

        if (isFlip)
        {
            rot = new Vector3(0, 180, 0);
        }
        else
        {
            rot = new Vector3(0, 0, 0);
        }

        playerDir.rotation = Quaternion.Euler(rot); // 좌우 반전 적용

        RotData moveData;

        // 현재 이동 방향을 알려주는 화살표
        CalculateAngle(this.transform, inputDir, out moveData);
        Dir.rotation = Quaternion.Euler(new Vector3(0, 0, moveData.angle * moveData.rotDir)); // 방향 적용
    }

    void CalculateAngle(Transform tr, Vector3 dir, out RotData data)
    {
        // 각도 계산
        float rad = Mathf.Acos(Vector3.Dot(tr.up, dir.normalized)); // 이동할 지점까지의 각도를 구함
        data.angle = 180 * (rad / Mathf.PI); // degree 각도로 바꿈
        data.rotDir = 1.0f; // 회전 방향값 => 오른쪽

        if (Vector3.Dot(tr.right , dir.normalized) > 0.0f)
        {
            data.rotDir = -1.0f; // 왼쪽방향
        }
    }

    IEnumerator Shotting()
    {
        while (detect.monsters.Count > 0)
        {
            SPUM.PlayAnimation(5); // attack

            yield return new WaitForSeconds(0.3f); // 애니메이션 딜레이 시간          

            // 투사체 생성
            Projectile_E clone = GameManager_E.Instance.Pool._ProjectilesPool.Get();
            clone.transform.position = this.transform.position;

            if (detect.nearestMonster == null) break;

            // 몬스터 방향으로 발사 
            RotData attackData;
            Vector3 dir = detect.nearestMonster.position - this.transform.position;

            CalculateAngle(this.transform, dir, out attackData);

            clone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, attackData.angle * attackData.rotDir));
            AttackDir.transform.rotation = Quaternion.Euler(new Vector3(0, 0, attackData.angle * attackData.rotDir));

            yield return new WaitForSeconds(GameManager_E.Instance.projectileShotTime);
        }

        coroutine = null;
    }
}

