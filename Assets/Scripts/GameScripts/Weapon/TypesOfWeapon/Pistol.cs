using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public Pistol() : base(4, 5.0, 1.0, 7, 2.0) { }
}
public class Arbalest : Weapon
{
    public Arbalest() : base(10, 3.0, 3.0, 1, 0.0) { }
}
public class AssaultRifle: Weapon
{
    public AssaultRifle() : base(8, 6.0, 2.0, 20, 5.0) { }
}
public class SniperRifle: Weapon
{
    public SniperRifle() : base(20, 8.0, 5.0, 4, 1.0) { }
}
public class DarkFalcon: Weapon
{
    public DarkFalcon() : base(11, 6.0, 0.0, -1, 1.0) { }
}

