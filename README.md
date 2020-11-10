# Unity_PackageManagerSample

This is a sample repository to make a PackageManager's Package in GitHub.
This repository works as either Unity project and Package.

- [Packages - Unity Official](https://docs.unity3d.com/ja/current/Manual/PackagesList.html)

<!-- ######################################################################################### -->
## How to add Package
<!-- ######################################################################################### -->

(1) To add Package with `Package Manager` via GitHub, install Git and add the path into environment variable.

(2) Paste this code into `PackageManager > Add package from git URL`.

```
https://github.com/XJINE/Unity_PackageManagerSample.git?path=/Packages/PackageManagerSample
```

Package URL `path` must shows parent folder of the `package.json`.

For more information about URL, see the official. Ex. it is able to use some revision with `#`.

- [Git URL - Unity Official](https://docs.unity3d.com/ja/current/Manual/upm-git.html)

<!-- ######################################################################################### -->
### How to develop new Package in Packages
<!-- ######################################################################################### -->

1. Make your Package folder and add `package.json` with Exproler.
    - Also you should to add `CHANGELOG.md`, `LICENSE.md`, `README.md` and `/Documentation~/(README).md`.
2. Add these into `/Packages` via Exproler.
3. Active the project in Unity Editor.

<!-- ######################################################################################### -->
## Edit package scripts with VisualStudio Intellisense
<!-- ######################################################################################### -->

Maybe scripts in the Package are unable to edit with Visual Studio Intellisense.

In such a case, open Editor menu `Edit > Preferences > External Tools`, and see the `Generate .csproj files for:`

- Turn on the `> Embedded packages` to edit in original Package project.
- Turn on the `> Git packages` to edit Package via `PackageManager > Add package from git URL`.

Then, push `Regenerate project files` button and restart VS.

<!-- ######################################################################################### -->
## About Package Resources
<!-- ######################################################################################### -->

There are Unity recommended layout. But it is not minimul and some of these are not required.

- [Package layout - Unity Official](https://docs.unity3d.com/Manual/cus-layout.html)

This is general layout.

- &#x1f4c1; Packages
    - &#x1f4c1; (Package Name)
        - [&#x1f4c4; package.json](#-packagejson)
        - [&#x1f4c4; (File Name).asmdef](#-file-nameasmdef)
        - [&#x1f4c4; CHANGELOG.md](#-changelogmd)
        - [&#x1f4c4; LICENSE.md](#-licensemd)
        - [&#x1f4c4; README.md](#-readmemd)        
        - [&#x1f4c1; Documentation~](#-documentation--file-namemd)
            - [&#x1f4c4; (File Name).md](#-documentation--file-namemd)
        - [&#x1f4c1; Editor](#-editor)
            - [&#x1f4c4; (File Name).asmdef](#-filenameasmdef)
            - [&#x1f4c4; EditorScript.cs](#-editor)
        - [&#x1f4c1; Runtime](#-runtime)
            - [&#x1f4c4; (File Name).asmdef](#-filenameasmdef)
            - [&#x1f4c4; RuntimeScript.cs](#-runtime)
        - [&#x1f4c1; (Sub Folder)](#-subfolder)

<!-- ######################################################################################### -->
### &#x1f4c4; package.json
<!-- ##########################################################################################-->
**&#9733;&#9733;&#9733; REQUIRED**

This makes your directory a Package.

- Name of this file must be `package.json`.
- Resources put in the same or under hierarchies will be included into the Package.
- This is able to edit with `Inspector`, but unable to add from Editor menu.

#### Package manifest

- Untiy says `Name` must be start with `com.(company-name)`.
    - but this is not required. It looks to work well even if it is not.
    - Maybe this rule is important to avoid name conflict.
    - Not same as `Display Name`.
- `author`, `keywords` and any others are unable to edit with `Inspector`. hmmm.
    - `author` is important because it used to group same author Packages in `Package Manager` window.
- `dependencies` has a prbolem now. See the ["Package Dependencies"](#package-dependencies) topic.

For more information, see the official. Ex. The name of the Package length should be less than 50 (or 214) characters.

- [Package manifest - Unity Official](https://docs.unity3d.com/Manual/upm-manifestPkg.html)

<!-- ######################################################################################### -->
### &#x1f4c4; (File Name).asmdef
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9733; REQUIRED**

This is important to regard `.cs` files as resources.
If this is not included, scripts in `/Assets` are unable to access the scripts in this Package.

- This is able to add from Editor menu, `Assets > Create > Assembly Definition`.
- This is able to edit with `Inspector`.
- Unity recommends the name like `Unity.(Package Name).asmdef`, but this is not required.
    - also recommends the name like `MyCompany.MyFeature.Editor.asmdef` or `MyCompany.MyFeature.Runtime.asmdef`, hmmm.

For more information about asmdef, see the official. EX. There are `unsafe` code option, Platform settings and any others.

- [Assembly definition and packages - Unity Official](https://docs.unity3d.com/Manual/cus-asmdef.html)
- [Assembly Definition - Unity Official](https://docs.unity3d.com/ja/current/Manual/ScriptCompilationAssemblyDefinitionFiles.html)

<!-- ######################################################################################### -->
### &#x1f4c4; CHANGELOG.md
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9733; RECOMMENDED**

Write some updates of the Package.

- This is unable to add with Editor menu.
- This is able to open from `View changelog` in `Package Manager` window.

<!-- ######################################################################################### -->
### &#x1f4c4; LICENSE.md
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9734; RECOMMENDED**

Write some license information of the Package.

- This is unable to add with Editor menu.
- This is able to open from `View licenses` in `Package Manager` window.

<!-- ######################################################################################### -->
### &#x1f4c4; README.md
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9734; RECOMMENDED**

Write some information for Package developers.

- Unity recommends to add `README.md`, but this is unable to open from `Package Manager` window.
    - also unable to add with Editor menu.
- Instead of this, `/Documentation~/(File Name).md` is able to open from `Package Manager` window.
    - See the topic of ["Documentation~"](#-documentation--file-namemd).
- Unity says this is mainly for the Package developers.

<!-- ######################################################################################### -->
###  &#x1f4c1; /Documentation~ &#x1f4c4; /(File Name).md
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9734; RECOMMENDED**

Write some information for Package users.

- Folder the name ends with `~` will be hidden in `Project` window.
- This is able to open from `View documentation` in `Package Manager` Window.
- Unity recommends the file name like `(Package Name).md`.
    - but this is not required.
    - The first `.md` file will be opend when `View documentation`.

<!-- ######################################################################################### -->
### &#x1f4c1; /Editor
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9733; REQUIRED (CONDITIONAL)**

`Editor` folder is needed when you add some Editor scripts.

- `Editor` folder works same as general project resources.

<!-- ######################################################################################### -->
### &#x1f4c1; /Runtime
<!-- ######################################################################################### -->
**&#9733;&#9734;&#9734; OPTIONAL**

Add the Package scripts which works in runtime.

- Unity recommends to add `Runtime` folder, and add the runtime scripts into there.
    - but this is not required.
    - Package and the runtime scripts well works even if it not use `Runtime` folder.

<!-- ######################################################################################### -->
### &#x1f4c1; /(Sub Folder)
<!-- ######################################################################################### -->
**&#9733;&#9734;&#9734; OPTIONAL**

Add some folders as you want.

<!-- ######################################################################################### -->
## Package Dependencies
<!-- ######################################################################################### -->

`package.json` is able to set the `dependencies` with git(Hub) URL.
`dependeincies` is a function to add the other Package which used in Package.

However, it does not works alone in ~ver.2020.2.
[Unity said it is comming in future(2020? hmmm).](https://forum.unity.com/threads/custom-package-with-git-dependencies.628390/#post-5367033)

If want to use `dependencies` now, add same `dependencies` settings into both `package.json` and `/Packages/manifest.json`.
`/Packages/manifest.json` is unable to open from Editor.

- [Git dependencies - Unity Official](https://docs.unity3d.com/Manual/upm-git.html)
- [Custom Package with Git Dependencies - Unity Forums](https://forum.unity.com/threads/custom-package-with-git-dependencies.628390/#post-5367033)
