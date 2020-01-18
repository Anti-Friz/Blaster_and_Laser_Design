using System;
using System.Collections.Generic;
using System.Linq;

namespace BLDesign
{
    class Desinger
    {
        public double GetEmptyWeight(double d, TLs tl, Beams beam, Focus focus, Generators generator, Barells barell = 0, bool oldWeap = false)
        {
            double s, e = 0, f = 0, g = 0, b = 1, oldMod = 1;
            if (oldWeap)
            {
                oldMod = 2;
            }
            #region IfForSForSuperS

            if ((int)beam < 11 && (int)tl >= 5)
            {
                s = 0.5;
            }
            else
            {
                s = 1;
            }

            #endregion IfForSForSuperS

            #region SwitchForEFromBeam

            switch (beam)
            {
                case Beams.Pulsar:
                case Beams.Plasma:
                case Beams.PlasmaLance:
                    e = 6;
                    break;

                case Beams.ForceBeam:
                    e = 4;
                    break;

                case Beams.GravitonBeam:
                    e = 1.5;
                    break;

                case Beams.Electrolaser:
                    e = 3.1;
                    break;

                case Beams.HighOutputPulseLaser:
                    e = 5;
                    break;

                case Beams.SonicStunner:
                case Beams.SonicScreamer:
                case Beams.SoundDisruptors:
                case Beams.NeuralDisraptor:
                case Beams.MindDisraptor:
                    e = 2.75;
                    break;

                case Beams.Disraptor:
                    e = 32;
                    break;

                default:
                    e = 3;
                    break;
            }

            #endregion SwitchForEFromBeam

            #region SwithForFFromFocus

            switch (focus)
            {
                case Focus.Tiny:
                    f = 0.25;
                    break;

                case Focus.VerySmall:
                    f = 0.5;
                    break;

                case Focus.Small:
                    f = 0.8;
                    break;

                case Focus.Medium:
                    f = 1;
                    break;

                case Focus.Large:
                    f = 1.25;
                    break;

                case Focus.VeryLarge:
                    f = 1.6;
                    break;

                case Focus.ExtremelyLarge:
                    f = 2;
                    break;
            }

            #endregion SwithForFFromFocus

            #region SwithForGFromGen

            switch (generator)
            {
                case Generators.SingleShot:
                    g = 1;
                    break;

                case Generators.SemiAuto:
                case Generators.LightAuto:
                    g = 1.25;
                    break;

                case Generators.SlowGen3:
                    g = 0.7;
                    break;

                case Generators.SlowGen5:
                    g = 0.6;
                    break;

                case Generators.SlowGen10:
                    g = 0.5;
                    break;

                default:
                    g = 2;
                    break;
            }
            if (beam == Beams.Plasma)
            {
                if (generator == Generators.LightAuto)
                {
                    g = 1.5;
                }
                else if (generator == Generators.LightGatling || generator == Generators.HeavyGatling)
                {
                    g = 4;
                }
            }

            #endregion SwithForGFromGen

            #region IfForBfromBarrel

            if (barell == Barells.Light)
            {
                b = 0.75;
            }
            else if (barell == Barells.Heavy)
            {
                b = 1.5;
            }

            #endregion IfForBfromBarrel

            if (beam == Beams.LowTechLaser)
            {
                return Math.Round((Math.Pow(d * s * 3.7, 3) * f) * oldMod, 2);
            }

            return Math.Round((Math.Pow(((d * s) / e), 3) * f * g * b) * oldMod, 2);
        }

