using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int _currentHealth;

    public HealthGetter healthGetter;
    public SceneLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
        healthGetter.ChangeHealth(_currentHealth.ToString());
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthGetter.ChangeHealth(_currentHealth.ToString());

        if (_currentHealth <= 0 )
        {
            SceneManager.LoadScene(3);
        }
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public void Die()
    {
        Debug.Log("My final message, change da world, goodbye");
    }
}
