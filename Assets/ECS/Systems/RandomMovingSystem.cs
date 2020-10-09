using UnityEngine;
using FYFY;

    public class RandomMovingSystem : FSystem
    {
        private Family _randomMovingGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move), typeof(RandomMove)));

        private Board _board = FamilyManager.getFamily(new AllOfComponents(typeof(Board))).First().GetComponent<Board>();

        public RandomMovingSystem()
        {
            foreach (GameObject go in _randomMovingGO)
                onGoEnter(go);

            _randomMovingGO.addEntryCallback(onGoEnter);
        }

        private void onGoEnter(GameObject go)
        {
            go.GetComponent<RandomMove>().target = go.transform.position;
        }

        // Use to process your families.
        protected override void onProcess(int familiesUpdateCount)
        {
            foreach (GameObject go in _randomMovingGO)
            {
                RandomMove rm = go.GetComponent<RandomMove>();

                if (rm.target.Equals(go.transform.position))
                {
                    rm.target = new Vector3(Random.Range(-_board.size.x / 2, _board.size.x / 2), Random.Range(-_board.size.y / 2, _board.size.y / 2), 0);
                }
                else
                    go.transform.position = Vector3.MoveTowards(go.transform.position, rm.target, go.GetComponent<Move>().speed * Time.deltaTime);
            }
        }
}
