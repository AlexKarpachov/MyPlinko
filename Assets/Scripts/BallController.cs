using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float buttomThresholdPosition;

    ObjectPool pool;

    void Start()
    {
        pool = FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (transform.position.y < -buttomThresholdPosition)
        {
            ReturnToQueue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Score.score++;
            StartCoroutine(DelayedReturnToQueue());
        }
    }

    IEnumerator DelayedReturnToQueue()
    {
        yield return new WaitForSeconds(0.05f);
        ReturnToQueue();
    }

    void ReturnToQueue()
    {
        gameObject.SetActive(false);
        pool.ReturnToQueue(gameObject);
    }
}
