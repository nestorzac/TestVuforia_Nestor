using UnityEngine;
using UnityEngine.Events;

public class FailChacker : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onFailNote;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
            _onFailNote?.Invoke();
        }
    }



}
