using System.Collections.Generic;
using HLAirships;
using KSP;
using ProceduralParts;
using UnityEngine;

namespace ProceduralEnvelopeSync
{
    public class ProceduralEnvelopeVolumeModule : PartModule
    {
        [KSPField(guiActive = false, guiActiveEditor = true, guiName = "Volume Scale",
                  isPersistant = true, guiFormat = "F1")]
        [UI_FloatRange(minValue = 1f, maxValue = 100f, stepIncrement = 0.5f, scene = UI_Scene.Editor)]
        public float volumeScale = 20f;

        [KSPField(guiActive = true, guiActiveEditor = true, guiName = "Current Volume",
                  guiFormat = "F2", guiUnits = "m\u00B3")]
        public float currentVolumeDisplay = 0f;

        [KSPField(guiActive = true, guiActiveEditor = true, guiName = "Buoyancy Volume",
                  guiFormat = "F2", guiUnits = "m\u00B3")]
        public float buoyancyVolumeDisplay = 0f;

        private HLEnvelopePartModule envelope;
        private ProceduralPart procPart;
        private bool initialized = false;

        private float lastGoodBuoyancy = 0f;
        private const float SPEED_THRESHOLD = 1.5f;

        public override void OnStart(StartState state)
        {
            this.enabled = (HighLogic.LoadedSceneIsEditor || HighLogic.LoadedSceneIsFlight);
            if (!this.enabled) return;

            envelope = part.FindModuleImplementing<HLEnvelopePartModule>();
            procPart = part.FindModuleImplementing<ProceduralPart>();

            if (envelope == null)
            {
                Debug.LogError("[ProceduralAirships] HLEnvelopePartModule not found! Ensure HL Airships Core is installed.");
                this.enabled = false;
                return;
            }
            if (procPart == null)
            {
                Debug.LogError("[ProceduralAirships] ProceduralPart not found! Ensure ProceduralParts is installed.");
                this.enabled = false;
                return;
            }

            initialized = true;

            SyncVolume();

            Fields[nameof(volumeScale)].uiControlEditor.onFieldChanged += OnVolumeScaleChanged;

            if (HighLogic.LoadedSceneIsEditor)
                GameEvents.onEditorShipModified.Add(OnEditorShipModified);
        }

        public void OnDestroy()
        {
            GameEvents.onEditorShipModified.Remove(OnEditorShipModified);
        }

        public override void OnFixedUpdate()
        {
            if (!initialized || envelope == null || !HighLogic.LoadedSceneIsFlight) return;
            if (part.vessel == null) return;

            if (envelope.specificVolumeFractionEnvelope > 0.02f)
            {
                lastGoodBuoyancy = envelope.specificVolumeFractionEnvelope;
            }

            if (lastGoodBuoyancy > 0.02f
                && part.vessel.srfSpeed > SPEED_THRESHOLD
                && envelope.specificVolumeFractionEnvelope < 0.01f)
            {
                envelope.targetBuoyantVessel = lastGoodBuoyancy;
                envelope.specificVolumeFractionEnvelope = lastGoodBuoyancy;
            }
        }

        public void OnPartVolumeChanged(BaseEventDetails data)
        {
            if (!initialized || envelope == null || procPart == null) return;
            SyncVolume();
        }

        private void OnVolumeScaleChanged(BaseField field, object obj)
        {
            if (!initialized || envelope == null || procPart == null) return;
            SyncVolume();
        }

        private void OnEditorShipModified(ShipConstruct ship)
        {
            if (!initialized || envelope == null || procPart == null) return;
            if (ship.Parts.Contains(part))
                SyncVolume();
        }

        [KSPEvent(guiActive = true, guiActiveEditor = true, guiName = "#ProceduralAirship__7")]
        public void ApplyScaleToAll()
        {
            if (!initialized) return;

            List<Part> partsList = null;
            if (HighLogic.LoadedSceneIsEditor)
            {
                partsList = EditorLogic.fetch.ship?.Parts;
            }
            else if (HighLogic.LoadedSceneIsFlight && part.vessel != null)
            {
                partsList = part.vessel.parts;
            }

            if (partsList == null) return;

            int count = 0;
            foreach (var p in partsList)
            {
                if (p == part) continue;
                var other = p.FindModuleImplementing<ProceduralEnvelopeVolumeModule>();
                if (other != null && other.initialized)
                {
                    other.volumeScale = volumeScale;
                    other.SyncVolume();
                    count++;
                }
            }

            string msg = count > 0
                ? KSP.Localization.Localizer.Format("#ProceduralAirship__8", volumeScale, count)
                : KSP.Localization.Localizer.Format("#ProceduralAirship__9");
            ScreenMessages.PostScreenMessage(msg, 3f, ScreenMessageStyle.UPPER_CENTER);
        }

        private void SyncVolume()
        {
            float currentVolume = procPart.Volume;
            envelope.envelopeVolume = currentVolume * volumeScale;

            currentVolumeDisplay = currentVolume;
            buoyancyVolumeDisplay = envelope.envelopeVolume;
        }
    }
}
