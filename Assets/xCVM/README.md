# VRM

The core library for xCVM-0.XX.

## Import VRM (Unity 2019.3.4f1~)

`Window` -> `Package Manager` -> `Add package from git URL` and add the followings in order: 

* `https://github.com/matonnet/xCVM.git?path=/Assets/VRMShaders`
* `https://github.com/matonnet/xCVM.git?path=/Assets/VRM` => depends on VRMShaders

or add the package name and git URL in `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.vrmc.vrmshaders": "https://github.com/matonnet/xCVM.git?path=/Assets/VRMShaders",
    "com.vrmc.xCVM": "https://github.com/matonnet/xCVM.git?path=/Assets/VRM",
  }
}
```
