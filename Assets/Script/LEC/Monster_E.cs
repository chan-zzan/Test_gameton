using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// 몬스터 스탯 -> scriptableObject 사용
// -> 우리 게임에서는 같은 몬스터가 많이 나오는데 그러면 (스텟 변수 x 몬스터 수)만큼 데이터를 사용하게 됨 -> 메모리 샤용 증가
// -> 하지만 ScriptableObject를 사용하면 데이터의 원본만 저장하여 참조하는 방식으로 사용되어 메모리 소모량을 줄임

public class Monster_E : MonoBehaviour
{
    public MonsterData_E myData; // ScriptableObject로 저장된 각 몬스터의 데이터

    Rigidbody2D rigid;
    SpriteRenderer sp_render;

    float maxHp; // 최대체력
    float curHp; // 현재체력
    

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
        // 플레이어와 몬스터 사이의 x축 거리
        float dist_x = GameManager_E.Instance.Player.transform.position.x - this.transform.position.x;

        // x축 거리에 따라 방향 전환
        this.sp_render.flipX = dist_x < 0;

        // 몬스터 사망
        if (curHp <= 0)
        {
            DestroyMonster();
        }
    }

    #region 오브젝트 풀
    IObjectPool<Monster_E> myPool;

    public void SetManagedPool(IObjectPool<Monster_E> pool)
    {
        // 풀을 PoolManager에 저장
        myPool = pool;
    }

    public void DestroyMonster()
    {
        // 투사체를 다시 풀에 돌려놓음
        myPool.Release(this);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // 캐릭터와 부딫힐 경우
            GameManager_E.Instance.Player.OnDamage(myData.Damage);
        }
    }

    // 캐릭터와 부딫힌 상태로 유지되는 경우
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        // 캐릭터와 부딫힌 상태로 유지되는 경우 -> 2초에 한번씩 데미지를 줌
    //        //GameManager_E.Instance.Player.OnDamage(myData.Damage);
    //    }
    //}

    IEnumerator following()
    {
        while(true)
        {
            // 캐릭터를 따라다니도록 함
            Vector2 dir = GameManager_E.Instance.Player.transform.position - this.transform.position;
            dir.Normalize();

            rigid.MovePosition(rigid.position + dir * GameManager_E.Instance.monsterSpeed * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();  
        }
    }

}
