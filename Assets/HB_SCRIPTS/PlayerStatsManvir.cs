using UnityEngine;
using UnityEngine.SceneManagement;
using static GoalLevels;

public class PlayerStatsManvir : MonoBehaviour
{
    public string nextLevel = "";
    public int counter = 0;
    public int health = 100;
    public int maxHealth = 100;
    public Transform RespawnPoint;
    private PlayerUIController playerUIControl;
    string thisLevel = SceneManager.GetActiveScene().name;

    // Start is called before the first frame update
    void Start()
    {
        playerUIControl = GetComponent<PlayerUIController>();
        playerUIControl.UpdateHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        switch (thisLevel)
        {
            case "Level_1Mer":
                {
                    nextLevel = "Level_2Mer";
                    break;
                }

            case "Level_1Seb":
                {
                    nextLevel = "Level_2Seb";
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Death":
                {
                    //Debug.Log("Player Has Died");
                    //string thisLevel = SceneManager.GetActiveScene().name;
                    //
                    health -= 10;
   
                    playerUIControl.UpdateHealth(health, maxHealth);
                    if (health <= 0)
                    {
   
                        //SceneManager.LoadScene(thisLevel);
                    }
                    else
                    {
    
                        SceneManager.LoadScene(thisLevel);
                    }
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Coin":
                {
                    counter++;
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if (health < 3)
                    {
                        health++;
 
                        playerUIControl.UpdateHealth(health, maxHealth);
                        Destroy(collision.gameObject);
                    }
                    break;
                }
        }
    }
}