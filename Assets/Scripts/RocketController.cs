using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float forwardSpeed = 10f;  // Karakterin ileri doğru hızı
    public float swerveSpeed = 3f;   // Karakterin yanlama hızı
    public float maxSwerveAmount = 2f;  // Maksimum yana doğru hareket miktarı

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // İleri doğru hareket
        rb.velocity = new Vector3(0, -forwardSpeed, 0);

        // Kullanıcının girişini al
        float swerveInput = Input.GetAxis("Horizontal");

        // Karakterin yana doğru hareketini uygula
        float swerveAmount = swerveInput * swerveSpeed;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        rb.position = new Vector3(swerveAmount, rb.position.y, rb.position.z);
    }
}
