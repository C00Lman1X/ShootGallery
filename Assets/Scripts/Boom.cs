using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{

    // Синглтон
    public static Boom Instance;

    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;
    public ParticleSystem fire;
    public ParticleSystem exp;


    public float explosionRadius = 10;// радиус поражения
    public float power = 300;// сила взрыва	

    private Rigidbody[] physicObject;// тут будут все физ. объекты которые есть на сцене

    public AudioClip boom; //переменная для работы со звуком dphsdf

    void Awake()
    {
        // регистрация синглтона
        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров Boom");
        }

        Instance = this;
    }

    // Создать взрыв в данной точке
    public void Explosion(Vector3 position)
    {
        instantiate(smokeEffect, position);
        instantiate(fireEffect, position);
        instantiate(fire, position);
        instantiate(exp, position);

        GetComponent<AudioSource>().PlayOneShot(boom); //проигрываем звук взрыва

        physicObject = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];// Записываем все физ. объекты
        for (int i = 0; i < physicObject.Length; i++)
        {
            if (Vector3.Distance(transform.position, physicObject[i].transform.position) <= explosionRadius)
            {// Исключаем от обработки объекты которые достаточно далеко от взвыва
                physicObject[i].AddExplosionForce(power, transform.position, explosionRadius);// Создание взрыва, с силой power, в позиции transform.position, c радиусом explosionRadius
            }
        }
    }

    // Создание экземпляра системы частиц из префаба
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
        // Убеждаемся, что это будет уничтожено
        Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);

        return newParticleSystem;
    }
}