        public int GetAcc(Configrations configration, Beams beam)
        {
            double ca = 0, ab = 0;
            switch (configration)
            {
                case Configrations.Beamer:
                    ca = 0.5;
                    break;

                case Configrations.Staf:
                    ca = 0.75;
                    break;

                case Configrations.Pistol:
                    ca = 1;
                    break;

                case Configrations.SMG:
                    ca = 1.5;
                    break;

                case Configrations.Rifle:
                    ca = 2;
                    break;

                case Configrations.HeavyWeapon:
                    ca = 3;
                    break;
            }
            switch (beam)
            {
                case Beams.SonicStunner:
                    ab = 3;
                    break;

                case Beams.SonicScreamer:
                    ab = 3;
                    break;

                case Beams.Electrolaser:
                    ab = 4;
                    break;

                case Beams.Plasma:
                    ab = 4;
                    break;

                case Beams.PlasmaFlamer: //custom round down
                    ab = 3;
                    break;

                case Beams.SoundDisruptors: //custom round down
                    ab = 3;
                    break;

                case Beams.PlasmaLance: //custom
                    ab = 2.5;
                    break;

                default:
                    ab = 6;
                    break;
            }

            return (int)Math.Round(ca * ab);
        }

        public int GetRange(double d, Beams beam, Focus focus, out int halfRange)
        {
            double rb = 0, rf = 0;
            int maxRange;
            switch (beam)
            {
                case Beams.Laser:
                    rb = 8;
                    break;

                case Beams.Blaster:
                case Beams.NeutralParticleBeam:
                    rb = 32;
                    break;

                case Beams.RainbowLaser:
                    rb = 56;
                    break;

                case Beams.XRayLaser:
                    rb = 2000;
                    break;

                case Beams.Pulsar:
                    rb = 8;
                    break;

                case Beams.Graser:
                    rb = 6000;
                    break;

                case Beams.Electrolaser:
                    rb = 10;
                    break;

                case Beams.SonicStunner:
                    rb = 3.5;
                    break;

                case Beams.HighOutputPulseLaser:
                    rb = 0.4;
                    break;

                case Beams.PlasmaFlamer:
                    rb = 2;
                    break;

                case Beams.SonicScreamer:
                case Beams.SoundDisruptors:
                    rb = 2;
                    break;

                case Beams.GravitonBeam:
                    rb = 100;
                    break;

                case Beams.ForceBeam:
                    rb = 10;
                    break;

                case Beams.Disraptor:
                    rb = 0.7;
                    break;

                case Beams.NeuralDisraptor:
                case Beams.MindDisraptor:
                    rb = 2.5;
                    break;
            }
            switch (focus)
            {
                case Focus.Tiny:
                    rb = 0.1;
                    break;

                case Focus.VerySmall:
                    rb = 0.3;
                    break;

                case Focus.Small:
                    rb = 0.5;
                    break;

                case Focus.Medium:
                    rb = 1;
                    break;

                case Focus.Large:
                    rb = 2;
                    break;

                case Focus.VeryLarge:
                    rb = 4;
                    break;

                case Focus.ExtremelyLarge:
                    rb = 8;
                    break;
            }
            switch (beam)
            {
                case Beams.LowTechLaser:
                    halfRange = (int)Math.Round(Math.Pow(d, 2) * 120 * rf);
                    maxRange = halfRange * 3;
                    break;

                case Beams.Plasma:
                    halfRange = (int)Math.Round(d * 50 * rf, -2);
                    maxRange = halfRange * 3;
                    break;

                case Beams.PlasmaLance:
                    halfRange = (int)Math.Round(2 * Math.Sqrt(d), -2);
                    maxRange = halfRange * 10;
                    break;

                default:
                    halfRange = (int)Math.Round(Math.Pow(d, 2) * rb * rf);
                    maxRange = halfRange * 3;
                    break;
            }
            return maxRange;
        }

