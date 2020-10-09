using UnityEngine;
using FYFY;

public class VirusFactory : FSystem
{
    private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));
    private Board _board = FamilyManager.getFamily(new AllOfComponents(typeof(Board))).First().GetComponent<Board>();
    private Factory factory;

    public VirusFactory()
    {
        factory = factory_F.First().GetComponent<Factory>();
    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        factory.reloadProgress += Time.deltaTime;
        if (factory.reloadProgress >= factory.reloadTime)
        {
            CreateVirus();
            factory.reloadProgress = 0;
        }
    }

    public void popVirus(int amount)
    {
        for (int i = 0; i < amount; i++)
            CreateVirus();
    }

    private void CreateVirus()
    {
        GameObject go = Object.Instantiate<GameObject>(factory.virusPrefab);
        GameObjectManager.bind(go);
        go.transform.position = new Vector3(Random.Range(-_board.size.x / 2, _board.size.x / 2), Random.Range(-_board.size.y / 2, _board.size.y / 2), 0);
    }
}
