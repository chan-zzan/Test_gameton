using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile_E : MonoBehaviour
{
    IObjectPool<Projectile_E> myPool;

    private void Update()
    {
        this.transform.Translate(this.transform.up * GameManager_E.Instance.projectileSpeed * Time.deltaTime, Space.World); // 투사체 발사
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 몬스터와 부딪혔을 경우
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {            
            collision.GetComponent<Monster_E>().OnDamage(GameManager_E.Instance.Player.myStatus.ATK); // 몬스터 피격 데미지
            DestroyProjectile();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 투사체가 사거리를 넘어간 경우
        if(collision.gameObject.layer == LayerMask.NameToLayer("ProjectileRange"))
        {
            DestroyProjectile();
        }
    }

    public void SetManagedPool(IObjectPool<Projectile_E> pool)
    {
        // 풀을 PoolManager에 저장
        myPool = pool;
    }

    public void DestroyProjectile()
    {
        if(this.gameObject.activeSelf)
        {
            myPool.Release(this);
        }
    }   
}
