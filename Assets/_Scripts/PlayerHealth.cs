using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;

    int coinScore;

    bool canTakeDMG;

    public GameObject player;
    public CircleCollider2D colliderDMG;

    [SerializeField]
    SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        canTakeDMG = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Health: " + health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTakeDMG)
        {
            if (collision.gameObject.GetComponent<CircleCollider2D>() == colliderDMG)
            {
                health = health - 50;
                StartCoroutine(IFrames());
            }
        }
        CoinsManager(collision);
    }

    void CoinsManager(Collider2D collision)
    {
        if (collision.tag == "Coins")
        {
            GameManager.Instance.GetCoin();
            collision.gameObject.SetActive(false);
        }
    }

    void BlinkCharacter(float alpha)
    {
        playerSprite.color = new Color(1, 1, 1, alpha);
    }
    IEnumerator IFrames()
    {
        canTakeDMG = false;
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(.2f);
        yield return new WaitForSeconds(.02f);
        BlinkCharacter(1f);
        canTakeDMG = true;
    }
}
