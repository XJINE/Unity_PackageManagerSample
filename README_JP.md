# Unity_PackageManagerSample

GitHub に PackageManager の Package を作るサンプルです。
このリポジトリは Unity プロジェクトとしても Package としても機能します。

- [Packages - Unity Official](https://docs.unity3d.com/ja/current/Manual/PackagesList.html)

<!-- ######################################################################################### -->
## Package を追加する方法
<!-- ######################################################################################### -->

(1) GitHub 上の Package を PackageManager から追加するためには Git をインストールし、環境パスを通します。

(2) `PackageManager > Add package from git URL` に次のコードを貼り付けます。

```
https://github.com/XJINE/Unity_PackageManagerSample.git?path=/Packages/PackageManagerSample
```

Package の URL には `path` は、`package.json` ファイルの含まれるフォルダを指す必要があります。

追加の情報は公式を参照してください。例えば `#` を使ってリビジョンを指定することなどができます。

- [Git URL - Unity Official](https://docs.unity3d.com/ja/current/Manual/upm-git.html)

<!-- ######################################################################################### -->
### Packages に新しい Package を追加する
<!-- ######################################################################################### -->

1. エクスプローラで Package 用のフォルダを作り、そこに `package.json` を追加します。
    - `CHANGELOG.md`, `LICENSE.md`, `README.md`, `/Documentation~/(README).md`も追加しておくとよいです。
2. エクスプローラから `/Packages` フォルダに追加します。
3. Unity Editor をアクティブにします。

<!-- ######################################################################################### -->
## Visual Studio でインテリセンスを有効にする
<!-- ######################################################################################### -->

Package に追加されたスクリプトを開発するとき、VisualStudio のインテリセンスが機能しないことがあります。
そのようなとき、Editor メニューから `Edit > Preferences > External Tools` を開き、
`Generate .csproj files for:` を確認します。

- Package を作っているプロジェクトで開発するとき、`> Embedded packages` を有効にします。
- Package を追加したプロジェクトで開発するとき、`> Git packages` を有効にします。

最後に、`Regenerate project files` ボタンを押して、VisualStudio を再起動します。

<!-- ######################################################################################### -->
## About Package Resources
<!-- ######################################################################################### -->

Unity 公式の Package 構成があります。しかしながら、これらは最小限のものではなく、必要でない仕様も含まれます。

- [Package layout - Unity Official](https://docs.unity3d.com/Manual/cus-layout.html)

主な構成は次の通りです。

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
**&#9733;&#9733;&#9733; 必要**

フォルダを Package にするために必要です。

- ファイル名は `package.json` である必要があります。
- これと同じ階層か、これより下の階層に置かれたリソースが Package に含まれます。
- `Inspector`　から編集することができますが、Editor メニューから追加することはできません。

#### Package manifest

- Unity の公式は `Name` は `com.(company-name)` から始めなければならないとしています。
    - しかしこの条件は必須ではありません。異なる名前でも機能します。
    - 名前の衝突を回避する目的があると思われます。
    - `Display Name` とは異なる点に注意してください。
- 一部の `author` や `keywords` のようなパラメータは `Inspector` から編集できません。
    - `author` は `Package Manager` ウィンドウでグループ化するために重要です。
- `dependencies` は問題があります。["Package の依存関係"](#package-%E3%81%AE%E4%BE%9D%E5%AD%98%E9%96%A2%E4%BF%82) の項目を確認してください。

追加の情報は公式を参照してください。例えば Package の名前は 50 (か214) 文字までが推奨されています。

- [Package manifest - Unity Official](https://docs.unity3d.com/Manual/upm-manifestPkg.html)

<!-- ######################################################################################### -->
### &#x1f4c4; (File Name).asmdef
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9733; 必要**

`.cs` ファイルをリソースとして認識させるために必要です。
もしこれがなければ、`/Assets` フォルダに含まれるスクリプトはこの Package 内のスクリプトにアクセスできません。

- Editor メニュー `Assets > Create > Assembly Definition` から追加することができます。
- `Inspector` から編集することができます。
- Unity は `Unity.(Package Name).asmdef` のような名前を推奨しますが、必須ではありません。
    - `MyCompany.MyFeature.Editor.asmdef` や `MyCompany.MyFeature.Runtime.asmdef` のような名前も推奨しています。

追加の情報は公式を参照してください。例えば、`unsafe` コードを有効にするオプションや、プラットフォームの設定などがあります。

- [Assembly definition and packages - Unity Official](https://docs.unity3d.com/Manual/cus-asmdef.html)
- [Assembly Definition - Unity Official](https://docs.unity3d.com/ja/current/Manual/ScriptCompilationAssemblyDefinitionFiles.html)

<!-- ######################################################################################### -->
### &#x1f4c4; CHANGELOG.md
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9733; 推奨**

Package の更新情報について書きます。

- Editor メニューから追加することができません。
- Package Manager のウィンドウにある `View changelog` から開きます。

<!-- ######################################################################################### -->
### &#x1f4c4; LICENSE.md
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9734; 推奨**

ライセンスについて書きます。

- Editor メニューから追加することができません。
- Package Manager のウィンドウにある `View licenses` から開きます。

<!-- ######################################################################################### -->
### &#x1f4c4; README.md
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9734; 推奨**

Package の開発者向けの情報を書きます。

- Unity は `README.md` の追加を推奨しますが、これは Package Manager のウィンドウから開くことはできません。
    - Editor メニューからも追加することができません。
- `/Documentation~/(File Name).md` は、Package Manager から開くことができます。
    - ["Documentation~"](#-documentation--file-namemd) を参照してください。
- Unity は主に開発者向けのドキュメントであるとしています。

<!-- ######################################################################################### -->
###  &#x1f4c1; /Documentation~ &#x1f4c4; /(File Name).md
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9734; 推奨**

Package のユーザ向けの情報を書きます。

- `~` で終わるフォルダは、Project ウィンドウから見えなくなります。
- Package Manager ウィンドウの `View documentation` から開きます。
- Unity は `(Package Name).md` のような名前を推奨しています。
    - ただし、これは必須ではありません。
    - 複数の `.md` ファイルがあるとき、ソートして一番上のものが `View documentation` によって開きます。

<!-- ######################################################################################### -->
### &#x1f4c1; /Editor
<!-- ######################################################################################### -->
**&#9733;&#9733;&#9733; 必須(条件付き)**

`Editor` フォルダは Editor スクリプトを追加するときに必要です。

- `Editor` フォルダは、一般的なプロジェクトリソースと同じように機能します。

<!-- ######################################################################################### -->
### &#x1f4c1; /Runtime
<!-- ######################################################################################### -->
**&#9733;&#9734;&#9734; 任意**

ランタイム用のスクリプトを追加します。

- Unity は `Runtime` フォルダを追加し、そこにランタイム用のスクリプトを追加するように推奨しています。
    - ただし、これは必須ではありません。
    - スクリプトも Package も、`Runtime` フォルダがなくても機能します。

<!-- ######################################################################################### -->
### &#x1f4c1; /(Sub Folder)
<!-- ######################################################################################### -->
**&#9733;&#9734;&#9734; 任意**

好きなようにフォルダを追加することができます。

<!-- ######################################################################################### -->
## Package の依存関係
<!-- ######################################################################################### -->

`package.json` は `dependencies` に git(Hub) の URL を追加することができます。
`dependeincies` は、Package が異なる他の Package を使うとき、それを自動で追加するための機能です。

しかしながら、ver.2020.2 までの間に、単独で機能できないようです。
[Unity は将来的に対応するように言っています。](https://forum.unity.com/threads/custom-package-with-git-dependencies.628390/#post-5367033)

もし今 `dependencies` の機能を使いたいなら、`dependencies` の設定を `package.json` と `/Packages/manifest.json` の両方に追加します。
`/Packages/manifest.json` は Editor から開くことができません。

- [Git dependencies - Unity Official](https://docs.unity3d.com/Manual/upm-git.html)
- [Custom Package with Git Dependencies - Unity Forums](https://forum.unity.com/threads/custom-package-with-git-dependencies.628390/#post-5367033)
