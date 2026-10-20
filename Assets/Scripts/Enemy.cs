using UnityEngine;
using System;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    public static event Action<Enemy> OnZombieMati;
    [SerializeField] private int hp = 100;
    [SerializeField] private UnityEvent OnZombieMatiVisual;
    public float ms = 2f;
    protected Transform player;
    
    [Header("Pengaturan State Machine")]
    [SerializeField] private float jarakDeteksi = 6f; //masuk CHASE
    [SerializeField] private float jarakSerang = 1.2f; //masuk ATTACK
    [SerializeField] private float jedaSerang = 1f; //delay serangan

    private StateZombie state = StateZombie.IDLE;
    private float waktuSerangTerakhir;
    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        PeriksaTransisi();

        switch (state)
        {
            case StateZombie.IDLE:  PerilakuIdle(); break;
            case StateZombie.PATROL: PerilakuPatrol(); break;
            case StateZombie.CHASE:  PerilakuChase(); break;
            case StateZombie.ATTACK: PerilakuAttack(); break;
        }
    }

    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;

        return Vector2.Distance(transform.position, player.position);
    }

    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

       if (jarak <= jarakSerang)
        {
            state = StateZombie.ATTACK;
        } else if (jarak <= jarakDeteksi)
        {
            state = StateZombie.CHASE;
        }
        else
        {
            state = StateZombie.PATROL;
        }
        
    }

    public void Kejar()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    public virtual void Serang()
    {
        Debug.Log("Enemy menyerang!");
    }

    public void KenaDamage(int jumlah)
    {
        hp -= jumlah;
        Debug.Log($"{gameObject.name} kena damage {jumlah}, HP sisa: {hp}");

        if (hp <= 0)
        {
            Mati();
        }
    }

    protected virtual void Mati()
    {
        Debug.Log(name + " kalah!");
        OnZombieMati?.Invoke(this); 
        OnZombieMatiVisual?.Invoke();
        Destroy(gameObject);
    }

    void PerilakuIdle()
    {
        
    }
    void PerilakuPatrol()
    {
       //Debug.Log("Enemy sedang patroli");
    }
    void PerilakuChase()
    {
        {Kejar();}
    }
    void PerilakuAttack()
    {
        if (Time.time >= waktuSerangTerakhir + jedaSerang)
        {
            Serang();
            waktuSerangTerakhir = Time.time;
        }
    }
}
