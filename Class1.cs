using HLAirships;
using KSP;
using ProceduralParts;
using UnityEngine;

namespace ProceduralEnvelopeSync
{
    public class ProceduralEnvelopeVolumeModule : PartModule
    {
        [KSPField]
        public float volumeScale = 1f;

        private HLEnvelopePartModule envelope;
        private ProceduralPart procPart;
        private float lastVolume = -1f;

        public override void OnStart(StartState state)
        {
            if (HighLogic.LoadedSceneIsEditor || HighLogic.LoadedSceneIsFlight)
            {
                envelope = part.FindModuleImplementing<HLEnvelopePartModule>();
                procPart = part.FindModuleImplementing<ProceduralPart>();
            }
        }

        void Update()
        {
            if (procPart == null || envelope == null)
                return;

            float currentVolume = procPart.Volume; // 这是 ProceduralPart 的公开属性，单位 m³
            if (!Mathf.Approximately(currentVolume, lastVolume))
            {
                lastVolume = currentVolume;
                envelope.envelopeVolume = currentVolume * volumeScale;

                // 若 HLEnvelopePartModule 需要刷新，可在此调用其公开方法，例如：
                // envelope.RecalculateBuoyancy();
            }
        }
    }
}