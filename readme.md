# Unity Gradle Plugin

This plugin resolves Android dependencies via Gradle.

## Importing

Import file `UnityGradlePlugin.unitypackage`

## How to use

After importing open scene `Example/Example`, you will see the same instruction there:

 1. Make sure you have `ANDROID_HOME` enviroment variable which points to Android SDK directory

 2. Open file `/Plugins/Gradle/build.gradle`

 3. Add your dependencies into this section:

        dependencies {
            // TODO replace lines below by your dependencies
            export 'com.shamanland:xdroid-toaster:0.3.0'
            // export 'com.google.firebase:firebase-core:10.0.0'
        }

 4. Window -> Gradle -> Resolve

 5. Discover new files under directory `/Plugins/Android/`

 6. Write your wrappers around Java classes like `/Example/Toaster.cs`

 7. Build project for Android

*NOTE*: this example was created and tested on Unity 5.5

## License

```
Copyright 2016 ShamanLand.Com

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```
