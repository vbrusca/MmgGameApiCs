# MmgGameApiCs
A 2D game API written in C# using the MonoGame XNA engine.

## Detailed Explantion of the API
A detailed explanation of the API can be found in this book, although it follows the Java version of the game engine more closely the core API code is almost identicle so you could potentially follow along or gain a lot of knowledge applicable to the C# version of the project.
<br>
<br>
[*Introduction to Video Game Engine Development*](https://github.com/Apress/introduction-video-game-engine-development)

## Games that Use The API
You can find the mot advacned game that uses the API here:
<br>
<br>
[Tyre](https://github.com/vbrusca/MmgGameApi-TyreSK)
<br>
<br>
This is a port of a T-Mobile SideKick game to the API. It is very easy to convert old T-Mobile SideKick games to this API and this project serves as an example.
There are also compatible games in this book repo:
<br>
<br>
[*Introduction to Java Through Game Development*](https://github.com/Apress/introduction-to-java-through-gamedev)

## Packages / Namespaces
<b>net.middlemind.MmgGameApiCs.MmgBase</b>
<br>
<br>
This is the lowest level API in the game engine SDK. It sits on top of the underlying framework technology. For the Java project it plugs into the Java Swing and AWT APIs. For the C# project it plugs into Monogame APIs which use OpenGL and OpenAL.
<br>
<br>
<b>net.middlemind.MmgGameApiCs.MmgCore</b>
<br>
<br>
This is the mid-level API in the game engine SDK. It sits between the low-level API, MmgBase, and the actual game implementation. It handles tasks like setting up the application window and drawing surfaces, loading resources, processing input. It also handles XML driven configuration, events, and more robust game screens.
<br>
<br>
<b>net.middlemindMmgGameApiCs.MmgTestSpace</b>
<br>
<br>
This package represents the application level and really isn’t an SDK API. It is an example of an implementation of the SDK with runtime code included. This application, when executed, demonstrates how to use classes from the MmgBase and MmgCore APIs.

## Class Listing
<ul>
  <li>
    <b>Base Classes:</b>
    <br>
    <ul>
      <li>MmgObj</li>
      <li>MmgColor</li>
      <li>MmgRect</li>
      <li>MmgFont</li>
      <li>MmgSound</li>
      <li>MmgPen</li>
      <li>MmgVector2</li>
      <li>MmgBmp</li>
    </ul>
  </li>
  <li>
    <b>Helper Classes:</b>
    <br>
    <ul>
      <li>MmgApiUtils</li>
      <li>MmgHelper</li>
      <li>MmgScreenData</li>
      <li>MmgFontData</li>
      <li>MmgDebug</li>
      <li>MmgBmpScaler</li>
      <li>MmgMediaTracker</li>
    </ul>  
  </li>
  <li>
    <b>Advanced Classes:</b>
    <ul>
      <li>Mmg9Slice</li>
      <li>MmgContainer</li>
      <li>MmgLabelValuePair</li>
      <li>MmgLoadingBar</li>
      <li>MmgLoadingBar</li>
      <li>MmgSprite</li>
      <li>MmgDrawableBmpSet</li>
    </ul>
  </li>

  <li>
    <b>Widget Classes:</b>
    <ul>
      <li>MmgTextField</li>
      <li>MmgTextBlock</li>
      <li>MmgScrollVert</li>
      <li>MmgScrollHor</li>
      <li>MmgScrollHorVert</li>
      <li>MmgMenuContainer</li>
      <li>MmgMenuItem</li>
    </ul>
  </li>
  <li>
    <b>Screen Classes:</b>
    <ul>
      <li>MmgSplashScreen</li>
      <li>MmgLoadingScreen</li>
      <li>MmgGameScreen</li>
    </ul>
  </li>
  <li>
    <b>Animation Classes:</b>
    <ul>
      <li>MmgPulse</li>
      <li>MmgPosTween</li>
      <li>MmgSizeTween</li>
    </ul>
  </li>
  <li>
    <b>Other Classes:</b>
    <ul>
      <li>MmgCfgFileEntry</li>
      <li>MmgEvent</li>
      <li>MmgEventHandler</li>
      <li></li>      
    </ul>
  </li>
</ul>

## Setting Up Your Environment
The code that powers this engine in two flavors Java and C#. That being said, this part only follows the Java code. All the method breakdowns are done while reviewing Java code. However, there is a complete C# implementation of the game engine and the MmgBase API is very similar between both engine versions. The next sections will show you how to setup your environment for viewing the associated projects in Visual Studio, for the C# project.
