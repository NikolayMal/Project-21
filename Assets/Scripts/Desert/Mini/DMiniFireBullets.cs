﻿using UnityEngine;

public class DMiniFireBulletsBug : MonoBehaviour
{
    // Phase 1 
    public int bulletsAmountDM;
    public float startAngleDM;
    public float endAngleDM;
    private Vector2 bulletMoveDirectionDM;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0.1f, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Fire()
    {
        float bulletSpread = (endAngleDM - startAngleDM) / bulletsAmountDM;
        float Bugangle = startAngleDM;

        for (int i = 0; i < bulletsAmountDM + 1; i++)
        {
            // End Point
            float DMbulletDirX = transform.position.x + Mathf.Sin((Bugangle * Mathf.PI) / 180f);
            float DMbulletDirY = transform.position.y + Mathf.Cos((Bugangle * Mathf.PI) / 180f);

            Vector3 DMbulletMoveVector = new Vector3(DMbulletDirX, DMbulletDirY, 0f);
            Vector2 DMbulletDir = (DMbulletMoveVector - transform.position).normalized;

            GameObject bulDM = DminiBulletPool.bulletPoolInstanseDM.GetBullet();
            bulDM.transform.position = transform.position;
            bulDM.transform.rotation = transform.rotation;
            bulDM.SetActive(true);
            bulDM.GetComponent<BugBullet>().SetMoveDirection(DMbulletDir);

            Bugangle += bulletSpread;
        }
    }
}

