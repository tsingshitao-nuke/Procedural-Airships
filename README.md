# Procedural Airships
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/89bf9cbc-8d4f-4a7f-a0a5-c0419828ca14" />

[![KSP version](https://img.shields.io/badge/KSP-1.12.x-blue.svg)](https://forum.kerbalspaceprogram.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

将 Procedural Parts 的可调体积与 HL Airships 的浮力系统相结合，让你可以自由捏出任意尺寸和形状的飞艇气囊。同时提供程序化动量轮，扭矩和电容量随体积自动缩放。

Bridges [Procedural Parts](https://github.com/KSP-RO/ProceduralParts) with [HL Airships Core](https://forum.kerbalspaceprogram.com/topic/207891-ksp-131-hooligan-labs-airships-core-7016-2026-0323/), giving you fully scalable airship envelopes that generate lift automatically based on volume. Also includes a procedural reaction wheel that scales torque and EC storage with part size.

---

## 包含部件 / Included Parts

### 程序化飞艇气囊 / Procedural Airship Envelope

基于 HL Airships 的可缩放气囊，浮力自动随体积变化。

A scalable airship envelope powered by HL Airships. Buoyancy scales with volume.

- 支持 Cylinder、Cone、Pill、Bezier Cone、Polygon 五种外形 / Five shapes available
- Volume Scale 滑条 (1-100x) 倍增浮力 / Multiplier slider for extra lift
- 一键批量同步到全船气囊 / Apply Scale to All Envelopes in one click

**依赖 / Requires:** HL Airships Core + Procedural Parts

---

### 程序化动量轮 / Procedural Reaction Wheel

扭矩、质量和电容量都随部件体积动态缩放的动量轮。

A reaction wheel whose torque, mass, and EC storage scale dynamically with part volume.

- 扭矩随体积缩放：torque = torqueDensity × 13.5 × √体积 / Torque scales with volume
- Torque Density 滑条 (0.1-5x) 精细调节 / Adjustable torque density in the PAW
- 电容量随体积缩放：EC = 体积 × 300 / EC capacity scales with volume (300/m³)
- 仅在 SAS 开启或手动输入时消耗电力 / Consumes EC only when SAS is active or manual input is given
- 通过 IPartMassModifier 正确缩放质量 / Mass scales correctly via IPartMassModifier

**依赖 / Requires:** HL Airships Core + Procedural Parts

---

## 安装 / Installation

1. 安装 **HL Airships Core** 和 **Procedural Parts**（见下方链接）/ Install both dependencies below
2. 将 `GameData/ProceduralAirships` 复制到你的 KSP `GameData` 目录 / Copy `GameData/ProceduralAirships` into your KSP `GameData`
3. 气囊在 **Aero** 分类，动量轮在 **Control** 分类 / Envelopes in **Aero**, reaction wheels in **Control**

```
GameData/
├── HLAirshipsCore/          ← 必须安装 / required
├── ProceduralParts/          ← 必须安装 / required
└── ProceduralAirships/       ← 本模组 / this mod
    ├── Localization/
    ├── Parts/
    ├── Plugins/
    └── Version/
```

---

## 使用说明 / How to Use

### 飞艇气囊 / Envelope

1. 从 Aero 分类放置"自定义飞艇气囊" / Place "Procedural Airship Envelope" from Aero tab
2. 拖拽节点调整直径和长度 / Drag gizmos to resize
3. 右键菜单调整 **Volume Scale** 滑条倍增浮力 / Tweak Volume Scale to multiply buoyancy
4. 点击 **Apply Scale to All Envelopes** 同步到全船 / Click to sync all envelopes
5. (可选) 安装气囊盖子整理两端外形 / Optionally add envelope caps

### 程序化动量轮 / Reaction Wheel

1. 从 Control 分类放置"程序化动量轮" / Place "Procedural Reaction Wheel" from Control tab
2. 拖拽节点调整尺寸，扭矩和质量自动更新 / Resize — torque and mass update automatically
3. 右键菜单调整 **Torque Density** (0.1-5x) 精细控制扭矩 / Adjust Torque Density for finer control
4. 开启 SAS 或手动按键时自动消耗电力 / EC is drained only when actively working

---

## 依赖 / Dependencies

| Mod | 下载链接 / Link |
|---|---|
| **HL Airships Core** | [KSP Forum](https://forum.kerbalspaceprogram.com/topic/207891-ksp-131-hooligan-labs-airships-core-7016-2026-0323/) |
| **Procedural Parts** | [GitHub](https://github.com/KSP-RO/ProceduralParts) |

> **注：飞艇气囊可能与 Principia 冲突 / Note: Envelopes may conflict with Principia**

---

## 许可证 / License

[MIT](LICENSE)

Copyright (c) 2026 tsingshitao-nuke, Iftn
