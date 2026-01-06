using UnityEngine;
using Project.Core;

[RequireComponent(typeof(Rigidbody))] // Bu scripti eklediğin objede Rigidbody olmak ZORUNDA kuralı
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private GameObject _inputProviderObject;
    
    private IInputProvider _inputProvider;
    private Rigidbody _rb; // Fizik motoruna erişim
    private Vector3 _inputDirection;

    private void Awake()
    {
        // Rigidbody bileşenini alıyoruz
        _rb = GetComponent<Rigidbody>();

        // Input Provider kontrolü (Eski kodumuzla aynı)
        if (_inputProviderObject != null)
        {
            _inputProvider = _inputProviderObject.GetComponent<IInputProvider>();
        }
        else
        {
            _inputProvider = GetComponent<IInputProvider>();
        }
    }

    private void Update()
    {
        // Girdileri her karede (frame) okumaya devam et.
        // Çünkü parmak hareketleri fizik döngüsünü beklemez.
        if (_inputProvider != null)
            _inputDirection = _inputProvider.GetMovementInput();
    }

    private void FixedUpdate() // Fizik döngüsü (Genelde saniyede 50 kez)
    {
        Move();
    }

    private void Move()
    {
        // Eğer girdi yoksa işlem yapma
        if (_inputDirection == Vector3.zero) return;

        // Mühendislik Notu: MovePosition, objeyi bir noktadan diğerine "ışınlamaz",
        // fizik motoruna "bir sonraki karede burada olmalı" der. 
        // Böylece arada duvar varsa motor bunu algılar ve durdurur.
        
        Vector3 targetPosition = _rb.position + (_inputDirection * _moveSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(targetPosition);
    }
}