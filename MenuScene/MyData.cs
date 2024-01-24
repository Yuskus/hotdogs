using System;

[Serializable]
public class MyLevels
{
    private int continueGame;
    private int availableLevels;
    public MyLevels(int playNow, int playAvailable)
    {
        continueGame = playNow;
        availableLevels = playAvailable;
    }
}

    [Serializable]
public class MyRecords
{
    private int[] lvlRec;
    public MyRecords()
    {
        lvlRec = new int[50];
    }
}
