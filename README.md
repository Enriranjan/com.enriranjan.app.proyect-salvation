# com.enriranjan.app.proyectsalvation

Paquete de **aplicación** (UPM) que contiene el juego completo *Proyect
Salvation*: toda la lógica de aplicación y todo el contenido (escenas,
prefabs, arte, audio, input, configuración). Los proyectos de Unity que lo
consumen no contienen lógica ni contenido propio - solo definen la
plataforma de build (`ProjectSettings/`, build profiles, `manifest.json` y,
opcionalmente, un `Sandbox/` para probar cosas sueltas fuera del paquete).

## Qué es un "application package" en esta arquitectura

En un paquete UPM normal (librería reutilizable) el consumidor aporta el
"resto de la app". Aquí es al revés: este paquete **es** la app entera, y el
proyecto Unity que lo importa solo aporta la configuración específica de
cada plataforma de build (PC, consola, móvil...). Esto permite:

- Tener un único repo de juego (este) versionado independientemente de cada
  target de plataforma.
- Que cada plataforma sea un proyecto Unity mínimo y desechable: se puede
  recrear con solo `ProjectSettings` + `manifest.json` apuntando a este
  paquete.
- Reutilizar toda la infraestructura arquitectónica de
  [com.enriranjan.core](https://github.com/enriranjan/core): `ITickable`,
  `IReferenceLocator`, `ApplicationBootstrap` y `SceneContextInstaller`.

Sigue las mismas reglas que el core: las dependencias solo miran hacia
abajo (`*.Unity` puede referenciar al ensamblado puro, nunca al revés), y
solo la parte `.Unity` conoce `MonoBehaviour`/`ScriptableObject`; Services,
Controllers y Providers son C# puro.

## Mapa de carpetas

### Código

```
Runtime/App/             EnriRanjan.App.ProyectSalvation - C# puro, noEngineReferences: true.
  Services/               Lógica de aplicación/dominio consumida por los controllers de escena.
  Controllers/            Orquestan Services y Providers; exponen los datos que las Views necesitan.
  Providers/              Fuentes de datos/contenido de solo lectura construidas sobre systems.
  ViewInterfaces/          Contratos que las Views (Unity) implementan, para que Controllers no conozcan Unity.
Runtime/Unity/            EnriRanjan.App.ProyectSalvation.Unity - referencia UnityEngine.
  Bootstrap/               ProyectSalvationBootstrap: composition root, una por Bootstrap.unity.
  Installers/              SceneContextInstaller por escena de juego (crea Controllers, conecta Views).
  Views/                   MonoBehaviours que implementan las ViewInterfaces e interactúan con Unity.
Editor/                   Herramientas de editor (SÍ puede usar Unity).
Tests/Runtime/            NUnit puro contra EnriRanjan.App.ProyectSalvation.
Tests/Editor/             NUnit contra Editor/ y contra el ensamblado .Unity.
```

### Contenido

```
Scenes/     Bootstrap.unity + escenas de juego.
Prefabs/    Prefabs de views, actores y cualquier objeto instanciable.
Art/        Materials/, Models/, Textures/.
Audio/      Clips consumidos vía IAudioPlayer (core).
Input/      Input Action Assets.
Config/     ScriptableObjects de configuración.
```

## Cómo se consume desde un proyecto Unity

### a) Embedded (durante desarrollo del juego)

Clona este repositorio directamente dentro de `Packages/` del proyecto de
plataforma:

```
<UnityProject>/Packages/com.enriranjan.app.proyectsalvation/
```

Es el modo recomendado mientras se itera sobre el juego: los cambios se ven
al instante en el proyecto y se puede commitear/pushear desde ese mismo
checkout, igual que con cualquier paquete embedded.

### b) Por Git URL con tag (cuando una versión es estable)

En `Packages/manifest.json` del proyecto de plataforma:

```json
{
  "dependencies": {
    "com.enriranjan.app.proyectsalvation": "https://github.com/enriranjan/app.proyectsalvation.git#v0.1.0"
  }
}
```

Sin `#tag` apunta a la rama por defecto, útil en desarrollo pero no
reproducible para un build de release.

Este paquete depende a su vez de `com.enriranjan.core` (ver
`package.json`); el manifest del proyecto de plataforma debe poder resolver
también esa dependencia (Git URL o registro privado).

## Ciclo de vida de la aplicación

1. El proyecto de plataforma arranca en la escena `Scenes/Bootstrap.unity`,
   que contiene un `ProyectSalvationBootstrap` (hereda de
   `ApplicationBootstrap`, en `Runtime/Unity/Bootstrap/`).
2. En su `Awake`, `ApplicationBootstrap` crea el `ReferenceLocator` y llama
   a `InstallBindings()`. Ahí se crean y registran, en orden, los systems,
   providers y services del juego (ver los TODO en
   `ProyectSalvationBootstrap.cs`).
3. Cuando `InstallBindings()` termina, `ApplicationBootstrap` carga la
   escena inicial de juego (configurada en el inspector del bootstrap).
4. Esa escena contiene un `SceneContextInstaller` concreto (p. ej.
   `MainSceneInstaller`, en `Runtime/Unity/Installers/`). Su `Awake` lee el
   `IReferenceLocator` ya poblado, resuelve los services que necesita,
   crea los controllers de la escena y los conecta a las views asignadas
   por `[SerializeField]` en el propio installer.
5. Los controllers (C# puro) hablan con los services/providers y con las
   views a través de `ViewInterfaces/`; las views (`Runtime/Unity/Views/`)
   son las únicas que tocan Unity de verdad.

## Los archivos `.meta` se commitean

Igual que en cualquier paquete UPM, los `.meta` viajan en el repo: contienen
los GUID estables que resuelven referencias a scripts, prefabs y assets
entre este paquete y los proyectos de plataforma que lo consumen. Ver
`.gitignore` para lo que sí se ignora (cachés, IDEs...).

## Versionado

Sigue [SemVer](https://semver.org/) y
[Keep a Changelog](https://keepachangelog.com/): cada release se documenta
en `CHANGELOG.md`, la versión se actualiza en `package.json`, y se etiqueta
con `git tag vX.Y.Z`.
