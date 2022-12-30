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
    // 오브젝트 풀링
    //public GameObject[] monsters; // 보관할 몬스터 프리팹들
    public GameObject[] projectiles; // 보관할 투사체 프리팹들

    // 부모의 위치
    public Transform P_monsters;
    public Transform P_projectiles;

    // 각 오브젝트를 담을 풀
    public IObjectPool<Monster_E> _MonsterPools;
    public IObjectPool<Projectile_E> _ProjectilesPool;

    public IObjectPool<GameObject> _ObjectPool;

    // 몬스터 종류
    //GameObject selectedMon; // 선택한 몬스터

    // 투사체 종류
    GameObject selectedProj; // 선택한 투사체

    private void Awake()
    {
        // 몬스터 풀
        _MonsterPools = new ObjectPool<Monster_E>(CreateMonster, OnGetMonster, OnReleaseMonster, OnDestroyMonster, maxSize: 10);

        // 투사체 풀
        _ProjectilesPool = new ObjectPool<Projectile_E>(CreateProjectile, OnGetProjectile, OnReleaseProjectile, OnDestroyProjectile, maxSize: 20);
    }
        
    void ProjectileSelect()
    {
        selectedProj = projectiles[((int)GameManager_E.Instance.curProjectileType)];
    }

    #region 몬스터 풀
    Monster_E CreateMonster()
    {
        // 풀에서 몬스터 생성
        Monster_E mon = Instantiate(GameManager_E.Instance.monsterSpawner.curPhase.spawnMonster, P_monsters).GetComponent<Monster_E>();
        mon.SetManagedPool(_MonsterPools);
        return mon;
    }

    void OnGetMonster(Monster_E mon)
    {
        // 오브젝트 활성화
        mon.gameObject.SetActive(true);
    }

    void OnReleaseMonster(Monster_E mon)
    {
        // 오브젝트 비활성화
        mon.gameObject.SetActive(false);
    }

    void OnDestroyMonster(Monster_E mon)
    {
        // 오브젝트 파괴
        Destroy(mon.gameObject);
    }
    #endregion

    #region 투사체 풀
    Projectile_E CreateProjectile()
    {
        ProjectileSelect();

        // 풀에서 투사체 생성
        Projectile_E proj = Instantiate(selectedProj, P_projectiles).GetComponent<Projectile_E>();
        proj.SetManagedPool(_ProjectilesPool);
        return proj;
    }

    void OnGetProjectile(Projectile_E proj)
    {
        // 오브젝트 활성화
        proj.gameObject.SetActive(true);
    }

    void OnReleaseProjectile(Projectile_E proj)
    {
        // 오브젝트 비활성화
        proj.gameObject.SetActive(false);
    }

    void OnDestroyProjectile(Projectile_E proj)
    {
        // 오브젝트 파괴
        Destroy(proj.gameObject);
    }
    #endregion
}
