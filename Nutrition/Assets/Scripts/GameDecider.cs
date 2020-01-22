using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDecider {

    private static bool macro = false;

    public static bool Macro
    {
        get
        {
            return macro;
        }
        set
        {
            macro = value;
        }
    }
}
