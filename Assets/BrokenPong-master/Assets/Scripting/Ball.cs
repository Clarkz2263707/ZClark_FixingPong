using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public enum CollisionTag
    {
        BounceWall,
        Player,
        ScoreWall
    }


    [SerializeField] private float speed = 8f;
    [SerializeField] private List<string> tags;
    private Vector2 direction;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private AudioClip clip3;
    void Start()
    {
        transform.position = Vector2.zero;
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tags[(int) CollisionTag.ScoreWall]))
        {
            GameManager.Instance.IncrementScore(other.GetComponent<ScoreWall>().scoringPlayer);
            ResetBall();
            audioSource.PlayOneShot(clip2);
        }
        else if (other.CompareTag(tags[(int)CollisionTag.BounceWall]))
        {
            direction.y = -direction.y;
            audioSource.PlayOneShot(clip3);
        }
        else if (other.CompareTag(tags[(int)CollisionTag.Player]))
        {
            direction.x = -direction.x;
            direction.y = transform.position.y - other.transform.position.y;
            direction = direction.normalized;
            audioSource.PlayOneShot(clip1);
        }
    }
}
