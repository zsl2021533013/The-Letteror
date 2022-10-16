using UnityEngine;


public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    public GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player == Player.GetComponent<Collider2D>())
        {
            Button.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D player)
    {
        if (player == Player.GetComponent<Collider2D>())
        {
            Button.SetActive(false);
        }
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.W))
        {
            talkUI.SetActive(true);
        }
    }
}
