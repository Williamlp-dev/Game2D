using UnityEngine;

public class GunController : MonoBehaviour
{
    SpriteRenderer sprite;
    AudioSource shootFX;
    public GameObject bullet;
    public Transform spawnBullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        shootFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();

    }

    void Shoot()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, spawnBullet.position, transform.rotation);
            shootFX.Play();
        }

    }
    void Aim()
    {

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (mousePos.x < screenPoint.x)
            sprite.flipY = true;
        else
            sprite.flipY = false;

    }
}
