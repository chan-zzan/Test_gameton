using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum STATE
{
    // ĳ������ ���¸� ������ ���¿� ���� �ൿ�ϵ��� ��
    Play, Die
}

[System.Serializable]
public class Stat
{
    // ĳ���� ����
    // Json �̿� -> �� ����ڸ��� ������ ������ �޶����� ������ Json�� �̿��Ͽ� �����ϴ� ����� ���
    // ������ ����� �� ������ �װ� �� ���� ��?!

    // ü��
    // ���ݷ�
    // ����
    // �̵��ӵ�
    // ����� -> projectileShotTime(����ü �߻��ֱ�)
    // (ġ��Ÿ Ȯ��)

    public float HP = 100; // ü��
    public float ATK = 10; // ���ݷ�
    public float DEF = 10; // ����
    public float Speed = 15; // �̵��ӵ�
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

    public Transform playerDir; // �÷��̾� ����
    bool isFlip; // �÷��̾��� �¿���� ����

    Vector2 joyInput; // ���̽�ƽ �Է°�
    Rigidbody2D rigid;

    public GameObject projectile; // �߻�ü
    public Transform spawnPos; // �߻�ü ���� ��ġ

    public RectTransform Dir; // ���� ĳ���Ͱ� �ٶ󺸴� ����

    public RectTransform AttackDir; // ���� ����
    public Transform attackPos; // ���� ���� ��ġ

    public Detect_E detect; // ���� Ž�� �ݶ��̴�

    Coroutine coroutine; // ���� �ڷ�ƾ ����

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
        // �ʱ� HP ����
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
            // ���̽�ƽ�� ���� ĳ������ �̵�
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
        // ���Ͱ� ������ ��쿡�� �ڷ�ƾ ����
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
            // �����̴� ���� ��
            inputDir = joyInput;
            SPUM.PlayAnimation(1); // run
        }
        else
        {
            // �������� ��
            inputDir = joy.lastPos;
            SPUM.PlayAnimation(0); // idle
        }

        // ĳ���� �¿� ����
        isFlip = inputDir.x > 0;

        if (isFlip)
        {
            rot = new Vector3(0, 180, 0);
        }
        else
        {
            rot = new Vector3(0, 0, 0);
        }

        playerDir.rotation = Quaternion.Euler(rot); // �¿� ���� ����

        RotData moveData;

        // ���� �̵� ������ �˷��ִ� ȭ��ǥ
        CalculateAngle(this.transform, inputDir, out moveData);
        Dir.rotation = Quaternion.Euler(new Vector3(0, 0, moveData.angle * moveData.rotDir)); // ���� ����
    }

    void CalculateAngle(Transform tr, Vector3 dir, out RotData data)
    {
        // ���� ���
        float rad = Mathf.Acos(Vector3.Dot(tr.up, dir.normalized)); // �̵��� ���������� ������ ����
        data.angle = 180 * (rad / Mathf.PI); // degree ������ �ٲ�
        data.rotDir = 1.0f; // ȸ�� ���Ⱚ => ������

        if (Vector3.Dot(tr.right , dir.normalized) > 0.0f)
        {
            data.rotDir = -1.0f; // ���ʹ���
        }
    }

    IEnumerator Shotting()
    {
        while (detect.monsters.Count > 0)
        {
            SPUM.PlayAnimation(5); // attack

            yield return new WaitForSeconds(0.3f); // �ִϸ��̼� ������ �ð�          

            // ����ü ����
            Projectile_E clone = GameManager_E.Instance.Pool._ProjectilesPool.Get();
            clone.transform.position = this.transform.position;

            if (detect.nearestMonster == null) break;

            // ���� �������� �߻� 
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

