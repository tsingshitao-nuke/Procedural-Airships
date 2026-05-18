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
        private bool shouldBeEnabled = false;

        public override void OnStart(StartState state)
        {
            this.enabled = this.shouldBeEnabled = (HighLogic.LoadedSceneIsEditor || HighLogic.LoadedSceneIsFlight);
            if (this.shouldBeEnabled)
            {
                envelope = part.FindModuleImplementing<HLEnvelopePartModule>();
                procPart = part.FindModuleImplementing<ProceduralPart>();
            }
        }

        void Update()
        {
            if (!this.shouldBeEnabled)
            {
                this.enabled = this.shouldBeEnabled; // 再次禁用，防止被其他模块强制启用
                return;
            }

            if (procPart == null || envelope == null)
                return;

            float currentVolume = procPart.Volume;
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