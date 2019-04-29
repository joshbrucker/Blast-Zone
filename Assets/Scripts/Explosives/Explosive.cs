using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is an interface given to all explosives so that
 * ChainExplode() can be called regardless of the type of
 * explosive that is triggered by another.
 */

interface Explosive
{
    bool primed { get; set; }
    void Explode();
    void ChainExplode();
}
