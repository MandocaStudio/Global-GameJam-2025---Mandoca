using UnityEngine;

public class tileDetector : MonoBehaviour
{

        public enum playerTileDetector
        {
                up,
                down,
                right,
                left,
                floor
        }



        [SerializeField] playerTileDetector detectorTileType;

        [SerializeField] gridMovement player;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
                player = transform.parent.parent.GetComponent<gridMovement>();
        }

        private void OnTriggerStay(Collider other)
        {

                TilePosition burble = other.GetComponent<TilePosition>();

                if (burble != null)
                {
                        switch (detectorTileType)
                        {
                                case playerTileDetector.up:
                                        player.setTileUp(burble);
                                        break;

                                case playerTileDetector.down:
                                        player.setTileDown(burble);

                                        break;

                                case playerTileDetector.left:
                                        player.setTileLeft(burble);

                                        break;

                                case playerTileDetector.right:
                                        player.setTileRight(burble);

                                        break;

                                case playerTileDetector.floor:
                                        player.setTileCurrent(burble);

                                        break;

                        }
                }

        }


        private void OnTriggerExit(Collider other)
        {

                TilePosition burble = other.GetComponent<TilePosition>();

                if (burble != null)
                {
                        switch (detectorTileType)
                        {
                                case playerTileDetector.up:
                                        player.setTileUp(null);
                                        break;

                                case playerTileDetector.down:
                                        player.setTileDown(null);

                                        break;

                                case playerTileDetector.left:
                                        player.setTileLeft(null);

                                        break;

                                case playerTileDetector.right:
                                        player.setTileRight(null);

                                        break;

                                case playerTileDetector.floor:
                                        player.setTileCurrent(null);

                                        break;

                        }
                }

        }
}
