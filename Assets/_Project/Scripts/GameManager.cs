using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private GameObject _winPanel; // Inspector'dan atayacağımız panel

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // Oyun başladığında kazanma ekranı kapalı olmalı
        if (_winPanel != null) 
            _winPanel.SetActive(false);
    }

    public void LevelComplete()
    {
        Debug.Log("TEBRİKLER! Seviye Tamamlandı.");
        
        // Paneli görünür yap
        if (_winPanel != null)
            _winPanel.SetActive(true);
            
        Time.timeScale = 0f; 
    }

    // Bu fonksiyonu butona bağlayacağız
    public void RestartGame()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}