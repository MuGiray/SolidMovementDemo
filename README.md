# Solid Movement Prototype

Bu proje, Unity üzerinde SOLID prensipleri ve Temiz Kod (Clean Code) mimarisi kullanılarak geliştirilmiş, ölçeklenebilir bir karakter kontrol prototipidir.

##  Projenin Amacı
Spagetti kod (Spaghetti Code) yerine modüler, genişletilebilir ve test edilebilir bir oyun mimarisi kurmak. Farklı girdi sistemlerinin (Klavye, Mobil Joystick, AI) ana oyun döngüsünü bozmadan sisteme entegre edilebileceğini kanıtlar.

##  Kullanılan Teknolojiler ve Mimari
* Unity 6 LTS (URP): Yüksek performanslı render hattı.
* New Input System: Modern girdi yönetimi.
* Cinemachine: Profesyonel kamera takip sistemi.

##  Tasarım Desenleri (Design Patterns)
Projede aşağıdaki mühendislik yaklaşımları uygulanmıştır:

### 1. Dependency Inversion & Interface Segregation
Karakter hareketi (`PlayerMovement`), doğrudan klavyeye veya joystick'e bağımlı değildir.
* `IInputProvider`: Tüm girdi kaynakları bu arayüzü kullanır. Bu sayede "KeyboardInput" scripti çıkarılıp yerine "MobileInput" takıldığında sistem çalışmaya devam eder.

### 2. Singleton Pattern
Oyun döngüsünü yönetmek için Thread-Safe Singleton yapısında bir `GameManager` kullanılmıştır.
* Seviye bitişi, UI yönetimi ve sahne geçişleri merkezi bir noktadan kontrol edilir.

### 3. Prefab Workflow
Tüm oyun objeleri (Player, Obstacles) "Prefab" haline getirilerek ölçeklenebilir bir seviye tasarımı (Level Design) altyapısı kurulmuştur.

##  Özellikler
* [x] Fizik tabanlı karakter kontrolü (Rigidbody).
* [x] Mobil uyumlu Joystick kontrolü.
* [x] Modüler Engel ve Zemin sistemi.
* [x] Win/Lose durumu ve UI entegrasyonu.

---
Developed by Muhammet