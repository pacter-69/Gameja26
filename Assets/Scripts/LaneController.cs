using UnityEngine;

public static class LaneController
{
    public static float[] laneValues = new float[] { 0f, 1.5f, 3f, 4.5f, 6f };

    static public bool CanMove(int indexToMove, int currentIndex) {
        return (currentIndex + indexToMove >= 0) && (currentIndex + indexToMove <= laneValues.Length - 1);
    }
}
