using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public int totalPoints;
    Animator animator;
    TMP_Text tmp_text;
    private void Start()
    {
        totalPoints = 0;
        animator = GetComponent<Animator>();
        tmp_text = GetComponentInChildren<TMP_Text>();
        tmp_text.text = totalPoints.ToString();
        animator.SetInteger("Points", totalPoints);
    }
    public void AddPoint()
    {
        totalPoints++;
        tmp_text.text = totalPoints.ToString();
        animator.SetInteger("Points", totalPoints);
    }
}
