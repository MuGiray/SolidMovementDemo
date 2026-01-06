using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    // Fizik motoru birisi "Trigger" alanına girdiğinde bu fonksiyonu tetikler
    private void OnTriggerEnter(Collider other)
    {
        // Gelen şeyin "Player" olup olmadığını kontrol etmeliyiz.
        // Yoksa düşen bir taş da oyunu bitirebilir!
        if (other.CompareTag("Player")) 
        {
            // Singleton sayesinde referans aramadan direkt yöneticiye ulaşıyoruz
            GameManager.Instance.LevelComplete();
        }
    }
}