        public IEnumerable<int> GetROF(Generators generator, out string specials)
        {
            specials = "";
            switch (generator) //todo при получении скорострельности сделать стринг-трим с разделителем "-", эти циф
            {
                case Generators.SingleShot:
                    return Enumerable.Range(1, 1);

                case Generators.SemiAuto:
                    return Enumerable.Range(1, 4);

                case Generators.LightAuto:
                    return Enumerable.Range(4, 11);

                case Generators.HeavyAutomatic:
                    return Enumerable.Range(11, 21);

                case Generators.LightGatling:
                    specials = "Это оружие не может стрелять хот-шотами (UT133), но не перегревается";
                    return Enumerable.Range(4, 11);

                case Generators.HeavyGatling:
                    specials = "Это оружие не может стрелять хот-шотами (UT133), но не перегревается";
                    return Enumerable.Range(11, 21);

                case Generators.SlowGen3:
                    specials = "После каждого выстрела оружие автоматически заряжается 3 секунды";
                    return Enumerable.Range(1, 1);

                case Generators.SlowGen5:
                    specials = "После каждого выстрела оружие автоматически заряжается 5 секунд";
                    return Enumerable.Range(1, 1);

                case Generators.SlowGen10:
                    specials = "После каждого выстрела оружие автоматически заряжается 10 секунд";
                    return Enumerable.Range(1, 1);

                default:
                    return null;
            }
        }

        public int GetShots(double d, TLs tl, Beams beam, PowerCells powerCell, int cellCount, out string specials, TLs cellTL = 0)
        {
            int shots = 0;
            cellTL = tl;
            specials = "";
            switch (beam)
            {
                case Beams.Laser:
                    ShotsByTL(tl, 255, 450, 450, 450);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.Blaster:
                    ShotsByTL(tl, 34, 68, 68, 68);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.NeutralParticleBeam:
                    ShotsByTL(tl, 16, 67, 67, 67);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.RainbowLaser:
                    ShotsByTL(cellTL, 112);
                    break;

                case Beams.XRayLaser:
                    ShotsByTL(tl, 112, 112, 225, 225);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.Pulsar:
                    ShotsByTL(tl, 135, 135, 135, 270);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.Graser:
                    ShotsByTL(cellTL, 28);
                    break;

                case Beams.LowTechLaser:
                    if (tl == TLs.TL8)
                    {
                        shots = 45;
                    }
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.Electrolaser:
                    ShotsByTL(tl, 2304, 5760, 5670, 5670);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.SonicStunner:
                    ShotsByTL(cellTL, 445);
                    break;

                case Beams.HighOutputPulseLaser:
                    ShotsByTL(tl, 2083, 2083, 5670, 5670);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.Plasma:
                    ShotsByTL(tl, 844, 2110, 2110, 2110);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.PlasmaFlamer:
                    ShotsByTL(tl, 450, 1125, 1125, 1125);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.PlasmaLance:
                    ShotsByTL(tl, 29, 29, 72, 72);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.SonicScreamer:
                case Beams.SoundDisruptors:
                    ShotsByTL(cellTL, 1780);
                    break;

                case Beams.GravitonBeam:
                    ShotsByTL(tl, 14, 14, 14, 28);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.ForceBeam:
                    ShotsByTL(tl, 270, 270, 540, 540);
                    ShotsByTL(cellTL, shots);
                    break;

                case Beams.Disraptor:
                    ShotsByTL(cellTL, 6250);
                    break;

                case Beams.NeuralDisraptor:
                case Beams.MindDisraptor:
                    ShotsByTL(cellTL, 111);
                    break;
            }
            return (int)(shots * cellCount / Math.Pow(d, 3));
        }

        public int GetTimeToReload(PowerCells powerCell, int cellCount)
        {
            switch (powerCell)
            {
                case PowerCells.A:
                case PowerCells.B:
                case PowerCells.C:
                    return 3 * cellCount;

                case PowerCells.D:
                case PowerCells.E:
                case PowerCells.F:
                    return 5 * cellCount;
            }
            return 0;
        }

        public double GetFullWeight(double emptyWeight, PowerCells powerCell, int cellCount, out string specials, bool powerPack)
        {
            double tempMod = 0;
            string tempPP;

            switch (powerCell)
            {
                case PowerCells.A:
                    tempMod = 0.0005;
                    break;

                case PowerCells.B:
                    tempMod = 0.005;
                    break;

                case PowerCells.C:
                    tempMod = 0.5;
                    break;

                case PowerCells.D:
                    tempMod = 5;
                    break;

                case PowerCells.E:
                    tempMod = 20;
                    break;

                case PowerCells.F:
                    tempMod = 200;
                    break;
            }
            if (powerPack)
            {
                tempPP = "p";
                tempMod = 1;
                cellCount = 1;
            }
            else
            {
                tempPP = "";
            }
            specials = $"{cellCount}{powerCell}{tempPP}";
            return emptyWeight * (tempMod * cellCount);
        }

