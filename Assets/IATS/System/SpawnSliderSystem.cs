using UnityEngine;
using FYFY;
using UnityEngine.UI;

public class SpawnSliderSystem : FSystem
{
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.

    Family _sliderFamily = FamilyManager.getFamily(new AllOfComponents(typeof(SpawnSlider)));
    private Nest _nest = FamilyManager.getFamily(new AllOfComponents(typeof(Nest))).First().GetComponent<Nest>();

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount)
    {
        _nest.timer += Time.deltaTime;
        if (_nest.timer >= _nest.spawnRate)
        {
            int rand = Random.Range(0, 100);
            int total = 0;
            for (int i = 0; i < _sliderFamily.Count; i++)
            {
                SpawnSlider spawnSlider = _sliderFamily.getAt(i).GetComponent<SpawnSlider>();
                total += (int)spawnSlider.slider.value;
                if (rand <= total)
                {
                    Spawn(spawnSlider.type);
                    break;
                }

            }
            _nest.timer = 0;
        }
    }

    private void Spawn(EUnitType unitType)
    {
        GameObject go = null;
        switch (unitType)
        {
            case EUnitType.Worker:
                go = _nest.workerPrefab;
                break;
            case EUnitType.Guard:
                go = _nest.guardPrefab;
                break;
            case EUnitType.Explorator:
                go = _nest.exploratorPrefab;
                break;
            default:
                break;
        }
        GameObject.Instantiate(go, _nest.transform.position, Quaternion.identity);
    }

    public void UpdateSlider(SpawnSlider spawnSlider)
    {
        float total = 0;
        foreach (GameObject sliderGo in _sliderFamily)
        {
            SpawnSlider spawnS = sliderGo.GetComponent<SpawnSlider>();
            total += spawnS.slider.value;
        }
        if (total >= 100)
        {
            spawnSlider.slider.value = spawnSlider.slider.value - total + 100;
        }
        spawnSlider.label.text = spawnSlider.slider.value.ToString();
    }
}