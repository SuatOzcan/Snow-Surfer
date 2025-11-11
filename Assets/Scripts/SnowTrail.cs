using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particleSystem;

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
