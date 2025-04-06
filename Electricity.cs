using System;
using System.Collections.Generic;
using System.Linq;

namespace CegepSciences
{
    class Electricity
    {
        // constants

        public const float g = 9.81f;
        public const float e = 1.6e-19f;
        public const float MassProton = 1.67e-27f;
        public const float MassNeutron = 1.67e-27f;
        public const float MassElectron = 9.11e-31f;

        public const float k = 9e9f;
        public const float Epsilon0 = 8.85e-12f; // ε0
        public const float Avogadro = 6.022e23f;

        // units

        public const string ug = "m/s^2";
        public const string ue = "C";
        public const string uMass = "kg";

        public const string uk = "Nm^2/C^2";
        public const string uEpsilon0 = "C^2/Nm^2";
        public const string uAvogadro = "atoms";


        #region Electric force
        float ElectricforceA(float charge, float charge2, float radius)
        {
            return k * Math.Abs(charge * charge2) / (float)Math.Pow(radius, 2);
        }

        Vector2 ElectricForceB(float charge, Vector2 electricField)
        {
            return charge * electricField;
        }

        float ElectricField(float charge, float radius)
        {
            return k * Math.Abs(charge) / (float)Math.Pow(radius, 2);
        }
        #endregion Electric force

        #region Charge density

        float LinearDensity(float charge, float length)
        {
            return charge / length;
        }

        float SurfaceDensity(float charge, float area)
        {
            return charge / area;
        }

        float VolumeDensity(float charge, float area)
        {
            return charge / area;
        }
        #endregion Charge density

        #region Infinite

        float ElectricFieldInfiniteWire(float linearDensity, float r)
        {
            return 2 * k * Math.Abs(linearDensity) / r;
        }

        float ElectricalFieldInfinitePlate(float surfaceDensity)
        {
            return surfaceDensity / 2 / Epsilon0;
        }
        #endregion Infinite

        #region Potential energy & Potential

        float PotentialEnergy(float charge, float potentialDifference)
        {
            return charge * potentialDifference;
        }

        float PotentialDifferenceByElectricField(float electricField, float distance)
        {
            return electricField * distance;
        }
        #endregion Potential energy & Potential

        #region Current & Resistance

        float IntensityPerSecond(float chargeDifference, float timeDifference)
        {
            return chargeDifference / timeDifference;
        }

        float IntensityBySpeed(float volumeDensity, float area, float driftSpeed)
        {
            return volumeDensity * area * e * driftSpeed;
        }

        float IntensityByOhm(float potentialDifference, float resistance)
        {
            return potentialDifference / resistance;
        }
        float ResistanceByOhm(float potentialDifference, float intensity)
        {
            return potentialDifference / intensity;
        }

        float ResistanceByWireArea(float materialResistivity, float length, float area)
        {
            return materialResistivity * length / area;
        }

        float MaterialResistivity(float initialMaterialResistivity, float thermalResistivity, float timeDifference)
        {
            return initialMaterialResistivity * (1 + thermalResistivity * timeDifference);
        }
        float PotentialDifferenceByOhm(float resistance, float intensity)
        {
            return resistance * intensity;
        }

        float PowerA(float intensity, float potentialDifference)
        {
            return intensity * potentialDifference;
        }

        float PowerB(float resistance, float intensity)
        {
            return resistance * (float)Math.Pow(intensity, 2);
        }

        float PowerC(float potentialDifference, float resistance)
        {
            return (float) Math.Pow(potentialDifference, 2) / resistance;
        }

        float CurrentDensityA(float volumeDensity, float driftSpeed)
        {
            return volumeDensity * e * driftSpeed;
        }

        float CurrentDensityB(float conductivity, float electricField)
        {
            return conductivity * electricField;
        }
        #endregion Current & Resistance

        #region Circuits

        float SeriesResistance(List<float> resistances)
        {
            return resistances.Sum(x => x);
        }

        float ParallelResistance(List<float> resistances)
        {
            return 1 / resistances.Sum(x => 1 / x);
        }
        #endregion Circuits

        #region Condensators

        float CapacityA(float area, float distanceBetweenPlates)
        {
            return Epsilon0 * area / distanceBetweenPlates;
        }

        float CapacityB(float charge, float potentialDifference)
        {
            return charge / potentialDifference;
        }

        float SeriesCapacity(List<float> capacities)
        {
            return ParallelResistance(capacities);
        }

        float ParallelCapacity(List<float> capacities)
        {
            return SeriesResistance(capacities);

        }

        float PotentialEnergyA(float charge, float potentialDifference)
        {
            return charge * potentialDifference / 2;
        }

        float PotentialEnergyB(float charge, float capacity)
        {
            return (float)(Math.Pow(charge, 2) / 2 / capacity);
        }

        float PotentialEnergyC(float capacity, float potentialDifference)
        {
            return capacity * (float)Math.Pow(potentialDifference, 2) / 2;
        }
        #endregion Condensators

        #region Charging & Decharging

        float Decharge(float initialCharge, float time, float tau)
        {
            return initialCharge * (float)Math.Pow(Math.E, -time / tau);
        }

        float DechargeIntensity(float initialIntensity, float time, float tau)
        {
            return Decharge(initialIntensity, time, tau);
        }

        float Charge(float initialCharge, float time, float tau)
        {
            return initialCharge * (float)Math.Pow(1 - Math.E, -time / tau);
        }

        float ChargeIntensity(float initialCharge, float time, float tau)
        {
            return DechargeIntensity(initialCharge, time, tau);
        }

        float HalfLifeTime(float tau)
        {
            return tau * (float)Math.Log(2); 
        }
        #endregion Charging & Decharging
    }
}
