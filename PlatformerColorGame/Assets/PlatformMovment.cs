using UnityEngine;

public class KareHareketi : MonoBehaviour
{
    public GameObject posR; // Sa� pozisyon nesnesi
    public GameObject posL; // Sol pozisyon nesnesi
    public float speed = 3f; // Hareket h�z�

    private Vector3 hedefNokta; // Hareketin sona erece�i nokta
    private bool hareketYonuSaga = true; // Kare hareket y�n�

    private Transform karakter; // Karakter nesnesi
    private Vector3 karakterOffset; // Karakterin platforma g�re konum fark�

    private bool karakterPlatformda = false; // Karakter platformda m�?

    private Vector3 platformScale; // Platformun scale de�eri

    void Start()
    {
        // Ba�lang��ta kareyi sa� pozisyona yerle�tir
        transform.position = posR.transform.position;
        hedefNokta = posL.transform.position;

        // Karakter nesnesini bul
        karakter = GameObject.FindGameObjectWithTag("Player").transform;

        // Karakterin platforma g�re ba�lang��taki konum fark�n� hesapla
        karakterOffset = transform.position - karakter.position;

        // Platformun ba�lang��taki scale de�erini kaydet
        platformScale = transform.localScale;
    }

    void Update()
    {
        // Kareyi hedef noktaya do�ru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, hedefNokta, speed * Time.deltaTime);

        // E�er kare hedef noktaya ula�t�ysa, hareket y�n�n� de�i�tir
        if (transform.position == hedefNokta)
        {
            if (hareketYonuSaga)
            {
                hedefNokta = posL.transform.position;
                hareketYonuSaga = false;
            }
            else
            {
                hedefNokta = posR.transform.position;
                hareketYonuSaga = true;
            }
        }

        // Karakter platformda de�ilse ve platformun ebeveyni ise, karakterin ebeveynli�ini kald�r
        if (!karakterPlatformda && karakter.parent == transform)
        {
            karakter.parent = null;
        }
    }

    private void FixedUpdate()
    {
        // Karakter platformda ise, karakterin platforma ba�l� oldu�u konumu g�ncelle
        if (karakterPlatformda)
        {
            karakter.position += transform.position - (transform.position + karakterOffset);
        }

        // Platformun scale de�erini karaktere aktarma
        transform.localScale = platformScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            karakterPlatformda = true;
            karakter.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            karakterPlatformda = false;
        }
    }
}
