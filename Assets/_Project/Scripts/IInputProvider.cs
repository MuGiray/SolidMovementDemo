using UnityEngine;

namespace Project.Core
{
    /// <summary>
    /// Hareket girdilerini sağlayan soyut arayüz.
    /// Bu arayüz sayesinde karakterimiz, girdinin klavyeden mi, joystickten mi 
    /// yoksa yapay zekadan mı geldiğini bilmek zorunda kalmayacak. (Dependency Inversion)
    /// </summary>
    public interface IInputProvider
    {
        Vector3 GetMovementInput();
    }
}