using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    protected float health;
    protected float atack;
    protected bool isTargetMouse = false;
    public Transform player;
    private float vectorlength;
    protected Rigidbody2D rigidbodyEnemy;
    protected Vector2 moveEnemyVector;
    protected Vector2 moveToMouseVector;
    public Camera cam;
    public CoinText CoinText;
    public bool IsSpeedImprovement;
    public void OnMouseDown()
    {
        isTargetMouse = true;
    }
    protected void MovetoMouse()
    {
        var mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveToMouseVector = GetOrtVectorInPosition(mouse, rigidbodyEnemy.position);
        CoinText.Coin += (int)Math.Sqrt(moveToMouseVector.x * moveToMouseVector.x + moveToMouseVector.y * moveToMouseVector.y);
        if (IsSpeedImprovement)
            rigidbodyEnemy.velocity += moveToMouseVector * 100;
        else
            rigidbodyEnemy.velocity += moveToMouseVector * 7.5f;
    }
    protected Vector2 GetOrtVectorInPosition(Vector3 first, Vector3 second)
    {
        /// first: точка куда идем , second: от куда 
        var rez = new Vector2();
        rez.x = first.x - second.x;
        rez.y = first.y - second.y;
        vectorlength = (float)Math.Sqrt(rez.x * rez.x + rez.y * rez.y);
        rez.x = rez.x / vectorlength;
        rez.y = rez.y / vectorlength;
        return rez;
    }
    public float GetAtk()
    {
        return atack;
    }
}
