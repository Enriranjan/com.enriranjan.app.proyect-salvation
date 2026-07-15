# Scenes

Contains every `.unity` scene of the game, including `Bootstrap.unity` (the
single entry point, holding a `ProyectSalvationBootstrap`) and the gameplay
scenes reached from it (each holding a `MainSceneInstaller` or another
`SceneContextInstaller` subclass). Consuming projects only reference these
scenes from their build profiles; they never define their own.
