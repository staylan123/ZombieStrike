using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; // Refs fire pt for bullet
    public GameObject bulletPrefab;

    public Text ammoCount;

    public int ammo;
    
    public bool isFiring;
    private bool isReloading = false;
    
    public float bulletForce = 20f;

    private AudioSource gunshotAudio;
    private AudioSource reloadAudio;

    
    
    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        gunshotAudio = audios[0];
        reloadAudio = audios[1];
        
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount.text = ammo.ToString();
        

        if(Input.GetButtonDown("Fire1") && !isFiring && ammo > 0 & !PauseMenu.GameIsPaused) 
        {
            gunshotAudio.Play();
            isFiring = true;
            ammo--;
            Shoot();
        } else
        {
            isFiring = false;
        }

        if(isReloading)
        {
            return;
        }

        if(Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
            reloadAudio.Play();
        }   
    }

    // Shoot method
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // spawns bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // gives RB to bullet obj
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // Will add force to bullet
    }


    // Reload Method
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("RELOADING!");
        yield return new WaitForSeconds(1);
        ammo = 10;
        isReloading = false;
    }
}
