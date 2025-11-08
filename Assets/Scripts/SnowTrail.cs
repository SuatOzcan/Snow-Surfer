using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particleSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int index = LayerMask.NameToLayer("Floor");
        if ((collision.gameObject.layer == index))
        {
            _particleSystem.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        int index = LayerMask.NameToLayer("Floor");
        if ((collision.gameObject.layer == index))
        {
            _particleSystem.Stop();
        }
    }
}
