using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mehmet;

public class GameManager : MonoBehaviour
{
    
    public static int instantCharacterCount = 1;

    public List<GameObject> players;
    public List<GameObject> createdEffects;
    public List<GameObject> destroyEffects;
    public List<GameObject> playerBlotEffects;

    [Header("Level's data")]
    public List<GameObject> enemies;
    public int numberOfEnemies;
    public GameObject _mainPlayer;
    public bool isGameOver;

    public GameObject gameWin;
    public GameObject gameLost;



    private void Start()
    {
        Created_Enemies();
    }

    private void War_State()
    {
        if (instantCharacterCount == 1 || numberOfEnemies == 0)
        {
            isGameOver = true;

            foreach (GameObject enemy in enemies)
            {
                if (enemy.activeInHierarchy)
                {
                    enemy.GetComponent<Animator>().SetBool("Attack", false);
                }
            }

            foreach (GameObject player in players)
            {
                if (player.activeInHierarchy)
                {
                    player.GetComponent<Animator>().SetBool("Attack", false);
                }
            }

            _mainPlayer.GetComponent<Animator>().SetBool("Attack", false); ;

            if (instantCharacterCount < numberOfEnemies || instantCharacterCount == numberOfEnemies)
            {
                gameLost.SetActive(true);
            }
            else
            {
                gameWin.SetActive(true);
            }
        }
        
    }

    public void Created_Enemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            enemies[i].SetActive(true);
        }
    }

    public void Enemies_Trigger()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy)
            {
                enemy.GetComponent<Enemy>().Animation_Trigger();
            }
        }
    }

    public void Create_Player(string operationType, int getNumber, Transform position)
    {
        switch (operationType)
        {
            case "Carpma":
                Mathematical_Operations.Multiply(getNumber, players, position, createdEffects);

                break;

            case "Toplama":
                Mathematical_Operations.Addition(getNumber, players, position, createdEffects);

                break;

            case "Cikarma":
                Mathematical_Operations.Subtraction(getNumber, players, destroyEffects);

                break;

            case "Bolme":
                Mathematical_Operations.Division(getNumber, players, destroyEffects);

                break;
        }
    }

    public void Created_Destroy_Effect(Vector3 position, bool hammer = false, bool playerState = false)
    {
        foreach (GameObject effect in destroyEffects)
        {
            if (!effect.activeInHierarchy)
            {
                effect.SetActive(true);
                effect.transform.position = position;
                effect.GetComponent<ParticleSystem>().Play();

                if (!playerState)
                {
                    instantCharacterCount--;
                }
                else
                {
                    numberOfEnemies--;
                }
                
                break;
            }
        }


        if (hammer)
        {
            Vector3 newPosition = new Vector3(position.x, 0.005f, position.z);

            foreach (GameObject effect in playerBlotEffects)
            {
                if (!effect.activeInHierarchy)
                {
                    effect.SetActive(true);
                    effect.transform.position = newPosition;
                    break;
                }
            }
        }

        if (!isGameOver)
        {
            War_State();
        }
    }
}