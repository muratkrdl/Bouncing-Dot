using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigid;
    [SerializeField] SpriteRenderer mySprite;
    [SerializeField] Sprite[] _ballSprites;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] string _currentColor;

    string _RED = "Red";
    string _YELLOW = "Yellow";
    string _BLUE = "Blue";
    string _PURPLE = "Purple";
    string _GREEN = "Green";
    string _ORANGE = "Orange";

    GameManager gameManager;

    void Awake() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start() 
    {
        RandomBallColor(3);
    }

    public void RandomBallColor(int _index)
    {
        switch(_index)
        {
            case 0:
                _currentColor = _RED;
                mySprite.sprite = _ballSprites[_index];
                gameObject.tag = _RED;
                break;
            case 1:
                _currentColor = _YELLOW;
                mySprite.sprite = _ballSprites[_index];
                gameObject.tag = _YELLOW;
                break;
            case 2:
                _currentColor = _BLUE;
                mySprite.sprite = _ballSprites[_index];
                gameObject.tag = _BLUE;
                break;
            case 3:
                _currentColor = _PURPLE;
                mySprite.sprite = _ballSprites[_index];
                gameObject.tag = _PURPLE;
                break;
            case 4:
                _currentColor = _GREEN;
                mySprite.sprite = _ballSprites[_index];
                gameObject.tag = _GREEN;
                break;
            case 5:
                _currentColor = _ORANGE;
                mySprite.sprite = _ballSprites[_index];
                gameObject.tag = _ORANGE;
                break;
            default:
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        myRigid.velocity = Vector3.up * jumpForce;

        if(other.gameObject.tag != gameObject.tag)
        {
            //GameOver
            StartCoroutine(gameManager.RestartGame());
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            return;
        }

        gameManager.InxreaseScore();

        int _randomIndex = Random.Range(0, _ballSprites.Length);
        RandomBallColor(_randomIndex);
    }

}
