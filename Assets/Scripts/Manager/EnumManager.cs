using UnityEngine;

public class EnumManager : Singleton<EnumManager>
{
    public enum detection
    {
        front,
        back,
        left,
        right,
        up,
        down,
        center
    }
}
