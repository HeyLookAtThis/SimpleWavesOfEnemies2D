using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected List<Weapon> _weapons;

    protected UnityAction onTakenDamage;
    protected UnityAction onDied;
    protected UnityAction onAttacked;

    private Coroutine _destroyer;

    public event UnityAction TakenDamage
    {
        add => onTakenDamage += value;
        remove => onTakenDamage -= value;
    }

    public event UnityAction Died
    {
        add => onDied += value;
        remove => onDied -= value;
    }

    public event UnityAction Attacked
    {
        add => onAttacked += value;
        remove => onAttacked -= value;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        onTakenDamage.Invoke();

        if (health <= 0)
        {
            onDied.Invoke();
            BeginDestroy();
        }
    }

    protected void BeginDestroy()
    {
        if (_destroyer != null)
            StopCoroutine(_destroyer);

        _destroyer = StartCoroutine(Destroyer());
    }

    private IEnumerator Destroyer()
    {
        float second = 1.0f;
        var waitTime = new WaitForSeconds(second);
        bool isSkeppedTime = false;

        while (isSkeppedTime == false)
        {
            isSkeppedTime = true;
            yield return waitTime;
        }

        if (isSkeppedTime)
        {
            Destroy(gameObject);
            yield break;
        }
    }
}
