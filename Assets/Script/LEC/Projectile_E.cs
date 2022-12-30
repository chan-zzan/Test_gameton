using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile_E : MonoBehaviour
{
    IObjectPool<Projectile_E> myPool;

    private void Update()
    {
        this.transform.Translate(this.transform.up * GameManager_E.Instance.projectileSpeed * Time.deltaTime, Space.World); // ����ü �߻�
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���Ϳ� �ε����� ���
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {            
            collision.GetComponent<Monster_E>().OnDamage(GameManager_E.Instance.Player.myStatus.ATK); // ���� �ǰ� ������
            DestroyProjectile();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ����ü�� ��Ÿ��� �Ѿ ���
        if(collision.gameObject.layer == LayerMask.NameToLayer("ProjectileRange"))
        {
            DestroyProjectile();
        }
    }

    public void SetManagedPool(IObjectPool<Projectile_E> pool)
    {
        // Ǯ�� PoolManager�� ����
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