        public string GetReqST(Configrations configration, double fullWeight)
        {
            string st = "";
            switch (configration)
            {
                case Configrations.Beamer:
                case Configrations.Pistol:
                    st = Math.Round((Math.Sqrt(fullWeight) * 3.3), 1).ToString();
                    break;

                case Configrations.Rifle:
                case Configrations.SMG:
                    st = Math.Round((Math.Sqrt(fullWeight) * 2.4), 1).ToString();
                    st += "t"; //поставить меч
                    break;

                case Configrations.Shotgun:
                case Configrations.Staf:
                case Configrations.HeavyWeapon:
                    st = Math.Round((Math.Sqrt(fullWeight) * 2.2), 1).ToString();
                    st += "M";
                    break;
            }
            return st;
        }

        public int GetBulk(double fullWeight, Configrations configration)
        {
            double sb = 0;
            switch (configration)
            {
                case Configrations.Beamer:
                    sb = 1;
                    break;

                case Configrations.Pistol:
                    sb = 1.25;
                    break;

                case Configrations.SMG:
                case Configrations.Rifle:
                case Configrations.Shotgun:
                case Configrations.Staf:
                case Configrations.HeavyWeapon:
                    sb = 1.5;
                    break;
            }
            return -(int)Math.Round(fullWeight * sb, 0);
        }

        public int GetRecoil(Beams beam)
        {
            switch (beam)
            {
                case Beams.Plasma:
                    return 2;

                case Beams.PlasmaLance:
                    return 2;

                default:
                    return 1;
            }
        }

        public int GetCost(double emptyWeight, Beams beam, Generators generator, double d = 0, bool oldWeap = false)
        {
            int bc = 0, gc = 0, oldMod = 1;
            if (oldWeap)
            {
                oldMod = 2;
            }
            switch (beam)
            {
                case Beams.Laser:
                    bc = 500;
                    break;
                case Beams.Blaster:
                    bc = 2000;
                    break;
                case Beams.NeutralParticleBeam:
                    bc = 3000;
                    break;
                case Beams.RainbowLaser:
                    bc = 500;
                    break;
                case Beams.XRayLaser:
                    bc = 1000;
                    break;
                case Beams.Pulsar:
                    break;
                case Beams.Graser:
                    bc = 1500;
                    break;
                case Beams.LowTechLaser:
                    bc = 500;
                    break; ;
                case Beams.Electrolaser:
                    bc = 1000;
                    break;
                case Beams.SonicStunner:
                case Beams.HighOutputPulseLaser:
                    bc = 500;
                    break;
                case Beams.Plasma:
                    bc = 2000;
                    break;
                case Beams.PlasmaFlamer:
                    return (int)Math.Round(Math.Pow(d, 3 * 18.4),0)/oldMod;
                case Beams.PlasmaLance:
                    bc = 2000;
                    break;
                case Beams.SonicScreamer:
                case Beams.SoundDisruptors:
                    bc = 1000;
                    break;
                case Beams.GravitonBeam:
                    bc = 2000;
                    break;
                case Beams.ForceBeam:
                    bc = 500;
                    break;
                case Beams.Disraptor:
                    bc = 500;
                    break;
                case Beams.NeuralDisraptor:
                    bc = 2000;
                    break;
                case Beams.MindDisraptor:
                    bc = 5000;
                    break;
            }
            switch (generator)
            {
                case Generators.SingleShot:
                case Generators.SemiAuto:
                    gc = 1;
                    break;
                case Generators.LightAuto:
                case Generators.HeavyAutomatic:
                case Generators.LightGatling:
                case Generators.HeavyGatling:
                    gc = 2;
                    break;
                case Generators.SlowGen3:
                case Generators.SlowGen5:
                case Generators.SlowGen10:
                    gc = 1;
                    break;
            }
            return (int)Math.Round(emptyWeight * bc * gc) / oldMod;
        }

