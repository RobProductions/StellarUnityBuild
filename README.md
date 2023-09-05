# Stellar Unity Build

*Stellar Unity Build* is a fork of the powerful automation tool [SuperUnityBuild](https://github.com/superunitybuild/buildtool), which aims to streamline the build process in Unity. This extension package provides new experimental features that offer more control over your build pipeline.

## Enhancements Over SuperUnityBuild

- **Customize constant file location:** You can now set the desired location of your BuildConstants.cs file within your project.
- **Generate Build Constants button:** A new button appears on a selected build which allows you to create the BuildConstants.cs file for a specific environment without adjusting your Platform or Editor BuildScenes. This is useful if you want your editor settings to remain unchanged but need to rely on compiled constants for scripts to work correctly.
- **Styling Improvements:** Header panels and dropdowns have been restyled for accessibility and clarity.
- **Sync Release Settings Feature:** You can now individually sync Product Name, Company Name, and Bundle Identifier with your project settings so that all of your releases can be updated automatically when your Player settings change. You can override this by unchecking the sync toggle and inputting your own custom strings.
- **Sync Release Scene List:** You can now sync the list of scenes to be included in a release with your EditorBuildScene list (File->Build Settings) so that your releases can be updated automatically when your build settings change.

## Goals

While I don't wish to understate the work done by the original SuperUnityBuild authors, I have far too many ideas for improvements that would be too much for the original project if I bombarded them with Pull Requests. In an attempt to keep the stability and sanity intact for SuperUnityBuild, I've opted to push my ideas into this new extension package instead.

In *Stellar Unity Build*, you are free to make more wild suggestions and drastic changes that wouldn't risk upsetting the standard that many people know from the original project. I might be making frequent adjustments here, but I will also try to pull in fixes and updates from SuperUnityBuild when possible to stay current. 

That said, full credit for the original idea and implementation goes to the SuperUnityBuild developers, which you can find [here](https://github.com/superunitybuild/buildtool/graphs/contributors).

## Compatibility

I will try my best to maintain compatibility with the SuperUnityBuild file structures and Actions, but it's likely that too many things will change in the future to promise full backwards support. From my experiments, it seems that you might have to recreate some data which could be formatted differently within your settings file should things stray too far, for example re-inputting your desired scene list. 

If you start with Stellar Unity Build, however, you can be assured that I will follow the SemVer standard and only make breaking changes on Major version updates. Stellar Unity Build will start at 1.0.0 and update at a different rate than SuperUnityBuild. 

## Installation

I recommend that you use the Package Manager within Unity or OpenUPM to install this package. For the Git URL, input this:

[https://github.com/RobProductions/StellarUnityBuild.git](https://github.com/RobProductions/StellarUnityBuild.git)

## License

Like the original SuperUnityBuild project, Stellar Unity Build uses the MIT License. Feel free to build your own ideas off of this project so long as you follow the agreements laid out in the license file. 

*Original description to follow:*

# SuperUnityBuild

[![openupm](https://img.shields.io/npm/v/com.github.superunitybuild.buildtool?label=openupm&registry_uri=https://package.openupm.com)][openupm-package]

> A powerful automation tool for quickly and easily generating builds with Unity.

![Logo](https://raw.githubusercontent.com/superunitybuild/buildtool/gh-pages/Cover.png)
![Screenshot](https://raw.githubusercontent.com/superunitybuild/buildtool/gh-pages/Screenshot_v1.0.0.png)

[Unity Forums Thread][unity-forums-thread] | [Documentation Wiki][wiki] | [OpenUPM package][openupm-package]

SuperUnityBuild is a Unity utility that automates the process of generating builds. It's easy and quick enough to use on small apps, but it's also powerful and extensible enough to be extremely useful on larger projects. The key to this flexibility lies in SuperUnityBuild's configurable degrees of granularity and its [BuildActions][buildactions] framework which allows additional operations to be added into the build process.

Features:

-   **Manage and Build Multiple Versions** - If you're targetting more than one platform or distribution storefront, the build process can quickly become very cumbersome with Unity's built in tools. SuperUnityBuild makes it easy to manage a wide array of build configurations targetting any number of versions, platforms, architectures, or distribution methods.
-   **One-Click Batch Builds** - Easily kick-off batch builds for all or a specific subset of your build configurations.
-   **Expanded Build Capability** - SuperUnityBuild offers many features not available in Unity's built in build workflow such as version number generation, and the BuildAction framework provides options for even more expanded build capabilities like automated file copying/moving, creating zip files, and building AssetBundles.
-   **Quick Initial Setup** - If all you need is the bare essentials, you can be up and running in minutes. SuperUnityBuild scales to fit your project's specific needs whether it be large or small.
-   **Highly Extensible and Customizable** - SuperUnityBuild's BuildAction framework provides simple hooks for adding in your own additional functionality.
-   **Free and Open-Source** - Some similar tools available only on the AssetStore are as much as $50+.

## Basic Usage

Requires Unity 2020.3 or higher. Supports building for Windows, macOS, Linux, iOS, Android, UWP and WebGL.

### Installation

Official releases of SuperUnityBuild can be installed via [Unity Package Manager](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@latest/index.html) from the [OpenUPM](https://openupm.com) package registry. See [https://openupm.com/packages/com.github.superunitybuild.buildtool/][openupm-package] for installation options.

You can also [download the source zip][download] of this repository and extract its contents into your Unity project's `Packages` directory to install SuperUnityBuild as an embedded package.

You may also want to [install](https://github.com/superunitybuild/buildtool#installation) the optional [BuildActions][buildactions] package to expand SuperUnityBuild's capabilities.

### Setup

See [Standard Usage](https://github.com/superunitybuild/buildtool/wiki/Standard-Usage) in the wiki.

## Customizing and Expanding

### Creating BuildActions

See [Build Actions](https://github.com/superunitybuild/buildtool/wiki/Build-Actions) in the wiki for details.

## Command Line Interface

See [Command Line Interface](https://github.com/superunitybuild/buildtool/wiki/Command-Line-Interface) in the wiki.

## Contributing

Bug reports, feature requests, and pull requests are welcome and appreciated.

## Credits

### Creator

-   **Chase Pettit** - [GitHub](https://github.com/Chaser324), [Twitter](http://twitter.com/chasepettit)

### Maintainer

-   **Robin North** - [GitHub](https://github.com/robinnorth)

### Contributors

You can see a complete list of contributors at [https://github.com/superunitybuild/buildtool/graphs/contributors][contributors]

## License

All code in this repository ([buildtool][buildtool]) is made freely available under the MIT license. This essentially means you're free to use it however you like as long as you provide attribution.

[download]: https://github.com/superunitybuild/buildtool/archive/master.zip
[contributors]: https://github.com/superunitybuild/buildtool/graphs/contributors
[release]: https://github.com/superunitybuild/buildtool/releases
[buildtool]: https://github.com/superunitybuild/buildtool
[buildactions]: https://github.com/superunitybuild/buildactions
[wiki]: https://github.com/superunitybuild/buildtool/wiki/
[openupm-package]: https://openupm.com/packages/com.github.superunitybuild.buildtool/
[unity-forums-thread]: https://forum.unity3d.com/threads/super-unity-build-automated-build-tool-and-framework.471114/
