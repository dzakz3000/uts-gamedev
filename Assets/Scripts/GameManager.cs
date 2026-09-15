using UnityEngine;
public class GameManager : MonoBehaviour
{
[SerializeField] private int skor = 0;

 public int totalKoin;
 private int koinTerkumpul = 0;
 void Start()
 {
 // TODO: hitung jumlah koin di scene saat mulai
 totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length;
 }

 void OnEnable()
    {
        Enemy.OnZombieMati += TambahSkorSaatZombieMati;
    }

 void OnDisable()
    {
        Enemy.OnZombieMati -= TambahSkorSaatZombieMati;
    }

    private void TambahSkorSaatZombieMati(Enemy zombie)
    {
        skor += 10; // Tambahkan skor saat zombie mati
        Debug.Log("Skor: " + skor);
    }   
 public void AmbilKoin()
 {
 koinTerkumpul++;
 // TODO: jika koinTerkumpul == totalKoin, panggil Menang()
 if (koinTerkumpul == totalKoin)
 {
     Menang();
 }
 }
 void Menang()
 {
 Debug.Log("KAMU MENANG!");
 }
}
