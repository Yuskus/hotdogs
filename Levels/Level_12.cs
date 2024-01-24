using UnityEngine;

public class Level_12 : MonoBehaviour //COLA  //����� ������
{
    private Game game;
    private readonly int levelNum = 11;
    private readonly string levelKey = "Rec_12";
    private void Awake()
    {
        game = Camera.main.GetComponent<Game>();
        game.AwakeAnyLevel();
    }
    private void Start()
    {
        game.StartAnyLevel();
        game.TabloOn();
        Invoke(nameof(Go), 5f); //CHECK
    }
    private void Update()
    {
        game.TimerForLevel();
    }
    public void Go() => game.TheFirstFew(4, 3.2f, 3.8f, 3, levelKey, levelNum);
}
