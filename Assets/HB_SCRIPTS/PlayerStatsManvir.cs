using UnityEngine;
using UnityEngine.SceneManagement;
using static GoalLevels;

public class PlayerStatsManvir : MonoBehaviour
{
    public string nextLevel0 = "";
    public int counter0 = 0;
    public int health0 = 100;
    public int maxHealth0 = 100;
    public Transform RespawnPoint;
    private PlayerUIController playerUIControl0;
    string thisLevel0 = SceneManager.GetActiveScene().name;

    // Start is called before the first frame update
    void Start()
    {
        playerUIControl0 = GetComponent<PlayerUIController>();
        playerUIControl0.UpdateHealth(health0, maxHealth0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (thisLevel0)
        {
            case "Level_1Seb":
                {
                    nextLevel0 = "(1)MerCutScene";
                    break;
                }

            case "Level_1Mer":
                {
                    nextLevel0 = "(2)SebCutScene";
                    break;
                }
            case "Level_2Seb":
                {
                    nextLevel0 = "(2)MerCutScene";
                    break;
                }

            case "Level_2Mer":
                {
                    nextLevel0 = "(3)SebCutScene";
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
                    health0 -= 10;
   
                    playerUIControl0.UpdateHealth(health0, maxHealth0);
                    if (health0 <= 0)
                    {
   
                        SceneManager.UnloadSceneAsync(thisLevel0); // exists scene on death
                    }
                    else
                    {
                        SceneManager.LoadScene(thisLevel0); // starts from beginning of level 
                    }
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel0);
                    break;
                }
            case "Coin":
                {
                    counter0++;
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if (health0 < 100)
                    {
                        health0+=10;
 
                        playerUIControl0.UpdateHealth(health0, maxHealth0);
                        Destroy(collision.gameObject);
                    }
                    break;
                }
        }
    }
}