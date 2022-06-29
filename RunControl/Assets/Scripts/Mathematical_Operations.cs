using System.Collections.Generic;
using UnityEngine;


namespace Mehmet
{
    public class Mathematical_Operations : MonoBehaviour
    {
        public static void Multiply(int getNumber, List<GameObject> players, Transform position, List<GameObject> created_effects)
        {
            int loopNumber = (GameManager.instantCharacterCount * getNumber - GameManager.instantCharacterCount);
            //                            10                  *    6       -       10 = 54
            //10 karakterimiz var. 6 ile çarptýðýmýzda 60 yapar. Bizim 60 tane karakter göstermemiz için 54 tane karakter üretmemiz gerekir.
            int number = 0;

            foreach (GameObject player in players)
            {

                if (number < loopNumber)
                {
                    if (!player.activeInHierarchy)
                    {

                        foreach (GameObject effect in created_effects)
                        {
                            if (!effect.activeInHierarchy)
                            {

                                effect.SetActive(true);
                                effect.transform.position = position.position;
                                effect.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }

                        player.transform.position = position.position;
                        player.SetActive(true);
                        number++;
                    }
                }
                else
                {
                    number = 0;
                    break;
                }
            }
            GameManager.instantCharacterCount *= getNumber;


        }

        public static void Addition(int getNumber, List<GameObject> players, Transform position, List<GameObject> created_effects)
        {
            int number1 = 0;

            foreach (GameObject player in players)
            {

                if (number1 < getNumber)
                {
                    if (!player.activeInHierarchy)
                    {

                        foreach (GameObject effect in created_effects)
                        {
                            if (!effect.activeInHierarchy)
                            {

                                effect.SetActive(true);
                                effect.transform.position = position.position;
                                effect.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }

                        player.transform.position = position.position;
                        player.SetActive(true);
                        number1++;
                    }
                }
                else
                {
                    number1 = 0;
                    break;
                }
            }
            GameManager.instantCharacterCount += getNumber;
        }

        public static void Subtraction(int getNumber, List<GameObject> players, List<GameObject> destroy_effects)
        {
            if (GameManager.instantCharacterCount < getNumber)
            {

                foreach (GameObject player in players)
                {
                    foreach (GameObject effect in destroy_effects)
                    {
                        if (!effect.activeInHierarchy)
                        {
                            Vector3 newPosition = new Vector3(player.transform.position.x, 0.24f, player.transform.position.z);

                            effect.SetActive(true);
                            effect.transform.position = newPosition;
                            effect.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }


                    player.transform.position = Vector3.zero;
                    player.SetActive(false);
                }
                GameManager.instantCharacterCount = 1;
            }
            else
            {
                int number = 0;

                foreach (GameObject player in players)
                {

                    if (number != getNumber)
                    {
                        if (player.activeInHierarchy)
                        {

                            foreach (GameObject effect in destroy_effects)
                            {
                                if (!effect.activeInHierarchy)
                                {
                                    Vector3 newPosition = new Vector3(player.transform.position.x, 0.24f, player.transform.position.z);

                                    effect.SetActive(true);
                                    effect.transform.position = newPosition;
                                    effect.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }

                            player.transform.position = Vector3.zero;
                            player.SetActive(false);
                            number++;
                        }
                    }
                    else
                    {
                        number = 0;
                        break;
                    }
                }
                GameManager.instantCharacterCount -= getNumber;
            }
        }

        public static void Division(int getNumber, List<GameObject> players, List<GameObject> destroy_effects)
        {
            if (GameManager.instantCharacterCount <= getNumber)
            {

                foreach (GameObject player in players)
                {
                    player.transform.position = Vector3.zero;
                    player.SetActive(false);
                }
                GameManager.instantCharacterCount = 1;
            }
            else
            {
                int bolen = GameManager.instantCharacterCount / getNumber;
                int number = 0;

                foreach (GameObject player in players)
                {

                    foreach (GameObject effect in destroy_effects)
                    {
                        if (!effect.activeInHierarchy)
                        {
                            Vector3 newPosition = new Vector3(player.transform.position.x, 0.24f, player.transform.position.z);

                            effect.SetActive(true);
                            effect.transform.position = newPosition;
                            effect.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }


                    if (number != bolen)
                    {
                        if (player.activeInHierarchy)
                        {

                            foreach (GameObject effect in destroy_effects)
                            {
                                if (!effect.activeInHierarchy)
                                {
                                    Vector3 newPosition = new Vector3(player.transform.position.x, 0.24f, player.transform.position.z);

                                    effect.SetActive(true);
                                    effect.transform.position = newPosition;
                                    effect.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }

                            player.transform.position = Vector3.zero;
                            player.SetActive(false);
                            number++;
                        }
                    }
                    else
                    {
                        number = 0;
                        break;
                    }
                }

                if (GameManager.instantCharacterCount % getNumber == 0)
                {
                    GameManager.instantCharacterCount /= getNumber;
                }
                else if (GameManager.instantCharacterCount % getNumber == 1)
                {
                    GameManager.instantCharacterCount /= getNumber;
                    GameManager.instantCharacterCount++;
                }
                else if (GameManager.instantCharacterCount % getNumber == 2)
                {
                    GameManager.instantCharacterCount /= getNumber;
                    GameManager.instantCharacterCount += 2;
                }
            }
        }
    }
}

