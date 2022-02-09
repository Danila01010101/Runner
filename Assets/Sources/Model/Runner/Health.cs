using System;

public class Health
{
    public int HealthPoints { get; private set; } = 2;
    public bool IsAlive => HealthPoints > 0;

    public static Action Death;
    public Action DamageTaken;

    public void TakeDamage()
    {
        HealthPoints--;
        if (HealthPoints <= 0)
        {
            if (Death != null)
                Death();
        }
        if (DamageTaken != null)
            DamageTaken();
    }

    public void CollideWithObject()
    {
        Death();
    }
}