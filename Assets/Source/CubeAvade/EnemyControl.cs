using System;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float ThresholdPos = -15f;
    
    public EnemyType enemyType;

    private PlayerControl playerCtrl;

    public ObjectStats status;

    private void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    private void Update()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - status.speed * Time.deltaTime);

        if (Vector3.Distance(playerCtrl.transform.position, transform.position) < 1.0f)
        {
            if (enemyType == EnemyType.Kwai)
                playerCtrl.ReceiveDamage();
            else
                AudioControl.PlaySound(SoundType.Gaining);

            Destroy(gameObject);
        }
        else if (playerCtrl.transform.position.z - transform.position.z > 5.0f && enemyType == EnemyType.Kwqua)
        {
            playerCtrl.ReceiveDamage();
            Destroy(gameObject);
        }
        else if (transform.position.z <= ThresholdPos)
            Destroy(gameObject);
    }
}

public enum EnemyType
{
    Kwai,
    Kwqua
}
