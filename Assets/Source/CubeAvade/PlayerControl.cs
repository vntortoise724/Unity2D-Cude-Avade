using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public HUDManager HUDManager;
    public ObjectStats status;
    [Space]
    public Transform leftWall;
    public Transform rightWall;

    //private Rigidbody rb;

    private float horizonInput;
    private float horizonPos;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        status.Heal(100);
        HUDManager.UpdateHealthText(status.health);
    }

    private void Update()
    {
        if (status.health <= 0)
        {
            //AudioControl.PlaySound(SoundType.Reset);
            status.Heal(100);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        horizonInput = Input.GetAxis("Horizontal");
        horizonPos = transform.position.x + horizonInput * status.speed * Time.deltaTime;

        if (horizonPos - 0.5f <= leftWall.position.x + 0.5f || horizonPos + 0.5f >= rightWall.position.x - 0.5f)
            return;

        transform.position = new Vector3 ( horizonPos, transform.position.y , transform.position.z);
    }

    public void ReceiveDamage()
    {
        status.UpdateHealth(5);
        HUDManager.UpdateHealthText(status.health);
        AudioControl.PlaySound(SoundType.Losing);    
    }
}
