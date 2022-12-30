using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// ���� ���� -> scriptableObject ���
// -> �츮 ���ӿ����� ���� ���Ͱ� ���� �����µ� �׷��� (���� ���� x ���� ��)��ŭ �����͸� ����ϰ� �� -> �޸� ���� ����
// -> ������ ScriptableObject�� ����ϸ� �������� ������ �����Ͽ� �����ϴ� ������� ���Ǿ� �޸� �Ҹ��� ����

public class Monster_E : MonoBehaviour
{
    public MonsterData_E myData; // ScriptableObject�� ����� �� ������ ������

    Rigidbody2D rigid;
    SpriteRenderer sp_render;

    float maxHp; // �ִ�ü��
    float curHp; // ����ü��
    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sp_render = GetComponent<SpriteRenderer>();
    }

    public void OnDamage(float damage)
    {
        curHp -= damage;
    }

    private void OnEnable()
    {
        StartCoroutine(following());
        curHp = myData.Hp;
    }

    private void Update()
    {
        // �÷��̾�� ���� ������ x�� �Ÿ�
        float dist_x = GameManager_E.Instance.Player.transform.position.x - this.transform.position.x;

        // x�� �Ÿ��� ���� ���� ��ȯ
        this.sp_render.flipX = dist_x < 0;

        // ���� ���
        if (curHp <= 0)
        {
            DestroyMonster();
        }
    }

    #region ������Ʈ Ǯ
    IObjectPool<Monster_E> myPool;

    public void SetManagedPool(IObjectPool<Monster_E> pool)
    {
        // Ǯ�� PoolManager�� ����
        myPool = pool;
    }

    public void DestroyMonster()
    {
        // ����ü�� �ٽ� Ǯ�� ��������
        myPool.Release(this);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // ĳ���Ϳ� �΋H�� ���
            GameManager_E.Instance.Player.OnDamage(myData.Damage);
        }
    }

    // ĳ���Ϳ� �΋H�� ���·� �����Ǵ� ���
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        // ĳ���Ϳ� �΋H�� ���·� �����Ǵ� ��� -> 2�ʿ� �ѹ��� �������� ��
    //        //GameManager_E.Instance.Player.OnDamage(myData.Damage);
    //    }
    //}

    IEnumerator following()
    {
        while(true)
        {
            // ĳ���͸� ����ٴϵ��� ��
            Vector2 dir = GameManager_E.Instance.Player.transform.position - this.transform.position;
            dir.Normalize();

            rigid.MovePosition(rigid.position + dir * GameManager_E.Instance.monsterSpeed * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();  
        }
    }

}
