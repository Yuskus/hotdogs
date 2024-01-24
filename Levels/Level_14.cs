using UnityEngine;

public class Level_14 : MonoBehaviour //������ - 1 ������� - ��������� ����� 1
{
    private Game game;
    private readonly int levelNum = 13;
    private readonly string levelKey = "Rec_14";
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
    private void Update() //CHECK
    {
        game.TimerForLevel();
    }
    private void Go() => game.TheFirstFew(4, 3.1f, 3.8f,3, levelKey, levelNum); //CHECK
}
