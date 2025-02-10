using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathBoundary : MonoBehaviour
{
    public TMP_Text fallCountText;

    private Transform player;
    private Vector2 startPosition;
    private string defaultFallCountText;
    private int fallCountCounter;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
        startPosition = player.transform.position;
        defaultFallCountText = fallCountText.text;
        fallCountText.text = $"{defaultFallCountText} {fallCountCounter}";
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        ResetPosition();
        addToFallCounter();
    }

    public void ResetPosition()
    {
        player.transform.position = startPosition;
    }
    public void addToFallCounter()
    {
        fallCountCounter++;
        fallCountText.text = $"{defaultFallCountText} {fallCountCounter}";
    }
}
