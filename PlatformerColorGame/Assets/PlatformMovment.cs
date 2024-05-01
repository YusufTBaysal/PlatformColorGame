using UnityEngine;

public class KareHareketi : MonoBehaviour
{
    public GameObject posR; // Sað pozisyon nesnesi
    public GameObject posL; // Sol pozisyon nesnesi
    public float speed = 3f; // Hareket hýzý

    private Vector3 hedefNokta; // Hareketin sona ereceði nokta
    private bool hareketYonuSaga = true; // Kare hareket yönü

    private Transform karakter; // Karakter nesnesi
    private Vector3 karakterOffset; // Karakterin platforma göre konum farký

    private bool karakterPlatformda = false; // Karakter platformda mý?

    private Vector3 platformScale; // Platformun scale deðeri

    void Start()
    {
        // Baþlangýçta kareyi sað pozisyona yerleþtir
        transform.position = posR.transform.position;
        hedefNokta = posL.transform.position;

        // Karakter nesnesini bul
        karakter = GameObject.FindGameObjectWithTag("Player").transform;

        // Karakterin platforma göre baþlangýçtaki konum farkýný hesapla
        karakterOffset = transform.position - karakter.position;

        // Platformun baþlangýçtaki scale deðerini kaydet
        platformScale = transform.localScale;
    }

    void Update()
    {
        // Kareyi hedef noktaya doðru hareket ettir
        transform.position = Vector3.MoveTowards(transform.position, hedefNokta, speed * Time.deltaTime);

        // Eðer kare hedef noktaya ulaþtýysa, hareket yönünü deðiþtir
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

        // Karakter platformda deðilse ve platformun ebeveyni ise, karakterin ebeveynliðini kaldýr
        if (!karakterPlatformda && karakter.parent == transform)
        {
            karakter.parent = null;
        }
    }

    private void FixedUpdate()
    {
        // Karakter platformda ise, karakterin platforma baðlý olduðu konumu güncelle
        if (karakterPlatformda)
        {
            karakter.position += transform.position - (transform.position + karakterOffset);
        }

        // Platformun scale deðerini karaktere aktarma
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
