using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public UnityEvent onDeath = new UnityEvent();
    public UnityEvent<int> onDamageTaken = new UnityEvent<int>();
    
    public UnityEvent<int> onHeal = new UnityEvent<int>();

    private void Start()
    {
        HealToMax();
    }

    private void OnDestroy()
    {
        onDeath.RemoveAllListeners();
        onDamageTaken.RemoveAllListeners();
        onHeal.RemoveAllListeners();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        onDamageTaken.Invoke(damage);
        if (currentHP <= 0)
        {
            currentHP = 0;
            onDeath.Invoke();
        }
    }

    public void HealToMax()
    {
        currentHP = maxHP;
    }

    public void Heal(int heal)
    {
        int oldHP = currentHP;
        currentHP = Mathf.Min(maxHP, currentHP + heal);
        onHeal.Invoke(currentHP - oldHP);
        
    }
}