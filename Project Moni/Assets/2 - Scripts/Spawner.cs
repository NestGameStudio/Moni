using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// Spawner de Mercadorias na Game Scene
    /// 
    /// A ideia desse script eh fazer as mercadorias spawnarem para dentro do carrinho.
    /// - Existe uma lista de objetos spawnaveis que será chamada por esse script e eles irão spawnar 
    /// em uma frequencia customizavel de tempo.
    /// - A posição inicial de cada objeto spawnado é randomizada, tanto sua direção inicial (direita ou esquerda),
    /// quanto a altura do item (dentro de um range definido).
    /// - Todos os itens irão realizar uma parábola para dentro do carrinho, a direção na qual o item é jogado 
    /// depende de qual lado o item foi spawnado, enquanto a curva da parábola depende da altura no qual o item foi colocado

    [Header("Spawn Itens")]

    // Game Object which will be the merc parent
    public GameObject MercParent;

    // Referencia a uma lista de Mercadoria que por sua vez está referenciando o Prefab do modelo
    public List<Mercadoria> Mercadorias = new List<Mercadoria>();

    [Header("Spawn Location")]

    public float MinY = 3;
    public float MaxY = 6;

    [Header("Spawn Time Configuration")]

    [Tooltip ("Primeiro intervalo de tempo entre a queda de um item e outro")]
    public float InitialSpawnFrequency = 5f;
    [Tooltip("Valor no qual ele multiplica a velocidade ao longo do tempo")]
    public float SpawnMultiplierOverTime = 1.5f;
    [Tooltip("menor intervalo possivel no qual o objeto pode fazer respawn")]
    public float MinLimitSpawnFrequency = 1f;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnerThread());
    }

    // Spawn the merchandise in the scene
    // -> SpawnerThread() - Após limite de tempo ele faz um spawn de um item
    // Se no futuro tiver que fazer algum randomizador, fazer isso aqui
    private void SpawnMerch() {

        Vector3 initialPosition = new Vector3(0, 6, 0);

        // choose between right or left
        if (Random.Range(0, 2) == 0)
            initialPosition.x = 5;  // Right
        else
            initialPosition.x = -5; // Left

        // choose a variable height to spawn
        initialPosition.y = Random.Range(MinY, MaxY);

        GameObject randomMerch = Mercadorias[Random.Range(0, Mercadorias.Count -1)].MercadoriaPrefab;

        GameObject merc;

        // Check if there's any parent for the merc
        if (MercParent)
            merc = Instantiate(randomMerch, initialPosition, randomMerch.transform.rotation, MercParent.transform);
        else
            merc = Instantiate(randomMerch, initialPosition, randomMerch.transform.rotation, randomMerch.transform);

        ThrowMercInCart(merc);

    }

    // Responsible for the function that throws the merc in the cart
    private void ThrowMercInCart(GameObject merc) {

        // parabola que age em funcao da alturar do objeto e da direção jogada
        // a*x^2 + b*x + c -> https://vilbeyli.github.io/Projectile-Motion-Tutorial-for-Arrows-and-Missiles-in-Unity3D/

        // fancy implementation of the projetile motion /\

        // sloppy implementation of the projetile motion \/

        if (merc.transform.position.x == 5)     // Spawned on the Right
            merc.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 300);
        else if (merc.transform.position.x == -5)     // Spawned on the Left
            merc.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 300);

    }

    // It's not a thread (yet)
    IEnumerator SpawnerThread() {

        while (true) {

            float SpawnTime = InitialSpawnFrequency - SpawnMultiplierOverTime * Time.deltaTime;
            if (SpawnTime < MinLimitSpawnFrequency) {
                SpawnTime = MinLimitSpawnFrequency; 
            }

            yield return new WaitForSeconds(SpawnTime);

            SpawnMerch();
        }
    }

}
