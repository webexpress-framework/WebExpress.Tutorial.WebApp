![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress/main/assets/banner.png)

# WebExpress
`WebExpress` is a lightweight web server optimized for use in low-performance environments (e.g. Rasperry PI). By providing 
a powerful plugin system and a comprehensive API, web applications can be easily and quickly integrated into a .net 
language (e.g. C#). Some advantages of `WebExpress` are:

- It is easy to use.
- It offers a variety of features and tools that can help you build and manage your website.
- It is fast and efficient and can help you save time and money.
- It is flexible and can be customized to meet your specific requirements.

The `WebExpress` family includes the following projects:

- [WebExpress](https://github.com/ReneSchwarzer/WebExpress#readme) - The web server for `WebExpress` applications and the documentation.
- [WebExpress.WebCore](https://github.com/ReneSchwarzer/WebExpress.WebCore#readme) - The core for `WebExpress` applications.
- [WebExpress.WebUI](https://github.com/ReneSchwarzer/WebExpress.WebUI#readme) - Common templates and controls for `WebExpress` applications.
- [WebExpress.WebIndex](https://github.com/ReneSchwarzer/WebExpress.WebIndex#readme) - Reverse index for `WebExpress` applications.
- [WebExpress.WebApp](https://github.com/ReneSchwarzer/WebExpress.WebApp#readme) - Business application template for `WebExpress` applications.

`WebExpress` is part of the `WebExpress` family. The project provides a web server for `WebExpress` applications.

To get started with `WebExpress`, use the following links.

- [installation guide](https://github.com/ReneSchwarzer/WebExpress/blob/main/doc/installation_guide.md) 
- [development guide](https://github.com/ReneSchwarzer/WebExpress/blob/main/doc/development_guide.md)

# Tutorial
How to tutorial to demonstrate a simple `WebExpress` application. The application includes the creation of a home page that displays this tutorial and an info page with information about the application.

## Prerequisites
- Install .NET 8.0. You can download and install .NET 8.0 from the official .NET website. Follow the instructions on the website to complete the installation.
- Verify the installation. Open the command line or terminal and run the following command:
  ```bash
  dotnet --version
  ```
  This command outputs the installed .NET version. Make sure the outputted version matches the version you installed (in this case 8.0).

After fulfilling these prerequisites, you can proceed with the tutorial.

## Create a new solution
- Open the command line or terminal.
    - On Windows, you can open the command line by typing cmd into the search box of the Start menu and pressing Enter.
    - On MacOS or Linux, you can open the terminal by typing terminal into the Spotlight search and pressing Enter.
- Navigate to the desired directory.
- Use the command cd `path/to/directory` to navigate to the desired directory.
- Create a new solution. Enter the following command and press Enter:
  ```bash
  # create a new folder for your solution
  mkdir WebExpress.Tutorial.WebApp
  cd WebExpress.Tutorial.WebApp

  # create a new solution
  dotnet new sln -n WebExpress.Tutorial.WebApp

  # create a new console application
  dotnet new console -n WebApp.App -f net8.0

  # create a new class library
  dotnet new classlib -n WebApp -f net8.0

  # add the projects to the solution
  dotnet sln add ./WebApp.App/WebApp.App.csproj
  dotnet sln add ./WebApp/WebApp.csproj
  ```

This command creates a new .NET solution named `WebExpress.Tutorial.WebApp` and uses .NET 8.0 as the framework.
- Check the newly created solution. There should now be a new directory named `WebExpress.Tutorial.WebApp` in the current directory. You can view the contents of this directory with the command ls (Linux/Mac) or dir (Windows).
- Open the solution in your preferred development environment.
  - If you are using Visual Studio Code, you can open the solution with the command `code .` in the solution directory.

Now you have created a new solution and are ready to proceed with the next steps in your tutorial.

## Customize the project
- Add the necessary dependencies in the `WebApp` project file.
  ```xml
  <PropertyGroup>
      ...
      <EnableDynamicLoading>true</EnableDynamicLoading>
  </PropertyGroup>

  <ItemGroup>
      <PackageReference Include="WebExpress.WebCore" Version="0.0.7-alpha">
          <Private>false</Private>
          <ExcludeAssets>runtime</ExcludeAssets>
      </PackageReference>

      <PackageReference Include="WebExpress.WebUI" Version="0.0.7-alpha">
          <Private>false</Private>
          <ExcludeAssets>runtime</ExcludeAssets>
      </PackageReference>

      <PackageReference Include="WebExpress.WebIndex" Version="0.0.7-alpha">
          <Private>false</Private>
          <ExcludeAssets>runtime</ExcludeAssets>
      </PackageReference>

      <PackageReference Include="WebExpress.WebApp" Version="0.0.7-alpha">
          <Private>false</Private>
          <ExcludeAssets>runtime</ExcludeAssets>
      </PackageReference>
  </ItemGroup>

  ```
- Add the necessary dependencies in the `WebApp.App` project file.
  ```xml
  <ItemGroup>
      <PackageReference Include="WebExpress.WebCore" Version="0.0.7-alpha" />
      <PackageReference Include="WebExpress.WebUI" Version="0.0.7-alpha" />
      <PackageReference Include="WebExpress.WebIndex" Version="0.0.7-alpha" />
      <PackageReference Include="WebExpress.WebApp" Version="0.0.7-alpha" />
  </ItemGroup>

  <ItemGroup>
      <ProjectReference Include="..\WebApp\WebApp.csproj" />
  </ItemGroup>
  ```
- Adjust the project file to your requirements.

## Configure the WebExpress package
- Add a file named `WebExpress.Tutorial.WebApp.spec` in the solution folder.
  ```xml
  <?xml version="1.0" encoding="utf-8"?>
  <package>
      <id>WebExpress.Tutorial.WebApp</id>
      <version>0.0.7-alpha</version>
      <title>WebApp</title>
      <authors>rene_schwarzer@hotmail.de</authors>
      <license>MIT</license>
      <icon>icon.png</icon>
      <readme>README.md</readme>
      <privacypolicy>PrivacyPolicy.md</privacypolicy>
      <description>Provides a simple WebExpress application.</description>
      <tags>webexpress tutorial</tags>
      <plugin>WebApp</plugin>
  </package>
  ```
- Adjust the spec file to your requirements.
- Add the spec file in the `WebApp.App` project file.
  ```
  <Target Name="PostBuild" AfterTargets="PostBuildEvent" Condition="'$(Configuration)' == 'Release'">
      <Exec Command="$(SolutionDir)$(AssemblyName)/bin/$(Configuration)/$(TargetFramework)/$(AssemblyName).exe -s $(SolutionDir)/$(SolutionName).spec -c $(Configuration) -t $(TargetFramework) -o $(SolutionDir)/pkg/$(Configuration)" />
  </Target>
  ```

## Create a WebExpress plugin
- Create a new class `Plugin` in the `WebApp` project that implements the `IPlugin` interface.
  ```csharp
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebPlugin;

  namespace WebApp
  {
      [Name("WebApp:plugin.name")]
      [Description("WebApp:plugin.description")]
      [Icon("/assets/img/webapp.svg")]
      [Dependency("webexpress.webui")]
      public sealed class Plugin : IPlugin
      {
          public void Initialization(IPluginContext context) {}
          public void Run() {}
          public void Dispose() {}
      }
  }
  ```
- Adjust the class to your requirements.

## Create a WebExpress application
- Create a new class `Application` in the `WebApp` project that implements the `IApplication` interface.
  ```csharp
  using WebExpress.WebCore.WebApplication;
  using WebExpress.WebCore.WebAttribute;

  namespace WebApp
  {
      [Name("WebApp:app.name")]
      [Description("WebApp:app.description")]
      [Icon("/assets/img/webapp.svg")]
      [AssetPath("/")]
      [ContextPath("/webapp")]
      public sealed class Application : IApplication
      {
          public void Initialization(IApplicationContext context) {}
          public void Run() {}
          public void Dispose() {}
     }
  }
  ```
- Adjust the class to your requirements.

## Create a WebExpress module
- Create a new class `Module` in the `WebApp` project that implements the `IModule` interface.
  ```csharp
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebModule;

  namespace WebApp
  {
      [Name("WebApp:module.name")]
      [Description("WebApp:module.description")]
      [Icon("/assets/img/webapp.svg")]
      [AssetPath("/")]
      [ContextPath("/")]
      [Application<Application>]
      public sealed class Module : IModule
      {
          public void Initialization(IModuleContext context) {}
          public void Run() {}
          public void Dispose() {}
      }
  }
  ```
- Adjust the class to your requirements.

## Create a home page
- Create a new view for the home page in the `WebApp` project.
  ```csharp
  using System.IO;
  using WebExpress.WebApp.WebPage;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebResource;
  using WebExpress.WebCore.WebScope;
  using WebExpress.WebUI.WebControl;

  namespace WebApp.WebPage
  {
      [Title("WebApp:homepage.label")]
      [Segment(null, "WebApp:homepage.label")]
      [ContextPath(null)]
      [Module<Module>]
      public sealed class HomePage : PageWebApp, IScope
      {
          public override void Process(RenderContextWebApp context)
          {
              base.Process(context);
              
              using var stream = GetType().Assembly.GetManifestResourceStream("WebApp.README.md");
              using var reader = new StreamReader(stream);
              
              context.VisualTree.Content.Primary.Add(new ControlText() { Text = reader.ReadToEnd(), Format = TypeFormatText.Markdown });
          }
      }
  }
  ```
- Adjust the homepage to your requirements.
- Copy this radme file in the solution directory and add the in the `WebApp` project file. 
  ```xml
  <ItemGroup>
      <EmbeddedResource Include="../README.md" />
  </ItemGroup>
  ```

## Create a info page
- Create a new view for the info page in the `WebApp` project.
  ```csharp
  using System.Linq;
  using WebExpress.WebApp.WebPage;
  using WebExpress.WebCore.Internationalization;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebComponent;
  using WebExpress.WebCore.WebResource;
  using WebExpress.WebCore.WebScope;
  using WebExpress.WebUI.WebControl;

  namespace WebApp.WebPage
  {
      [Title("WebApp:infopage.label")]
      [Segment("info", "WebApp:infopage.label")]
      [ContextPath(null)]
      [Module<Module>]
      public sealed class InfoPage : PageWebApp, IScope
      {
          public override void Process(RenderContextWebApp context)
          {
              base.Process(context);

              var visualTree = context.VisualTree;
              var webexpress = ComponentManager.PluginManager.Plugins.Where(x => x.PluginId == "webexpress.webapp").FirstOrDefault();
              var webapp = ComponentManager.PluginManager.Plugins.Where(x => x.Assembly == GetType().Assembly).FirstOrDefault();

              visualTree.Content.Primary.Add(new ControlImage()
              {
                  Uri = ResourceContext.ContextPath.Append("assets/img/webapp.svg"),
                  Width = 200,
                  Height = 200,
                  HorizontalAlignment = TypeHorizontalAlignment.Right
              });

              var card = new ControlPanelCard() { Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two) };

              card.Add(new ControlText()
              {
                  Text = this.I18N("WebApp:app.name"),
                  Format = TypeFormatText.H3
              });

              card.Add(new ControlText()
              {
                  Text = this.I18N("WebApp:app.description"),
                  Format = TypeFormatText.Paragraph
              });

              card.Add(new ControlText()
              {
                  Text = this.I18N("WebApp:app.about"),
                  Format = TypeFormatText.H3
              });

              card.Add(new ControlText()
              {
                  Text = string.Format
                  (
                      this.I18N("WebApp:app.version.label"),
                      this.I18N(webapp?.PluginName),
                      webapp?.Version,
                      webexpress?.PluginName,
                      webexpress?.Version
                  ),
                  TextColor = new PropertyColorText(TypeColorText.Primary)
              });

              visualTree.Content.Primary.Add(card);
          }
      }
  }
  ```

## Create a resource endpoint for assets
- Create a `ResourceAsset` class in the `WebApp` project, witch delivery embedded resources.
  ```csharp
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebResource;

  namespace WebApp.WebResource
  {
    [Title("Assets")]
    [Segment("assets", "")]
    [ContextPath("/")]
    [IncludeSubPaths(true)]
    [Module<Module>]
    public sealed class ResourceAsset : WebExpress.WebCore.WebResource.ResourceAsset
    {
    }
  }
  ```

## Add a fragment for the info page
- Create a new fragment to view the info page in the `WebApp` project.
  ```csharp
  using WebApp.WebPage;
  using WebExpress.WebApp.WebFragment;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebComponent;
  using WebExpress.WebCore.WebHtml;
  using WebExpress.WebCore.WebPage;
  using WebExpress.WebUI.WebAttribute;
  using WebExpress.WebUI.WebControl;
  using WebExpress.WebUI.WebFragment;

  namespace WebApp.WebFragment
  {
      [Section(Section.AppNavigationSecondary)]
      [Module<Module>]
      [Cache]
      public sealed class InfoFragment : FragmentControlNavigationItemLink
      {
          public override void Initialization(IFragmentContext context, IPage page)
          {
              base.Initialization(context, page);

              Text = "WebApp:infopage.label";
              Uri = ComponentManager.SitemapManager.GetUri<InfoPage>();
              Icon = new PropertyIcon(TypeIcon.InfoCircle);
              Active = page is InfoPage ? TypeActive.Active : TypeActive.None;
          }
      }
  }
  ```

## Add a fragment for the page footer
- Create a new fragment to view the footer in the `WebApp` project.
  ```csharp
  using WebExpress.WebApp.WebFragment;
  using WebExpress.WebCore.Internationalization;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebHtml;
  using WebExpress.WebCore.WebPage;
  using WebExpress.WebUI.WebAttribute;
  using WebExpress.WebUI.WebControl;
  using WebExpress.WebUI.WebFragment;

  namespace WebApp.WebFragment
  {
      [Section(Section.FooterPrimary)]
      [Module<Module>]
      public sealed class FooterFragment : FragmentControlPanel
      {
          private ControlLink LicenceLink { get; } = new ControlLink()
          {
              TextColor = new PropertyColorText(TypeColorText.Muted),
              Size = new PropertySizeText(TypeSizeText.Small)
          };

          public override void Initialization(IFragmentContext context, IPage page)
          {
              base.Initialization(context, page);

              Classes.Add("text-center");  

              LicenceLink.Text = InternationalizationManager.I18N(context.Culture, "webapp:app.license.label");
              LicenceLink.Uri = InternationalizationManager.I18N(context.Culture, "webapp:app.license.uri");
              Content.Add(LicenceLink);
          }
      }
  }
  ```


## Change the program class
- Change the program class of the `WebApp.App` project as follows:
  ```csharp
  using System.Reflection;

  namespace HalloWorld.App
  {
      internal class Program
      {
          static void Main(string[] args)
          {
              var app = new WebExpress.WebCore.WebEx()
              {
                  Name = Assembly.GetExecutingAssembly().GetName().Name
              };

              app.Execution(args);
          }
      }
  }
  ```

## Internationalization
- Add support for multiple languages. This can be achieved by using i18n files. Each resource file contains the translations for all strings in your application. Name your resource files according to the culture they represent. For example, the file for German translations should be called `de``. In the following, we use the english language.
 ```
  plugin.name=WebApp
  plugin.description=Tutorial of a simple WebExprss application.

  app.name=WebApp Tutorial
  app.label=WebExprss Application
  app.description=Tutorial of a simple WebExpress application.
  app.license.label=License MIT 
  app.license.uri=https://github.com/ReneSchwarzer/WebExpress.Tutorial.WebApp/blob/main/LICENSE
  app.about=About WebApp Tutorial
  app.version.label={0} version {1} created with {2} version {3}.

  module.name=WebApp
  module.description=Module of the WebApp application.

  homepage.label=Home page
  infopage.label=Info
  ```

  - Add the en file in the `WebApp` project file.
  ```xml
  <ItemGroup>
      <EmbeddedResource Include="Internationalization/en" />
  </ItemGroup>
  ```

## Add the Assets
- Add assets to the `WebApp` project. You can get the assets for this tutorial here: https://github.com/ReneSchwarzer/WebExpress.Tutorial.WebApp/tree/main/WebApp/Assets/img
- Add the assets in the `WebApp` project file.
  ```xml
  <ItemGroup>
      <EmbeddedResource Include="Assets/img/favicon.png" />
      <EmbeddedResource Include="Assets/img/webapp.svg" />
  </ItemGroup>
  ```

## Add a Configuration
- The application must be configured. A standard configuration must be delivered for this purpose. Add the configuration file to the `WebApp.App` project.
  ```xml
  <?xml version="1.0" encoding="utf-8" ?>
  <config version = "1">
      <log modus="Off" debug="false" path="/var/log/" encoding="utf-8" filename="webexpress.log" timepattern="dd.MM.yyyy HH:mm:ss" />
      <uri>http://localhost/</uri>
      <endpoint uri="http://localhost/"/>
      <limit>
          <connectionlimit>300</connectionlimit>
          <uploadlimit>3000000000</uploadlimit>
      </limit>
      <culture>en</culture>
      <packages>./packages</packages>
      <assets>./assets</assets>
      <data>./data</data>
      <contextpath></contextpath>
  </config>
  ```
- Include the configuration file in the `WebApp.App` project file.
  ```
  <ItemGroup>
      <None Update="config/webexpress.config.xml">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      </None>
  </ItemGroup>
  ```

## Compile and register in WebExpress
- Compile the solution as a release. To do this, open the command line or terminal in the solution directory and run the following command:
  ```bash
  dotnet build --configuration Release
  ```
  This command compiles the solution in release mode. You can find the compiled files in the `bin/Release` directory of your project.

- Run the solution by starting the `WebApp.App` project.
  ```bash
  cd WebApp.App\bin\Release\net8.0
  dotnet run --project ../../../WebApp.App.csproj
  ```

- After compiling, there should be a file with the `.wxp` extension in the `pkg/Release` directory. This file do you need in `WebExpress`.

## Try the application
- Check the result by calling up the following URL in the browser: http://localhost/webapp

Good luck!
    
# Tags
#WebExpress #WebServer #WebCore #WebUI #Tutorial #DotNet
