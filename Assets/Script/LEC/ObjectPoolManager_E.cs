using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

//public enum MonsterType
//{
//    Penguin, Penguin_red
//}

public enum ProjectileType
{
    Sword, Syringe, Flask
}

public class ObjectPoolManager_E : MonoBehaviour
{
    // ������Ʈ Ǯ��
    //public GameObject[] monsters; // ������ ���� �����յ�
    public GameObject[] projectiles; // ������ ����ü �����յ�

    // �θ��� ��ġ
    public Transform P_monsters;
    public Transform P_projectiles;

    // �� ������Ʈ�� ���� Ǯ
    public IObjectPool<Monster_E> _MonsterPools;
    public IObjectPool<Projectile_E> _ProjectilesPool;

    public IObjectPool<GameObject> _ObjectPool;

    // ���� ����
    //GameObject selectedMon; // ������ ����

    // ����ü ����
    GameObject selectedProj; // ������ ����ü

    private void Awake()
    {
        // ���� Ǯ
        _MonsterPools = new ObjectPool<Monster_E>(CreateMonster, OnGetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);

        // ����ü Ǯ
        _ProjectilesPool = new ObjectPool<Projectile_E>(CreateProjectile, OnGetProjectile, OnReleaseProjectile, OnDestroyProjectile, maxSize: 20);
    }
        
    void ProjectileSelect()
    {
        selectedProj = projectiles[((int)GameManager_E.Instance.curProjectileType)];
    }

    #region ���� Ǯ
    Monster_E CreateMonster()
    {
        // Ǯ���� ���� ����
        Monster_E mon = Instantiate(GameManager_E.Instance.monsterSpawner.curPhase.spawnMonster, P_monsters).GetComponent<Monster_E>();
        mon.SetManagedPool(_MonsterPools);
        return mon;
    }

    void OnGetMonster(Monster_E mon)
    {
        // ������Ʈ Ȱ��ȭ
        mon.gameObject.SetActive(true);
    }

    void OnReleaseMonster(Monster_E mon)
    {
        // ������Ʈ ��Ȱ��ȭ
        mon.gameObject.SetActive(false);
    }

    void OnDestroyMonster(Monster_E mon)
    {
        // ������Ʈ �ı�
        Destroy(mon.gameObject);
    }
    #endregion

    #region ����ü Ǯ
    Projectile_E CreateProjectile()
    {
        ProjectileSelect();

        // Ǯ���� ����ü ����
        Projectile_E proj = Instantiate(selectedProj, P_projectiles).GetComponent<Projectile_E>();
        proj.SetManagedPool(_ProjectilesPool);
        return proj;
    }

    void OnGetProjectile(Projectile_E proj)
    {
        // ������Ʈ Ȱ��ȭ
        proj.gameObject.SetActive(true);
    }

    void OnReleaseProjectile(Projectile_E proj)
    {
        // ������Ʈ ��Ȱ��ȭ
        proj.gameObject.SetActive(false);
    }

    void OnDestroyProjectile(Projectile_E proj)
    {
        // ������Ʈ �ı�
        Destroy(proj.gameObject);
    }
    #endregion
}
