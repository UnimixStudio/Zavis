using System;
using UnityEngine;

public class ShowObjectTrigger : MonoBehaviour
{

    [SerializeField] private GameObject _showingObject;
    [SerializeField]private  string _tag = "Player";

    private void Awake()
    {
        Hide();
    }

    private void Show()
    {
        _showingObject.SetActive(true);
    }

    private void Hide()
    {
        _showingObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_tag)) 
            Show();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_tag)) 
            Hide();
    }
}
