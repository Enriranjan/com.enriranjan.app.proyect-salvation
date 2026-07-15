# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.1.0] - 2026-07-08

### Added

- Initial release of App Proyect Salvation as an application package: full
  game (logic + content), consumed by build-platform Unity projects.
- `Runtime/App` (`EnriRanjan.App.ProyectSalvation`, pure C#) and
  `Runtime/Unity` (`EnriRanjan.App.ProyectSalvation.Unity`) assemblies, split
  by the same `noEngineReferences` convention as `com.enriranjan.core`.
- `ProyectSalvationBootstrap` and `MainSceneInstaller` skeletons, wired to
  `EnriRanjan.Core.Unity`'s `ApplicationBootstrap` and
  `SceneContextInstaller`, with the anchor points for the first Services,
  Controllers, Providers and Views.
- Content folder structure: `Scenes/`, `Prefabs/`, `Art/`, `Audio/`,
  `Input/`, `Config/`.
- Dependency on `com.enriranjan.core` (`0.1.0`).
