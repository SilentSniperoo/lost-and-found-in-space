

public static class ScoreStatus
{
    static int score = 0;
    static bool timeout = false;

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public static bool Timeout
    {
        get
        {
            return timeout;
        }
        set
        {
            timeout = value;
        }
    }
}
