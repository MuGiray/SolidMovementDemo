using UnityEngine;
using UnityEngine.EventSystems;
using Project.Core;

public class MobileInput : MonoBehaviour, IInputProvider, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("UI References")]
    [SerializeField] private RectTransform _background;
    [SerializeField] private RectTransform _handle;
    
    private Vector3 _inputVector; // Hareket değerini burada tutacağız

    // 1. IInputProvider'dan gelen zorunluluk
    public Vector3 GetMovementInput()
    {
        // PlayerMovement sadece burayı çağıracak, içeride ne döndüğü umurunda değil.
        return _inputVector; 
    }

    // 2. Ekrana dokunduğumuzda (Tıklama anı)
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData); // Dokunur dokunmaz joystick çalışsın
    }

    // 3. Parmağımızı sürüklediğimizde
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        
        // Tıklanan noktanın, background içindeki yerel koordinatını bul
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _background, 
            eventData.position, 
            eventData.pressEventCamera, 
            out position))
        {
            // Pozisyonu joystick boyutuna oranla (-1 ile 1 arasına sıkıştır)
            position.x = (position.x / _background.sizeDelta.x);
            position.y = (position.y / _background.sizeDelta.y);

            // Joystick'in tam ortasını (0,0) kabul etmesi için ayar (Anchor center varsayarak)
            // Not: Eğer pivotlar farklıysa bu hesap değişebilir, ama temel mantık oranlamaktır.
            // Daha sağlam bir matematik için normalize edilmiş vektör kullanalım:
            
            _inputVector = new Vector3(position.x * 2 , 0, position.y * 2); // *2 çünkü -0.5, 0.5 aralığını -1, 1 yapar
            
            // Vektörün uzunluğu 1'i geçmesin (Hızlı gitmemesi için)
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            // Görsel topuzu (Handle) hareket ettir
            _handle.anchoredPosition = new Vector2(
                _inputVector.x * (_background.sizeDelta.x / 2), 
                _inputVector.z * (_background.sizeDelta.y / 2)
            );
        }
    }

    // 4. Parmağımızı çektiğimizde
    public void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector3.zero;
        _handle.anchoredPosition = Vector2.zero; // Topuzu merkeze al
    }
}