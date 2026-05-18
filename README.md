# Procedural Airships
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/89bf9cbc-8d4f-4a7f-a0a5-c0419828ca14" />

[![KSP version](https://img.shields.io/badge/KSP-1.12.x-blue.svg)](https://forum.kerbalspaceprogram.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

将 Procedural Parts 的可调体积与 HL Airships 的浮力系统相结合，让你可以自由捏出任意尺寸和形状的飞艇气囊。

Bridges [Procedural Parts](https://github.com/KSP-RO/ProceduralParts) with [HL Airships Core](https://forum.kerbalspaceprogram.com/topic/207891-ksp-131-hooligan-labs-airships-core-7016-2026-0323/), giving you fully scalable airship envelopes that generate lift automatically based on volume.

---

## 特性 / Features

- **体积即浮力** — 调整气囊的直径和长度，浮力自动按比例变化 / Resize your envelopes, and buoyancy scales automatically
- **多种形状** — 支持 Cylinder、Cone、Pill、Bezier Cone、Polygon 五种外形 / Multiple shapes to choose from
- **体积缩放** — Volume Scale 滑条可在实际体积基础上倍增浮力 / Extra slider to multiply buoyancy beyond actual volume
- **批量同步** — "应用到所有气囊"按钮一键同步缩放比例 / Apply Scale to All Envelopes in one click
- **多语言** — 内置中文和英文 / Localized in English and Chinese

---

## 依赖 / Dependencies

**必须安装 / Required:**

| Mod | 下载链接 / Link |
|---|---|
| **HL Airships Core** | [KSP Forum](https://forum.kerbalspaceprogram.com/topic/207891-ksp-131-hooligan-labs-airships-core-7016-2026-0323/) |
| **Procedural Parts** | [GitHub](https://github.com/KSP-RO/ProceduralParts) |

---

## 安装 / Installation

1. 安装 **HL Airships Core** 和 **Procedural Parts**（见上方链接）/ Install the two dependencies above
2. 将 `GameData/ProceduralAirships` 文件夹复制到你的 KSP `GameData` 目录 / Copy `GameData/ProceduralAirships` into your KSP `GameData`
3. 启动游戏，在 Aero 分类中找到部件 / Launch the game — parts are in the **Aero** category

```
GameData/
├── HLAirshipsCore/          ← 必须安装 / required
├── ProceduralParts/          ← 必须安装 / required
└── ProceduralAirships/       ← 本模组 / this mod
    ├── Parts/
    ├── Plugins/
    └── Localization/
```

---

## 使用说明 / How to Use

### 在 VAB/SPH 中 / In the Editor

1. 从 Aero 分类中放置"自定义飞艇气囊" / Place the envelope from the Aero category
2. 使用 Procedural Parts 的节点调整气囊的直径和长度 / Adjust diameter and length with the stock resize gizmos
3. 在右键菜单中调整 **Volume Scale** 滑条，控制浮力比例 / Tweak **Volume Scale** in the PAW to multiply buoyancy
4. 点击 **Apply Scale to All Envelopes** 同步到同飞船的其他气囊 / Click the button to sync to all envelopes
5. （可选）在两端安装"自定义飞艇气囊盖子"整理外形 / Optionally cap the ends with the Envelope Cap

### 在飞行中 / In Flight

- 使用 HL Airships 的控制窗口调节浮力大小 / Use the HL Airships control window to adjust buoyancy
- **Volume Scale** 在飞行中不可调，需要在 VAB/SPH 中预设 / Volume Scale is locked in flight

---

## 许可证 / License

[MIT](LICENSE)

Copyright (c) 2026 tsingshitao-nuke
