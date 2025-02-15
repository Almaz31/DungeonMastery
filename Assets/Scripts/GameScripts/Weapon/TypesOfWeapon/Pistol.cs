using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public Pistol() : base(4, 5, 1, 7, 2) { }
}
public class Arbalest : Weapon
{
    public Arbalest() : base(10, 3, 3, 1, 0) { }
}
public class AssaultRifle: Weapon
{
    public AssaultRifle() : base(8, 6, 2, 20, 5) { }
}
public class SniperRifle: Weapon
{
    public SniperRifle() : base(20, 8, 5, 4, 1) { }
}
public class DarkFalcon: Weapon
{
    public DarkFalcon() : base(11, 6, 0, -1, 1) { }
}