        public int GetLC(Beams beam, double fullWeight)
        {
            int basecl = 0;
            switch (beam)
            {
                case Beams.Laser:
                case Beams.Blaster:
                case Beams.NeutralParticleBeam:
                case Beams.RainbowLaser:
                case Beams.XRayLaser:
                    basecl = 3;
                    break;
                case Beams.Pulsar:
                    basecl = 2;
                    break;
                case Beams.Graser:
                    basecl = 3;
                    break;
                case Beams.LowTechLaser:
                case Beams.Electrolaser:
                case Beams.SonicStunner:
                case Beams.HighOutputPulseLaser:
                    basecl = 3;
                    break;
                case Beams.Plasma:
                case Beams.PlasmaFlamer:
                case Beams.PlasmaLance:
                case Beams.SonicScreamer:
                case Beams.SoundDisruptors:
                    basecl = 2;
                    break;
                case Beams.GravitonBeam:
                    basecl = 3;
                    break;
                case Beams.ForceBeam:
                    basecl = 4;
                    break;
                case Beams.Disraptor:
                case Beams.NeuralDisraptor:
                case Beams.MindDisraptor:
                    basecl = 2;
                    break;
            }
            if (fullWeight > 5)
            {
                basecl--;
            }
            if (fullWeight > 15)
            {
                if (basecl != 1)
                {
                    basecl--;
                }
            }
            return basecl;
        }

        public string GetFormatedDamage(double d, Beams beam)
        {

            return "";
        }

        private string RoundDamage(double d)
        {
            if (d < 1)
            {
                if (d > 0 && d <= 0.032)
                {
                    return "1d-5";
                }
                else if (d >= 0.33 && d <= 0.42)
                {
                    return "1d-4";
                }
                else if (d >= 0.43 && d <= 0.56)
                {
                    return "1d-3";
                }
                else if (d >= 0.57 && d <= 0.75)
                {
                    return "1d-2";
                }
                else if (d >= 0.76 && d <= 0.95)
                {
                    return "1d-1";
                }
                else if (d > 0.95)
                {
                    return "1d";
                }
            }
            else if (d >= 1 && d <= 12)
            {
                double dT = d - Math.Truncate(d);
                if (dT < 0.14)
                {
                    return $"{Math.Truncate(d)}d";
                }
                else if (dT >= 0.15 && dT <= 0.42)
                {
                    return $"{Math.Truncate(d)}d+1";
                }
                else if (dT >= 0.43 && dT <= 0.64)
                {
                    return $"{Math.Truncate(d) + 1}d-2";
                }
                else if (dT >= 0.65 && dT <= 0.85)
                {
                    return $"{Math.Truncate(d) + 1}d-1";
                }
                else if (dT >= 0.85)
                {
                    return $"{Math.Round(d, 0, MidpointRounding.ToEven)}d";
                }
            }
            return $"6d*{Math.Round(d) / 6}";
        }

        private int ShotsByTL(TLs cellTL, int shotsBase)
        {
            switch (cellTL)
            {
                case TLs.TL9:
                    return shotsBase;

                case TLs.TL10:
                    return shotsBase * 4;

                case TLs.TL11:
                    return shotsBase * 4 * 4;

                case TLs.TL12:
                    return shotsBase * 4 * 4 * 4;

                default:
                    return shotsBase;
            }
        }

        private int ShotsByTL(TLs tl, int shotsTL9, int shotsTL10, int shotsTL11, int shotsTL12)
        {
            switch (tl)
            {
                case TLs.TL9:
                    return shotsTL9;

                case TLs.TL10:
                    return shotsTL10;

                case TLs.TL11:
                    return shotsTL11;

                case TLs.TL12:
                    return shotsTL12;

                default:
                    return shotsTL9;
            }
        }
    }
}