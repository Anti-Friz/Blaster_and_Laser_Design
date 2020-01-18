using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaster_and_Laser_Design
{
    enum Beams
    {
        Laser = 0,
        Blaster = 1,
        NeutralParticleBeam = 2,
        RainbowLaser = 3,
        XRayLaser = 4,
        Pulsar = 5,
        Graser = 6,
        LowTechLaser = 7,
        Electrolaser = 8,
        SonicStunner = 9,
        HighOutputPulseLaser = 10,
        Plasma = 11,
        PlasmaFlamer = 12,
        PlasmaLance = 13,
        SonicScreamer = 14,
        SoundDisruptors = 15,
        GravitonBeam = 16,
        ForceBeam = 17,
        Disraptor = 18,
        NeuralDisraptor = 19,
        MindDisraptor = 20
    }
    enum TLs
    {
        TL8 = 0,        
        TL9 = 1,
        TL10 = 2,
        TL11 = 3,
        TL12 = 4,
        TL8S = 5,
        TL9S = 6,
        TL10S = 7,
        TL11S = 8,
        TL12S = 9
    }

    enum Focus
    {
        Tiny = 0,
        VerySmall = 1,
        Small = 2,
        Medium = 3,
        Large = 4,
        VeryLarge = 5,
        ExtremelyLarge = 6
    }

    enum Generators
    {
        SingleShot = 0,
        SemiAuto = 1,
        LightAuto = 2,
        HeavyAutomatic = 3,
        LightGatling = 4,
        HeavyGatling = 5,
        SlowGen3 = 6,
        SlowGen5 = 7,
        SlowGen10 = 8
    }
    enum Configrations
    {
        Beamer = 0,
        Pistol = 1,
        SMG = 2,
        Rifle = 3,
        Shotgun = 4,
        Staf = 5,
        HeavyWeapon = 6
    }
    enum Barells
    {
        Standart = 0,
        Light = 1,
        Heavy = 2
    }
    /// <summary>
    /// Divide by 100 for formulas
    /// </summary>
    enum PowerCells
    {
        A = 1,
        B = 10,
        C = 100,
        D = 1000,
        E = 10000,
        F = 100000
    }
}
