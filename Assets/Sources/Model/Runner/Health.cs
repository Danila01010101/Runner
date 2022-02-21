using System;

public class Health
{
    private int _health = 2;

    public int HealthPoints => _health;
    public bool IsAlive => HealthPoints > 0;
    public static Action Death;

    public void TakeDamage()
    {
        _health--;
        if (_health <= 0)
        {
            Death?.Invoke();
        }
    }

    public void Die()
    {
        _health = 0;
        Death?.Invoke();
    }
}