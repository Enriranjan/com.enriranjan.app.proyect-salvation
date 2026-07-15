# App Proyect Salvation

Application package: contains the full game (application logic + content)
consumed by Unity projects that only define the build platform.

Package: `com.enriranjan.app.proyectsalvation`

## Table of Contents

- [Installation](#installation)
- [Getting Started](#getting-started)
- [Concepts](#concepts)
- [API Reference](#api-reference)
- [Samples](#samples)
- [Changelog](#changelog)

## Installation

See the main [README](../README.md#cómo-se-consume-desde-un-proyecto-unity)
for installation instructions (Git URL or embedded package). Requires
`com.enriranjan.core` to be resolvable from the consuming project's
manifest.

## Getting Started

1. Create/open a Unity project whose `Packages/manifest.json` resolves this
   package (embedded or Git URL) and its `com.enriranjan.core` dependency.
2. Set `Scenes/Bootstrap.unity` as the entry scene in the project's build
   profile.
3. Press Play from `Bootstrap.unity`: `ProyectSalvationBootstrap` installs
   the app's systems/providers/services, then loads the configured initial
   gameplay scene, whose `SceneContextInstaller` wires controllers to views.

## Concepts

- **`Runtime/App`** (`EnriRanjan.App.ProyectSalvation`, `noEngineReferences: true`) -
  Services, Controllers, Providers and ViewInterfaces. Pure C#, testable
  with plain NUnit, no `UnityEngine` reference allowed.
- **`Runtime/Unity`** (`EnriRanjan.App.ProyectSalvation.Unity`) - Bootstrap,
  Installers and Views. The only layer allowed to know about
  `MonoBehaviour`/`ScriptableObject`.
- **`ProyectSalvationBootstrap`** - the app's composition root; see
  `EnriRanjan.Core.Unity.ApplicationBootstrap` for the base contract.
- **`MainSceneInstaller`** - per-scene composition root; see
  `EnriRanjan.Core.Unity.SceneContextInstaller` for the base contract.

## API Reference

<!-- Document the public surface as it grows: Services, Controllers,
     Providers, ViewInterfaces, and any concrete Bootstrap/Installer/View
     added under Runtime/Unity. -->

## Samples

See [Samples~/BasicUsage](../Samples~/BasicUsage/README.md).

## Changelog

See [CHANGELOG.md](../CHANGELOG.md).
